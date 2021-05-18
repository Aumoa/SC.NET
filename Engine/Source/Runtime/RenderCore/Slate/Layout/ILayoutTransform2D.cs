// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;

namespace SC.Engine.Runtime.RenderCore.Slate.Layout
{
    /// <summary>
    /// 변형 가능한 레이아웃 형식에 대한 공통 함수를 제공합니다.
    /// </summary>
    public interface ILayoutTransform2D
    {
        /// <summary>
        /// 위치를 변형합니다.
        /// </summary>
        /// <param name="point"> 위치를 전달합니다. </param>
        /// <returns> 변형된 위치가 반환됩니다. </returns>
        T TransformPoint<T>(T point) where T : IVectorType, new();

        /// <summary>
        /// 벡터를 변형합니다.
        /// </summary>
        /// <param name="vector"> 위치를 전달합니다. </param>
        /// <returns> 변형된 위치가 반환됩니다. </returns>
        T TransformVector<T>(T vector) where T : IVectorType, new();
    }
}
