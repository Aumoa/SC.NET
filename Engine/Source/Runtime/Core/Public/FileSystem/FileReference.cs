// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System.IO;
using System.Text;

namespace SC.Engine.Runtime.Core.FileSystem
{
    /// <summary>
    /// 파일 시스템에서 특정 경로에 해당하는 파일을 참조하기 위한 기능을 제공합니다.
    /// </summary>
    public class FileReference : FileSystemReference
    {
        /// <summary>
        /// 상대적 경로 또는 전체 경로를 지정하여 인식 가능한 경로를 생성합니다.
        /// </summary>
        /// <param name="inPath"> 경로를 전달합니다. </param>
        public FileReference(string inPath) : base(inPath)
        {
            NameWithoutExtension = Path.GetFileNameWithoutExtension(inPath);
            Extension = Path.GetExtension(inPath);
        }

        /// <summary>
        /// 새 임시 파일 레퍼런스를 생성합니다.
        /// </summary>
        /// <returns> 임시 파일의 레퍼런스가 반환됩니다. </returns>
        public static FileReference NewTemp()
        {
            return new FileReference(Path.GetTempFileName());
        }

        /// <summary>
        /// 파일 스트림을 생성합니다.
        /// </summary>
        /// <param name="inMode"> 파일 스트림 생성 모드를 전달합니다. </param>
        /// <returns> 생성된 파일 스트림이 반환됩니다. </returns>
        public FileStream OpenStream(FileMode inMode)
        {
            return new FileStream(FullPath, inMode);
        }

        /// <summary>
        /// 파일에서 모든 텍스트를 읽습니다.
        /// </summary>
        /// <returns> 읽은 텍스트 문자열 개체가 반환됩니다. </returns>
        public string ReadAllText()
        {
            return ReadAllText(Encoding.Default);
        }

        /// <summary>
        /// 파일에서 모든 텍스트를 읽습니다.
        /// </summary>
        /// <param name="inEncoding"> 인코딩 정보를 전달합니다. </param>
        /// <returns> 읽은 텍스트 문자열 개체가 반환됩니다. </returns>
        public string ReadAllText(Encoding inEncoding)
        {
            return File.ReadAllText(FullPath, inEncoding);
        }

        /// <summary>
        /// 파일에 모든 텍스트를 씁니다.
        /// </summary>
        /// <param name="inText"> 텍스트 내용을 전달합니다. </param>
        public void WriteAllText(string inText)
        {
            File.WriteAllText(FullPath, inText, Encoding.Default);
        }

        /// <summary>
        /// 파일에 모든 텍스트를 씁니다.
        /// </summary>
        /// <param name="inText"> 텍스트 내용을 전달합니다. </param>
        /// <param name="inEncoding"> 인코딩 정보를 전달합니다. </param>
        public void WriteAllText(string inText, Encoding inEncoding)
        {
            File.WriteAllText(FullPath, inText, inEncoding);
        }

        /// <summary>
        /// 파일을 제거합니다.
        /// </summary>
        public void Remove()
        {
            File.Delete(FullPath);
        }

        /// <summary>
        /// 해당 레퍼런스에 해당하는 파일이 존재하는지 검사합니다.
        /// </summary>
        public override bool IsExists => File.Exists(FullPath);

        /// <summary>
        /// 파일의 확장자 없는 이름을 가져옵니다.
        /// </summary>
        public string NameWithoutExtension { get; }

        /// <summary>
        /// 파일의 확장자를 가져옵니다.
        /// </summary>
        public string Extension { get; }
    }
}