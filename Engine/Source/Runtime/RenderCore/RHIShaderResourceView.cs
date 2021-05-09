// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using SC.ThirdParty.DirectX;

namespace SC.Engine.Runtime.RenderCore
{
    /// <summary>
    /// 셰이더 리소스 뷰를 표현합니다.
    /// </summary>
    public class RHIShaderResourceView : RHIResourceView
    {
        ID3D12Device _device;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="deviceBundle"> 디바이스 개체를 전달합니다. </param>
        /// <param name="descriptorsCount"> 뷰 디스크럽터 개수를 전달합니다. </param>
        public RHIShaderResourceView(RHIDeviceBundle deviceBundle, uint descriptorsCount) : base(deviceBundle, D3D12DescriptorHeapType.CBV_SRV_UAV, descriptorsCount)
        {
            _device = deviceBundle.GetDevice();
        }

        internal void CreateShaderResourceView(int index, ID3D12Resource target, D3D12ShaderResourceViewDesc? srvDesc)
        {
            if (index > DescriptorsCount)
            {
                throw new IndexOutOfRangeException();
            }

            D3D12CPUDescriptorHandle handle = GetCPUHandle(index);
            _device.CreateShaderResourceView(target, srvDesc, handle);
        }

        internal void CreateConstantBufferView(int index, ulong bufferLocation, uint sizeInBytes)
        {
            if (index > DescriptorsCount)
            {
                throw new IndexOutOfRangeException();
            }

            D3D12ConstantBufferViewDesc cbvDesc = new();
            cbvDesc.BufferLocation = bufferLocation;
            cbvDesc.SizeInBytes = sizeInBytes;

            D3D12CPUDescriptorHandle handle = GetCPUHandle(index);
            _device.CreateConstantBufferView(cbvDesc, handle);
        }

        internal void CreateUnorderedAccessView(int index, ID3D12Resource target, ID3D12Resource counterResource, D3D12UnorderedAccessViewDesc? uavDesc)
        {
            if (index > DescriptorsCount)
            {
                throw new IndexOutOfRangeException();
            }

            D3D12CPUDescriptorHandle handle = GetCPUHandle(index);
            _device.CreateUnorderedAccessView(target, counterResource, uavDesc, handle);
        }
    }
}
