// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.WinAPI
{
    [StructLayout(LayoutKind.Explicit)]
    struct TRACKMOUSEEVENT
    {
        [FieldOffset(0)]
        public uint cbSize;

        [FieldOffset(4)]
        public uint dwFlags;
        
        [FieldOffset(8)]
        public IntPtr hwndTrack;

        [FieldOffset(16)]
        public uint dwHoverTime;
    }
}
