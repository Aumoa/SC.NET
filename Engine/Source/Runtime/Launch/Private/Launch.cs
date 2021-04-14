// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.IO;
using System.Reflection;

using SC.Engine.Runtime.Core.FileSystem;
using SC.ThirdParty.Win32Runtime;

namespace SC.Engine.Runtime.Launch
{
    static class Launch
    {
        static void Main(string[] inArgs)
        {
            LoadDLL(inArgs?[0]);

            var application = new Application();
            var coreWindow = new CoreWindow(application, "CoreWindow");
            coreWindow.IsVisible = true;
        }

        static void LoadDLL(string firstArgument)
        {
            if (firstArgument is null)
            {
                throw new ArgumentException("게임을 실행하기 위한 매개변수가 부족합니다. 게임 DLL 파일의 위치를 지정하세요.");
            }

            // 레퍼런스 파일의 전체 경로를 계산합니다.
            FileReference assemblyFile = new(firstArgument);
            if (!assemblyFile.IsExists)
            {
                throw new FileNotFoundException($"게임 DLL 파일을 {assemblyFile} 위치에서 찾지 못했습니다.");
            }

            // DLL을 로드합니다.
            var gameAssembly = Assembly.LoadFrom(assemblyFile.FullPath);
            if (gameAssembly is null)
            {
                throw new BadImageFormatException("게임 DLL파일이 올바르지 않습니다.");
            }
        }
    }
}
