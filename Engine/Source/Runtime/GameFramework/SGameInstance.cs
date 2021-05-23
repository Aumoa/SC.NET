// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using SC.Engine.Runtime.GameFramework.Controllers;
using SC.Engine.Runtime.GameFramework.Info;

namespace SC.Engine.Runtime.GameFramework
{
    /// <summary>
    /// 게임 인스턴스를 표현합니다.
    /// </summary>
    public class SGameInstance : SGameObject
    {
        SWorld _world;
        AGameModeBase _gameMode;
        APlayerController _localPlayerController;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public SGameInstance()
        {
            _world = new SWorld();
            _gameMode = Activator.CreateInstance(GameModeClass.Class) as AGameModeBase;
            _localPlayerController = _gameMode.CreatePlayerController();
        }

        /// <summary>
        /// 전체 게임 인스턴스의 프레임을 진행합니다.
        /// </summary>
        /// <param name="deltaTime"> 프레임 시간을 전달합니다. </param>
        public virtual void Tick(float deltaTime)
        {
        }

        /// <inheritdoc/>
        public override SWorld GetWorld()
        {
            return _world;
        }

        /// <summary>
        /// 현재 게임 모드 개체를 가져옵니다.
        /// </summary>
        /// <returns> 개체가 반환됩니다. </returns>
        public AGameModeBase GetCurrentGameMode()
        {
            return _gameMode;
        }

        /// <summary>
        /// 로컬 플레이어 컨트롤러 개체를 가져옵니다.
        /// </summary>
        /// <returns> 개체가 반환됩니다. </returns>
        public APlayerController GetLocalPlayerController()
        {
            return _localPlayerController;
        }

        /// <summary>
        /// 게임 모드 클래스를 지정합니다.
        /// </summary>
        public TSubclassOf<AGameModeBase> GameModeClass;
    }
}
