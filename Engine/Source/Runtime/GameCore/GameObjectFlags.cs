// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

namespace SC.Engine.Runtime.GameCore
{
    /// <summary>
    /// 게임 오브젝트의 상태 플래그 목록을 나타냅니다.
    /// </summary>
    [Flags]
    public enum GameObjectFlags
    {
        /// <summary>
        /// 정상 상태를 나타냅니다.
        /// </summary>
        None = 0,

        /// <summary>
        /// 오브젝트가 소멸 대기중입니다.
        /// </summary>
        PendingKill = 0x01,
    }
}
