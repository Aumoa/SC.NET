// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using SC.ThirdParty.DirectX;

namespace SC.Engine.Runtime.RenderCore
{
    /// <summary>
    /// 렌더 타겟 뷰를 표현합니다.
    /// </summary>
    public class RHIRenderTargetView : RHIResourceView
    {
        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="deviceBundle"> 디바이스 개체를 전달합니다. </param>
        /// <param name="descriptorsCount"> 뷰 디스크럽터 개수를 전달합니다. </param>
        public RHIRenderTargetView(RHIDeviceBundle deviceBundle, uint descriptorsCount) : base(deviceBundle, D3D12DescriptorHeapType.RTV, descriptorsCount)
        {

        }

        internal void CreateView(int index, ID3D12Resource target, D3D12RenderTargetViewDesc? rtvDesc)
        {
            if (index > DescriptorsCount)
            {
                throw new IndexOutOfRangeException();
            }

            var dev = GetDevice().GetDevice();

            D3D12CPUDescriptorHandle handle = GetCPUHandle(index);
            dev.CreateRenderTargetView(target, rtvDesc, handle);
        }
    }
}
