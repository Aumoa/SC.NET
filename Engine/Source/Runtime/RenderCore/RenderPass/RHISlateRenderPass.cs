// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Container;
using SC.Engine.Runtime.Core.FileSystem;
using SC.Engine.Runtime.Core.Numerics;
using SC.Engine.Runtime.RenderShader.Shaders;
using SC.ThirdParty.DirectX;
using SC.ThirdParty.WindowsCodecs;

namespace SC.Engine.Runtime.RenderCore.RenderPass
{
    /// <summary>
    /// 슬레이트 렌더 패스를 표현합니다.
    /// </summary>
    public unsafe class RHISlateRenderPass : RHIRenderPass
    {
        SlateShaderCodeCompile _shaderCode = new();

        ID3D12RootSignature _rootSignature;
        ID3D12PipelineState _pipelineState;

        RHITexture2D _texture;
        RHIShaderResourceView _srv;
        RHIDescriptorAllocator _descriptorAllocator;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="deviceBundle"> 디바이스를 전달합니다. </param>
        public RHISlateRenderPass(RHIDeviceBundle deviceBundle) : base(deviceBundle)
        {
            _texture = deviceBundle.CreateTexture2D(new FileReference("dtd.jpg"), ImagePixelFormat.R8G8B8A8_UNORM);
            _srv = new RHIShaderResourceView(deviceBundle, 1);
            _srv.CreateShaderResourceView(0, _texture._resource, null);
            _descriptorAllocator = new RHIDescriptorAllocator(deviceBundle);
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            _texture?.Dispose();
            _srv?.Dispose();
            _descriptorAllocator?.Dispose();

            _rootSignature?.Dispose();
            _pipelineState?.Dispose();

            base.Dispose();
        }

        /// <inheritdoc/>
        public override void CompileShader()
        {
            _shaderCode.CompileShader();

            var deviceBundle = GetDevice();
            var device = deviceBundle.GetDevice();

            D3D12DescriptorRange texture = new()
            {
                RangeType = D3D12DescriptorRangeType.SRV,
                NumDescriptors = 1,
                BaseShaderRegister = 0,
                OffsetInDescriptorsFromTableStart = uint.MaxValue
            };

            D3D12RootDescriptorTable descriptorTable = new();
            descriptorTable.DescriptorRanges = new TArray<D3D12DescriptorRange>() { texture };

            D3D12RootParameter textureParam = new();
            textureParam.ParameterType = D3D12RootParameterType.DescriptorTable;
            textureParam.ShaderVisibility = D3D12ShaderVisibility.Pixel;
            textureParam.DescriptorTable = descriptorTable;

            // 루트 시그니쳐 개체를 생성합니다.
            D3D12RootSignatureDesc rsd = new()
            {
                Parameters = new TArray<D3D12RootParameter>()
                {
                    textureParam
                },
                StaticSamplers = new TArray<D3D12StaticSamplerDesc>()
                {
                    new D3D12StaticSamplerDesc(D3D12Filter.MIN_MAG_MIP_LINEAR, D3D12TextureAddressMode.Wrap, 0, D3D12ShaderVisibility.Pixel)
                },
                Flags = D3D12RootSignatureFlags.DenyDomainShaderRootAccess
                      | D3D12RootSignatureFlags.DenyHullShaderRootAccess
                      | D3D12RootSignatureFlags.DenyGeometryShaderRootAccess
            };

            using (ID3DBlob blob = D3D12.D3D12SerializeRootSignature(rsd))
            {
                _rootSignature = device.CreateRootSignature(blob);
            }

            // 파이프라인 상태를 생성합니다.
            ShaderBytecodes bytecodes = _shaderCode.GetBytecodes();

            fixed (byte* pVertexShaderBytecode = &bytecodes.VertexShaderBytecode[0])
            fixed (byte* pPixelShaderBytecode = &bytecodes.PixelShaderBytecode[0])
            {
                D3D12GraphicsPipelineStateDesc pipd = new()
                {
                    pRootSignature = _rootSignature,
                    VS = new D3D12ShaderBytecode(pVertexShaderBytecode, (ulong)bytecodes.VertexShaderBytecode.Length),
                    PS = new D3D12ShaderBytecode(pPixelShaderBytecode, (ulong)bytecodes.PixelShaderBytecode.Length),
                    BlendState = new D3D12BlendDesc()
                    {
                        AlphaToCoverageEnable = false,
                        IndependentBlendEnable = false,
                    },
                    SampleMask = uint.MaxValue,
                    RasterizerState = D3D12RasterizerDesc.Default,
                    DepthStencilState = D3D12DepthStencilDesc.Default,
                    PrimitiveTopologyType = D3D12PrimitiveTopologyType.Triangle,
                    NumRenderTargets = 1,
                    SampleDesc = new DXGISampleDesc(1, 0),
                };
                pipd.RasterizerState.CullMode = D3D12CullMode.None;

                pipd.BlendState.RenderTarget[0] = D3D12RenderTargetBlendDesc.Default;
                pipd.RTVFormats[0] = DXGIFormat.B8G8R8A8_UNORM;

                _pipelineState = device.CreatePipelineState(pipd);
            }
        }

        RHIRenderTarget _renderTarget;

        /// <inheritdoc/>
        public override void BeginPass(RHIDeviceContext deviceContext, params RHIRenderTarget[] renderTargets)
        {
            ID3D12GraphicsCommandList commandList = deviceContext.GetCommandList();

            var desc = renderTargets[0].Resource.GetDesc();

            commandList.SetGraphicsRootSignature(_rootSignature);
            commandList.SetPipelineState(_pipelineState);

            _descriptorAllocator.BeginAllocate();
            int r = _descriptorAllocator.Issue(_srv);
            _descriptorAllocator.EndAllocate();

            _descriptorAllocator.SetDescriptorHeaps(commandList);
            commandList.SetGraphicsRootDescriptorTable(0, _descriptorAllocator.GetViewGpuHandle(r));

            commandList.OMSetRenderTargets(1, renderTargets[0].CPUHandle, null);
            commandList.RSSetScissorRects(new Rectangle(new Vector2(0, 0), new Vector2(desc.Width, desc.Height)));
            commandList.RSSetViewports(new D3D12Viewport(desc.Width, desc.Height));
            commandList.IASetPrimitiveTopology(D3DPrimitiveTopology.TriangleStrip);
            commandList.DrawInstanced(4, 1, 0, 0);

            _renderTarget = renderTargets[0];
        }

        /// <inheritdoc/>
        public override void EndPass(RHIDeviceContext deviceContext)
        {
            ID3D12GraphicsCommandList commandList = deviceContext.GetCommandList();

            commandList.ResourceBarrier(D3D12ResourceBarrier.TransitionBarrier(
                _renderTarget.Resource,
                D3D12ResourceStates.RenderTarget,
                D3D12ResourceStates.Present
                ));
            _renderTarget = default;
        }
    }
}
