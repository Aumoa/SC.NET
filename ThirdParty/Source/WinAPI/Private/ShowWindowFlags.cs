// Copyright 2020-2021 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.WinAPI
{
    enum ShowWindowFlags
    {
        /// <summary>
        /// Hides the window and activates another window.
        /// </summary>
        SW_HIDE = 0,

        /// <summary>
        /// <para> Activates and displays a window. </para>
        /// <para> If the window is minimized or maximized, the system restores it to its original size and position. </para>
        /// <para> An application should specify this flag when dislaying the window for the first time. </para>
        /// </summary>
        SW_SHOWNORMAL = 1,

        /// <summary>
        /// Activates the window and displays it as a minimized window.
        /// </summary>
        SW_SHOWMINIMIZED = 2,

        /// <summary>
        /// Maximizes the specified window.
        /// </summary>
        SW_MAXIMIZE = 3,

        /// <summary>
        /// Activates the window and displays it as a maximized window.
        /// </summary>
        SW_SHOWMAXIMIZED = 3,

        /// <summary>
        /// <para> Displays a window in its most recent size and position. </para>
        /// <para> This value is similar to <see cref="SW_SHOW"/>, except that the window is not activated. </para>
        /// </summary>
        SW_SHOWNOACTIVATE = 4,

        /// <summary>
        /// Activates the widnow and displays it in its current size and position.
        /// </summary>
        SW_SHOW = 5,

        /// <summary>
        /// Minimizes the specified window and activates the next top-level window in the Z order.
        /// </summary>
        SW_MINIMIZE = 6,

        /// <summary>
        /// <para> Displays the window as a minimized windows. </para>
        /// <para> This value is similar to <see cref="SW_SHOWMINIMIZED"/>, except the window is not activated. </para>
        /// </summary>
        SW_SHOWMINNOACTIVE = 7,

        /// <summary>
        /// <para> Displays the window in its current size and position. </para>
        /// <para> This value is similar to <see cref="SW_SHOW"/>, except that the window is not activated. </para>
        /// </summary>
        SW_SHOWNA = 8,

        /// <summary>
        /// <para>Activates and displays the window.</para>
        /// <para>If the window is minimized or maximized, the system restores it to its original size and position.</para>
        /// <para>An application should specify this flag when restoring a minimized window.</para>
        /// </summary>
        SW_RESTORE = 9,

        /// <summary>
        /// Sets the show state based on the SW_ value specified in the <see cref="STARTUPINFO"/> structure passed to the CreateProcess function by the program that started the application.
        /// </summary>
        SW_SHOWDEFAULT = 10,

        /// <summary>
        /// Minimizes a window, even if the thread that owns the window is not responding. This flag should only be used when minimizing windows from a different thread.
        /// </summary>
        SW_FORCEMINIMIZE = 11,
    }
}
