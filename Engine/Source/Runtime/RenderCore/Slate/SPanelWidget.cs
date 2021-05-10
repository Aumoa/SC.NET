// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System.Collections.Generic;
using System.Linq;

using SC.Engine.Runtime.Core.Container;

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
        }

        /// <summary>
        /// 새 슬롯을 추가합니다.
        /// </summary>
        /// <returns> 생성된 슬롯이 반환됩니다. </returns>
        public SSlot AddSlot()
        {
            SSlot slot = OnAddSlot();
            _slots.Add(slot);
            return slot;
        }

        /// <summary>
        /// 새 슬롯을 추가합니다.
        /// </summary>
        /// <typeparam name="T"> 슬롯 형식을 전달합니다. </typeparam>
        /// <returns> 생성된 슬롯이 반환됩니다. </returns>
        public T AddSlot<T>() where T : SSlot => AddSlot() as T;

        /// <summary>
        /// 슬롯 목록을 가져옵니다.
        /// </summary>
        /// <returns> 열거 가능 개체가 반환됩니다. </returns>
        public IEnumerable<SSlot> GetSlots()
        {
            return _slots;
        }

        /// <summary>
        /// 슬롯 목록을 가져옵니다.
        /// </summary>
        /// <typeparam name="T"> 슬롯 형식을 전달합니다. </typeparam>
        /// <returns> 열거 가능 개체가 반환됩니다. </returns>
        public IEnumerable<T> GetSlots<T>() where T : SSlot
        {
            return from item in _slots select item as T;
        }

        /// <summary>
        /// 슬롯이 추가될 때 호출되는 함수의 구현입니다.
        /// </summary>
        /// <returns> 지정한 클래스 형식의 슬롯을 생성하여 반환합니다. </returns>
        protected abstract SSlot OnAddSlot();

        /// <inheritdoc/>
        protected override void OnPaint(SlatePaintArgs paintArgs, SlateTransform allottedTransform)
        {
            ArrangedChildren arranged = new();
            ArrangeChildren(arranged);

            foreach (ArrangedChildren.ArrangedWidget widget in arranged.GetWidgets())
            {
                widget.Widget.Paint(paintArgs, allottedTransform);
            }
        }

        /// <summary>
        /// 레이아웃 위젯을 재배치합니다.
        /// </summary>
        /// <param name="arrangedChildren"> 재배치 위젯 목록 개체를 전달합니다. </param>
        protected abstract void ArrangeChildren(ArrangedChildren arrangedChildren);

        TArray<SSlot> _slots = new();
    }
}
