// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.RenderCore.Slate.Widgets;

namespace SC.Engine.Runtime.RenderCore.Slate.WidgetEvents
{
    /// <summary>
    /// 위젯 이벤트 매개변수를 표현합니다.
    /// </summary>
    public record WidgetEventArgs
    {
        /// <summary>
        /// 이 이벤트를 호출한 상위 위젯 개체를 가져옵니다.
        /// </summary>
        public SWidget Parent;
    }
}
