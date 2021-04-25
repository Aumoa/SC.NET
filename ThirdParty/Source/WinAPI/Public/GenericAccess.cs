// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.WinAPI
{
    /// <summary>
    /// 특정 개체에 대한 엑세스 권한을 정의합니다.
    /// </summary>
    [Flags]
    public enum GenericAccess : uint
    {
        /// <summary>
        /// 모든 엑세스 권한을 나타냅니다.
        /// </summary>
        All = 0x10000000,

        /// <summary>
        /// 실행 권한을 나타냅니다.
        /// </summary>
        Execute = 0x20000000,

        /// <summary>
        /// 읽기 권한을 나타냅니다.
        /// </summary>
        Read = 0x40000000,

        /// <summary>
        /// 쓰기 권한을 나타냅니다.
        /// </summary>
        Write = 0x80000000,

        /// <summary>
        /// 삭제 권한을 나타냅니다.
        /// </summary>
        Delete = 0x00010000,

        /// <summary>
        /// 사용자, 그룹, 임의 엑세스 제어 목록(DACL)의 읽기 권한을 나타냅니다.
        /// </summary>
        ReadControl = 0x00020000,

        /// <summary>
        /// 임의 엑세스 제어 목록(DACL)의 쓰기 권한을 나타냅니다.
        /// </summary>
        WriteDAC = 0x00040000,

        /// <summary>
        /// 사용자의 쓰기 권한을 나타냅니다.
        /// </summary>
        WriteOwner = 0x00080000,

        /// <summary>
        /// 동기화 권한을 나타냅니다.
        /// </summary>
        Synchronize = 0x00100000,

        /// <summary>
        /// 이벤트 상태를 변경할 수 있습니다.
        /// </summary>
        EventModifyState = 0x0002,
    }
}
