// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.RenderCore.Slate;

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
    }
}
