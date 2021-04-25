// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

namespace SC.Engine.Runtime.GameFramework
{
    /// <summary>
    /// 컨트롤러 관련 예외 사항을 나타냅니다.
    /// </summary>
    public class ControllerException : Exception
    {
        /// <summary>
        /// 오류 ID를 나타냅니다.
        /// </summary>
        public enum ErrorId
        {
            /// <summary>
            /// 이미 빙의되어 있습니다.
            /// </summary>
            AlreadyPossessed,
        }

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="errId"> 오류 ID를 전달합니다. </param>
        /// <param name="message"> 메시지를 전달합니다. </param>
        public ControllerException(ErrorId errId, string message) : base($"ErrorID: {errId} => {message}")
        {
            Message = message;
            Error = errId;
        }

        /// <summary>
        /// 메시지를 가져옵니다.
        /// </summary>
        public new string Message { get; }

        /// <summary>
        /// 오류 ID를 가져옵니다.
        /// </summary>
        public ErrorId Error { get; }
    }
}
