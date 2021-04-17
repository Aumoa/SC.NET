// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.IO;
using System.Reflection;

using SC.Engine.Runtime.Core.FileSystem;

namespace SC.Engine.Runtime.Launch
{
    class GameLaunchLoader
    {
        FileReference _dllFile;
        Assembly _dllAssembly;

        public GameLaunchLoader(string dllPath)
        {
            _dllFile = new FileReference(dllPath);
            if (!_dllFile.IsExists)
            {
                throw new FileNotFoundException("DLL path is not valid.");
            }
        }

        public void LoadAssembly()
        {
            _dllAssembly = Assembly.LoadFrom(_dllFile.FullPath);
        }
    }
}
