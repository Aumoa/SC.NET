// Copyright 2020-2021 Aumoa.lib. All right reserved.

namespace SC.Engine.Runtime.RenderCore.Slate
{
    /// <summary>
    /// 위젯의 가시 상태를 표현합니다.
    /// </summary>
    public enum SlateVisibility
    {
        /// <summary>
        /// 화면에 보이며 상호작용 가능합니다.
        /// </summary>
        Visible,

        /// <summary>
        /// 화면에 보이지 않으며, 레이아웃 영역을 차지하지 않습니다.
        /// </summary>
        Collapsed,

        /// <summary>
        /// 화면에 보이지 않지만 레이아웃 영역은 차지합니다.
        /// </summary>
        Hidden,

        /// <summary>
        /// 화면에 보이지만 상호작용 불가능하며, 모든 하위 위젯에게도 적용됩니다.
        /// </summary>
        HitTestInvisible,

        /// <summary>
        /// 화면에 보이지만 상호작용 불가능하며, 자신만 적용됩니다.
        /// </summary>
        SelfHitTestInvisible,
    }
}
