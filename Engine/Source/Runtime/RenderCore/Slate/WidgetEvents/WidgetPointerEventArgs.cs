// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;

namespace SC.Engine.Runtime.RenderCore.Slate.WidgetEvents
{
    /// <summary>
    /// 위젯 포인터 이벤트 매개변수를 나타냅니다.
    /// </summary>
    public record WidgetPointerEventArgs : WidgetEventArgs
    {
        /// <summary>
        /// 버튼 형식을 나타냅니다.
        /// </summary>
        public enum ButtonType
        {
            /// <summary>
            /// 왼쪽 마우스 버튼입니다.
            /// </summary>
            Left,

            /// <summary>
            /// 오른쪽 마우스 버튼입니다.
            /// </summary>
            Right
        }

        /// <summary>
        /// 마우스 위치를 나타냅니다.
        /// </summary>
        public Vector2 CursorLocation;

        /// <summary>
        /// 버튼 형식을 나타냅니다.
        /// </summary>
        public ButtonType? Type;

        /// <summary>
        /// 마우스 위치의 이동 값을 나타냅니다.
        /// </summary>
        public Vector2 CursorLocationDelta;
    }
}
