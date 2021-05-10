// Copyright 2020-2021 Aumoa.lib. All right reserved.

namespace SC.Engine.Runtime.RenderCore.Slate.Application
{
    /// <summary>
    /// UI로 구성되는 애플리케이션을 표현합니다.
    /// </summary>
    public abstract class SApplication : SLeafWidget
    {
        SPanelWidget _panel;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public SApplication(RHIDeviceBundle deviceBundle)
        {
            _panel = CreateApplicationPanel();
        }

        /// <inheritdoc/>
        protected override sealed void OnPaint(SlatePaintArgs paintArgs, SlateTransform allottedTransform)
        {
            paintArgs.ScreenSize = GetDesiredSize();
            _panel.Paint(paintArgs, allottedTransform);
        }

        /// <summary>
        /// 애플리케이션 패널 위젯을 생성하는 함수입니다.
        /// </summary>
        /// <returns> 개체를 반환합니다. </returns>
        protected abstract SPanelWidget CreateApplicationPanel();
    }
}
