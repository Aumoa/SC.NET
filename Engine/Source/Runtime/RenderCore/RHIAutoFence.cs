// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.ThirdParty.DirectX;
using SC.ThirdParty.WinAPI;

namespace SC.Engine.Runtime.RenderCore
{
    /// <summary>
    /// 자동 관리 펜스 개체를 표현합니다.
    /// </summary>
    public class RHIAutoFence : RHIDeviceResource
    {
        ID3D12Fence _fence;
        ulong _fenceValue;
        EventHandle _event;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="deviceBundle"> 디바이스를 전달합니다. </param>
        public RHIAutoFence(RHIDeviceBundle deviceBundle) : base(deviceBundle)
        {
            _fence = deviceBundle.GetDevice().CreateFence();
            _event = new EventHandle();
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            base.Dispose();

            _fence?.Release();
            _event?.Dispose();
        }

        /// <summary>
        /// 마지막 동기화 값을 가져옵니다.
        /// </summary>
        /// <returns> 값이 반환됩니다. </returns>
        public ulong GetCompletedValue()
        {
            return _fence.GetCompletedValue();
        }

        /// <summary>
        /// 명령 대기열의 마지막에 동기화 신호를 추가합니다.
        /// </summary>
        /// <param name="queue"> 대기열 개체를 전달합니다. </param>
        /// <returns> 동기화 신호 값이 반환됩니다. </returns>
        public ulong Signal(RHICommandQueue queue)
        {
            queue.GetQueue().Signal(_fence, ++_fenceValue);
            return _fenceValue;
        }

        /// <summary>
        /// 신호가 동기화 될때까지 대기합니다.
        /// </summary>
        public void Wait()
        {
            if (_fence.GetCompletedValue() < _fenceValue)
            {
                _fence.SetEventOnCompletion(_fenceValue, _event);
                _event.Wait();
            }
        }
    }
}
