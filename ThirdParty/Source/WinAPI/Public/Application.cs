// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using static SC.ThirdParty.WinAPI.WindowMessage;
using static SC.ThirdParty.WinAPI.User32;

namespace SC.ThirdParty.WinAPI
{
    /// <summary>
    /// 애플리케이션을 정의합니다.
    /// </summary>
    public class Application : IPlatformHandle
    {
        /// <summary>
        /// 애플리케이션이 초기화될 때 호출되는 이벤트의 대리자입니다.
        /// </summary>
        /// <param name="target"> 대상 윈도우가 전달됩니다. </param>
        public delegate void InitializeDelegate(CoreWindow target);

        /// <summary>
        /// 애플리케이션이 종료될 때 호출되는 이벤트의 대리자입니다.
        /// </summary>
        public delegate void ShutdownDelegate();

        /// <summary>
        /// 애플리케이션이 메시지를 처리하지 않는 유휴 시간동안 호출되는 이벤트의 대리자입니다.
        /// </summary>
        public delegate void IdleDelegate();

        IntPtr _handle;
        bool _disposed;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public Application()
        {
            _handle = Kernel32.GetModuleHandle(null);
        }

        /// <inheritdoc/>
        public virtual void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
            }
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        public virtual void Close()
        {
            CheckDisposed();
        }

        /// <inheritdoc/>
        public virtual IntPtr GetHandle()
        {
            return _handle;
        }

        /// <summary>
        /// 애플리케이션의 주 루프를 실행합니다.
        /// </summary>
        /// <param name="dialog"> 애플리케이션이 표시하는 주 대화 상자를 나타냅니다. </param>
        public void Run(CoreWindow dialog)
        {
            Initialize?.Invoke(dialog);

            // 창이 보이지 않는 상태라면 보이게 합니다.
            if (!dialog.IsVisible)
            {
                dialog.IsVisible = true;
            }

            MSG msg = new();
            while (true)
            {
                if (PeekMessage(ref msg, IntPtr.Zero, 0, 0, 1))
                {
                    if (msg.message == WM_QUIT)
                    {
                        break;
                    }
                    else
                    {
                        TranslateMessage(ref msg);
                        DispatchMessage(ref msg);
                    }
                }
                else
                {
                    Idle?.Invoke();
                }
            }

            Shutdown?.Invoke();
        }

        /// <summary>
        /// 애플리케이션이 초기화될 때 호출되는 이벤트입니다.
        /// </summary>
        public event InitializeDelegate Initialize;

        /// <summary>
        /// 애플리케이션이 종료될 때 호출되는 이벤트입니다.
        /// </summary>
        public event ShutdownDelegate Shutdown;

        /// <summary>
        /// 애플리케이션이 메시지를 처리하지 않는 유휴 시간동안 호출되는 이벤트입니다.
        /// </summary>
        public event IdleDelegate Idle;

        void CheckDisposed()
        {
            if (_disposed)
            {
                throw new AccessViolationException("개체가 이미 종료되었습니다.");
            }
        }
    }
}
