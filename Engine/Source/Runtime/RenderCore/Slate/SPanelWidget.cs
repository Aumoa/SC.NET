// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

namespace SC.Engine.Runtime.RenderCore.Slate
{
    /// <summary>
    /// 패널 위젯을 표현합니다.
    /// </summary>
    public abstract class SPanelWidget : SWidget
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

        /// <summary>
        /// 새 슬롯을 추가합니다.
        /// </summary>
        /// <returns> 생성된 슬롯이 반환됩니다. </returns>
        public SSlot AddSlot()
        {
            SSlot slot = OnAddSlot();
            return slot;
        }

        /// <summary>
        /// 슬롯을 제거합니다.
        /// </summary>
        /// <param name="index"> 제거할 슬롯의 인덱스를 전달합니다. </param>
        public void RemoveSlot(int index) => OnRemoveSlot(new Index(index));

        /// <summary>
        /// 슬롯을 제거합니다.
        /// </summary>
        /// <param name="index"> 제거할 슬롯의 인덱스를 전달합니다. </param>
        public void RemoveSlot(Index index) => OnRemoveSlot(index);

        /// <summary>
        /// 새 슬롯을 추가합니다.
        /// </summary>
        /// <typeparam name="T"> 슬롯 형식을 전달합니다. </typeparam>
        /// <returns> 생성된 슬롯이 반환됩니다. </returns>
        public T AddSlot<T>() where T : SSlot => AddSlot() as T;

        /// <summary>
        /// 슬롯이 추가될 때 호출되는 함수의 구현입니다.
        /// </summary>
        /// <returns> 지정한 클래스 형식의 슬롯을 생성하여 반환합니다. </returns>
        protected abstract SSlot OnAddSlot();

        /// <summary>
        /// 슬롯이 제거될 때 호출되는 함수의 구현입니다.
        /// </summary>
        /// <param name="index"> 제거할 슬롯의 인덱스가 전달됩니다. </param>
        protected abstract void OnRemoveSlot(Index index);

        /// <inheritdoc/>
        protected override void OnPaint(SlatePaintArgs paintArgs, Geometry allottedGeometry)
        {
            ArrangedChildren arranged = new();
            ArrangeChildren(arranged, allottedGeometry);
            PaintArrangedChildren(paintArgs, allottedGeometry, arranged);
        }

        /// <summary>
        /// 레이아웃 위젯을 재배치합니다.
        /// </summary>
        /// <param name="arrangedChildren"> 재배치 위젯 목록 개체를 전달합니다. </param>
        /// <param name="allottedGeometry"> 이 위젯에 할당된 트랜스폼이 전달됩니다. </param>
        public abstract void ArrangeChildren(ArrangedChildren arrangedChildren, Geometry allottedGeometry);

        void PaintArrangedChildren(SlatePaintArgs paintArgs, Geometry allottedGeometry, ArrangedChildren arranged)
        {
            foreach (ArrangedWidget widget in arranged.GetWidgets())
            {
                widget.Widget.Paint(paintArgs, allottedGeometry);
            }
        }
    }
}
