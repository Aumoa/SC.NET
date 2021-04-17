// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.WinAPI
{
    /// <summary>
    /// Contains message information from a thread's message queue.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    struct MSG
    {
        /// <summary>
        /// A handle to the window whose window procedure receives the message. This member is <see langword="null"/> when the message is a thread message.
        /// </summary>
        [FieldOffset(0)]
        public IntPtr hWnd;

        /// <summary>
        /// The message identifier. Applications can only use the low word; the high word is reserved by the system.
        /// </summary>
        [FieldOffset(8)]
        public WindowMessage message;

        /// <summary>
        /// Additional information about the message. The exact meaning depends on the value of the message member.
        /// </summary>
        [FieldOffset(12)]
        public ulong wParam;

        /// <summary>
        /// Additional information about the message. The exact meaning depends on the value of the message member.
        /// </summary>
        [FieldOffset(20)]
        public long lParam;

        /// <summary>
        /// The time at which the message was posted.
        /// </summary>
        [FieldOffset(28)]
        public uint time;

        /// <summary>
        /// The cursor position, in screen coordinates, when the message was posted.
        /// </summary>
        [FieldOffset(32)]
        public POINT pt;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(40)]
        public uint lPrivate;
    }
}
