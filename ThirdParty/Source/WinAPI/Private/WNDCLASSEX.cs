// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.WinAPI
{
    /// <summary>
    /// Contains window class information. It is used with the RegisterClassEx and GetClassInfoEx  functions.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    struct WNDCLASSEX
    {
        /// <summary>
        /// The size, in bytes, of this structure. Set this member to sizeof(WNDCLASSEX). Be sure to set this member before calling the GetClassInfoEx function.
        /// </summary>
        [FieldOffset(0)]
        public uint cbSize;

        /// <summary>
        /// The class style(s). This member can be any combination of the Class Styles.
        /// </summary>
        [FieldOffset(4)]
        public uint style;

        /// <summary>
        /// A pointer to the window procedure. You must use the CallWindowProc function to call the window procedure. For more information, see WindowProc.
        /// </summary>
        [FieldOffset(8)]
        public IntPtr lpfnWndProc;

        /// <summary>
        /// The number of extra bytes to allocate following the window-class structure. The system initializes the bytes to zero.
        /// </summary>
        [FieldOffset(16)]
        public int cbClsExtra;

        /// <summary>
        /// The number of extra bytes to allocate following the window instance. The system initializes the bytes to zero. If an application uses WNDCLASSEX to register a dialog box created by using the CLASS directive in the resource file, it must set this member to DLGWINDOWEXTRA.
        /// </summary>
        [FieldOffset(20)]
        public int cbWndExtra;

        /// <summary>
        /// A handle to the instance that contains the window procedure for the class.
        /// </summary>
        [FieldOffset(24)]
        public IntPtr hInstance;

        /// <summary>
        /// A handle to the class icon. This member must be a handle to an icon resource. If this member is NULL, the system provides a default icon.
        /// </summary>
        [FieldOffset(32)]
        public IntPtr hIcon;

        /// <summary>
        /// A handle to the class cursor. This member must be a handle to a cursor resource. If this member is NULL, an application must explicitly set the cursor shape whenever the mouse moves into the application's window.
        /// </summary>
        [FieldOffset(40)]
        public IntPtr hCursor;

        /// <summary>
        /// A handle to the class background brush. This member can be a handle to the brush to be used for painting the background, or it can be a color value. A color value must be one of the following standard system colors (the value 1 must be added to the chosen color).
        /// </summary>
        [FieldOffset(48)]
        public IntPtr hbrBackground;

        /// <summary>
        /// Pointer to a null-terminated character string that specifies the resource name of the class menu, as the name appears in the resource file. If you use an integer to identify the menu, use the MAKEINTRESOURCE macro. If this member is NULL, windows belonging to this class have no default menu.
        /// </summary>
        [FieldOffset(56)]
        public string lpszMenuName;

        /// <summary>
        /// <para> A pointer to a null-terminated string or is an atom. If this parameter is an atom, it must be a class atom created by a previous call to the RegisterClass or RegisterClassEx function. The atom must be in the low-order word of lpszClassName; the high-order word must be zero. </para>
        /// <para> If lpszClassName is a string, it specifies the window class name. The class name can be any name registered with RegisterClass or RegisterClassEx, or any of the predefined control-class names. </para>
        /// <para> The maximum length for lpszClassName is 256. If lpszClassName is greater than the maximum length, the RegisterClassEx function will fail. </para>
        /// </summary>
        [FieldOffset(64)]
        public string lpszClassName;

        /// <summary>
        /// A handle to a small icon that is associated with the window class. If this member is NULL, the system searches the icon resource specified by the hIcon member for an icon of the appropriate size to use as the small icon.
        /// </summary>
        [FieldOffset(72)]
        public IntPtr hIconSm;
    }
}
