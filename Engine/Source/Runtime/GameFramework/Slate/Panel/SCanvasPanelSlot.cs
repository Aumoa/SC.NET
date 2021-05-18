// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;
using SC.Engine.Runtime.RenderCore.Slate;
using SC.Engine.Runtime.RenderCore.Slate.Layout;
using SC.Engine.Runtime.RenderCore.Slate.Widgets;

namespace SC.Engine.Runtime.GameFramework.Slate.Panel
{
    /// <summary>
    /// <see cref="SCanvasPanel"/>의 슬롯을 표현합니다.
    /// </summary>
    public class SCanvasPanelSlot : SSlot
    {
        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="sourcePanel"> 슬롯의 소유자를 전달합니다. </param>
        public SCanvasPanelSlot(SCanvasPanel sourcePanel) : base(sourcePanel)
        {
        }

        /// <inheritdoc/>
        protected override void ConstructSlot(SWidget content)
        {
        }

        /// <summary>
        /// 슬롯의 오프셋을 설정하거나 가져옵니다.
        /// </summary>
        public Margin Offset { get; set; } = new Margin(0, 0, 100, 100);

        /// <summary>
        /// 슬롯의 고정점 영역을 설정하거나 가져옵니다.
        /// </summary>
        public Anchors Anchors { get; set; }

        /// <summary>
        /// 정렬 계수를 설정하거나 가져옵니다.
        /// </summary>
        public Vector2 Alignment { get; set; }

        /// <summary>
        /// Z 순서를 설정하거나 가져옵니다.
        /// </summary>
        public float ZOrder { get; set; }

        /// <summary>
        /// 슬롯의 크기를 컨텐츠의 크기에 맞게 자동으로 결정합니다.
        /// </summary>
        public bool AutoSize { get; set; }

        /// <summary>
        /// 특성을 초기화합니다.
        /// </summary>
        /// <param name="Offset"> 슬롯의 오프셋을 전달합니다. </param>
        /// <param name="Anchors"> 슬롯의 고정점 영역을 전달합니다. </param>
        /// <param name="Alignment"> 정렬 계수를 전달합니다. </param>
        /// <param name="ZOrder"> Z 순서를 전달합니다. </param>
        /// <param name="AutoSize"> 자동 크기 조절 설정 여부를 전달합니다. </param>
        /// <returns> 작업 체인이 반환됩니다. </returns>
        public SCanvasPanelSlot Init(Margin? Offset = null, Anchors? Anchors = null, Vector2? Alignment = null, float? ZOrder = null, bool? AutoSize = null)
        {
            this.Offset = Offset ?? new Margin(0, 0, 100, 100);
            this.Anchors = Anchors ?? default;
            this.Alignment = Alignment ?? default;
            this.ZOrder = ZOrder ?? default;
            this.AutoSize = AutoSize ?? default;
            return this;
        }

        /// <summary>
        /// 슬롯의 컨텐츠를 설정합니다.
        /// </summary>
        /// <param name="content"> 컨텐츠를 전달합니다. </param>
        /// <returns> 작업 체인이 반환됩니다. </returns>
        public SCanvasPanelSlot this[SWidget content]
        {
            get
            {
                Content = content;
                return this;
            }
        }
    }
}
