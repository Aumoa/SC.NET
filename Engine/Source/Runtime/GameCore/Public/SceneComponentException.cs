// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

namespace SC.Engine.Runtime.GameCore
{
    /// <summary>
    /// 씬 컴포넌트 관련 예외를 표현합니다.
    /// </summary>
    public class SceneComponentException : Exception
    {
        /// <summary>
        /// 오류 종류를 나타냅니다.
        /// </summary>
        public enum ErrorId
        {
            /// <summary>
            /// 지정한 소켓을 찾을 수 없습니다.
            /// </summary>
            SocketNotFound,

            /// <summary>
            /// 부착 정보를 찾을 수 없습니다.
            /// </summary>
            NotFound,

            /// <summary>
            /// 모빌리티 설정 문제입니다.
            /// </summary>
            Mobility,
        }

        ErrorId _errid;
        string _messagee;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="errId"> 오류 종류를 전달합니다. </param>
        /// <param name="errorMessage"> 오류 메시지를 전달합니다. </param>
        public SceneComponentException(ErrorId errId, string errorMessage) : base($"{errId}: {errorMessage}")
        {
            _errid = errId;
            _messagee = errorMessage;
        }

        /// <summary>
        /// 오류 종류를 가져옵니다.
        /// </summary>
        /// <returns> 값이 반환됩니다. </returns>
        public ErrorId GetErrorId()
        {
            return _errid;
        }

        /// <summary>
        /// 예외를 발생시킨 컴포넌트 이름을 가져옵니다.
        /// </summary>
        /// <returns> 컴포넌트 이름이 반환됩니다. </returns>
        public string GetMessage()
        {
            return _messagee;
        }
    }
}
