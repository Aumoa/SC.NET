// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;

namespace SC.Engine.Runtime.RenderCore.Slate
{
    /// <summary>
    /// 슬레이트 레이아웃 트랜스폼을 표현합니다.
    /// </summary>
    public struct SlateLayoutTransform
    {
        /// <summary>
        /// 비례 계수를 나타냅니다.
        /// </summary>
        public float Scale;

        /// <summary>
        /// 이동 값을 나타냅니다.
        /// </summary>
        public Vector2 Translation;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="scale"> 비례 계수를 전달합니다. </param>
        /// <param name="translation"> 이동 값을 전달합니다. </param>
        public SlateLayoutTransform(float scale, Vector2 translation)
        {
            Scale = scale;
            Translation = translation;
        }

        /// <summary>
        /// 행렬으로 표현합니다.
        /// </summary>
        /// <returns> 값이 반환됩니다. </returns>
        public Matrix3x2 ToMatrix()
        {
            Matrix3x2 value = new();
            value._11 = Scale;
            value._22 = Scale;
            value._31 = Translation.X;
            value._32 = Translation.Y;
            return value;
        }
    }
}
