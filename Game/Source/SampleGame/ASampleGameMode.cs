// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SampleGame.Controller;
using SampleGame.Levels;

using SC.Engine.Runtime.GameFramework.Info;

namespace SampleGame.Properties
{
    public class ASampleGameMode : AGameModeBase
    {
        public ASampleGameMode()
        {
            StartLevelClass.Assign<SStartupLevel>();
            PlayerControllerClass.Assign<ASamplePlayerController>();
        }
    }
}
