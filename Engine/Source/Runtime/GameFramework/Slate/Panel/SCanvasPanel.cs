// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.RenderCore.Slate;

namespace SC.Engine.Runtime.GameFramework.Slate.Panel
{
    /// <summary>
    /// 위치를 지정하여 위젯 목록을 렌더링하는 패널을 표현합니다.
    /// </summary>
    public class SCanvasPanel : SPanelWidget
    {
        /// <inheritdoc/>
        protected override SSlot OnAddSlot()
        {
            return new SCanvasPanelSlot(this);
        }

        /// <inheritdoc/>
        protected override void ArrangeChildren(ArrangedChildren arrangedChildren)
        {
            foreach (SCanvasPanelSlot slot in GetSlots<SCanvasPanelSlot>())
            {
                // Ignore empty slots.
                SWidget content = slot.Content;
                if (content is null)
                {
                    continue;
                }

                arrangedChildren.AddWidget(content);
            }
        }
    }
}
