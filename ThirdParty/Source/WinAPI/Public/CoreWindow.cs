// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

using static SC.ThirdParty.WinAPI.User32;
using static SC.ThirdParty.WinAPI.Kernel32;
using static SC.ThirdParty.WinAPI.WindowStyles;
using static SC.ThirdParty.WinAPI.WindowMessage;

namespace SC.ThirdParty.WinAPI
{
    /// <summary>
    /// 응용 프로그램의 주 대화 창입니다.
    /// </summary>
    public class CoreWindow : Window
    {
        delegate long WndProcDelegate(IntPtr hWnd, uint uMsg, ulong wParam, long lParam);

        /// <summary>
        /// 창이 파괴될 때 호출되는 이벤트의 대리자입니다.
        /// </summary>
        public delegate void DestroyDelegate();

        /// <summary>
        /// 창의 크기가 변경될 때 호출되는 이벤트의 대리자입니다.
        /// </summary>
        /// <param name="x"> X 크기가 전달됩니다. </param>
        /// <param name="y"> Y 크기가 전달됩니다. </param>
        public delegate void SizingDelegate(int x, int y);

        Application _app;
        IntPtr _handle;
        bool _disposed;
        WndProcDelegate _binder;

        /// <summary>
        /// 새 개체를 초기화합니다.
        /// </summary>
        /// <param name="app"> 애플리케이션 개체를 전달합니다. </param>
        /// <param name="title"> 창의 제목을 전달합니다. </param>
        public CoreWindow(Application app, string title = null)
        {
            _app = app;
            _binder = WndProc;
            _handle = CreateCoreWindow();
            if (title is not null)
            {
                Title = title;
            }
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }

        /// <inheritdoc/>
        public override void Close()
        {
            CheckDisposed();
        }

        /// <inheritdoc/>
        public override IntPtr GetHandle()
        {
            CheckDisposed();
            return _handle;
        }

        /// <summary>
        /// 창이 파괴될 때 호출되는 이벤트입니다.
        /// </summary>
        public event DestroyDelegate Destroy;

        /// <summary>
        /// 창의 크기가 변경될 때 호출되는 이벤트입니다.
        /// </summary>
        public event SizingDelegate Sizing;

        IntPtr CreateCoreWindow()
        {
            WNDCLASSEX wcex = new();
            wcex.cbSize = (uint)Marshal.SizeOf<WNDCLASSEX>();
            wcex.lpfnWndProc = Marshal.GetFunctionPointerForDelegate(_binder);
            wcex.hInstance = _app.GetHandle();
            wcex.lpszClassName = GetType().FullName;

            ushort atom = RegisterClassEx(ref wcex);
            if (atom == 0)
            {
                throw new Win32Exception(GetLastError());
            }

            IntPtr hWnd = CreateWindowEx(0, atom, "", (int)WS_OVERLAPPEDWINDOW, int.MinValue, int.MinValue, int.MinValue, int.MinValue, IntPtr.Zero, IntPtr.Zero, wcex.hInstance, IntPtr.Zero);
            if (hWnd == IntPtr.Zero)
            {
                throw new Win32Exception(GetLastError());
            }

            return hWnd;
        }

        void CheckDisposed()
        {
            if (_disposed)
            {
                throw new AccessViolationException("개체가 이미 종료되었습니다.");
            }
        }

        long WndProc(IntPtr hWnd, uint uMsg, ulong wParam, long lParam)
        {
            if (ProcessMessage(uMsg, wParam, lParam))
            {
                return 0;
            }

            switch ((WindowMessage)uMsg)
            {
                case WM_DESTROY:
                    Destroy?.Invoke();
                    PostQuitMessage(0);
                    break;
                case WM_SIZE:
                    Sizing?.Invoke(LOWORD((int)lParam), HIWORD((int)lParam));
                    break;
            }

            return DefWindowProc(hWnd, uMsg, wParam, lParam);
        }

        /// <summary>
        /// 모든 메시지를 처리합니다.
        /// </summary>
        /// <param name="uMsg"> 메시지 ID가 전달됩니다. </param>
        /// <param name="wParam"> 첫 번째 매개변수가 전달됩니다. </param>
        /// <param name="lParam"> 두 번째 매개변수가 전달됩니다. </param>
        /// <returns> <see langword="true"/>를 반환할 경우 이후 메시지를 처리하지 않습니다. </returns>
        protected virtual bool ProcessMessage(uint uMsg, ulong wParam, long lParam)
        {
            return false;
        }

        short LOWORD(int l)
        {
            return (short)(l & 0xffff);
        }

        short HIWORD(int l)
        {
            return (short)((l >> 16) & 0xffff);
        }
    }
}
