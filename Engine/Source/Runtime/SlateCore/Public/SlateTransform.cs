// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;

namespace SC.Engine.Runtime.SlateCore
{
    /// <summary>
    /// 슬레이트 트랜스폼을 표현합니다.
    /// </summary>
    public struct SlateTransform
    {
        /// <summary>
        /// 슬레이트 위치를 표현합니다.
        /// </summary>
        public Vector2 Location;

        /// <summary>
        /// 슬레이트 크기를 표현합니다.
        /// </summary>
        public Vector2 Size;
    }
}
