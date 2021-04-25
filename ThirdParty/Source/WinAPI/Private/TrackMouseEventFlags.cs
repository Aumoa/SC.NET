// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.WinAPI
{
    [Flags]
    enum TrackMouseEventFlags
    {
        TME_HOVER       = 0x00000001,
        TME_LEAVE       = 0x00000002,
        TME_NONCLIENT   = 0x00000010,
        TME_QUERY       = 0x40000000,
        TME_CANCEL      = unchecked((int)0x80000000),
    }
}
