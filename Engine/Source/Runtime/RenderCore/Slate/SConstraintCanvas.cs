// Copyright 2020-2021 Aumoa.lib. All right reserved.

namespace SC.Engine.Runtime.RenderCore.Slate
{
    /// <summary>
    /// 강제 위치를 지정하는 캔버스를 표현합니다.
    /// </summary>
    public class SConstraintCanvas : SPanelWidget
    {
        /// <inheritdoc/>
        protected override SSlot OnAddSlot() => new SCanvasPanelSlot();

        /// <inheritdoc/>
        protected override void OnPaint(SlatePaintArgs paintArgs, SlateTransform allottedTransform)
        {
        }
    }
}
