// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.RenderCore.Slate.Layout;
using SC.Engine.Runtime.RenderCore.Slate.Widgets;

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
        protected override sealed void OnPaint(SlatePaintArgs paintArgs, Geometry allottedTransform)
        {
            paintArgs.ScreenSize = GetDesiredSize();
            _panel.Paint(paintArgs, allottedTransform);
        }

        /// <inheritdoc/>
        public override void Tick(Geometry allottedGeometry, double inCurrentTime, float inDeltaTime)
        {
            _panel.Tick(allottedGeometry, inCurrentTime, inDeltaTime);
            base.Tick(allottedGeometry, inCurrentTime, inDeltaTime);
        }

        /// <summary>
        /// 애플리케이션 패널 위젯을 생성하는 함수입니다.
        /// </summary>
        /// <returns> 개체를 반환합니다. </returns>
        protected abstract SPanelWidget CreateApplicationPanel();

        /// <summary>
        /// 내부 값을 이용해 틱 시물레이션을 진행합니다.
        /// </summary>
        /// <param name="inCurrentTime"> 전체 흐른 시간을 전달합니다. </param>
        /// <param name="inDeltaTime"> 이전 프레임에서 이동한 시간을 전달합니다. </param>
        public void Tick(double inCurrentTime, float inDeltaTime)
        {
            var sTransform = Geometry.MakeRoot(GetDesiredSize(), SlateLayoutTransform.Identity, SlateRenderTransform.Identity);
            Tick(sTransform, inCurrentTime, inDeltaTime);
        }

        /// <summary>
        /// 내부 값을 이용해 렌더링을 진행합니다.
        /// </summary>
        /// <param name="args"> 렌더링 매개변수를 전달합니다. </param>
        public void Paint(SlatePaintArgs args)
        {
            var sTransform = Geometry.MakeRoot(GetDesiredSize(), SlateLayoutTransform.Identity, SlateRenderTransform.Identity);
            Paint(args, sTransform);
        }
    }
}
