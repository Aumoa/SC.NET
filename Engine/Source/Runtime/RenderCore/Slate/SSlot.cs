// Copyright 2020-2021 Aumoa.lib. All right reserved.

namespace SC.Engine.Runtime.RenderCore.Slate
{
    /// <summary>
    /// 패널 슬레이트의 슬롯을 표현합니다.
    /// </summary>
    public abstract class SSlot
    {
        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public SSlot()
        {
        }

        internal SPanelWidget SourcePanel;
        
        /// <summary>
        /// 슬롯이 소유한 컨텐츠 위젯을 가져옵니다.
        /// </summary>
        public SWidget Content
        {
            get => _content;
            internal set
            {
                _content = value;
                ConstructSlot(_content);
            }
        }

        SWidget _content;

        /// <summary>
        /// 슬롯을 빌드합니다.
        /// </summary>
        /// <param name="content"> 슬롯 컨텐츠가 전달됩니다. </param>
        protected abstract void ConstructSlot(SWidget content);
    }
}
