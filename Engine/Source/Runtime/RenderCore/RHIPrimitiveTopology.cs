// Copyright 2020-2021 Aumoa.lib. All right reserved.

namespace SC.Engine.Runtime.RenderCore
{
    /// <summary>
    /// 프리미티브 형태를 표현합니다.
    /// </summary>
    public enum RHIPrimitiveTopology
    {
        /// <summary>
        /// 삼각형 리스트로 나타냅니다.
        /// </summary>
        TriangleList = 4,

        /// <summary>
        /// 삼각형 연결로 나타냅니다.
        /// </summary>
        TriangleStrip = 5,
    }
}
