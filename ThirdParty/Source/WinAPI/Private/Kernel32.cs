
// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.WinAPI
{
    static class Kernel32
    {
        /// <summary>
        /// Retrieves the calling thread's last-error code value. The last-error code is maintained on a per-thread basis. Multiple threads do not overwrite each other's last-error code.
        /// </summary>
        /// <returns>
        /// <para> The return value is the calling thread's last-error code. </para>
        /// <para> The Return Value section of the documentation for each function that sets the last-error code notes the conditions under which the function sets the last-error code. Most functions that set the thread's last-error code set it when they fail. However, some functions also set the last-error code when they succeed. If the function is not documented to set the last-error code, the value returned by this function is simply the most recent last-error code to have been set; some functions set the last-error code to 0 on success and others do not. </para>
        /// </returns>
        [DllImport("Kernel32.dll")]
        public static extern int GetLastError();

        /// <summary>
        /// <para> Retrieves a module handle for the specified module. The module must have been loaded by the calling process. </para>
        /// <para> To avoid the race conditions described in the Remarks section, use the GetModuleHandleEx function. </para>
        /// </summary>
        /// <param name="lpModuleName">
        /// <para> The name of the loaded module (either a .dll or .exe file). If the file name extension is omitted, the default library extension .dll is appended. The file name string can include a trailing point character (.) to indicate that the module name has no extension. The string does not have to specify a path. When specifying a path, be sure to use backslashes (\), not forward slashes (/). The name is compared (case independently) to the names of modules currently mapped into the address space of the calling process. </para>
        /// <para> If this parameter is NULL, GetModuleHandle returns a handle to the file used to create the calling process (.exe file). </para>
        /// <para> The GetModuleHandle function does not retrieve handles for modules that were loaded using the LOAD_LIBRARY_AS_DATAFILE flag. For more information, see LoadLibraryEx. </para>
        /// </param>
        /// <returns>
        /// <para> If the function succeeds, the return value is a handle to the specified module. </para>
        /// <para> If the function fails, the return value is NULL. To get extended error information, call <see cref="GetLastError"/>. </para>
        /// </returns>
        [DllImport("Kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        /// <summary>
        /// Closes an open object handle.
        /// </summary>
        /// <param name="hObject"> A valid handle to an open object. </param>
        /// <returns>
        /// <para> If the function succeeds, the return value is nonzero. </para>
        /// <para> If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>. </para>
        /// <para> If the application is running under a debugger, the function will throw an exception if it receives either a handle value that is not valid or a pseudo-handle value. This can happen if you close a handle twice, or if you call CloseHandle on a handle returned by the FindFirstFile function instead of calling the FindClose function. </para>
        /// </returns>
        [DllImport("Kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hObject);

        /// <summary>
        /// Creates or opens a named or unnamed event object and returns a handle to the object.
        /// </summary>
        /// <param name="lpEventAttributes"> A pointer to a SECURITY_ATTRIBUTES structure. If lpEventAttributes is NULL, the event handle cannot be inherited by child processes. </param>
        /// <param name="lpName"> The name of the event object. The name is limited to MAX_PATH characters. Name comparison is case sensitive. </param>
        /// <param name="dwFlags"></param>
        /// <param name="dwDesiredAccess"> The access mask for the event object. For a list of access rights, see Synchronization Object Security and Access Rights. </param>
        /// <returns> If the function succeeds, the return value is a handle to the event object. If the named event object existed before the function call, the function returns a handle to the existing object and <see cref="GetLastError"/> returns ERROR_ALREADY_EXISTS. </returns>
        [DllImport("Kernel32.dll")]
        public static extern IntPtr CreateEventEx(IntPtr lpEventAttributes, string lpName, uint dwFlags, uint dwDesiredAccess);

        /// <summary>
        /// <para> Waits until the specified object is in the signaled state or the time-out interval elapses. </para>
        /// <para> To enter an alertable wait state, use the WaitForSingleObjectEx function. To wait for multiple objects, use WaitForMultipleObjects. </para>
        /// </summary>
        /// <param name="hHandle"> A handle to the object. For a list of the object types whose handles can be specified, see the following Remarks section. </param>
        /// <param name="dwMilliseconds"> The time-out interval, in milliseconds. If a nonzero value is specified, the function waits until the object is signaled or the interval elapses. If dwMilliseconds is zero, the function does not enter a wait state if the object is not signaled; it always returns immediately. If dwMilliseconds is INFINITE, the function will return only when the object is signaled. </param>
        /// <returns> If the function succeeds, the return value indicates the event that caused the function to return. </returns>
        [DllImport("Kernel32.dll")]
        public static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);
    }
}
