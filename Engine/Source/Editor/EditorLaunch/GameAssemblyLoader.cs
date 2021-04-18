// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System.IO;
using System.Reflection;

namespace SC.Engine.Editor.EditorLaunch
{
    class GameAssemblyLoader
    {
        Assembly _assembly;

        public GameAssemblyLoader(string assemblyPath)
        {
            AssemblyPath = assemblyPath;
        }

        public void LoadAssembly()
        {
            if (AssemblyPath is null)
            {
                throw new FileNotFoundException();
            }

            _assembly = Assembly.LoadFrom(AssemblyPath);
        }

        public string AssemblyPath { get; }
        public Assembly Assembly => _assembly;
    }
}
