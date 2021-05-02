// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;
using SC.Engine.Runtime.RenderCore;

namespace SC.Engine.Runtime.SlateCore
{
    /// <summary>
    /// 슬레이트 브러시를 표현합니다.
    /// </summary>
    public struct SlateBrush
    {
        /// <summary>
        /// 이미지 소스를 나타냅니다.
        /// </summary>
        public RHIShaderResourceView ImageSource;

        /// <summary>
        /// 이미시 크기를 나타냅니다.
        /// </summary>
        public Vector2 ImageSize;
    }
}
