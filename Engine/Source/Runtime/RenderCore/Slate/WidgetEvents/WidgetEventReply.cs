// Copyright 2020-2021 Aumoa.lib. All right reserved.

namespace SC.Engine.Runtime.RenderCore.Slate.WidgetEvents
{
    /// <summary>
    /// 위젯에서 처리한 이벤트에 대한 응답을 표현합니다.
    /// </summary>
    public record WidgetEventReply
    {
        /// <summary>
        /// 이벤트를 완전히 소비합니다. 이후에 등록된 이벤트 처리기가 발동하지 않습니다.
        /// </summary>
        /// <remarks>
        /// 일부 콜백 처리기 형태의 이벤트 응답은 이벤트를 소비해야 발생할 수도 있습니다.
        /// </remarks>
        public bool Consume = false;

        /// <summary>
        /// 이벤트가 올바르게 처리되었는지 나타내는 값을 가져옵니다.
        /// </summary>
        public bool IsProcessed = true;
    }
}
