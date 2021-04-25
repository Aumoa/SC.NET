// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

namespace SC.Engine.Runtime.RenderCore
{
    /// <summary>
    /// 디바이스를 참조하는 리소스 개체를 표현합니다.
    /// </summary>
    public class RHIDeviceResource : IDisposable
    {
        RHIDeviceBundle _device;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="deviceBundle"> 디바이스를 전달합니다. </param>
        public RHIDeviceResource(RHIDeviceBundle deviceBundle)
        {
            _device = deviceBundle;
        }

        /// <summary>
        /// 개체의 사용을 종료하고 내부 자원을 해제합니다.
        /// </summary>
        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 디버그 이름을 설정합니다.
        /// </summary>
        /// <param name="name"> 이름을 전달합니다. </param>
        public virtual void SetDebugName(string name)
        {
            
        }

        /// <summary>
        /// 이 개체를 생성한 디바이스를 가져옵니다.
        /// </summary>
        /// <returns> 개체가 반환됩니다. </returns>
        public RHIDeviceBundle GetDevice()
        {
            return _device;
        }
    }
}
