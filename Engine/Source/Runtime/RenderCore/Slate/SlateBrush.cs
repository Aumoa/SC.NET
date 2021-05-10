// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;

namespace SC.Engine.Runtime.RenderCore.Slate
{
    /// <summary>
    /// 슬레이트 브러시를 표현합니다.
    /// </summary>
    public readonly struct SlateBrush
    {
        /// <summary>
        /// 이미지 소스를 나타냅니다.
        /// </summary>
        public readonly RHIShaderResourceView ImageSource;

        /// <summary>
        /// 이미시 크기를 나타냅니다.
        /// </summary>
        public readonly Vector2 ImageSize;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="imageSource"> 이미지 소스를 전달합니다. </param>
        /// <param name="imageSize"> 이미지 크기를 전달합니다. </param>
        public SlateBrush(RHIShaderResourceView imageSource, Vector2 imageSize)
        {
            ImageSource = imageSource;
            ImageSize = imageSize;
        }
    }
}
