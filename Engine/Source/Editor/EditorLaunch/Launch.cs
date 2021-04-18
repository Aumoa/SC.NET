// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using SC.ThirdParty.WinAPI;

namespace SC.Engine.Editor.EditorLaunch
{
    static class Launch
    {
        static EditorApplication _app;
        static CoreWindow _coreWindow;

        static void Main(string[] inArgs)
        {
            if (inArgs.Length == 0)
            {
                throw new ArgumentException();
            }

            _app = new EditorApplication(inArgs[0]);
            _coreWindow = new CoreWindow(_app, "SE Editor");
            _app.Run(_coreWindow);
        }
    }
}
