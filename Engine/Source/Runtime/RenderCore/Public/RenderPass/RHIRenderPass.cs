// Copyright 2020-2021 Aumoa.lib. All right reserved.

namespace SC.Engine.Runtime.RenderCore.RenderPass
{
    /// <summary>
    /// 렌더 패스를 정의합니다.
    /// </summary>
    public abstract class RHIRenderPass : RHIDeviceResource
    {
        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="deviceBundle"> 디바이스를 전달합니다. </param>
        public RHIRenderPass(RHIDeviceBundle deviceBundle) : base(deviceBundle)
        {
        }

        /// <summary>
        /// 렌더 패스에서 사용하는 셰이더를 컴파일합니다.
        /// </summary>
        public virtual void CompileShader()
        {
        }

        /// <summary>
        /// 렌더 패스를 시작합니다.
        /// </summary>
        /// <param name="deviceContext"> 디바이스 컨텍스트를 전달합니다. </param>
        /// <param name="renderTargets"> 렌더 타겟 목록을 전달합니다. </param>
        public abstract void BeginPass(RHIDeviceContext deviceContext, params RHIRenderTarget[] renderTargets);

        /// <summary>
        /// 렌더 패스를 종료합니다.
        /// </summary>
        /// <param name="deviceContext"> 디바이스 컨텍스트를 전달합니다. </param>
        public abstract void EndPass(RHIDeviceContext deviceContext);
    }
}
