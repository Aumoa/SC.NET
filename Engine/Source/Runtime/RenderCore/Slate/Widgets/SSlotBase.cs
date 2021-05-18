// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.RenderCore.Slate.Widgets;

namespace SC.Engine.Runtime.RenderCore.Slate
{
    /// <summary>
    /// 패널 슬레이트의 슬롯을 표현합니다.
    /// </summary>
    public abstract class SSlotBase
    {
        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="sourcePanel"> 슬롯의 소유자를 전달합니다. </param>
        public SSlotBase(SPanelWidget sourcePanel)
        {
            SourcePanel = sourcePanel;
        }

        /// <summary>
        /// 슬롯을 소유한 패널 위젯을 가져옵니다.
        /// </summary>
        public SPanelWidget SourcePanel
        {
            get;
            private set;
        }
        
        /// <summary>
        /// 슬롯이 소유한 컨텐츠 위젯을 가져옵니다.
        /// </summary>
        public virtual SWidget Content
        {
            get => _content;
            set
            {
                _content = value;
            }
        }

        SWidget _content;

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{GetType().Name}: {Content}";
        }
    }
}
