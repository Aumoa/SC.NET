// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System.Collections.Generic;

using SC.ThirdParty.DirectX;

namespace SC.Engine.Runtime.RenderCore
{
    /// <summary>
    /// 디스크럽터 할당기 개체를 표현합니다.
    /// </summary>
    public class RHIDescriptorAllocator : RHIDeviceResource
    {
        ID3D12Device _device;
        uint _descriptorsCount;

        ID3D12DescriptorHeap _descriptorHeap;
        uint _incrementSize;

        List<RHIShaderResourceView> _issuedViews = new();
        List<uint> _issuedIndex = new();

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="deviceBundle"> 디바이스 개체를 전달합니다. </param>
        public RHIDescriptorAllocator(RHIDeviceBundle deviceBundle) : base(deviceBundle)
        {
            _device = deviceBundle.GetDevice();
            _incrementSize = _device.GetDescriptorHandleIncrementSize(D3D12DescriptorHeapType.CBV_SRV_UAV);
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            _descriptorHeap?.Dispose();

            base.Dispose();
        }

        internal void SetDescriptorHeaps(ID3D12GraphicsCommandList cmdList)
        {
            cmdList.SetDescriptorHeaps(_descriptorHeap);
        }

        /// <summary>
        /// 개체를 초기화하고 할당을 시작합니다.
        /// </summary>
        public void BeginAllocate()
        {
            _issuedViews.Clear();
            _issuedIndex.Clear();
        }

        /// <summary>
        /// 할당을 종료합니다.
        /// </summary>
        public void EndAllocate()
        {
            uint descriptorsCount = 0;
            foreach (RHIShaderResourceView view in _issuedViews)
            {
                descriptorsCount += view.DescriptorsCount;
            }

            Capacity = descriptorsCount;
            D3D12CPUDescriptorHandle handle = _descriptorHeap.GetCPUDescriptorHandleForHeapStart();
            foreach (RHIShaderResourceView view in _issuedViews)
            {
                uint numDescriptors = view.DescriptorsCount;
                ID3D12DescriptorHeap heap = view.GetHeap();

                _device.CopyDescriptorsSimple(numDescriptors, handle, heap.GetCPUDescriptorHandleForHeapStart(), D3D12DescriptorHeapType.CBV_SRV_UAV);
                handle.Offset(_incrementSize, (int)numDescriptors);
            }
        }

        /// <summary>
        /// 새로운 디스크럽터 인덱스를 할당합니다.
        /// </summary>
        /// <returns> 인덱스가 반환됩니다. </returns>
        public int Issue(RHIShaderResourceView view)
        {
            uint index = 0;

            if (_issuedIndex.Count != 0)
            {
                index = _issuedIndex[_issuedIndex.Count - 1];
                index += _issuedViews[_issuedViews.Count - 1].DescriptorsCount;
            }

            _issuedViews.Add(view);
            _issuedIndex.Add(index);

            return _issuedIndex.Count - 1;
        }

        internal D3D12CPUDescriptorHandle GetViewHandle(int viewIndex)
        {
            D3D12CPUDescriptorHandle handle = _descriptorHeap.GetCPUDescriptorHandleForHeapStart();
            handle.Offset(_incrementSize, (int)_issuedIndex[viewIndex]);
            return handle;
        }

        internal D3D12GPUDescriptorHandle GetViewGpuHandle(int viewIndex)
        {
            D3D12GPUDescriptorHandle handle = _descriptorHeap.GetGPUDescriptorHandleForHeapStart();
            handle.Offset(_incrementSize, (int)_issuedIndex[viewIndex]);
            return handle;
        }

        /// <summary>
        /// 현재 할당기가 보유한 한도를 가져옵니다.
        /// </summary>
        public uint Capacity
        {
            get => _descriptorsCount;
            private set
            {
                if (_descriptorsCount < value)
                {
                    _descriptorHeap?.Release();

                    _descriptorHeap = _device.CreateDescriptorHeap(D3D12DescriptorHeapType.CBV_SRV_UAV, value, D3D12DescriptorHeapFlags.ShaderVisible);
                    _descriptorsCount = value;
                }
            }
        }
    }
}
