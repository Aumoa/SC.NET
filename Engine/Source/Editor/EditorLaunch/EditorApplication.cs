// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using SC.ThirdParty.WinAPI;

namespace SC.Engine.Editor.EditorLaunch
{
    class EditorApplication : Application
    {
        GameAssemblyLoader _assemblyLoader;
        SSlateEditorApplication _slateApplication;
        EditorEngine _engine;

        public EditorApplication(string assemblyPath)
        {
            _assemblyLoader = new GameAssemblyLoader(assemblyPath);
            _slateApplication = new SSlateEditorApplication();
            _engine = new EditorEngine();

            Initialize += EditorApplication_Initialize;
            Shutdown += EditorApplication_Shutdown;
            Idle += EditorApplication_Idle;
        }

        private void EditorApplication_Idle()
        {
            _engine.Tick();
        }

        private void EditorApplication_Shutdown()
        {
            _engine.Dispose();
        }

        private void EditorApplication_Initialize(CoreWindow target)
        {
            _engine.Init(target);
        }
    }
}
