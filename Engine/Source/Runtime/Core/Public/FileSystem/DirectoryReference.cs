// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System.IO;

namespace SC.Engine.Runtime.Core.FileSystem
{
    /// <summary>
    /// 파일 시스템에서 특정 경로에 해당하는 디렉토리를 참조하기 위한 기능을 제공합니다.
    /// </summary>
    public class DirectoryReference : FileSystemReference
    {
        /// <summary>
        /// 상대적 경로 또는 전체 경로를 지정하여 인식 가능한 경로를 생성합니다.
        /// </summary>
        /// <param name="path"> 경로를 전달합니다. </param>
        public DirectoryReference(string path) : base(path)
        {

        }

        /// <summary>
        /// 이 레퍼런스에 해당하는 디렉토리가 존재하지 않는다면 새로 생성합니다.
        /// </summary>
        public void CreateIfNotExists()
        {
            if (!IsExists)
            {
                Directory.CreateDirectory(FullPath);
            }
        }

        /// <summary>
        /// 디렉토리를 제거합니다.
        /// </summary>
        /// <param name="bRecursive"> 재귀적으로 모든 하위 디렉토리를 제거합니다. </param>
        public void Remove(bool bRecursive = false)
        {
            Directory.Delete(FullPath, bRecursive);
        }

        /// <summary>
        /// 이 레퍼런스에 해당하는 디렉토리에서 특정 디렉토리로 이동합니다.
        /// </summary>
        /// <param name="relativePath"> 이동하기 위한 상대 경로를 전달합니다. </param>
        /// <returns> 이동된 디렉토리 레퍼런스가 반환됩니다. </returns>
        public DirectoryReference Move(string relativePath)
        {
            return new(Path.Combine(FullPath, relativePath));
        }

        /// <summary>
        /// 현재 디렉토리 및 하위 디렉토리에 있는 파일 레퍼런스를 가져옵니다.
        /// </summary>
        /// <param name="bRecursive"> 재귀적으로 모든 하위 디렉토리를 탐색합니다. </param>
        /// <returns> 파일 레퍼런스 목록을 가져옵니다. </returns>
        public FileReference[] GetAllFiles(bool bRecursive)
        {
            return ConvertFilePaths(Directory.GetFiles(FullPath, "*.*", bRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly));
        }

        /// <summary>
        /// 현재 디렉토리에 있는 하위 디렉토리 레퍼런스를 가져옵니다.
        /// </summary>
        /// <returns> 디렉토리 레퍼런스 목록을 가져옵니다. </returns>
        public DirectoryReference[] GetCurrentDirectories()
        {
            return ConvertDirectoryPaths(Directory.GetDirectories(FullPath, "*", SearchOption.TopDirectoryOnly));
        }

        /// <summary>
        /// 해당 레퍼런스에 해당하는 디렉토리이 존재하는지 검사합니다.
        /// </summary>
        public override bool IsExists => Directory.Exists(FullPath);

        /// <summary>
        /// 파일 경로를 파일 레퍼런스 형식으로 변환합니다.
        /// </summary>
        /// <param name="inPaths"> 경로 목록을 전달합니다. </param>
        /// <returns> 레퍼런스 목록을 반환합니다. </returns>
        private FileReference[] ConvertFilePaths(string[] inPaths)
        {
            if (inPaths is null || inPaths.Length == 0)
            {
                return new FileReference[0];
            }
            var references = new FileReference[inPaths.Length];
            for (int i = 0; i < inPaths.Length; ++i)
            {
                references[i] = new(inPaths[i]);
            }

            return references;
        }

        /// <summary>
        /// 디렉토리 경로를 디렉토리 레퍼런스 형식으로 변환합니다.
        /// </summary>
        /// <param name="inPaths"> 경로 목록을 전달합니다. </param>
        /// <returns> 레퍼런스 목록을 반환합니다. </returns>
        private DirectoryReference[] ConvertDirectoryPaths(string[] inPaths)
        {
            if (inPaths is null || inPaths.Length == 0)
            {
                return new DirectoryReference[0];
            }
            var references = new DirectoryReference[inPaths.Length];
            for (int i = 0; i < inPaths.Length; ++i)
            {
                references[i] = new(inPaths[i]);
            }

            return references;
        }
    }
}