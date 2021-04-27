// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.RenderCore;
using SC.Engine.Runtime.Slate;

namespace SC.Engine.Runtime.SlateCore
{
    /// <summary>
    /// 슬레이트 렌더링 매개변수를 표현합니다.
    /// </summary>
    public struct SlatePaintArgs
    {
        /// <summary>
        /// 슬레이트 애플리케이션이 시작된 후 흐른 시간을 나타냅니다.
        /// </summary>
        public double CurrentTime;

        /// <summary>
        /// 이전 프레임에서 경과한 시간을 나타냅니다.
        /// </summary>
        public float DeltaTime;

        /// <summary>
        /// 부모 슬레이트를 나타냅니다.
        /// </summary>
        public SWidget SlateParent;
    }
}
