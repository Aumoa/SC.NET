// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

namespace SC.Engine.Runtime.GameCore
{
    /// <summary>
    /// 치명적 예외를 표현합니다.
    /// </summary>
    public class FatalException : Exception
    {
        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="category"> 카테고리 텍스트를 전달합니다. </param>
        /// <param name="message"> 메시지를 전달합니다. </param>
        public FatalException(string category, string message) : base(message)
        {
            Category = category;
        }

        /// <summary>
        /// 예외 카테고리를 가져옵니다.
        /// </summary>
        public string Category { get; }
    }
}
