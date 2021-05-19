// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

namespace SC.Engine.Runtime.Core.Mathematics
{
    /// <summary>
    /// 라디안 확장 함수를 제공합니다.
    /// </summary>
    public static class RadiansDegrees
    {
        const float PIInv180 = (float)Math.PI / 180.0f;

        /// <summary>
        /// 각도 형식으로 변환합니다.
        /// </summary>
        /// <param name="this"> 값을 전달합니다. </param>
        /// <returns> 변환된 값이 반환됩니다.</returns>
        public static float ToDegrees(this float @this) => @this * MathEx.Inv180;

        /// <summary>
        /// 라디안 형식으로 변환합니다.
        /// </summary>
        /// <param name="this"> 값을 전달합니다. </param>
        /// <returns> 변환된 값이 반환됩니다.</returns>
        public static float ToRadians(this float @this) => @this * PIInv180;
    }
}
