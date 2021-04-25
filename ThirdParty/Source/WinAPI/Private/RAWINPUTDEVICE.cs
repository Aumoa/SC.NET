// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.WinAPI
{
    [StructLayout(LayoutKind.Explicit)]
    struct RAWINPUTDEVICE
    {
        [FieldOffset(0)]
        public ushort usUsagePage;

        [FieldOffset(2)]
        public ushort usUsage;

        [FieldOffset(4)]
        public uint dwFlags;

        [FieldOffset(8)]
        public IntPtr hwndTarget;
    }
}
