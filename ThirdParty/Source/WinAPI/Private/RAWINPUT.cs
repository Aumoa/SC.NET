// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.WinAPI
{
    [StructLayout(LayoutKind.Explicit)]
    struct RAWINPUTHEADER
    {
        [FieldOffset(0)]
        public uint dwType;

        [FieldOffset(4)]
        public uint dwSize;

        [FieldOffset(8)]
        public IntPtr hDevice;

        [FieldOffset(16)]
        public long wParam;
    }

    [StructLayout(LayoutKind.Explicit)]
    struct RAWMOUSE
    {
        [FieldOffset(0)]
        public ushort usFlags;

        [FieldOffset(4)]
        public uint ulButtons;

        [FieldOffset(4)]
        public ushort usButtonFlags;

        [FieldOffset(6)]
        public ushort usButtonData;

        [FieldOffset(8)]
        public uint ulRawButtons;

        [FieldOffset(12)]
        public int lLastX;

        [FieldOffset(16)]
        public int lLastY;

        [FieldOffset(20)]
        public uint ulExtraInformation;
    }

    [StructLayout(LayoutKind.Explicit)]
    struct RAWKEYBOARD
    {
        [FieldOffset(0)]
        public ushort MakeCode;

        [FieldOffset(2)]
        public ushort Flags;

        [FieldOffset(4)]
        public ushort Reserved;

        [FieldOffset(6)]
        public ushort VKey;

        [FieldOffset(8)]
        public uint Message;

        [FieldOffset(12)]
        public uint ExtraInformation;
    }

    [StructLayout(LayoutKind.Explicit)]
    struct RAWHID
    {
        [FieldOffset(0)]
        public uint dwSizeHide;

        [FieldOffset(4)]
        public uint dwCount;

        [FieldOffset(8)]
        public byte bRawData;
    }

    [StructLayout(LayoutKind.Explicit)]
    struct RAWINPUT
    {
        [FieldOffset(0)]
        public RAWINPUTHEADER header;

        [StructLayout(LayoutKind.Explicit)]
        public struct Unnamed
        {
            [FieldOffset(0)]
            public RAWMOUSE mouse;

            [FieldOffset(0)]
            public RAWKEYBOARD keyboard;

            [FieldOffset(0)]
            public RAWHID hid;
        };

        [FieldOffset(24)]
        public Unnamed data;
    }
}
