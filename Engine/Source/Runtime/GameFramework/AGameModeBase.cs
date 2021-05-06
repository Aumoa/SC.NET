// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.GameCore;

using static SC.Engine.Runtime.GameCore.Diagnostics.LoggingSystem;
using static SC.Engine.Runtime.GameCore.Diagnostics.LogVerbosity;

namespace SC.Engine.Runtime.GameFramework
{
    /// <summary>
    /// 게임 모드 정보를 표시합니다.
    /// </summary>
    public class AGameModeBase : AInfo
    {
        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public AGameModeBase()
        {
            PlayerControllerClass = TSubclassOf<APlayerController>.Get();
            StartLevelClass = TSubclassOf<SLevel>.Get();
        }

        /// <summary>
        /// 게임 모드에서 사용할 기본 플레이어 컨트롤러 클래스를 지정합니다.
        /// </summary>
        public TSubclassOf<APlayerController> PlayerControllerClass;

        /// <summary>
        /// 시작 레벨 클래스를 지정합니다.
        /// </summary>
        public TSubclassOf<SLevel> StartLevelClass;

        /// <summary>
        /// 플레이어 컨트롤러 개체를 생성합니다.
        /// </summary>
        /// <returns> 개체가 반환됩니다. </returns>
        internal APlayerController CreatePlayerController()
        {
            if (PlayerControllerClass.Class is null)
            {
                Log(Fatal, "GameMode", "플레이어 컨트롤러 클래스가 지정되지 않았습니다.");
            }

            return PlayerControllerClass.Instantiate();
        }
    }
}
