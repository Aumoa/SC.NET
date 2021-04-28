// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System.Collections.Generic;

using SC.Engine.Runtime.RenderShader.Shaders;
using SC.ThirdParty.DirectX;

namespace SC.Engine.Runtime.RenderCore.RenderPass
{
    /// <summary>
    /// 기하 버퍼 렌더 패스를 표현합니다.
    /// </summary>
    public unsafe class RHIGeometryRenderPass : RHIRenderPass
    {
        GeometryShaderCodeCompile _shaderCode = new();

        ID3D12RootSignature _rootSignature;
        ID3D12PipelineState _pipelineState;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="deviceBundle"> 디바이스를 전달합니다. </param>
        public RHIGeometryRenderPass(RHIDeviceBundle deviceBundle) : base(deviceBundle)
        {
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
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

            // 루트 시그니쳐 개체를 생성합니다.
            D3D12RootSignatureDesc rsd = new()
            {
                Parameters = new List<D3D12RootParameter>()
                {
                },
                StaticSamplers = new List<D3D12StaticSamplerDesc>()
                {
                },
                Flags = D3D12RootSignatureFlags.AllowInputAssemblerInputLayout
                      | D3D12RootSignatureFlags.DenyDomainShaderRootAccess
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
                    DepthStencilState = D3D12DepthStencilDesc.DepthTest,
                    InputLayout = new D3D12InputLayoutDesc()
                    {
                        InputElementDescs = new List<D3D12InputElementDesc>()
                        {
                            new() { SemanticName = "POSITION", Format = DXGIFormat.R32G32B32_FLOAT, AlignedByteOffset = 0 },
                            new() { SemanticName = "TEXCOORD", Format = DXGIFormat.R32G32_FLOAT, AlignedByteOffset = 12 },
                            new() { SemanticName = "NORMAL", Format = DXGIFormat.R32G32B32_FLOAT, AlignedByteOffset = 20 },
                            new() { SemanticName = "TANGENT", Format = DXGIFormat.R32G32B32A32_FLOAT, AlignedByteOffset = 32 }
                        }
                    },
                    PrimitiveTopologyType = D3D12PrimitiveTopologyType.Triangle,
                    NumRenderTargets = 1,
                    DSVFormat = DXGIFormat.D24_UNORM_S8_UINT,
                    SampleDesc = new DXGISampleDesc(1, 0),
                };

                pipd.BlendState.RenderTarget[0] = D3D12RenderTargetBlendDesc.AlphaBlend;
                pipd.RTVFormats[0] = DXGIFormat.B8G8R8A8_UNORM;

                _pipelineState = device.CreatePipelineState(pipd);
            }
        }

        RHIRenderTarget _renderTarget;

        /// <inheritdoc/>
        public override void BeginPass(RHIDeviceContext deviceContext, params RHIRenderTarget[] renderTargets)
        {
            ID3D12GraphicsCommandList commandList = deviceContext.GetCommandList();

            commandList.SetGraphicsRootSignature(_rootSignature);
            commandList.SetPipelineState(_pipelineState);

            commandList.ResourceBarrier(D3D12ResourceBarrier.TransitionBarrier(
                renderTargets[0].Resource,
                D3D12ResourceStates.Present,
                D3D12ResourceStates.RenderTarget
                ));
            commandList.OMSetRenderTargets(1, renderTargets[0].CPUHandle, null);
            if (renderTargets[0].ClearColor is not null)
            {
                commandList.ClearRenderTargetView(renderTargets[0].CPUHandle, renderTargets[0].ClearColor.Value, null);
            }

            _renderTarget = renderTargets[0];
        }

        /// <inheritdoc/>
        public override void EndPass(RHIDeviceContext deviceContext)
        {
            _renderTarget = default;
        }
    }
}
