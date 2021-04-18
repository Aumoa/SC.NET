// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using static SC.ThirdParty.WinAPI.Kernel32;

namespace SC.ThirdParty.WinAPI
{
    /// <summary>
    /// Windows에서 제공하는 기본 핸들을 사용합니다.
    /// </summary>
    public class GeneralHandle : IPlatformHandle
    {
        IntPtr _handle;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="handle"> 핸들 값을 전달합니다. </param>
        public GeneralHandle(IntPtr handle)
        {
            _handle = handle;
        }

        /// <summary>
        /// 핸들을 닫고 개체 사용을 종료합니다.
        /// </summary>
        public virtual void Dispose()
        {
            Close();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 핸들을 닫습니다.
        /// </summary>
        public virtual void Close()
        {
            if (_handle != IntPtr.Zero)
            {
                CloseHandle(_handle);
                _handle = IntPtr.Zero;
            }
        }

        /// <summary>
        /// 참조된 핸들을 가져옵니다.
        /// </summary>
        /// <returns> 값이 반환됩니다. </returns>
        public virtual IntPtr GetHandle()
        {
            return _handle;
        }
    }
}
