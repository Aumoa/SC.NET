// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System.Diagnostics;

namespace SC.Engine.Runtime.GameFramework.Diagnostics
{
    /// <summary>
    /// 전역 로그 시스템을 표현합니다.
    /// </summary>
    public static class LoggingSystem
    {
        /// <summary>
        /// 로그 정보를 기록합니다.
        /// </summary>
        /// <param name="logVerbosity"> 로그 중요도를 전달합니다. </param>
        /// <param name="category"> 카테고리 텍스트를 전달합니다. </param>
        /// <param name="message"> 로그 메시지를 전달합니다. </param>
        public static void Log(LogVerbosity logVerbosity, string category, string message)
        {
            string logCat = $"Log{category}";
            string logHead = $"[{logVerbosity}]";

            Trace.WriteLine($"{logCat}: {logHead}: {message}");

            if (logVerbosity == LogVerbosity.Fatal)
            {
                throw new FatalException(category, message);
            }
        }

        /// <summary>
        /// 로그 정보를 기록합니다.
        /// </summary>
        /// <param name="this"> 카테고리를 표현할 개체를 전달합니다. </param>
        /// <param name="logVerbosity"> 로그 중요도를 전달합니다. </param>
        /// <param name="message"> 로그 메시지를 전달합니다. </param>
        public static void Log(this object @this, LogVerbosity logVerbosity, string message)
        {
            Log(logVerbosity, $"Log{@this.GetType().Name}", message);
        }
    }
}
