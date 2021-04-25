// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.WinAPI
{
    [Flags]
    enum WaitFlags
    {
        WAIT_FAILED = unchecked((int)0xFFFFFFFF),
        WAIT_OBJECT_0 = 0,
        WAIT_ABANDONED = unchecked((int)0x00000080L),
        WAIT_ABANDONED_0 = WAIT_ABANDONED,
        WAIT_TIMEOUT = 258,
    }
}
