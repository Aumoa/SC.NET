// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.Engine.Runtime.Core.Numerics
{
    /// <summary>
    /// 대상 값과 근접한지 비교할 수 있는 메서드를 제공하는 개체에 대한 인터페이스입니다.
    /// </summary>
    /// <typeparam name="T"> 개체 유형을 전달합니다. </typeparam>
    /// <typeparam name="ValueType"> 개체가 가지는 값 유형을 전달합니다. </typeparam>
    public interface INearlyEquatable<T, ValueType> : IEquatable<T>
    {
        /// <summary>
        /// 대상 값과 근접한지 비교합니다.
        /// </summary>
        /// <param name="right"> 비교 대상 개체를 전달합니다. </param>
        /// <param name="epsilon"> 얼마나 근접할 때 true를 반환할지 결정하는 값을 전달합니다. </param>
        /// <returns> 근접 여부의 부울 값이 반환됩니다. </returns>
        bool NearlyEquals(T right, ValueType epsilon);
    }
}
