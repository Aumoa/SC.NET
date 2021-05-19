// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

namespace SC.Engine.Runtime.RenderCore.Slate.Layout
{
    /// <summary>
    /// 위젯의 여백을 표현합니다.
    /// </summary>
    public struct Margin
    {
        /// <summary>
        /// 왼쪽 여백 영역을 나타냅니다.
        /// </summary>
        public float Left;

        /// <summary>
        /// 위쪽 여백 영역을 나타냅니다.
        /// </summary>
        public float Top;

        /// <summary>
        /// 오른쪽 여백 영역을 나타냅니다.
        /// </summary>
        public float Right;

        /// <summary>
        /// 아래쪽 여백 영역을 나타냅니다.
        /// </summary>
        public float Bottom;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="left"> 왼쪽 여백 영역을 전달합니다. </param>
        /// <param name="top"> 위쪽 여백 영역을 전달합니다. </param>
        /// <param name="right"> 오른쪽 여백 영역을 전달합니다. </param>
        /// <param name="bottom"> 아래쪽 여백 영역을 전달합니다. </param>
        public Margin(float left, float top, float right, float bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="uniformValue"> 단일 값을 전달합니다. </param>
        public Margin(float uniformValue)
        {
            Left = uniformValue;
            Top = uniformValue;
            Right = uniformValue;
            Bottom = uniformValue;
        }

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="horizontal"> 수평 값을 전달합니다. </param>
        /// <param name="vertical"> 수직 값을 전달합니다. </param>
        public Margin(float horizontal, float vertical)
        {
            Left = horizontal;
            Right = horizontal;
            Top = vertical;
            Bottom = vertical;
        }

        /// <summary>
        /// 방향에 대한 전체 빈 공간 값을 계산합니다.
        /// </summary>
        /// <param name="orientation"> 방향을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public float GetTotalSpaceAlong(Orientation orientation)
        {
            return orientation switch
            {
                Orientation.Horizontal => Left + Right,
                Orientation.Vertical => Top + Bottom,
                _ => throw new ArgumentException($"매개변수 {nameof(orientation)}에 잘못된 값({orientation})이 전달되었습니다."),
            };
        }
    }
}
