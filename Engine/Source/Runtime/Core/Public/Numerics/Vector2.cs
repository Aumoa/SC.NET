// Copyright 2020 Aumoa.lib. All right reserved.

using System;

using SC.Engine.Runtime.Core.Mathematics;

namespace SC.Engine.Runtime.Core.Numerics
{
    /// <summary>
    /// 2차원 벡터를 정의합니다.
    /// </summary>
    public struct Vector2 : INearlyEquatable<Vector2, float>, IFormattable, IVectorType
    {
        /// <summary>
        /// 벡터의 X 값을 나타냅니다.
        /// </summary>
        public float X;

        /// <summary>
        /// 벡터의 Y 값을 나타냅니다.
        /// </summary>
        public float Y;

        /// <summary>
        /// 벡터의 모든 값을 지정하여 <see cref="Vector2"/> 구조체의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="x"> X 값을 전달합니다. </param>
        /// <param name="y"> Y 값을 전달합니다. </param>
        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// 벡터의 모든 값을 스칼라 값으로 지정하여 <see cref="Vector2"/> 구조체의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="splat"> 단일 값으로 지정할 스칼라 값을 전달합니다. </param>
        public Vector2(float splat)
        {
            X = splat;
            Y = splat;
        }

        /// <summary>
        /// 대상 오브젝트가 벡터일 경우, 두 벡터가 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="obj"> 대상 오브젝트를 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public override bool Equals(object obj)
        {
            if (obj is Vector2 v)
            {
                return Equals(v);
            }
            else
            {
                return base.Equals(obj);
            }
        }

        /// <summary>
        /// 벡터의 전체 값의 해시 코드를 가져옵니다.
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
        /// 두 벡터가 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="v"> 대상 벡터를 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public bool Equals(Vector2 v)
        {
            return this == v;
        }

        /// <inheritdoc/>
        public bool NearlyEquals(in Vector2 right, float epsilon)
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
                Y.ToString(format, formatProvider)
            );
        }

        /// <inheritdoc/>
        public float GetComponentOrDefault(int index)
        {
            return index switch
            {
                0 => X,
                1 => Y,
                _ => default
            };
        }

        /// <inheritdoc/>
        public void Construct<T>(in T vector) where T : IVectorType
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

        /// <inheritdoc/>
        public float this[int index]
        {
            get => GetComponentOrDefault(index);
            set
            {
                switch (index)
                {
                    case 0:
                        X = value;
                        break;
                    case 1:
                        Y = value;
                        break;
                }
            }
        }

        /// <inheritdoc/>
        public int Count
        {
            get => 2;
        }

        /// <summary>
        /// 위치가 대상 사각형 내에 존재하는지 검사합니다.
        /// </summary>
        /// <param name="rect"> 대상 사삭형을 전달합니다. </param>
        /// <returns> 내부에 존재할 경우 true를 반환합니다. </returns>
        public bool IsOverlap(Rectangle rect)
        {
            if (X >= rect.Left && X <= rect.Right &&
                Y >= rect.Top && Y <= rect.Bottom)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 벡터의 길이의 제곱을 가져옵니다.
        /// </summary>
        public float LengthSq
        {
            get => X * X + Y * Y;
        }

        /// <summary>
        /// 벡터의 길이를 가져옵니다.
        /// </summary>
        public float Length
        {
            get => MathEx.Sqrt(LengthSq);
        }

        /// <summary>
        /// 정규화된 벡터를 가져옵니다.
        /// </summary>
        public Vector2 Normalized
        {
            get => this / Length;
        }

        /// <summary>
        /// 정규화된 벡터 방향을 설정하거나 가져옵니다.
        /// </summary>
        public Vector2 Direction
        {
            get => Normalized;
            set => this = value * Length;
        }

        /// <summary>
        /// 두 벡터의 거리의 제곱을 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 제곱된 거리 값이 반환됩니다. </returns>
        public static float DistanceSq(in Vector2 left, in Vector2 right)
        {
            return (right - left).LengthSq;
        }

        /// <summary>
        /// 두 벡터의 거리를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 거리 값이 반환됩니다. </returns>
        public static float Distance(in Vector2 left, in Vector2 right)
        {
            return (right - left).Length;
        }

        /// <summary>
        /// 두 벡터의 내적 연산한 결과를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 연산 결과가 반환됩니다. </returns>
        public static float DotProduct(in Vector2 left, in Vector2 right)
        {
            return left.X * right.X + left.Y * right.Y;
        }

        /// <summary>
        /// 부호가 변경된 벡터 값을 가져옵니다.
        /// </summary>
        /// <param name="left"> 벡터를 전달합니다. </param>
        /// <returns> 벡터가 반환됩니다. </returns>
        public static Vector2 operator -(in Vector2 left)
        {
            return new Vector2(-left.X, -left.Y);
        }

        /// <summary>
        /// 두 벡터를 단순 덧셈한 벡터를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 계산된 벡터가 반환됩니다. </returns>
        public static Vector2 operator +(in Vector2 left, in Vector2 right)
        {
            return new Vector2(left.X + right.X, left.Y + right.Y);
        }

        /// <summary>
        /// 두 벡터를 단순 뺄셈한 벡터를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 계산된 벡터가 반환됩니다. </returns>
        public static Vector2 operator -(in Vector2 left, in Vector2 right)
        {
            return new Vector2(left.X - right.X, left.Y - right.Y);
        }

        /// <summary>
        /// 두 벡터를 단순 곱셈한 벡터를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 계산된 벡터가 반환됩니다. </returns>
        public static Vector2 operator *(in Vector2 left, in Vector2 right)
        {
            return new Vector2(left.X * right.X, left.Y * right.Y);
        }

        /// <summary>
        /// 두 벡터를 단순 곱셈한 벡터를 가져옵니다. 스칼라 값은 모든 원소가 동일한 벡터로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 계산된 벡터가 반환됩니다. </returns>
        public static Vector2 operator *(float left, in Vector2 right)
        {
            return new Vector2(left * right.X, left * right.Y);
        }

        /// <summary>
        /// 두 벡터를 단순 곱셈한 벡터를 가져옵니다. 스칼라 값은 모든 원소가 동일한 벡터로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 계산된 벡터가 반환됩니다. </returns>
        public static Vector2 operator *(in Vector2 left, float right)
        {
            return new Vector2(left.X * right, left.Y * right);
        }

        /// <summary>
        /// 두 벡터를 단순 나눗셈한 벡터를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 계산된 벡터가 반환됩니다. </returns>
        public static Vector2 operator /(in Vector2 left, in Vector2 right)
        {
            return new Vector2(left.X / right.X, left.Y / right.Y);
        }

        /// <summary>
        /// 두 벡터를 단순 나눗셈한 벡터를 가져옵니다. 스칼라 값은 모든 원소가 동일한 벡터로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 계산된 벡터가 반환됩니다. </returns>
        public static Vector2 operator /(float left, in Vector2 right)
        {
            return new Vector2(left / right.X, left / right.Y);
        }

        /// <summary>
        /// 두 벡터를 단순 나눗셈한 벡터를 가져옵니다. 스칼라 값은 모든 원소가 동일한 벡터로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 계산된 벡터가 반환됩니다. </returns>
        public static Vector2 operator /(in Vector2 left, float right)
        {
            return new Vector2(left.X / right, left.Y / right);
        }

        /// <summary>
        /// 두 벡터의 내적 연산 결과를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 계산된 스칼라가 반환됩니다. </returns>
        public static float operator |(in Vector2 left, in Vector2 right)
        {
            return DotProduct(left, right);
        }

        /// <summary>
        /// 두 벡터가 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator ==(in Vector2 left, in Vector2 right)
        {
            return left.X == right.X && left.Y == right.Y;
        }

        /// <summary>
        /// 두 벡터가 서로 같지 않은지 비교합니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator !=(in Vector2 left, in Vector2 right)
        {
            return left.X != right.X || left.Y != right.Y;
        }

        /// <summary>
        /// 엔진이 정의하는 정규화된 오른쪽 벡터를 가져옵니다.
        /// </summary>
        public static Vector2 Right
        {
            get => new Vector2(1, 0);
        }

        /// <summary>
        /// 엔진이 정의하는 정규화된 상향 벡터를 가져옵니다.
        /// </summary>
        public static Vector2 Up
        {
            get => new Vector2(0, 1);
        }

        /// <summary>
        /// 모든 값이 0인 벡터를 가져옵니다.
        /// </summary>
        public static Vector2 Zero
        {
            get => new Vector2(0, 0);
        }

        /// <summary>
        /// 모든 값이 1인 벡터를 가져옵니다.
        /// </summary>
        public static Vector2 One
        {
            get => new Vector2(1, 1);
        }
    }
}
