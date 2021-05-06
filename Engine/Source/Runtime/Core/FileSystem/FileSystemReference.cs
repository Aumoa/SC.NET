// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System.IO;

namespace SC.Engine.Runtime.Core.FileSystem
{
    /// <summary>
    /// 파일 시스템에서 특정 경로를 참조하기 위한 기능을 제공합니다.
    /// </summary>
    public abstract class FileSystemReference
    {
        /// <summary>
        /// 상대적 경로 또는 전체 경로를 지정하여 인식 가능한 경로를 생성합니다.
        /// </summary>
        /// <param name="inPath"> 경로를 전달합니다. </param>
        public FileSystemReference(string inPath)
        {
            FullPath = Path.GetFullPath(inPath);
            Name = Path.GetFileName(inPath);
        }

        /// <summary>
        /// 대상 레퍼런스와의 상대적 경로를 계산합니다.
        /// </summary>
        /// <param name="inReference"> 대상 레퍼런스를 전달합니다. </param>
        /// <returns> 상대 경로가 반환됩니다. </returns>
        public string GetRelativePath(FileSystemReference inReference)
        {
            return Path.GetRelativePath(FullPath, inReference.FullPath);
        }

        /// <summary>
        /// 상위 디렉토리를 가져옵니다.
        /// </summary>
        /// <returns> 디렉토리 레퍼런스가 반환됩니다. </returns>
        public DirectoryReference GetParent()
        {
            return new(Directory.GetParent(FullPath).FullName);
        }

        /// <summary>
        /// 전체 경로를 가져옵니다.
        /// </summary>
        public string FullPath { get; }

        /// <summary>
        /// 레퍼런스의 이름을 가져옵니다.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 이 경로에 해당하는 레퍼런스가 존재하는지 나타내는 값을 가져옵니다.
        /// </summary>
        public abstract bool IsExists { get; }

        /// <summary>
        /// 전체 경로를 가져옵니다.
        /// </summary>
        /// <returns> 문자열 개체가 반환됩니다. </returns>
        public override string ToString()
        {
            return FullPath;
        }
    }
}