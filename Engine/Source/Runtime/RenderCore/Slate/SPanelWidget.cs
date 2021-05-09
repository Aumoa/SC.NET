// Copyright 2020-2021 Aumoa.lib. All right reserved.

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
            slot.SourcePanel = this;
            return slot;
        }

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
    }
}
