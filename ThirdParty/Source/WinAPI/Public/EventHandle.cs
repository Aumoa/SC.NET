// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.WinAPI
{
    /// <summary>
    /// 대기 핸들을 표현합니다.
    /// </summary>
    public class EventHandle : GeneralHandle
    {
        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public EventHandle() : base(Kernel32.CreateEventEx(IntPtr.Zero, null, 0, (uint)GenericAccess.All))
        {

        }

        /// <summary>
        /// 핸들 개체가 신호를 받을 때까지 현재 스레드를 대기합니다.
        /// </summary>
        public void Wait()
        {
            Kernel32.WaitForSingleObject(GetHandle(), 0xFFFFFFFF);
        }
    }
}
