// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.WinAPI
{
    /// <summary>
    /// Contains global cursor information.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    struct CURSORINFO
    {
        [FieldOffset(0)]
        public uint cbSize;

        [FieldOffset(4)]
        public CursorFlags flags;

        [FieldOffset(8)]
        public IntPtr hCursor;
        
        [FieldOffset(16)]
        public POINT ptScreenPos;
    }
}
