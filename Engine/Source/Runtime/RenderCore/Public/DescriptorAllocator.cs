// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.ThirdParty.DirectX;

namespace SC.Engine.Runtime.RenderCore
{
    /// <summary>
    /// 디스크럽터 할당기 개체를 표현합니다.
    /// </summary>
    public class DescriptorAllocator : DeviceResource
    {
        ID3D12Device _device;
        uint _descriptorsCount;
        uint _issued;

        ID3D12DescriptorHeap _descriptorHeap;
        D3D12CPUDescriptorHandle _handleStart;
        D3D12GPUDescriptorHandle _handleStartGpu;
        uint _incrementSize;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="deviceBundle"> 디바이스 개체를 전달합니다. </param>
        public DescriptorAllocator(DeviceBundle deviceBundle) : base(deviceBundle)
        {

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
            _issued = 0;
        }

        /// <summary>
        /// 할당을 종료합니다.
        /// </summary>
        public void EndAllocate()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public uint Issue()
        {

        }

        /// <summary>
        /// 현재 할당기가 보유한 한도를 가져옵니다.
        /// </summary>
        public uint Capacity
        {
            get => _descriptorsCount;
            private set
            {
                
            }
        }
    }
}
