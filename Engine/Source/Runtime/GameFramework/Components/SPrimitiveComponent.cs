// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.GameFramework.SceneRendering;

namespace SC.Engine.Runtime.GameFramework.Components
{
    /// <summary>
    /// 충돌 데이터, 렌더링 데이터 등을 소유하고 제출할 수 있는 기능을 제공하는 씬 컴포넌트의 일종입니다.
    /// </summary>
    public abstract class SPrimitiveComponent : SSceneComponent
    {
        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public SPrimitiveComponent()
        {
        }

        /// <summary>
        /// 상속 개체의 씬 프록시 개체를 생성합니다. 기본값은 <see langword="null"/>을 반환합니다.
        /// </summary>
        /// <returns> <see langword="null"/>이 반환됩니다. </returns>
        public virtual PrimitiveSceneProxy CreateSceneProxy() => null;
    }
}
