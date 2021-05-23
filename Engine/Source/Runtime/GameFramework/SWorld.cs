// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using SC.Engine.Runtime.GameFramework.Components;

namespace SC.Engine.Runtime.GameFramework
{
    /// <summary>
    /// 게임 세계를 표현합니다.
    /// </summary>
    public class SWorld : SGameObject
    {
        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public SWorld()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inComponent"></param>
        public void RegisterComponent(SActorComponent inComponent)
        {
            throw new NotImplementedException();
        }
    }
}
