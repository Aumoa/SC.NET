// Copyright 2020-2021 Aumoa.lib. All right reserved.

namespace SC.Engine.Runtime.GameFramework.Ticking
{
    /// <summary>
    /// 틱 그룹을 표현합니다.
    /// </summary>
    public enum TickingGroup
    {
        /// <summary>
        /// 물리 연산 전 실행되는 그룹입니다.
        /// </summary>
        PrePhysics = 0,

        /// <summary>
        /// 물리 연산이 진행중일 때 함께 실행되는 그룹입니다.
        /// </summary>
        DuringPhysics = 1,

        /// <summary>
        /// 물리 연산 이후 실행되는 그룹입니다.
        /// </summary>
        PostPhysics = 2,

        /// <summary>
        /// 모든 업데이트 이후 실행되는 그룹입니다.
        /// </summary>
        PostUpdateWork = 3,
    }
}
