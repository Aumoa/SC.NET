// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

namespace SC.Engine.Runtime.Core.Numerics
{
    /// <summary>
    /// 복소수로 정의되는 2차원 사원수 값을 나타냅니다.
    /// </summary>
    public struct Quaternion2 : INearlyEquatable<Quaternion2, float>, IFormattable, IVectorType
    {
        /// <summary>
        /// X값을 나타냅니다.
        /// </summary>
        public float X;

        /// <summary>
        /// Y값을 나타냅니다.
        /// </summary>
        public float Y;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="x"> X값을 전달합니다. </param>
        /// <param name="y"> Y값을 전달합니다. </param>
        public Quaternion2(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="value"> 값을 전달합니다. </param>
        public Quaternion2(Vector2 value)
        {
            X = value.X;
            Y = value.Y;
        }

        /// <summary>
        /// 벡터를 변환합니다.
        /// </summary>
        /// <param name="vector"> 벡터를 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public Vector2 TransformVector(Vector2 vector)
        {
            return new Vector2(
                vector.X * X - vector.Y * Y,
                vector.X * Y + vector.Y * X
                );
        }

        /// <summary>
        /// 대상 오브젝트가 사원수일 경우, 두 사원수가 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="obj"> 대상 오브젝트를 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public override bool Equals(object obj)
        {
            if (obj is Quaternion2 q)
            {
                return Equals(q);
            }
            else
            {
                return base.Equals(obj);
            }
        }

        /// <summary>
        /// 사원수의 전체 값의 해시 코드를 가져옵니다.
        /// </summary>
        /// <returns> 해시 코드가 반환됩니다. </returns>
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        /// <summary>
        /// {X, Y} 형식의 문자열을 가져옵니다.
        /// </summary>
        /// <returns> 생성된 문자열이 반환됩니다. </returns>
        public override string ToString()
        {
            return string.Format("{{{0}, {1}}}", X, Y);
        }

        /// <summary>
        /// 두 사원수가 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="v"> 대상 사원수를 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public bool Equals(Quaternion2 v)
        {
            return this == v;
        }

        /// <inheritdoc/>
        public bool NearlyEquals(Quaternion2 right, float epsilon)
        {
            return Math.Abs(X - right.X) <= epsilon
                && Math.Abs(Y - right.Y) <= epsilon;
        }

        /// <summary>
        /// 서식을 지정하여 {X, Y} 형식의 문자열을 가져옵니다.
        /// </summary>
        /// <param name="format"> 서식 문자열을 전달합니다. </param>
        /// <param name="formatProvider"> 문화권 정보를 전달합니다. </param>
        /// <returns> 생성된 문자열이 반환됩니다. </returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("{{{0}, {1}}}",
                X.ToString(format, formatProvider),
                Y.ToString(format, formatProvider));
        }

        /// <inheritdoc/>
        public unsafe float GetComponentOrDefault(int index)
        {
            fixed (float* ptr = &X)
            {
                if (index < Count)
                {
                    return ptr[index];
                }
                else
                {
                    return default;
                }
            }
        }

        /// <inheritdoc/>
        public void Construct<T>(T vector) where T : IVectorType
        {
            if (vector is not null)
            {
                X = vector.GetComponentOrDefault(0);
                Y = vector.GetComponentOrDefault(1);
            }
            else
            {
                X = 0;
                Y = 0;
            }
        }

        /// <inheritdoc/>
        public T Convert<T>() where T : IVectorType, new()
        {
            var value = new T();
            value.Construct(this);
            return value;
        }

        /// <inheritdoc/>
        public bool Contains(int index)
        {
            return index >= 0 && index < 2;
        }

        /// <summary>
        /// 두 사원수가 나타내는 회전을 더한 회전을 나타내는 사원수를 계산합니다.
        /// </summary>
        /// <param name="InLeft"> 첫 번째 사원수를 전달합니다. </param>
        /// <param name="InRight"> 두 번째 사원수를 전달합니다. </param>
        /// <returns> 계산된 사원수 개체가 반환됩니다. </returns>
        public static Quaternion2 Concatenate(Quaternion2 InLeft, Quaternion2 InRight)
        {
            return new Quaternion2(InLeft.TransformVector(InRight.Convert<Vector2>()));
        }

        /// <summary>
        /// 이 사원수의 역을 가져옵니다.
        /// </summary>
        public Quaternion2 Inverse
        {
            get => new Quaternion2(X, -Y);
        }

        /// <inheritdoc/>
        public unsafe float this[int index]
        {
            get => GetComponentOrDefault(index);
            set
            {
                fixed (float* ptr = &X)
                {
                    if (index < Count)
                    {
                        ptr[index] = value;
                    }

                }
            }
        }

        /// <inheritdoc/>
        public int Count
        {
            get => 2;
        }

        /// <summary>
        /// 부호가 변경된 사원수 값을 가져옵니다.
        /// </summary>
        /// <param name="left"> 사원수를 전달합니다. </param>
        /// <returns> 사원수가 반환됩니다. </returns>
        public static Quaternion2 operator -(Quaternion2 left)
        {
            return new Quaternion2(-left.X, -left.Y);
        }

        /// <summary>
        /// 두 사원수를 단순 덧셈한 사원수를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 사원수를 전달합니다. </param>
        /// <param name="right"> 두 번째 사원수를 전달합니다. </param>
        /// <returns> 계산된 사원수가 반환됩니다. </returns>
        public static Quaternion2 operator +(Quaternion2 left, Quaternion2 right)
        {
            return new Quaternion2(left.X + right.X, left.Y + right.Y);
        }

        /// <summary>
        /// 두 사원수를 단순 뺄셈한 사원수를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 사원수를 전달합니다. </param>
        /// <param name="right"> 두 번째 사원수를 전달합니다. </param>
        /// <returns> 계산된 사원수가 반환됩니다. </returns>
        public static Quaternion2 operator -(Quaternion2 left, Quaternion2 right)
        {
            return new Quaternion2(left.X - right.X, left.Y - right.Y);
        }

        /// <summary>
        /// 두 사원수를 단순 곱셈한 사원수를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 사원수를 전달합니다. </param>
        /// <param name="right"> 두 번째 사원수를 전달합니다. </param>
        /// <returns> 계산된 사원수가 반환됩니다. </returns>
        public static Quaternion2 operator *(Quaternion2 left, Quaternion2 right)
        {
            return new Quaternion2(left.X * right.X, left.Y * right.Y);
        }

        /// <summary>
        /// 두 사원수를 단순 곱셈한 사원수를 가져옵니다. 스칼라 값은 모든 원소가 동일한 사원수로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 사원수를 전달합니다. </param>
        /// <param name="right"> 두 번째 사원수를 전달합니다. </param>
        /// <returns> 계산된 사원수가 반환됩니다. </returns>
        public static Quaternion2 operator *(float left, Quaternion2 right)
        {
            return new Quaternion2(left * right.X, left * right.Y);
        }

        /// <summary>
        /// 두 사원수를 단순 곱셈한 사원수를 가져옵니다. 스칼라 값은 모든 원소가 동일한 사원수로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 사원수를 전달합니다. </param>
        /// <param name="right"> 두 번째 사원수를 전달합니다. </param>
        /// <returns> 계산된 사원수가 반환됩니다. </returns>
        public static Quaternion2 operator *(Quaternion2 left, float right)
        {
            return new Quaternion2(left.X * right, left.Y * right);
        }

        /// <summary>
        /// 두 사원수를 단순 나눗셈한 사원수를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 사원수를 전달합니다. </param>
        /// <param name="right"> 두 번째 사원수를 전달합니다. </param>
        /// <returns> 계산된 사원수가 반환됩니다. </returns>
        public static Quaternion2 operator /(Quaternion2 left, Quaternion2 right)
        {
            return new Quaternion2(left.X / right.X, left.Y / right.Y);
        }

        /// <summary>
        /// 두 사원수를 단순 나눗셈한 사원수를 가져옵니다. 스칼라 값은 모든 원소가 동일한 사원수로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 사원수를 전달합니다. </param>
        /// <param name="right"> 두 번째 사원수를 전달합니다. </param>
        /// <returns> 계산된 사원수가 반환됩니다. </returns>
        public static Quaternion2 operator /(float left, Quaternion2 right)
        {
            return new Quaternion2(left / right.X, left / right.Y);
        }

        /// <summary>
        /// 두 사원수를 단순 나눗셈한 사원수를 가져옵니다. 스칼라 값은 모든 원소가 동일한 사원수로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 사원수를 전달합니다. </param>
        /// <param name="right"> 두 번째 사원수를 전달합니다. </param>
        /// <returns> 계산된 사원수가 반환됩니다. </returns>
        public static Quaternion2 operator /(Quaternion2 left, float right)
        {
            return new Quaternion2(left.X / right, left.Y / right);
        }

        /// <summary>
        /// 두 사원수가 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="left"> 첫 번째 사원수를 전달합니다. </param>
        /// <param name="right"> 두 번째 사원수를 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator ==(Quaternion2 left, Quaternion2 right)
        {
            return left.X == right.X && left.Y == right.Y;
        }

        /// <summary>
        /// 두 사원수가 서로 같지 않은지 비교합니다.
        /// </summary>
        /// <param name="left"> 첫 번째 사원수를 전달합니다. </param>
        /// <param name="right"> 두 번째 사원수를 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator !=(Quaternion2 left, Quaternion2 right)
        {
            return left.X != right.X || left.Y != right.Y;
        }

        /// <summary>
        /// 모든 값이 0인 사원수를 가져옵니다.
        /// </summary>
        public static Quaternion2 Zero
        {
            get => new Quaternion2(0, 0);
        }

        /// <summary>
        /// 모든 값이 1인 사원수를 가져옵니다.
        /// </summary>
        public static Quaternion2 One
        {
            get => new Quaternion2(1, 1);
        }

        /// <summary>
        /// 단위 사원수를 가져옵니다.
        /// </summary>
        public static Quaternion2 Identity
        {
            get => new Quaternion2(1, 0);
        }
    }
}
