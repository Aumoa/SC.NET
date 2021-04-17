// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.WinAPI
{
    /// <summary>
    /// Specifies the window station, desktop, standard handles, and appearance of the main window for a process at creation time.
    /// </summary>
    /// <remarks>
    /// <para> For graphical user interface (GUI) processes, this information affects the first window created by the CreateWindow function and shown by the ShowWindow function. For console processes, this information affects the console window if a new console is created for the process. A process can use the GetStartupInfo function to retrieve the STARTUPINFO structure specified when the process was created. </para>
    /// <para> If a GUI process is being started and neither STARTF_FORCEONFEEDBACK or STARTF_FORCEOFFFEEDBACK is specified, the process feedback cursor is used. A GUI process is one whose subsystem is specified as "windows." </para>
    /// <para> If a process is launched from the taskbar or jump list, the system sets GetStartupInfo to retrieve the STARTUPINFO structure and check that hStdOutput is set. If so, use GetMonitorInfo to check whether hStdOutput is a valid monitor handle (HMONITOR). The process can then use the handle to position its windows. </para>
    /// <para> If the GetStartupInfo function, then applications should be aware that the command line is untrusted. If this flag is set, applications should disable potentially dangerous features such as macros, downloaded content, and automatic printing. This flag is optional. Applications that call CreateProcess are encouraged to set this flag when launching a program with a untrusted command line so that the created process can apply appropriate policy. </para>
    /// <para> The STARTF_UNTRUSTEDSOURCE flag is supported starting in Windows Vista, but it is not defined in the SDK header files prior to the Windows 10 SDK. To use the flag in versions prior to Windows 10, you can define it manually in your program. </para>
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    struct STARTUPINFO
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// </summary>
        [FieldOffset(0)]
        public uint cb;

        /// <summary>
        /// Reserved; must be <see langword="null"/>.
        /// </summary>
        [FieldOffset(4)]
        public string lpReserved;

        /// <summary>
        /// The name of the desktop, or the name of both the desktop and window station for this process. A backslash in the string indicates that the string includes both the desktop and window station names.
        /// </summary>
        /// <remarks> For more information, see <see href="https://docs.microsoft.com/en-us/windows/win32/winstation/thread-connection-to-a-desktop">Thread Connection to a Desktop</see>. </remarks>
        [FieldOffset(12)]
        public string lpDesktop;

        /// <summary>
        /// For console processes, this is the title displayed in the title bar if a new console window is created. If <see langword="null"/>, the name of the executable file is used as the window title instead. This parameter must be <see langword="null"/> for GUI or console processes that do not create a new console window.
        /// </summary>
        [FieldOffset(20)]
        public string lpTitle;

        /// <summary>
        /// <para> If dwFlags specifies STARTF_USEPOSITION, this member is the x offset of the upper left corner of a window if a new window is created, in pixels. Otherwise, this member is ignored. </para>
        /// <para> The offset is from the upper left corner of the screen. For GUI processes, the specified position is used the first time the new process calls <see cref="User32.CreateWindowEx"/> to create an overlapped window if the x parameter of CreateWindow is CW_USEDEFAULT. </para>
        /// </summary>
        [FieldOffset(28)]
        public uint dwX;

        /// <summary>
        /// <para> If dwFlags specifies STARTF_USEPOSITION, this member is the y offset of the upper left corner of a window if a new window is created, in pixels. Otherwise, this member is ignored. </para>
        /// <para> The offset is from the upper left corner of the screen. For GUI processes, the specified position is used the first time the new process calls <see cref="User32.CreateWindowEx"/> to create an overlapped window if the y parameter of CreateWindow is CW_USEDEFAULT. </para>
        /// </summary>
        [FieldOffset(32)]
        public uint dwY;

        /// <summary>
        /// <para> If dwFlags specifies STARTF_USESIZE, this member is the width of the window if a new window is created, in pixels. Otherwise, this member is ignored. </para>
        /// <para> For GUI processes, this is used only the first time the new process calls CreateWindow to create an overlapped window if the nWidth parameter of <see cref="User32.CreateWindowEx"/> is CW_USEDEFAULT. </para>
        /// </summary>
        [FieldOffset(36)]
        public uint dwXSize;

        /// <summary>
        /// <para> If dwFlags specifies STARTF_USESIZE, this member is the height of the window if a new window is created, in pixels. Otherwise, this member is ignored. </para>
        /// <para> For GUI processes, this is used only the first time the new process calls CreateWindow to create an overlapped window if the nHeight parameter of <see cref="User32.CreateWindowEx"/> is CW_USEDEFAULT. </para>
        /// </summary>
        [FieldOffset(40)]
        public uint dwYSize;

        /// <summary>
        /// If dwFlags specifies STARTF_USECOUNTCHARS, if a new console window is created in a console process, this member specifies the screen buffer width, in character columns. Otherwise, this member is ignored.
        /// </summary>
        [FieldOffset(44)]
        public uint dwXCountChars;

        /// <summary>
        /// If dwFlags specifies STARTF_USECOUNTCHARS, if a new console window is created in a console process, this member specifies the screen buffer height, in character rows. Otherwise, this member is ignored.
        /// </summary>
        [FieldOffset(48)]
        public uint dwYCountChars;

        /// <summary>
        /// <para> If dwFlags specifies STARTF_USEFILLATTRIBUTE, this member is the initial text and background colors if a new console window is created in a console application. Otherwise, this member is ignored. </para>
        /// <para> This value can be any combination of the following values: FOREGROUND_BLUE, FOREGROUND_GREEN, FOREGROUND_RED, FOREGROUND_INTENSITY, BACKGROUND_BLUE, BACKGROUND_GREEN, BACKGROUND_RED, and BACKGROUND_INTENSITY. For example, the following combination of values produces red text on a white background: </para>
        /// <para> <c>FOREGROUND_RED | BACKGROUND_RED | BACKGROUND_GREEN | BACKGROUND_BLUE</c> </para>
        /// </summary>
        [FieldOffset(52)]
        public uint dwFillAttribute;

        /// <summary>
        /// A bitfield that determines whether certain STARTUPINFO members are used when the process creates a window.
        /// </summary>
        [FieldOffset(56)]
        public uint dwFlags;

        /// <summary>
        /// <para> If dwFlags specifies STARTF_USESHOWWINDOW, this member can be any of the values that can be specified in the nCmdShow parameter for the <see cref="User32.ShowWindow"/> function, except for SW_SHOWDEFAULT. Otherwise, this member is ignored. </para>
        /// <para> For GUI processes, the first time <see cref="User32.ShowWindow"/> is called, its nCmdShow parameter is ignored wShowWindow specifies the default value. In subsequent calls to <see cref="User32.ShowWindow"/>, the wShowWindow member is used if the nCmdShow parameter of ShowWindow is set to SW_SHOWDEFAULT. </para>
        /// </summary>
        [FieldOffset(60)]
        public ushort wShowWindow;

        /// <summary>
        /// Reserved for use by the C Run-time; must be zero.
        /// </summary>
        [FieldOffset(62)]
        public ushort cbReserved2;

        /// <summary>
        /// Reserved for use by the C Run-time; must be <see langword="null"/>.
        /// </summary>
        [FieldOffset(64)]
        public byte[] lpReserved2;

        /// <summary>
        /// <para> If dwFlags specifies STARTF_USESTDHANDLES, this member is the standard input handle for the process. If STARTF_USESTDHANDLES is not specified, the default for standard input is the keyboard buffer. </para>
        /// <para> If dwFlags specifies STARTF_USEHOTKEY, this member specifies a hotkey value that is sent as the wParam parameter of a WM_SETHOTKEY message to the first eligible top-level window created by the application that owns the process. If the window is created with the WS_POPUP window style, it is not eligible unless the WS_EX_APPWINDOW extended window style is also set. For more information, see <see cref="User32.CreateWindowEx"/>. </para>
        /// <para> Otherwise, this member is ignored. </para>
        /// </summary>
        [FieldOffset(72)]
        IntPtr hStdInput;

        /// <summary>
        /// <para> If dwFlags specifies STARTF_USESTDHANDLES, this member is the standard output handle for the process. Otherwise, this member is ignored and the default for standard output is the console window's buffer. </para>
        /// <para> If a process is launched from the taskbar or jump list, the system sets hStdOutput to a handle to the monitor that contains the taskbar or jump list used to launch the process. For more information, see Remarks.Windows 7, Windows Server 2008 R2, Windows Vista, Windows Server 2008, Windows XP and Windows Server 2003:  This behavior was introduced in Windows 8 and Windows Server 2012. </para>
        /// </summary>
        [FieldOffset(80)]
        IntPtr hStdOutput;

        /// <summary>
        /// If dwFlags specifies STARTF_USESTDHANDLES, this member is the standard error handle for the process. Otherwise, this member is ignored and the default for standard error is the console window's buffer.
        /// </summary>
        [FieldOffset(88)]
        IntPtr hStdError;
    }
}
