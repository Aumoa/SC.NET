// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using SC.Engine.Runtime.GameFramework.Components;
using SC.Engine.Runtime.GameFramework.Controllers;

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

        public void RegisterComponent(SActorComponent inComponent)
        {
            throw new NotImplementedException();
        }

        public APlayerController GetLocalPlayer()
        {
            throw new NotImplementedException();
        }
    }
}
