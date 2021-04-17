// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.Text;

using static SC.ThirdParty.WinAPI.ShowWindowFlags;

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
                int length = User32.GetWindowText(hWnd, null, 0);

                var sb = new StringBuilder(length + 1);
                User32.GetWindowText(hWnd, sb, length);

                return sb.ToString();
            }
            set
            {
                var hWnd = GetHandle();
                User32.SetWindowText(hWnd, value);
            }
        }

        /// <summary>
        /// 창의 보이기 상태를 설정하거나 가져옵니다.
        /// </summary>
        public bool IsVisible
        {
            get
            {
                return User32.IsWindowVisible(GetHandle());
            }
            set
            {
                IntPtr hWnd = GetHandle();
                User32.ShowWindow(hWnd, (int)(value ? SW_SHOW : SW_HIDE));
            }
        }
    }
}
