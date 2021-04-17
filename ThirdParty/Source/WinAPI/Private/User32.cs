// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace SC.ThirdParty.WinAPI
{
    static class User32
    {
        /// <summary>
        /// Copies the text of the specified window's title bar (if it has one) into a buffer. If the specified window is a control, the text of the control is copied. However, GetWindowText cannot retrieve the text of a control in another application.
        /// </summary>
        /// <param name="hWnd"> A handle to the window or control containing the text. </param>
        /// <param name="lpString"> The buffer that will receive the text. If the string is as long or longer than the buffer, the string is truncated and terminated with a null character. </param>
        /// <param name="nMaxCount"> The maximum number of characters to copy to the buffer, including the null character. If the text exceeds this limit, it is truncated. </param>
        /// <returns>
        /// <para> If the function succeeds, the return value is the length, in characters, of the copied string, not including the terminating null character. If the window has no title bar or text, if the title bar is empty, or if the window or control handle is invalid, the return value is zero. To get extended error information, call <see cref="Kernel32.GetLastError"/>. </para>
        /// <para> This function cannot retrieve the text of an edit control in another application. </para>
        /// </returns>
        [DllImport("User32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        /// <summary>
        /// Changes the text of the specified window's title bar (if it has one). If the specified window is a control, the text of the control is changed. However, SetWindowText cannot change the text of a control in another application.
        /// </summary>
        /// <param name="hWnd"> A handle to the window or control whose text is to be changed. </param>
        /// <param name="lpString"> The new title or control text. </param>
        /// <returns>
        /// <para> If the function succeeds, the return value is nonzero. </para>
        /// <para> If the function fails, the return value is zero. To get extended error information, call <see cref="Kernel32.GetLastError"/>. </para>
        /// </returns>
        [DllImport("User32.dll")]
        public static extern int SetWindowText(IntPtr hWnd, string lpString);

        /// <summary>
        /// Determines the visibility state of the specified window.
        /// </summary>
        /// <param name="hWnd"> A handle to the window to be tested. </param>
        /// <returns>
        /// <para> If the specified window, its parent window, its parent's parent window, and so forth, have the WS_VISIBLE style, the return value is nonzero. Otherwise, the return value is zero. </para>
        /// <para> Because the return value specifies whether the window has the WS_VISIBLE style, it may be nonzero even if the window is totally obscured by other windows. </para>
        /// </returns>
        [DllImport("User32.dll")]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        /// <summary>
        /// Sets the specified window's show state.
        /// </summary>
        /// <param name="hWnd"> A handle to the window. </param>
        /// <param name="nCmdShow"> Controls how the window is to be shown. This parameter is ignored the first time an application calls ShowWindow, if the program that launched the application provides a STARTUPINFO structure. Otherwise, the first time ShowWindow is called, the value should be the value obtained by the WinMain function in its nCmdShow parameter. In subsequent calls, this parameter can be one of the <see cref="ShowWindowFlags"/>. </param>
        /// <returns>
        /// <para> If the window was previously visible, the return value is nonzero. </para>
        /// <para> If the window was previously hidden, the return value is zero. </para>
        /// </returns>
        [DllImport("User32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        /// <summary>
        /// Creates an overlapped, pop-up, or child window with an extended window style; otherwise, this function is identical to the CreateWindow function. For more information about creating a window and for full descriptions of the other parameters of CreateWindowEx, see CreateWindow.
        /// </summary>
        /// <param name="dwExStyle"> The extended window style of the window being created. For a list of possible values, see <see cref="ExtendedWindowStyles"/> </param>
        /// <param name="class"> A null-terminated string or a class atom created by a previous call to the RegisterClass or RegisterClassEx function. The atom must be in the low-order word of lpClassName; the high-order word must be zero. If lpClassName is a string, it specifies the window class name. The class name can be any name registered with RegisterClass or RegisterClassEx, provided that the module that registers the class is also the module that creates the window. The class name can also be any of the predefined system class names. </param>
        /// <param name="lpWindowName"> The window name. If the window style specifies a title bar, the window title pointed to by lpWindowName is displayed in the title bar. When using CreateWindow to create controls, such as buttons, check boxes, and static controls, use lpWindowName to specify the text of the control. When creating a static control with the SS_ICON style, use lpWindowName to specify the icon name or identifier. To specify an identifier, use the syntax "#num". </param>
        /// <param name="dwStyle"> The style of the window being created. This parameter can be a combination of the <see cref="WindowStyles"/>, plus the control styles indicated in the Remarks section. </param>
        /// <param name="X"> The initial horizontal position of the window. For an overlapped or pop-up window, the x parameter is the initial x-coordinate of the window's upper-left corner, in screen coordinates. For a child window, x is the x-coordinate of the upper-left corner of the window relative to the upper-left corner of the parent window's client area. If x is set to CW_USEDEFAULT, the system selects the default position for the window's upper-left corner and ignores the y parameter. CW_USEDEFAULT is valid only for overlapped windows; if it is specified for a pop-up or child window, the x and y parameters are set to zero. </param>
        /// <param name="Y"> The initial vertical position of the window. For an overlapped or pop-up window, the y parameter is the initial y-coordinate of the window's upper-left corner, in screen coordinates. For a child window, y is the initial y-coordinate of the upper-left corner of the child window relative to the upper-left corner of the parent window's client area. For a list box y is the initial y-coordinate of the upper-left corner of the list box's client area relative to the upper-left corner of the parent window's client area. </param>
        /// <param name="nWidth"> The width, in device units, of the window. For overlapped windows, nWidth is the window's width, in screen coordinates, or CW_USEDEFAULT. If nWidth is CW_USEDEFAULT, the system selects a default width and height for the window; the default width extends from the initial x-coordinates to the right edge of the screen; the default height extends from the initial y-coordinate to the top of the icon area. CW_USEDEFAULT is valid only for overlapped windows; if CW_USEDEFAULT is specified for a pop-up or child window, the nWidth and nHeight parameter are set to zero. </param>
        /// <param name="nHeight"> The height, in device units, of the window. For overlapped windows, nHeight is the window's height, in screen coordinates. If the nWidth parameter is set to CW_USEDEFAULT, the system ignores nHeight. </param>
        /// <param name="hWndParent"> A handle to the parent or owner window of the window being created. To create a child window or an owned window, supply a valid window handle. This parameter is optional for pop-up windows. </param>
        /// <param name="hMenu"> A handle to a menu, or specifies a child-window identifier, depending on the window style. For an overlapped or pop-up window, hMenu identifies the menu to be used with the window; it can be <see langword="null"/> if the class menu is to be used. For a child window, hMenu specifies the child-window identifier, an integer value used by a dialog box control to notify its parent about events. The application determines the child-window identifier; it must be unique for all child windows with the same parent window. </param>
        /// <param name="hInstance"> A handle to the instance of the module to be associated with the window. </param>
        /// <param name="lpParam">
        /// <para> Pointer to a value to be passed to the window through the CREATESTRUCT structure (lpCreateParams member) pointed to by the lParam param of the WM_CREATE message. This message is sent to the created window by this function before it returns. </para>
        /// <para> If an application calls CreateWindow to create a MDI client window, lpParam should point to a CLIENTCREATESTRUCT structure. If an MDI client window calls CreateWindow to create an MDI child window, lpParam should point to a MDICREATESTRUCT structure. lpParam may be <see langword="null"/> if no additional data is needed. </para>
        /// </param>
        /// <returns>
        /// <para> If the function succeeds, the return value is a handle to the new window. </para>
        /// <para> If the function fails, the return value is <see langword="null"/>. To get extended error information, call <see cref="Kernel32.GetLastError"/>. </para>
        /// </returns>
        [DllImport("User32.dll")]
        public static extern IntPtr CreateWindowEx(uint dwExStyle, ushort @class, string lpWindowName, uint dwStyle, int X, int Y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

        /// <summary>
        /// Dispatches incoming sent messages, checks the thread message queue for a posted message, and retrieves the message (if any exist).
        /// </summary>
        /// <param name="lpMsg"> A pointer to an <see cref="MSG"/> structure that receives message information. </param>
        /// <param name="hWnd">
        /// <para> A handle to the window whose messages are to be retrieved. The window must belong to the current thread. </para>
        /// <para> If hWnd is <see langword="null"/>, PeekMessage retrieves messages for any window that belongs to the current thread, and any messages on the current thread's message queue whose hwnd value is <see langword="null"/> (see the <see cref="MSG"/> structure). Therefore if hWnd is <see langword="null"/>, both window messages and thread messages are processed. </para>
        /// <para> If hWnd is -1, PeekMessage retrieves only messages on the current thread's message queue whose hwnd value is <see langword="null"/>, that is, thread messages as posted by PostMessage (when the hWnd parameter is <see langword="null"/>) or PostThreadMessage. </para>
        /// </param>
        /// <param name="wMsgFilterMin">
        /// <para> The value of the first message in the range of messages to be examined. Use WM_KEYFIRST (0x0100) to specify the first keyboard message or WM_MOUSEFIRST (0x0200) to specify the first mouse message. </para>
        /// <para> If wMsgFilterMin and wMsgFilterMax are both zero, PeekMessage returns all available messages (that is, no range filtering is performed). </para>
        /// </param>
        /// <param name="wMsgFilterMax">
        /// <para> The value of the last message in the range of messages to be examined. Use WM_KEYLAST to specify the last keyboard message or WM_MOUSELAST to specify the last mouse message. </para>
        /// <para> If wMsgFilterMin and wMsgFilterMax are both zero, PeekMessage returns all available messages (that is, no range filtering is performed). </para>
        /// </param>
        /// <param name="wRemoveMsg"> Specifies how messages are to be handled. </param>
        /// <returns>
        /// <para> If a message is available, the return value is nonzero. </para>
        /// <para> If no messages are available, the return value is zero. </para>
        /// </returns>
        [DllImport("User32.dll")]
        public static extern bool PeekMessage(ref MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg);

        /// <summary>
        /// Translates virtual-key messages into character messages. The character messages are posted to the calling thread's message queue, to be read the next time the thread calls the GetMessage or <see cref="PeekMessage"/> function.
        /// </summary>
        /// <param name="lpMsg"> A pointer to an <see cref="MSG"/> structure that contains message information retrieved from the calling thread's message queue by using the GetMessage or <see cref="PeekMessage"/> function. </param>
        /// <returns>
        /// <para> If the message is translated (that is, a character message is posted to the thread's message queue), the return value is nonzero. </para>
        /// <para> If the message is WM_KEYDOWN, WM_KEYUP, WM_SYSKEYDOWN, or WM_SYSKEYUP, the return value is nonzero, regardless of the translation. </para>
        /// <para> If the message is not translated (that is, a character message is not posted to the thread's message queue), the return value is zero. </para>
        /// </returns>
        [DllImport("User32.dll")]
        public static extern bool TranslateMessage(ref MSG lpMsg);

        /// <summary>
        /// Dispatches a message to a window procedure. It is typically used to dispatch a message retrieved by the GetMessage function.
        /// </summary>
        /// <param name="lpMsg"> A pointer to a structure that contains the message. </param>
        /// <returns> The return value specifies the value returned by the window procedure. Although its meaning depends on the message being dispatched, the return value generally is ignored. </returns>
        [DllImport("User32.dll")]
        public static extern bool DispatchMessage(ref MSG lpMsg);

        /// <summary>
        /// Registers a window class for subsequent use in calls to the CreateWindow or CreateWindowEx function.
        /// </summary>
        /// <param name="lpWndClass"> A pointer to a WNDCLASSEX structure. You must fill the structure with the appropriate class attributes before passing it to the function. </param>
        /// <returns>
        /// <para> If the function succeeds, the return value is a class atom that uniquely identifies the class being registered. This atom can only be used by the CreateWindow, CreateWindowEx, GetClassInfo, GetClassInfoEx, FindWindow, FindWindowEx, and UnregisterClass functions and the IActiveIMMap.FilterClientWindows method. </para>
        /// <para> If the function fails, the return value is zero. To get extended error information, call <see cref="Kernel32.GetLastError"/>. </para>
        /// </returns>
        [DllImport("User32.dll")]
        public static extern ushort RegisterClassEx(ref WNDCLASSEX lpWndClass);

        /// <summary>
        /// Calls the default window procedure to provide default processing for any window messages that an application does not process. This function ensures that every message is processed. DefWindowProc is called with the same parameters received by the window procedure.
        /// </summary>
        /// <param name="hWnd"> A handle to the window procedure that received the message. </param>
        /// <param name="Msg"> The message. </param>
        /// <param name="wParam"> Additional message information. The content of this parameter depends on the value of the Msg parameter. </param>
        /// <param name="lParam"> Additional message information. The content of this parameter depends on the value of the Msg parameter. </param>
        /// <returns> The return value is the result of the message processing and depends on the message. </returns>
        [DllImport("User32.dll")]
        public static extern long DefWindowProc(IntPtr hWnd, uint Msg, ulong wParam, long lParam);

        /// <summary>
        /// Indicates to the system that a thread has made a request to terminate (quit). It is typically used in response to a WM_DESTROY message.
        /// </summary>
        /// <param name="nExitCode"> The application exit code. This value is used as the wParam parameter of the WM_QUIT message. </param>
        [DllImport("User32.dll")]
        public static extern void PostQuitMessage(int nExitCode);
    }
}
