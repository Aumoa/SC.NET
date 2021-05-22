// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

namespace SC.Engine.Runtime.GameCore
{
    /// <summary>
    /// 컴포넌트의 더티 마스크를 표현합니다.
    /// </summary>
    [Flags]
    public enum ComponentDirtyFlags
    {
        /// <summary>
        /// 상태가 없습니다.
        /// </summary>
        None = 0,

        /// <summary>
        /// 씬 프록시가 다시 생성되어야 합니다.
        /// </summary>
        RecreateProxy = 0x1,

        /// <summary>
        /// 씬 프록시가 업데이트되어야 합니다.
        /// </summary>
        UpdateProxy = 0x2,

        /// <summary>
        /// 트랜스폼이 업데이트되었습니다.
        /// </summary>
        TransformUpdated = 0x4,
    }
}
