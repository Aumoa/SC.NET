// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Mathematics;

namespace SC.Engine.Runtime.Core.Numerics
{
    /// <summary>
    /// <see cref="IVectorType"/> 인터페이스를 구현하는 벡터 형식에 대한 확장 함수를 제공합니다.
    /// </summary>
    public static class IVectorTypeExtensions
    {
        /// <summary>
        /// 벡터의 길이의 제곱을 가져옵니다.
        /// </summary>
        /// <typeparam name="T"> 벡터 형식을 전달합니다. </typeparam>
        /// <param name="value"> 값을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public static float GetLengthSq<T>(this T value) where T : IVectorType, new()
        {
            float r = 0;
            for (int i = 0; i < value.Count; ++i)
            {
                float t = value[i];
                r += t * t;
            }
            return r;
        }

        /// <summary>
        /// 벡터의 길이를 가져옵니다.
        /// </summary>
        /// <typeparam name="T"> 벡터 형식을 전달합니다. </typeparam>
        /// <param name="value"> 값을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public static float GetLength<T>(this T value) where T : IVectorType, new()
        {
            float lengthSq = GetLengthSq(value);
            return MathEx.Sqrt(lengthSq);
        }

        /// <summary>
        /// 벡터의 방향을 가져옵니다.
        /// </summary>
        /// <typeparam name="T"> 벡터 형식을 전달합니다. </typeparam>
        /// <param name="value"> 값을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public static T GetNormal<T>(this T value) where T : IVectorType, new()
        {
            T v = new();
            float lengthSq = value.GetLengthSq();
            float invLength = MathEx.InvSqrt(lengthSq);

            for (int i = 0; i < value.Count; ++i)
            {
                v[i] = value[i] * invLength;
            }

            return v;
        }

        /// <summary>
        /// 벡터의 제곱 거리를 계산합니다.
        /// </summary>
        /// <typeparam name="T"> 벡터 형식을 전달합니다. </typeparam>
        /// <param name="lhs"> 값을 전달합니다. </param>
        /// <param name="rhs"> 값을 전달합니다. </param>
        /// <returns> 제곱 거리가 반환됩니다. </returns>
        public static float DistanceSq<T>(this T lhs, T rhs) where T : IVectorType, new()
        {
            T v = new();
            for (int i = 0; i < lhs.Count; ++i)
            {
                v[i] = lhs[i] - rhs[i];
            }
            return v.GetLengthSq();
        }

        /// <summary>
        /// 벡터의 거리를 계산합니다.
        /// </summary>
        /// <typeparam name="T"> 벡터 형식을 전달합니다. </typeparam>
        /// <param name="lhs"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="rhs"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 거리가 반환됩니다. </returns>
        public static float Distance<T>(this T lhs, T rhs) where T : IVectorType, new()
        {
            T v = new();
            for (int i = 0; i < lhs.Count; ++i)
            {
                v[i] = lhs[i] - rhs[i];
            }
            return v.GetLength();
        }

        /// <summary>
        /// 두 벡터의 내적 연산한 결과를 가져옵니다.
        /// </summary>
        /// <param name="lhs"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="rhs"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 연산 결과가 반환됩니다. </returns>
        public static float DotProduct<T>(this T lhs, T rhs) where T : IVectorType, new()
        {
            float r = 0;
            for (int i = 0; i < lhs.Count; ++i)
            {
                r += lhs[i] * rhs[i];
            }
            return r;
        }

        /// <summary>
        /// 벡터의 실수 값을 정수 영역에 스냅합니다.
        /// </summary>
        /// <returns> 변경된 벡터가 반환됩니다. </returns>
        public static T Round<T>(this T lhs) where T : IVectorType, new()
        {
            T v = new();
            for (int i = 0; i < lhs.Count; ++i)
            {
                v[i] = MathEx.Round(lhs[i]);
            }
            return v;
        }
    }
}
