// Copyright 2020-2021 Aumoa.lib. All right reserved.

namespace SC.Engine.Runtime.GameCore
{
    /// <summary>
    /// 틱 함수를 제공하는 오브젝트에 대한 공통 함수를 제공합니다.
    /// </summary>
    public interface ITickFunctionObject
    {
        /// <summary>
        /// 틱 함수를 가져옵니다.
        /// </summary>
        /// <returns> 개체가 반환됩니다. </returns>
        TickFunction GetTickFunction();

        /// <summary>
        /// 의존 관계를 추가합니다.
        /// </summary>
        /// <param name="obj"> 틱 가능 오브젝트를 전달합니다. </param>
        void AddPrerequisiteObject(ITickFunctionObject obj);

        /// <summary>
        /// 의존 관계를 제거합니다.
        /// </summary>
        /// <param name="obj"> 틱 가능 오브젝트를 전달합니다. </param>
        void RemovePrerequisiteObject(ITickFunctionObject obj);

        /// <summary>
        /// 틱이 활성화되어 있는지 나타내는 값을 설정하거나 가져옵니다.
        /// </summary>
        bool TickEnabled { get; }
    }
}
