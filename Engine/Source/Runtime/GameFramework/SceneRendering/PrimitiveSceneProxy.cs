// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;
using SC.Engine.Runtime.GameFramework.Components;

namespace SC.Engine.Runtime.GameFramework.SceneRendering
{
    /// <summary>
    /// 씬에 제출되는 렌더링 데이터의 대체 컨테이너입니다.
    /// </summary>
    public class PrimitiveSceneProxy
    {
        /// <summary>
        /// 이 씬 프록시를 소유한 컴포넌트를 가져옵니다.
        /// </summary>
        public SPrimitiveComponent PrimitiveComponent { get; init; }

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="inPrimitiveComponent"> 소유자 컴포넌트를 전달합니다. </param>
        public PrimitiveSceneProxy(SPrimitiveComponent inPrimitiveComponent)
        {
            PrimitiveComponent = inPrimitiveComponent;
            Mobility = inPrimitiveComponent.Mobility;
        }

        /// <summary>
        /// 데이터를 갱신합니다.
        /// </summary>
        public virtual void Update()
        {
            PrimitiveTransform = PrimitiveComponent.ComponentTransform;
        }

        /// <summary>
        /// <see cref="Mobility"/> 값이 <see cref="ComponentMobility.Movable"/>일 때 갱신해야 할 데이터를 갱신합니다.
        /// </summary>
        public virtual void UpdateMovable()
        {
        }

        /// <summary>
        /// 컴포넌트의 월드 트랜스폼을 가져옵니다.
        /// </summary>
        public Transform PrimitiveTransform { get; private set; }

        /// <summary>
        /// 컴포넌트의 모빌리티를 가져옵니다.
        /// </summary>
        public ComponentMobility Mobility { get; init; }

        /// <summary>
        /// 프리미티브의 경계 박스를 가져옵니다.
        /// </summary>
        /// <returns> 경계 박스를 반환하거나, 사용하지 않을 경우 <see langword="null"/>을 반환합니다. </returns>
        public virtual AxisAlignedCube? GetPrimitiveBoundingBox() => null;
    }
}
