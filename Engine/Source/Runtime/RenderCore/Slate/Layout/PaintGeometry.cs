// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;

namespace SC.Engine.Runtime.RenderCore.Slate.Layout
{
    /// <summary>
    /// 렌더링 전용 트랜스폼을 표현합니다.
    /// </summary>
    public struct PaintGeometry
    {
        /// <summary>
        /// 로컬 공간 크기를 표현합니다.
        /// </summary>
        public Vector2 LocalSize;

        /// <summary>
        /// 렌더링 트랜스폼을 표현합니다.
        /// </summary>
        public SlateRenderTransform AccumulatedRenderTransform;

        /// <summary>
        /// 렌더 트랜스폼의 활성화 상태를 표현합니다.
        /// </summary>
        public bool bHasRenderTransform;

        /// <summary>
        /// 단위 렌더링 트랜스폼을 가져옵니다.
        /// </summary>
        public static readonly PaintGeometry Identity = new PaintGeometry
        {
            LocalSize = Vector2.Zero,
            AccumulatedRenderTransform = SlateRenderTransform.Identity,
            bHasRenderTransform = false
        };

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="inAccumulatedLayoutTransform"> 누적된 레이아웃 트랜스폼을 전달합니다. </param>
        /// <param name="inAccumulatedRenderTransform"> 누적된 렌더 트랜스폼을 전달합니다. </param>
        /// <param name="inLocalSize"> 로컬 공간 크기를 전달합니다. </param>
        /// <param name="inHasRenderTransform"> 렌더 트랜스폼의 활성화 여부를 전달합니다. </param>
        public PaintGeometry(SlateLayoutTransform inAccumulatedLayoutTransform, SlateRenderTransform inAccumulatedRenderTransform, Vector2 inLocalSize, bool inHasRenderTransform)
        {
            LocalSize = inLocalSize;
            AccumulatedRenderTransform = inAccumulatedRenderTransform;
            bHasRenderTransform = inHasRenderTransform;
        }

        /// <summary>
        /// 트랜스폼을 누적해서 더합니다.
        /// </summary>
        /// <param name="layoutTransform"> 누적할 레이아웃 트랜스폼을 전달합니다. </param>
        public void AppendTransform(SlateLayoutTransform layoutTransform)
        {
            AccumulatedRenderTransform = AccumulatedRenderTransform.Concatenate(layoutTransform);
        }

        /// <summary>
        /// 렌더 트랜스폼을 설정합니다.
        /// </summary>
        /// <param name="renderTransform"> 트랜스폼을 전달합니다. </param>
        public void SetRenderTransform(SlateRenderTransform renderTransform)
        {
            AccumulatedRenderTransform = renderTransform;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"DrawPosition: {AccumulatedRenderTransform.Translation}, DrawSize: {LocalSize}";
        }
    }
}
