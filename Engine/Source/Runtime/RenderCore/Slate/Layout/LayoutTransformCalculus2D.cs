// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;

namespace SC.Engine.Runtime.RenderCore.Slate.Layout
{
    /// <summary>
    /// 2차원 트랜스폼에 대한 명명된 계산 함수를 제공합니다.
    /// </summary>
    public static class TransformCalculus2D
    {
        /// <summary>
        /// 위치를 변환합니다.
        /// </summary>
        /// <param name="translation"> 트랜스폼을 전달합니다. </param>
        /// <param name="point"> 위치를 전달합니다. </param>
        /// <returns> 계산 결과가 반환됩니다. </returns>
        public static TVector TransformPoint<TVector>(this Vector2 translation, TVector point) where TVector : IVectorType, new()
        {
            TVector v = new();
            v[0] = translation[0] + point[0];
            v[1] = translation[1] + point[1];
            return v;
        }

        /// <summary>
        /// 벡터를 변환합니다.
        /// </summary>
        /// <param name="transform"> 트랜스폼을 전달합니다. </param>
        /// <param name="vector"> 벡터를 전달합니다. </param>
        /// <returns> 계산 결과가 반환됩니다. </returns>
        public static TVector TransformVector<TVector>(this Vector2 transform, TVector vector) where TVector : IVectorType, new()
        {
            return vector;
        }

        /// <summary>
        /// 역 이동 벡터를 계산합니다.
        /// </summary>
        /// <param name="transform"> 이동 벡터를 전달합니다. </param>
        /// <returns> 계산 결과가 반환됩니다. </returns>
        public static Vector2 Inverse(this Vector2 transform) => -transform;

        /// <summary>
        /// 사각 영역을 레이아웃 트랜스폼으로 조정합니다.
        /// </summary>
        /// <param name="transform"> 트랜스폼을 전달합니다. </param>
        /// <param name="rect"> 사각 영역을 전달합니다. </param>
        /// <returns> 변환된 사각 영역이 반환됩니다. </returns>
        public static SlateRotatedRect TransformRect<T>(this T transform, SlateRotatedRect rect) where T : ILayoutTransform2D
        {
            return new SlateRotatedRect
            (
                transform.TransformPoint(rect.TopLeft),
                transform.TransformVector(rect.ExtentX),
                transform.TransformVector(rect.ExtentY)
            );
        }

        /// <summary>
        /// 위치를 더합니다.
        /// </summary>
        /// <param name="translation"> 이동 벡터를 전달합니다. </param>
        /// <param name="vector"> 추가할 벡터를 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public static Vector2 Concatenate(this Vector2 translation, Vector2 vector)
        {
            return translation + vector;
        }

        /// <summary>
        /// 트랜스폼을 누적합니다.
        /// </summary>
        /// <param name="translation"> 이동 트랜스폼을 전달합니다. </param>
        /// <param name="transform"> 누적 트랜스폼을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public static SlateRenderTransform Concatenate(this Vector2 translation, SlateRenderTransform transform)
        {
            return new SlateRenderTransform(1.0f, translation).Concatenate(transform);
        }

        /// <summary>
        /// 두 트랜스폼을 누적합니다.
        /// </summary>
        /// <param name="transform"> 트랜스폼을 전달합니다. </param>
        /// <param name="rhs"> 누적할 트랜스폼을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public static SlateRenderTransform Concatenate(this SlateLayoutTransform transform, SlateRenderTransform rhs)
        {
            var M = transform.ToMatrix().Convert<Matrix2x2>();
            return new SlateRenderTransform(
                Matrix2x2.Multiply(M, rhs.M),
                rhs.M.TransformPoint(transform.Translation).Concatenate(transform.Translation)
                );
        }

        /// <summary>
        /// 지정한 영역만큼 확장합니다.
        /// </summary>
        /// <param name="rect"> 영역을 전달합니다. </param>
        /// <param name="extendAmount"> 확장할 값을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public static Rectangle ExtendBy(this Rectangle rect, Margin extendAmount)
        {
            return new Rectangle(rect.Left - extendAmount.Left, rect.Top - extendAmount.Top, rect.Right + extendAmount.Right, rect.Bottom + extendAmount.Bottom);
        }
    }
}
