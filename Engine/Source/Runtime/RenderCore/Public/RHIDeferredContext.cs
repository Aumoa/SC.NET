// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.ThirdParty.DirectX;

namespace SC.Engine.Runtime.RenderCore
{
    /// <summary>
    /// 지연된 렌더링을 수행하는 기본적인 컨텍스트를 표현합니다.
    /// </summary>
    public class RHIDeferredContext : RHIDeviceContext
    {
        ID3D12CommandAllocator _deferredAllocator;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="deviceBundle"> 디바이스를 전달합니다. </param>
        /// <param name="support2D"> 2D 렌더링 디바이스 컨텍스트를 지원합니다. </param>
        public RHIDeferredContext(RHIDeviceBundle deviceBundle, bool support2D) : base(deviceBundle, support2D)
        {
            _deferredAllocator = deviceBundle.GetDevice().CreateCommandAllocator(D3D12CommandListType.Direct);
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            _deferredAllocator?.Release();
            base.Dispose();
        }

        /// <inheritdoc/>
        public override void BeginDraw()
        {
            SwapCommandAllocator(ref _deferredAllocator);
            base.BeginDraw();
        }

        /// <inheritdoc/>
        public override void SetDebugName(string name)
        {
            _deferredAllocator.SetName(name);
            base.SetDebugName(name);
        }
    }
}
