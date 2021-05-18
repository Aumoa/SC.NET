// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

namespace SC.Engine.Runtime.RenderCore.Slate.Widgets
{
    /// <summary>
    /// 패널 위젯을 표현합니다.
    /// </summary>
    public abstract class SPanelWidget : SCompoundWidget
    {
        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public SPanelWidget()
        {
            // Panel widgets does not provide hit test functions,
            // but childs can be.
            Visibility = SlateVisibility.SelfHitTestInvisible;
        }

        /// <inheritdoc/>
        public override sealed SlateVisibility Visibility
        {
            get => base.Visibility;
            set => base.Visibility = value;
        }
    }
}
