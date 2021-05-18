// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using SC.Engine.Runtime.Core.Mathematics;
using SC.Engine.Runtime.Core.Numerics;

namespace SC.Engine.Runtime.RenderCore.Slate.Layout
{
    /// <summary>
    /// 회전 가능한 슬레이트 사각 영역을 표현합니다.
    /// </summary>
    public struct SlateRotatedRect
    {
        /// <summary>
        /// 왼쪽 위 위치를 나타냅니다.
        /// </summary>
        public Vector2 TopLeft;

        /// <summary>
        /// 변형된 X축 확장을 표현합니다.
        /// </summary>
        public Vector2 ExtentX;

        /// <summary>
        /// 변형된 Y축 확장을 표현합니다.
        /// </summary>
        public Vector2 ExtentY;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="alignedRect"> 축 정렬된 사각 영역을 전달합니다. </param>
        public SlateRotatedRect(Rectangle alignedRect)
        {
            TopLeft = alignedRect.LeftTop;
            ExtentX = new Vector2(alignedRect.Right - alignedRect.Left, 0);
            ExtentY = new Vector2(0, alignedRect.Bottom - alignedRect.Top);
        }

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="inTopLeft"> 왼쪽 위 위치를 전달합니다. </param>
        /// <param name="inExtentX"> 변형된 X축 확장을 전달합니다. </param>
        /// <param name="inExtentY"> 변형된 Y축 확장을 전달합니다. </param>
        public SlateRotatedRect(Vector2 inTopLeft, Vector2 inExtentX, Vector2 inExtentY)
        {
            TopLeft = inTopLeft;
            ExtentX = inExtentX;
            ExtentY = inExtentY;
        }

        /// <summary>
        /// 전체 영역을 둘러싸는 사각 영역으로 표현합니다.
        /// </summary>
        /// <returns> 값이 반환됩니다. </returns>
        public Rectangle ToBoundingRect()
        {
            Span<Vector2> points = stackalloc Vector2[4]
            {
                TopLeft,
                TopLeft + ExtentX,
                TopLeft + ExtentY,
                TopLeft + ExtentX + ExtentY
            };
            return new Rectangle(
                MathEx.Min(points[0].X, points[1].X, points[2].X, points[3].X),
                MathEx.Min(points[0].Y, points[1].Y, points[2].Y, points[3].Y),
                MathEx.Max(points[0].X, points[1].X, points[2].X, points[3].X),
                MathEx.Max(points[0].Y, points[1].Y, points[2].Y, points[3].Y)
                );
        }

        /// <summary>
        /// 위치가 이 사각 영역 내부에 포함되어있는지 검사합니다.
        /// </summary>
        /// <param name="location"> 위치를 전달합니다. </param>
        /// <returns> 결과가 반환됩니다. </returns>
        public bool IsUnderLocation(Vector2 location)
        {
            Vector2 offset = location - TopLeft;
            float det = Vector2.CrossProduct(ExtentX, ExtentY);

            // Not exhaustively efficient. Could optimize the checks for [0..1] to short circuit faster.
            float S = -Vector2.CrossProduct(offset, ExtentX) / det;
            if (MathEx.IsWithinInclusive(S, 0.0f, 1.0f))
            {
                float T = Vector2.CrossProduct(offset, ExtentY) / det;
                return MathEx.IsWithinInclusive(T, 0.0f, 1.0f);
            }
            return false;
        }

        /// <summary>
        /// 슬레이트 트랜스폼을 사용하여 회전 가능한 사각 영역을 계산합니다.
        /// </summary>
        /// <param name="clipRectInLayoutWindowSpace"> 클리핑 창 레이아웃 영역을 전달합니다. </param>
        /// <param name="inverseLayoutTransform"> 레이아웃 트랜스폼의 역을 전달합니다. </param>
        /// <param name="renderTransform"> 렌더 트랜스폼을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public static SlateRotatedRect MakeRotatedRect(Rectangle clipRectInLayoutWindowSpace, SlateLayoutTransform inverseLayoutTransform, SlateRenderTransform renderTransform)
            => MakeRotatedRect(clipRectInLayoutWindowSpace, inverseLayoutTransform.Concatenate(renderTransform));

        /// <summary>
        /// 트랜스폼을 사용하여 회전 가능한 사각 영역을 계산합니다.
        /// </summary>
        /// <param name="clipRectInLayoutWindowSpace"> 클리핑 창 레이아웃 영역을 전달합니다. </param>
        /// <param name="layoutToRenderTransform"> 렌더 트랜스폼으로 변환하기 위한 트랜스폼을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public static SlateRotatedRect MakeRotatedRect(Rectangle clipRectInLayoutWindowSpace, SlateRenderTransform layoutToRenderTransform)
        {
            SlateRotatedRect RotatedRect = layoutToRenderTransform.TransformRect(new SlateRotatedRect(clipRectInLayoutWindowSpace));

            Vector2 TopRight = RotatedRect.TopLeft + RotatedRect.ExtentX;
            Vector2 BottomLeft = RotatedRect.TopLeft + RotatedRect.ExtentY;

            return new SlateRotatedRect(
                RotatedRect.TopLeft,
                TopRight - RotatedRect.TopLeft,
                BottomLeft - RotatedRect.TopLeft);
        }

        /// <summary>
        /// 스냅 된 회전 사각 영역을 계산합니다.
        /// </summary>
        /// <param name="clipRectInLayoutWindowSpace"> 클리핑 창 레이아웃 영역을 전달합니다. </param>
        /// <param name="inverseLayoutTransform"> 레이아웃 트랜스폼의 역을 전달합니다. </param>
        /// <param name="renderTransform"> 렌더 트랜스폼을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public static SlateRotatedRect MakeSnappedRotatedRect(Rectangle clipRectInLayoutWindowSpace, SlateLayoutTransform inverseLayoutTransform, SlateRenderTransform renderTransform)
            => MakeSnappedRotatedRect(clipRectInLayoutWindowSpace, inverseLayoutTransform.Concatenate(renderTransform));

        /// <summary>
        /// 스냅 된 회전 사각 영역을 계산합니다.
        /// </summary>
        /// <param name="clipRectInLayoutWindowSpace"> 클리핑 창 레이아웃 영역을 전달합니다. </param>
        /// <param name="layoutToRenderTransform"> 렌더 트랜스폼으로 변환하기 위한 트랜스폼을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public static SlateRotatedRect MakeSnappedRotatedRect(Rectangle clipRectInLayoutWindowSpace, SlateRenderTransform layoutToRenderTransform)
        {
            SlateRotatedRect RotatedRect = layoutToRenderTransform.TransformRect(new SlateRotatedRect(clipRectInLayoutWindowSpace));

            // Pixel snapping is done here by rounding the resulting floats to ints, we do this before
            // calculating the final extents of the clip box otherwise we'll get a smaller clip rect than a visual
            // rect where each point is individually snapped.
            Vector2 SnappedTopLeft = (RotatedRect.TopLeft).Round();
            Vector2 SnappedTopRight = (RotatedRect.TopLeft + RotatedRect.ExtentX).Round();
            Vector2 SnappedBottomLeft = (RotatedRect.TopLeft + RotatedRect.ExtentY).Round();

            //NOTE: We explicitly do not re-snap the extent x/y, it wouldn't be correct to snap again in distance space
            // even if two points are snapped, their distance wont necessarily be a whole number if those points are not
            // axis aligned.
            return new SlateRotatedRect(
                SnappedTopLeft,
                SnappedTopRight - SnappedTopLeft,
                SnappedBottomLeft - SnappedTopLeft
                );
        }
    }
}
