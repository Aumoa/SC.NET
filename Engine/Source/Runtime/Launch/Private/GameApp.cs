// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.ThirdParty.Win32Runtime;

namespace SC.Engine.Runtime.Launch
{
    class GameApp : Application
    {
        GameLaunchLoader _gameLoader;

        public GameApp(string gameAssemblyPath)
        {
            _gameLoader = new GameLaunchLoader(gameAssemblyPath);
        }
    }
}
