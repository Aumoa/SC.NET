// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.ThirdParty.DirectX;

namespace SC.Engine.Runtime.RenderCore
{
    /// <summary>
    /// GPU 리소스 뷰를 표현합니다.
    /// </summary>
    public class RHIResourceView : RHIDeviceResource
    {
        ID3D12DescriptorHeap _descriptorHeap;

        uint _descriptorsCount;
        uint _incrementSize;
        D3D12CPUDescriptorHandle _handle;

        internal RHIResourceView(RHIDeviceBundle deviceBundle, D3D12DescriptorHeapType heapType, uint descriptorsCount) : base(deviceBundle)
        {
            ID3D12Device device = deviceBundle.GetDevice();

            _descriptorHeap = device.CreateDescriptorHeap(heapType, descriptorsCount, D3D12DescriptorHeapFlags.None);
            _incrementSize = device.GetDescriptorHandleIncrementSize(heapType);
            _handle = _descriptorHeap.GetCPUDescriptorHandleForHeapStart();
            _descriptorsCount = descriptorsCount;
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            _descriptorHeap?.Dispose();
        }

        /// <inheritdoc/>
        public override void SetDebugName(string name)
        {
            _descriptorHeap.SetName(name);
        }

        internal D3D12CPUDescriptorHandle GetCPUHandle(int index)
        {
            D3D12CPUDescriptorHandle handle = _handle;
            handle.Offset(_incrementSize, index);
            return handle;
        }

        /// <summary>
        /// 뷰가 소유한 디스크럽터 개수를 가져옵니다.
        /// </summary>
        public uint DescriptorsCount => _descriptorsCount;

        internal ID3D12DescriptorHeap GetHeap()
        {
            return _descriptorHeap;
        }
    }
}
