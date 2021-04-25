// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using static SC.ThirdParty.WinAPI.Kernel32;

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
        public EventHandle(EventFlags flags = 0, GenericAccess accessFlags = GenericAccess.All) : base(CreateEventEx(IntPtr.Zero, null, (uint)flags, (uint)accessFlags))
        {

        }

        /// <summary>
        /// 핸들 개체가 신호를 받을 때까지 현재 스레드를 대기합니다.
        /// </summary>
        public void Wait()
        {
            WaitForSingleObject(GetHandle(), 0xFFFFFFFF);
        }

        /// <summary>
        /// 이벤트 상태를 활성화합니다.
        /// </summary>
        public void Set()
        {
            SetEvent(GetHandle());
        }

        /// <summary>
        /// 이벤트 상태를 비활성화합니다.
        /// </summary>
        public void Reset()
        {
            ResetEvent(GetHandle());
        }
    }
}
