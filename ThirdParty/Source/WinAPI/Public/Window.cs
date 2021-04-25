// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.Drawing;
using System.Text;

using static SC.ThirdParty.WinAPI.ShowWindowFlags;
using static SC.ThirdParty.WinAPI.User32;

namespace SC.ThirdParty.WinAPI
{
    /// <summary>
    /// 창 개체를 표현합니다.
    /// </summary>
    public abstract class Window : IPlatformHandle
    {
        /// <summary>
        /// 새 개체를 초기화합니다.
        /// </summary>
        public Window()
        {

        }

        /// <inheritdoc/>
        public abstract void Dispose();

        /// <inheritdoc/>
        public abstract void Close();

        /// <inheritdoc/>
        public abstract IntPtr GetHandle();

        /// <summary>
        /// 창의 타이틀을 설정하거나 가져옵니다.
        /// </summary>
        public string Title
        {
            get
            {
                var hWnd = GetHandle();
                int length = GetWindowText(hWnd, null, 0);

                var sb = new StringBuilder(length + 1);
                GetWindowText(hWnd, sb, length);

                return sb.ToString();
            }
            set
            {
                var hWnd = GetHandle();
                SetWindowText(hWnd, value);
            }
        }

        /// <summary>
        /// 창의 보이기 상태를 설정하거나 가져옵니다.
        /// </summary>
        public bool IsVisible
        {
            get
            {
                return IsWindowVisible(GetHandle());
            }
            set
            {
                IntPtr hWnd = GetHandle();
                ShowWindow(hWnd, (int)(value ? SW_SHOW : SW_HIDE));
            }
        }

        /// <summary>
        /// 창의 클라이언트 영역 크기를 가져옵니다.
        /// </summary>
        /// <returns> 값이 반환됩니다. </returns>
        public Size GetClientSize()
        {
            IntPtr hWnd = GetHandle();
            GetClientRect(hWnd, out RECT rc);
            return new Size(rc.right - rc.left, rc.bottom - rc.top);
        }
    }
}
