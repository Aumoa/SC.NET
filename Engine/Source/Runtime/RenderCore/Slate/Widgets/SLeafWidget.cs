// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;
using SC.Engine.Runtime.RenderCore.Slate.Layout;

namespace SC.Engine.Runtime.RenderCore.Slate.Widgets
{
    /// <summary>
    /// 자식을 가지지 않는 단일 위젯을 표현합니다.
    /// </summary>
    public abstract class SLeafWidget : SWidget
    {
        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public SLeafWidget()
        {
        }

        /// <inheritdoc/>
        protected override void OnArrangeChildren(ArrangedChildren arrangedChildren, Geometry allottedGeometry)
        {
            arrangedChildren.AddWidget(Visibility, allottedGeometry.MakeChild(
                this,
                Vector2.Zero,
                GetDesiredSize()
            ));
        }
    }
}
