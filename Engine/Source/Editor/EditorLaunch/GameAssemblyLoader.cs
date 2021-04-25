// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.IO;
using System.Reflection;

using SC.Engine.Runtime.GameFramework;

namespace SC.Engine.Editor.EditorLaunch
{
    class GameAssemblyLoader
    {
        Assembly _assembly;
        Type _gameInstanceType;

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

            // Find game instance type.
            Type[] types = _assembly.GetTypes();
            for (int i = 0; i < types.Length; ++i)
            {
                if (types[i].IsSubclassOf(typeof(SGameInstance)))
                {
                    _gameInstanceType = types[i];
                    break;
                }
            }
        }

        public SGameInstance AllocGameInstance()
        {
            if (_gameInstanceType is null)
            {
                return new SGameInstance();
            }
            else
            {
                return Activator.CreateInstance(_gameInstanceType) as SGameInstance;
            }
        }

        public string AssemblyPath { get; }
        public Assembly Assembly => _assembly;
    }
}
