﻿// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

using SC.Engine.Runtime.Core.Numerics;

namespace SC.Engine.Runtime.Core.Mathematics
{
    /// <summary>
    /// 확장된 수학 함수를 제공합니다.
    /// </summary>
    public static class MathEx
    {
        static readonly int[] Primes =
        {
            3, 7, 11, 17, 23, 29, 37, 47, 59, 71, 89, 107, 131, 163, 197, 239, 293, 353, 431, 521, 631, 761, 919,
            1103, 1327, 1597, 1931, 2333, 2801, 3371, 4049, 4861, 5839, 7013, 8419, 10103, 12143, 14591,
            17519, 21023, 25229, 30293, 36353, 43627, 52361, 62851, 75431, 90523, 108631, 130363, 156437,
            187751, 225307, 270371, 324449, 389357, 467237, 560689, 672827, 807403, 968897, 1162687, 1395263,
            1674319, 2009191, 2411033, 2893249, 3471899, 4166287, 4999559, 5999471, 7199369
        };

        const int HashPrime = 101;
        const int MaxPrimeArrayLength = 0x7FEFFFFD;

        /// <summary>
        /// 파이의 역수입니다.
        /// </summary>
        public const float InvPI = 1.0f / (float)Math.PI;

        /// <summary>
        /// 파이의 절반입니다.
        /// </summary>
        public const float HalfPI = (float)Math.PI * 0.5f;

        /// <summary>
        /// 180의 역수입니다.
        /// </summary>
        public const float Inv180 = 1.0f / 180.0f;

        /// <summary>
        /// 역제곱근을 계산합니다.
        /// </summary>
        /// <param name="x"> 값을 전달합니다. </param>
        /// <returns> 역제곱근 값이 반환됩니다. </returns>
        public static float InvSqrt(float x)
        {
            IntFloatUnionHelper converter = new();
            converter.FloatValue = x;

            int i = 0x5F3759DF - (converter.IntValue >> 1);
            converter.IntValue = i;

            float ret = converter.FloatValue;
            ret *= 1.5f - (x * 0.5f * ret * ret);
            return ret;
        }

        /// <summary>
        /// 삼각함수 사인 및 코사인을 한 번에 계산합니다.
        /// </summary>
        /// <param name="radians"> 라디안 각도 단위를 전달합니다. </param>
        /// <returns> 첫 번째 아이템에 사인 값이, 두 번째 아이템에 코사인 값이 반환됩니다. </returns>
        public static (float, float) SinCos(float radians)
        {
            SinCos(out float sin, out float cos, radians);
            return (sin, cos);
        }

        /// <summary>
        /// 삼각함수 사인 및 코사인을 한 번에 계산합니다.
        /// </summary>
        /// <param name="sin"> 사인 값이 반환됩니다. </param>
        /// <param name="cos"> 코사인 값이 반환됩니다. </param>
        /// <param name="radians"> 라디안 각도 단위를 전달합니다. </param>
        public static void SinCos(out float sin, out float cos, float radians)
        {
            float quotient = (float)(InvPI * 0.5f) * radians;
            if (radians >= 0)
            {
                quotient = (int)(quotient + 0.5f);
            }
            else
            {
                quotient = (int)(quotient - 0.5f);
            }
            float y = radians - (float)(2.0f * Math.PI) * quotient;

            float sign;
            if (y > HalfPI)
            {
                y = (float)(Math.PI - y);
                sign = -1.0f;
            }
            else if (y < -HalfPI)
            {
                y = (float)(-Math.PI - y);
                sign = -1.0f;
            }
            else
            {
                sign = +1.0f;
            }

            float y2 = y * y;

                  sin = (((((-2.3889859e-08f * y2 + 2.7525562e-06f) * y2 - 0.00019840874f) * y2 + 0.0083333310f) * y2 - 0.16666667f) * y2 + 1.0f) * y;
            float p = ((((-2.6051615e-07f * y2 + 2.4760495e-05f) * y2 - 0.0013888378f) * y2 + 0.041666638f) * y2 - 0.5f) * y2 + 1.0f;
                  cos = sign * p;
        }

        /// <summary>
        /// 최솟값을 넘는 소수를 가져옵니다.
        /// </summary>
        /// <param name="min"> 최솟값을 가져옵니다. </param>
        /// <returns> 일치하는 소수가 반환됩니다. </returns>
        public static int GetPrime(int min)
        {
            for (int i = 0; i < Primes.Length; i++)
            {
                int prime = Primes[i];
                if (prime >= min)
                {
                    return prime;
                }
            }

            for (int i = (min | 1); i < int.MaxValue; i += 2)
            {
                if (IsPrime(i) && ((i - 1) % HashPrime != 0))
                {
                    return i;
                }
            }
            return min;
        }

        /// <summary>
        /// 소수 단위로 확장합니다.
        /// </summary>
        /// <param name="oldSize"> 이전 크기를 전달합니다. </param>
        /// <returns> 일치하는 소수 값이 반환됩니다. </returns>
        public static int ExpandPrime(int oldSize)
        {
            int newSize = 2 * oldSize;

            if ((uint)newSize > MaxPrimeArrayLength && MaxPrimeArrayLength > oldSize)
            {
                if (MaxPrimeArrayLength == GetPrime(MaxPrimeArrayLength))
                {
                    throw new InvalidOperationException("Invalid MaxPrimeArrayLength");
                }
                return MaxPrimeArrayLength;
            }

            return GetPrime(newSize);
        }

        /// <summary>
        /// 전달된 값이 소수인지 검사합니다.
        /// </summary>
        /// <param name="candidate"> 값을 전달합니다. </param>
        /// <returns> 결과가 반환됩니다. </returns>
        public static bool IsPrime(int candidate)
        {
            if ((candidate & 1) != 0)
            {
                int limit = (int)Math.Sqrt(candidate);
                for (int divisor = 3; divisor <= limit; divisor += 2)
                {
                    if ((candidate % divisor) == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            return candidate == 2;
        }

        /// <summary>
        /// 전달된 값의 루트값을 계산합니다.
        /// </summary>
        /// <param name="value"> 값을 전달합니다. </param>
        /// <returns> 계산 결과가 반환됩니다. </returns>
        public static float Sqrt(float value) => (float)Math.Sqrt(value);

        [StructLayout(LayoutKind.Explicit, Size = 4)]
        struct IntFloatUnionHelper
        {
            [FieldOffset(0)]
            public float FloatValue;

            [FieldOffset(0)]
            public int IntValue;
        }

        /// <summary>
        /// 사인 값을 계산합니다.
        /// </summary>
        /// <param name="theta"> 라디안을 전달합니다. </param>
        /// <returns> 계산 결과가 반환됩니다. </returns>
        public static float Sin(float theta) => (float)Math.Sin(theta);

        /// <summary>
        /// 코사인 값을 계산합니다.
        /// </summary>
        /// <param name="theta"> 라디안을 전달합니다. </param>
        /// <returns> 계산 결과가 반환됩니다. </returns>
        public static float Cos(float theta) => (float)Math.Cos(theta);

        /// <summary>
        /// 역 코사인 값을 계산합니다.
        /// </summary>
        /// <param name="value"> 코사인 값을 전달합니다. </param>
        /// <returns> 계산 결과가 반환됩니다. </returns>
        public static float Acos(float value) => (float)Math.Acos(value);

        /// <summary>
        /// 두 값 중 더 큰 값만 사용하여 새 벡터를 생성합니다.
        /// </summary>
        /// <param name="lh"> 값을 전달합니다. </param>
        /// <param name="rh"> 값을 전달합니다. </param>
        /// <returns> 벡터가 반환됩니다. </returns>
        public static Vector2 Max(Vector2 lh, Vector2 rh)
        {
            return new Vector2(Math.Max(lh.X, rh.X), Math.Max(lh.Y, rh.Y));
        }

        /// <summary>
        /// 두 값 중 더 큰 값만 사용하여 새 벡터를 생성합니다.
        /// </summary>
        /// <param name="lh"> 값을 전달합니다. </param>
        /// <param name="rh"> 값을 전달합니다. </param>
        /// <returns> 벡터가 반환됩니다. </returns>
        public static Vector3 Max(Vector3 lh, Vector3 rh)
        {
            return new Vector3(Math.Max(lh.X, rh.X), Math.Max(lh.Y, rh.Y), Math.Max(lh.Z, rh.Z));
        }

        /// <summary>
        /// 두 값 중 더 큰 값만 사용하여 새 벡터를 생성합니다.
        /// </summary>
        /// <param name="lh"> 값을 전달합니다. </param>
        /// <param name="rh"> 값을 전달합니다. </param>
        /// <returns> 벡터가 반환됩니다. </returns>
        public static Vector4 Max(Vector4 lh, Vector4 rh)
        {
            return new Vector4(Math.Max(lh.X, rh.X), Math.Max(lh.Y, rh.Y), Math.Max(lh.Z, rh.Z), Math.Max(lh.W, rh.W));
        }

        /// <summary>
        /// 두 값 중 더 작은 값만 사용하여 새 벡터를 생성합니다.
        /// </summary>
        /// <param name="lh"> 값을 전달합니다. </param>
        /// <param name="rh"> 값을 전달합니다. </param>
        /// <returns> 벡터가 반환됩니다. </returns>
        public static Vector2 Min(Vector2 lh, Vector2 rh)
        {
            return new Vector2(Math.Min(lh.X, rh.X), Math.Min(lh.Y, rh.Y));
        }

        /// <summary>
        /// 두 값 중 더 작은 값만 사용하여 새 벡터를 생성합니다.
        /// </summary>
        /// <param name="lh"> 값을 전달합니다. </param>
        /// <param name="rh"> 값을 전달합니다. </param>
        /// <returns> 벡터가 반환됩니다. </returns>
        public static Vector3 Min(Vector3 lh, Vector3 rh)
        {
            return new Vector3(Math.Min(lh.X, rh.X), Math.Min(lh.Y, rh.Y), Math.Min(lh.Z, rh.Z));
        }

        /// <summary>
        /// 두 값 중 더 작은 값만 사용하여 새 벡터를 생성합니다.
        /// </summary>
        /// <param name="lh"> 값을 전달합니다. </param>
        /// <param name="rh"> 값을 전달합니다. </param>
        /// <returns> 벡터가 반환됩니다. </returns>
        public static Vector4 Min(Vector4 lh, Vector4 rh)
        {
            return new Vector4(Math.Min(lh.X, rh.X), Math.Min(lh.Y, rh.Y), Math.Min(lh.Z, rh.Z), Math.Min(lh.W, rh.W));
        }

        /// <summary>
        /// 탄젠트 값을 계산합니다.
        /// </summary>
        /// <param name="a"> 매개변수를 전달합니다. </param>
        /// <returns> 계산 값이 반환됩니다. </returns>
        public static float Tan(float a)
        {
            return (float)Math.Tan(a);
        }

        /// <summary>
        /// 두 값 중 큰 값을 가져옵니다.
        /// </summary>
        /// <param name="arg1"> 값을 전달합니다. </param>
        /// <param name="arg2"> 값을 전달합니다. </param>
        /// <returns> 가장 큰 값이 반환됩니다. </returns>
        public static float Max(float arg1, float arg2) => arg1 > arg2 ? arg1 : arg2;

        /// <summary>
        /// 전달된 값 중 큰 값을 가져옵니다.
        /// </summary>
        /// <param name="arg1"> 값을 전달합니다. </param>
        /// <param name="arg2"> 값을 전달합니다. </param>
        /// <param name="arg3"> 값을 전달합니다. </param>
        /// <returns> 가장 큰 값이 반환됩니다. </returns>
        public static float Max(float arg1, float arg2, float arg3) => Max(Max(arg1, arg2), arg3);

        /// <summary>
        /// 전달된 값 중 큰 값을 가져옵니다.
        /// </summary>
        /// <param name="arg1"> 값을 전달합니다. </param>
        /// <param name="arg2"> 값을 전달합니다. </param>
        /// <param name="arg3"> 값을 전달합니다. </param>
        /// <param name="arg4"> 값을 전달합니다. </param>
        /// <returns> 가장 큰 값이 반환됩니다. </returns>
        public static float Max(float arg1, float arg2, float arg3, float arg4) => Max(Max(arg1, arg2, arg3), arg4);

        /// <summary>
        /// 전달된 값 중 큰 값을 가져옵니다.
        /// </summary>
        /// <param name="arg1"> 값을 전달합니다. </param>
        /// <param name="arg2"> 값을 전달합니다. </param>
        /// <param name="arg3"> 값을 전달합니다. </param>
        /// <param name="arg4"> 값을 전달합니다. </param>
        /// <param name="arg5"> 값을 전달합니다. </param>
        /// <param name="args"> 값을 전달합니다. </param>
        /// <returns> 가장 큰 값이 반환됩니다. </returns>
        public static float Max(float arg1, float arg2, float arg3, float arg4, float arg5, params float[] args)
        {
            float v = Max(Max(arg1, arg2, arg3, arg4), arg5);
            if (args.Length != 0)
            {
                for (int i = 0; i < args.Length; ++i)
                {
                    v = Max(v, args[i]);
                }
            }
            return v;
        }

        /// <summary>
        /// 두 값 중 작은 값을 가져옵니다.
        /// </summary>
        /// <param name="arg1"> 값을 전달합니다. </param>
        /// <param name="arg2"> 값을 전달합니다. </param>
        /// <returns> 가장 작은 값이 반환됩니다. </returns>
        public static float Min(float arg1, float arg2) => arg1 > arg2 ? arg1 : arg2;

        /// <summary>
        /// 전달된 값 중 작은 값을 가져옵니다.
        /// </summary>
        /// <param name="arg1"> 값을 전달합니다. </param>
        /// <param name="arg2"> 값을 전달합니다. </param>
        /// <param name="arg3"> 값을 전달합니다. </param>
        /// <returns> 가장 작은 값이 반환됩니다. </returns>
        public static float Min(float arg1, float arg2, float arg3) => Min(Min(arg1, arg2), arg3);

        /// <summary>
        /// 전달된 값 중 작은 값을 가져옵니다.
        /// </summary>
        /// <param name="arg1"> 값을 전달합니다. </param>
        /// <param name="arg2"> 값을 전달합니다. </param>
        /// <param name="arg3"> 값을 전달합니다. </param>
        /// <param name="arg4"> 값을 전달합니다. </param>
        /// <returns> 가장 작은 값이 반환됩니다. </returns>
        public static float Min(float arg1, float arg2, float arg3, float arg4) => Min(Min(arg1, arg2, arg3), arg4);

        /// <summary>
        /// 전달된 값 중 작은 값을 가져옵니다.
        /// </summary>
        /// <param name="arg1"> 값을 전달합니다. </param>
        /// <param name="arg2"> 값을 전달합니다. </param>
        /// <param name="arg3"> 값을 전달합니다. </param>
        /// <param name="arg4"> 값을 전달합니다. </param>
        /// <param name="arg5"> 값을 전달합니다. </param>
        /// <param name="args"> 값을 전달합니다. </param>
        /// <returns> 가장 작은 값이 반환됩니다. </returns>
        public static float Min(float arg1, float arg2, float arg3, float arg4, float arg5, params float[] args)
        {
            float v = Min(Min(arg1, arg2, arg3, arg4), arg5);
            if (args.Length != 0)
            {
                for (int i = 0; i < args.Length; ++i)
                {
                    v = Min(v, args[i]);
                }
            }
            return v;
        }

        /// <summary>
        /// 값이 범위 안에 있는지 검사합니다.
        /// </summary>
        /// <param name="testValue"> 값을 전달합니다. </param>
        /// <param name="minValue"> 최소값을 전달합니다. </param>
        /// <param name="maxValue"> 최댓값을 전달합니다. </param>
        /// <returns> 검사 결과가 반환됩니다. </returns>
        public static bool IsWithin(float testValue, float minValue, float maxValue)
        {
            return testValue > minValue && testValue < maxValue;
        }

        /// <summary>
        /// 값이 범위 안에 있는지 검사합니다. 정확한 범위 수치를 포함합니다.
        /// </summary>
        /// <param name="testValue"> 값을 전달합니다. </param>
        /// <param name="minValue"> 최소값을 전달합니다. </param>
        /// <param name="maxValue"> 최댓값을 전달합니다. </param>
        /// <returns> 검사 결과가 반환됩니다. </returns>
        public static bool IsWithinInclusive(float testValue, float minValue, float maxValue)
        {
            return testValue >= minValue && testValue <= maxValue;
        }

        /// <summary>
        /// 인접한 정수 값을 계산합니다.
        /// </summary>
        /// <param name="x"> 실수 값을 전달합니다. </param>
        /// <returns> 정수 값의 실수 형식이 반환됩니다. </returns>
        public static float Round(float x)
        {
            return (float)Math.Round(x);
        }

        /// <summary>
        /// 절댓값을 가져옵니다.
        /// </summary>
        /// <param name="x"> 값을 전달합니다. </param>
        /// <returns> 절댓값이 반환됩니다. </returns>
        public static float Abs(float x) => x * Math.Sign(x);
    }
}
