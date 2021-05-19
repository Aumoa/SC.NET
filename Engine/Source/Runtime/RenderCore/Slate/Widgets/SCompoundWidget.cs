// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using SC.Engine.Runtime.Core.Numerics;
using SC.Engine.Runtime.RenderCore.Slate.Layout;
using SC.Engine.Runtime.RenderCore.Slate.WidgetEvents;

namespace SC.Engine.Runtime.RenderCore.Slate.Widgets
{
    /// <summary>
    /// 여러 위젯의 집합으로 표현되는 단일 위젯에 대한 기초 기능을 제공합니다.
    /// </summary>
    public abstract class SCompoundWidget : SWidget
    {
        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public SCompoundWidget()
        {
        }

        /// <inheritdoc/>
        protected override int OnPaint(SlatePaintArgs paintArgs, Geometry allottedGeometry, Rectangle myCullingRect, SlateWindowElementList drawElements, int layer, bool parentEnabled)
        {
            ArrangedChildren arrangedChildren = new(SlateVisibility.Visible);
            ArrangeChildren(arrangedChildren, allottedGeometry);

            return PaintArrangedChildren(paintArgs, arrangedChildren, allottedGeometry, myCullingRect, drawElements, layer, parentEnabled);
        }

        /// <summary>
        /// 재배열된 자식 위젯들을 렌더링합니다.
        /// </summary>
        /// <param name="paintArgs"> 렌더링 매개변수를 전달합니다. </param>
        /// <param name="arrangedChildren"> 재배치 위젯 목록 개체를 전달합니다. </param>
        /// <param name="allottedGeometry"> 이 위젯에 할당된 트랜스폼이 전달됩니다. </param>
        /// <param name="myCullingRect"> 컬링 영역이 전달됩니다. </param>
        /// <param name="drawElements"> 렌더링 요소 목록 개체가 전달됩니다. </param>
        /// <param name="layer"> 레이어 위치가 전달됩니다. </param>
        /// <param name="parentEnabled"> 상위 요소의 활성화 여부가 전달됩니다. </param>
        protected virtual int PaintArrangedChildren(SlatePaintArgs paintArgs, ArrangedChildren arrangedChildren, Geometry allottedGeometry, Rectangle myCullingRect, SlateWindowElementList drawElements, int layer, bool parentEnabled)
        {
            SlatePaintArgs newArgs = paintArgs with { Parent = this };
            bool shouldBeEnabled = ShouldBeEnabled(parentEnabled);

            foreach (ArrangedWidget arrangedWidget in arrangedChildren.GetWidgets())
            {
                SWidget curWidget = arrangedWidget.Widget;

                if (!IsChildWidgetCulled(myCullingRect, arrangedWidget))
                {
                    int curWidgetsMaxLayer = curWidget.Paint(newArgs, arrangedWidget.Geometry, myCullingRect, drawElements, layer, shouldBeEnabled);
                    layer = Math.Max(curWidgetsMaxLayer, layer);
                }
            }

            return layer;
        }
    }
}
