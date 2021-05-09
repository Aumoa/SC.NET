// Copyright 2020-2021 Aumoa.lib. All right reserved.

namespace SC.Engine.Runtime.GameCore.Diagnostics
{
    /// <summary>
    /// 로그 중요도를 나타냅니다.
    /// </summary>
    public enum LogVerbosity
    {
        /// <summary>
        /// 치명적 오류로, 더 이상 프로그램을 진행할 수 없습니다.
        /// </summary>
        Fatal,

        /// <summary>
        /// 논리 오류입니다.
        /// </summary>
        Error,

        /// <summary>
        /// 오류로 이어질 수 있는 잘못된 논리입니다.
        /// </summary>
        Warning,

        /// <summary>
        /// 개발자에게 제공하는 정보입니다.
        /// </summary>
        Info,

        /// <summary>
        /// 단순 텍스트 정보입니다.
        /// </summary>
        Verbose,
    }
}
