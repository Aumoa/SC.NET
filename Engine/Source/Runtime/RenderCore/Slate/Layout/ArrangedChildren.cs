// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.Collections.Generic;

using SC.Engine.Runtime.Core.Container;

namespace SC.Engine.Runtime.RenderCore.Slate.Layout
{
    /// <summary>
    /// 배열된 레이아웃을 표현합니다.
    /// </summary>
    public class ArrangedChildren
    {
        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="visibilityFilter"> 비저빌리티 필터를 전달합니다. </param>
        public ArrangedChildren(SlateVisibility visibilityFilter)
        {
            VisibilityFilter = visibilityFilter;
        }

        /// <summary>
        /// 배열된 위젯을 추가합니다.
        /// </summary>
        /// <param name="visibilityOverride"> 상속된 가시 속성을 전달합니다. </param>
        /// <param name="inWidgetGeometry"> 재배열된 위젯 개체를 전달합니다. </param>
        public void AddWidget(SlateVisibility visibilityOverride, ArrangedWidget inWidgetGeometry)
        {
            if (Accepts(visibilityOverride))
            {
                _array.Add(inWidgetGeometry);
            }
        }

        /// <summary>
        /// 배열된 위젯을 추가합니다.
        /// </summary>
        /// <param name="visibilityOverride"> 상속된 가시 속성을 전달합니다. </param>
        /// <param name="inWidgetGeometry"> 재배열된 위젯 개체를 전달합니다. </param>
        /// <param name="index"> 추가할 위치를 전달합니다. </param>
        public void InsertWidget(SlateVisibility visibilityOverride, ArrangedWidget inWidgetGeometry, Index index)
        {
            if (Accepts(visibilityOverride))
            {
                _array.Insert(index, inWidgetGeometry);
            }
        }

        /// <summary>
        /// 배열된 위젯을 추가합니다.
        /// </summary>
        /// <param name="visibilityOverride"> 상속된 가시 속성을 전달합니다. </param>
        /// <param name="inWidgetGeometry"> 재배열된 위젯 개체를 전달합니다. </param>
        /// <param name="index"> 추가할 위치를 전달합니다. </param>
        public void InsertWidget(SlateVisibility visibilityOverride, ArrangedWidget inWidgetGeometry, int index)
        {
            if (Accepts(visibilityOverride))
            {
                _array.Insert(index, inWidgetGeometry);
            }
        }

        /// <summary>
        /// 가시 속성 필터를 설정하거나 가져옵니다.
        /// </summary>
        public SlateVisibility VisibilityFilter { get; set; }

        /// <summary>
        /// 배열 상태를 뒤집습니다.
        /// </summary>
        public void Reverse()
        {
            for (int widgetIndex = 0; widgetIndex < _array.Count / 2; ++widgetIndex)
            {
                _array.Swap(widgetIndex, ^(widgetIndex + 1));
            }
        }

        /// <summary>
        /// 배열된 위젯 목록을 가져옵니다.
        /// </summary>
        /// <returns> 위젯 목록을 가져옵니다. </returns>
        public IReadOnlyList<ArrangedWidget> GetWidgets()
        {
            return _array;
        }

        /// <summary>
        /// 위젯을 수용합니다.
        /// </summary>
        /// <param name="inVisibility"> 위젯의 가시 상태를 전달합니다. </param>
        /// <returns> 수용 가능 여부가 반환됩니다. </returns>
        public bool Accepts(SlateVisibility inVisibility)
        {
            return inVisibility.DoesVisibilityPassFilter(VisibilityFilter);
        }

        TArray<ArrangedWidget> _array = new();
    }
}
