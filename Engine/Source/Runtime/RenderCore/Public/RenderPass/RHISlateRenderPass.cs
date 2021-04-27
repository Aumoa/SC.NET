// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.ThirdParty.DirectX;

namespace SC.Engine.Runtime.RenderCore.RenderPass
{
    /// <summary>
    /// 슬레이트 렌더 패스를 표현합니다.
    /// </summary>
    public class RHISlateRenderPass : RHIRenderPass
    {
        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="deviceBundle"> 디바이스를 전달합니다. </param>
        public RHISlateRenderPass(RHIDeviceBundle deviceBundle) : base(deviceBundle)
        {
        }

        /// <inheritdoc/>
        public override void BeginPass(RHIDeviceContext deviceContext, params RHIRenderTarget[] renderTargets)
        {
            ID2D1DeviceContext dc = deviceContext.GetDeviceContext2D();
            dc.SetTarget(renderTargets[0].Bitmap);
            dc.BeginDraw();
        }

        /// <inheritdoc/>
        public override void EndPass(RHIDeviceContext deviceContext)
        {
            ID2D1DeviceContext dc = deviceContext.GetDeviceContext2D();
            dc.EndDraw();
            dc.SetTarget(null);
            deviceContext.Flush2D();
        }
    }
}
