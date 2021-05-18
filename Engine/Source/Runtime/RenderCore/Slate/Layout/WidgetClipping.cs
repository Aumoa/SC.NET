// Copyright 2020-2021 Aumoa.lib. All right reserved.

namespace SC.Engine.Runtime.RenderCore.Slate.Layout
{
    /// <summary>
    /// 위젯 영역 클리핑에 대한 규칙을 제공합니다.
    /// </summary>
    public enum WidgetClipping
    {
        /// <summary>
        /// 부모 위젯으로부터 규칙을 상속받습니다.
        /// </summary>
        Inherit,

        /// <summary>
        /// 바운드 영역으로 클리핑을 제공합니다. 부모 위젯의 클리핑 영역과 교차합니다.
        /// </summary>
        ClipToBounds,

        /// <summary>
        /// 바운드 영역으로 클리핑을 제공합니다. 부모 위젯의 클리핑 영역을 무시하고 새 클리핑 영역을 푸시합니다.
        /// </summary>
        ClipToBoundsWithoutIntersection,
    }
}
