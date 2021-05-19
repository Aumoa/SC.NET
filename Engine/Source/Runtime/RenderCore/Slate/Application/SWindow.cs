// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;
using SC.Engine.Runtime.RenderCore.Slate.Layout;
using SC.Engine.Runtime.RenderCore.Slate.Widgets;

namespace SC.Engine.Runtime.RenderCore.Slate.Application
{
    /// <summary>
    /// UI로 구성되는 애플리케이션을 표현합니다.
    /// </summary>
    public abstract class SWindow : SCompoundWidget
    {
        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public SWindow()
        {
        }

        double _lastCurrentTime;
        float _lastDeltaTime;

        /// <summary>
        /// 루트 트랜스폼을 생성합니다.
        /// </summary>
        /// <returns> 값이 반환됩니다. </returns>
        protected Geometry MakeRootGeometry() => Geometry.MakeRoot(GetDesiredSize(), SlateLayoutTransform.Identity, SlateRenderTransform.Identity);

        /// <summary>
        /// 내부 값을 이용해 틱 시물레이션을 진행합니다.
        /// </summary>
        /// <param name="inCurrentTime"> 전체 흐른 시간을 전달합니다. </param>
        /// <param name="inDeltaTime"> 이전 프레임에서 이동한 시간을 전달합니다. </param>
        public void Tick(double inCurrentTime, float inDeltaTime) =>
            Tick(
                MakeRootGeometry(),
                _lastCurrentTime = inCurrentTime,
                _lastDeltaTime = inDeltaTime
                );

        /// <summary>
        /// 내부 값을 이용해 렌더링을 진행합니다.
        /// </summary>
        /// <param name="drawElements"> 렌더링 요소 목록 개체를 전달합니다. </param>
        public void Paint(SlateWindowElementList drawElements) =>
            Paint(
                new SlatePaintArgs { CurrentTime = _lastCurrentTime, DeltaTime = _lastDeltaTime, Parent = this },
                MakeRootGeometry(),
                new Rectangle(Vector2.Zero, GetDesiredSize()),
                drawElements,
                0,
                IsEnabled
                );
    }
}
