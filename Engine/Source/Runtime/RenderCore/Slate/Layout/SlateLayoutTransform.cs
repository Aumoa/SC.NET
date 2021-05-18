// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using SC.Engine.Runtime.Core.Numerics;

namespace SC.Engine.Runtime.RenderCore.Slate.Layout
{
    /// <summary>
    /// 슬레이트 레이아웃 트랜스폼을 표현합니다.
    /// </summary>
    public readonly struct SlateLayoutTransform : ILayoutTransform2D, IEquatable<SlateLayoutTransform>, INearlyEquatable<SlateLayoutTransform, float>, IFormattable
    {
        /// <summary>
        /// 비례 계수를 나타냅니다.
        /// </summary>
        public readonly float Scale;

        /// <summary>
        /// 이동 값을 나타냅니다.
        /// </summary>
        public readonly Vector2 Translation;

        /// <summary>
        /// 단위 레이아웃 트랜스폼을 가져옵니다.
        /// </summary>
        public static readonly SlateLayoutTransform Identity = new SlateLayoutTransform(1.0f, Vector2.Zero);

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="inScale"> 비례 계수를 전달합니다. </param>
        /// <param name="inTranslation"> 이동 값을 전달합니다. </param>
        public SlateLayoutTransform(float inScale, Vector2 inTranslation)
        {
            Scale = inScale;
            Translation = inTranslation;
        }

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="inTranslation"> 이동 값을 전달합니다. </param>
        public SlateLayoutTransform(Vector2 inTranslation)
        {
            Scale = 1.0f;
            Translation = inTranslation;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is SlateLayoutTransform transform)
            {
                return Equals(transform);
            }
            else
            {
                return base.Equals(obj);
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Translation: {Translation}, Scale: {Scale}";
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return Translation.GetHashCode() ^ Scale.GetHashCode();
        }

        /// <inheritdoc/>
        public bool Equals(SlateLayoutTransform rhs)
        {
            return Translation.Equals(rhs.Translation) && Scale.Equals(rhs.Scale);
        }

        /// <inheritdoc/>
        public bool NearlyEquals(SlateLayoutTransform rhs, float epsilon)
        {
            return Translation.NearlyEquals(rhs.Translation, epsilon)
                && Math.Abs(Scale - rhs.Scale) <= epsilon;
        }

        /// <inheritdoc/>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"Translation: {Translation.ToString(format, formatProvider)}, Scale: {Scale.ToString(format, formatProvider)}";
        }

        /// <summary>
        /// 행렬으로 표현합니다.
        /// </summary>
        /// <returns> 값이 반환됩니다. </returns>
        public readonly Matrix3x2 ToMatrix()
        {
            Matrix3x2 value = new();
            value._11 = Scale;
            value._22 = Scale;
            value._31 = Translation.X;
            value._32 = Translation.Y;
            return value;
        }

        /// <inheritdoc/>
        public readonly T TransformPoint<T>(T point) where T : IVectorType, new()
        {
            return Translation.TransformPoint(new Scale2D(Scale).TransformPoint(point));
        }

        /// <inheritdoc/>
        public readonly T TransformVector<T>(T vector) where T : IVectorType, new()
        {
            return Translation.TransformVector(new Scale2D(Scale).TransformVector(vector));
        }

        /// <summary>
        /// 두 트랜스폼을 누적합니다.
        /// </summary>
        /// <param name="rhs"> 누적할 트랜스폼을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public readonly SlateLayoutTransform Concatenate(SlateLayoutTransform rhs)
        {
            return new SlateLayoutTransform(Scale2D.Concatenate(Scale, rhs.Scale), rhs.TransformPoint(Translation));
        }

        /// <summary>
        /// 두 트랜스폼을 누적합니다.
        /// </summary>
        /// <param name="rhs"> 누적할 트랜스폼을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public readonly SlateRenderTransform Concatenate(SlateRenderTransform rhs)
        {
            return new SlateRenderTransform(Matrix2x2.Multiply(Matrix2x2.Scale(new Vector2(Scale)), rhs.M), TransformPoint(rhs.Translation));
        }

        /// <summary>
        /// 역 트랜스폼을 가져옵니다.
        /// </summary>
        /// <returns></returns>
        public readonly SlateLayoutTransform Inverse()
        {
            float invScale = 1.0f / Scale;
            return new SlateLayoutTransform(invScale, -Translation * invScale);
        }

        /// <summary>
        /// 두 값이 같은지 비교합니다.
        /// </summary>
        /// <param name="lhs"> 값을 전달합니다. </param>
        /// <param name="rhs"> 값을 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator ==(SlateLayoutTransform lhs, SlateLayoutTransform rhs) => lhs.Translation == rhs.Translation && lhs.Scale == rhs.Scale;
                                                                                                                                 
        /// <summary>                                                                                                            
        /// 두 값이 같지 않은지 비교합니다.                                                                                        
        /// </summary>                                                                                                           
        /// <param name="lhs"> 값을 전달합니다. </param>                                                                          
        /// <param name="rhs"> 값을 전달합니다. </param>                                                                          
        /// <returns> 비교 결과가 반환됩니다. </returns>                                                                          
        public static bool operator !=(SlateLayoutTransform lhs, SlateLayoutTransform rhs) => lhs.Translation != rhs.Translation || lhs.Scale != rhs.Scale;

        /// <summary>
        /// 사각 영역을 레이아웃 트랜스폼으로 조정합니다.
        /// </summary>
        /// <param name="rect"> 사각 영역을 전달합니다. </param>
        /// <returns> 변환된 사각 영역이 반환됩니다. </returns>
        public Rectangle TransformRect(Rectangle rect)
        {
            Vector2 topLeftTransformed = TransformPoint(rect.LeftTop);
            Vector2 bottomRightTransformed = TransformPoint(rect.RightBottom);

            if (topLeftTransformed.X > bottomRightTransformed.X)
            {
                Swap(ref topLeftTransformed.X, ref bottomRightTransformed.X);
            }
            if (topLeftTransformed.Y > bottomRightTransformed.Y)
            {
                Swap(ref topLeftTransformed.Y, ref bottomRightTransformed.Y);
            }
            return new Rectangle(topLeftTransformed, bottomRightTransformed);
        }

        static void Swap(ref float lhs, ref float rhs)
        {
            float t = lhs;
            lhs = rhs;
            rhs = t;
        }
    }
}
