// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.WinAPI
{
    /// <summary>
    /// 핸들 형식에 대한 공통 함수를 제공합니다.
    /// </summary>
    public interface IPlatformHandle : IDisposable
    {
        /// <summary>
        /// 핸들을 닫고 사용을 종료합니다.
        /// </summary>
        void Close();

        /// <summary>
        /// 개체가 소유한 네이티브 핸들을 가져옵니다.
        /// </summary>
        /// <returns> 핸들의 포인터가 반환됩니다. </returns>
        IntPtr GetHandle();
    }
}
