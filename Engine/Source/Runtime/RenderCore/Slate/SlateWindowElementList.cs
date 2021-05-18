// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using SC.Engine.Runtime.Core.Container;
using SC.Engine.Runtime.RenderCore.Slate.Application;

namespace SC.Engine.Runtime.RenderCore.Slate
{
    /// <summary>
    /// 슬레이트 창 렌더링 대상 요소 목록입니다.
    /// </summary>
    [DebuggerDisplay("PaintWindow = {PaintWindow}, Count = {_drawElements.Count}")]
    [DebuggerTypeProxy(typeof(IReadOnlyCollectionDebugView<>))]
    public class SlateWindowElementList : IEnumerable<SlateDrawElement>
    {
        TArray<SlateDrawElement> _drawElements = new();

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="inPaintWindow"> 렌더링 대상 창 위젯을 전달합니다. </param>
        public SlateWindowElementList(SWindow inPaintWindow)
        {
            PaintWindow = inPaintWindow;
        }

        /// <summary>
        /// 렌더링 대상 창을 가져옵니다.
        /// </summary>
        public SWindow PaintWindow { get; init; }

        /// <summary>
        /// 새 요소를 추가합니다.
        /// </summary>
        /// <param name="element"> 요소를 전달합니다. </param>
        public void AddElement(SlateDrawElement element)
        {
            _drawElements.Add(element);
        }

        /// <summary>
        /// 요소 개수를 가져옵니다.
        /// </summary>
        /// <returns> 값이 반환됩니다. </returns>
        public int NumElements() => _drawElements.Count;

        /// <summary>
        /// 요소를 레이어 값을 이용하여 정렬합니다.
        /// </summary>
        public void SortByLayer()
        {
            _drawElements.Sort((lhs, rhs) => lhs.Layer - rhs.Layer);
        }

        /// <inheritdoc/>
        public virtual IEnumerator<SlateDrawElement> GetEnumerator() => _drawElements.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
