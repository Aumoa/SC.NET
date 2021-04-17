// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using SC.ThirdParty.Win32Runtime;

namespace SC.Engine.Runtime.Launch
{
    static class Launch
    {
        static GameApp _app;
        static CoreWindow _coreWindow;

        static void Main(string[] inArgs)
        {
            if (inArgs.Length == 0)
            {
                throw new ArgumentException();
            }

            _app = new GameApp(inArgs[0]);
            _coreWindow = new CoreWindow(_app, "GameApp");
            _app.Run(_coreWindow);
        }
    }
}
