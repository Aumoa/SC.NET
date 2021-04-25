// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.WinAPI
{
    /// <summary>
    /// 이벤트 속성을 나타냅니다.
    /// </summary>
    [Flags]
    public enum EventFlags
    {
        /// <summary>
        /// 수동 리셋을 사용합니다.
        /// </summary>
        ManualReset = 0x00000001,

        /// <summary>
        /// 초기 상태가 true입니다.
        /// </summary>
        InitialSet = 0x00000002,
    }
}
