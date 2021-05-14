// Copyright 2020 Aumoa.lib. All right reserved.

using System;

using SC.Engine.Runtime.Core.Mathematics;

namespace SC.Engine.Runtime.Core.Numerics
{
    /// <summary>
    /// 3차원 벡터를 정의합니다.
    /// </summary>
    public struct Vector3 : INearlyEquatable<Vector3, float>, IFormattable, IVectorType
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
        /// 벡터의 Z 값을 나타냅니다.
        /// </summary>
        public float Z;

        /// <summary>
        /// 벡터의 모든 값을 지정하여 <see cref="Vector3"/> 구조체의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="x"> X 값을 전달합니다. </param>
        /// <param name="y"> Y 값을 전달합니다. </param>
        /// <param name="z"> Z 값을 전달합니다. </param>
        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// 벡터의 모든 값을 스칼라 값으로 지정하여 <see cref="Vector3"/> 구조체의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="splat"> 단일 값으로 지정할 스칼라 값을 전달합니다. </param>
        public Vector3(float splat)
        {
            X = splat;
            Y = splat;
            Z = splat;
        }

        /// <summary>
        /// 대상 오브젝트가 벡터일 경우, 두 벡터가 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="obj"> 대상 오브젝트를 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public override bool Equals(object obj)
        {
            if (obj is Vector3 v)
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
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }

        /// <summary>
        /// {X, Y, Z} 형식의 문자열을 가져옵니다.
        /// </summary>
        /// <returns> 생성된 문자열이 반환됩니다. </returns>
        public override string ToString()
        {
            return string.Format("{{{0}, {1}, {2}}}", X, Y, Z);
        }

        /// <summary>
        /// 두 벡터가 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="v"> 대상 벡터를 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public bool Equals(Vector3 v)
        {
            return this == v;
        }

        /// <inheritdoc/>
        public bool NearlyEquals(Vector3 right, float epsilon)
        {
            return Math.Abs(X - right.X) <= epsilon
                && Math.Abs(Y - right.Y) <= epsilon
                && Math.Abs(Z - right.Z) <= epsilon;
        }

        /// <summary>
        /// 서식을 지정하여 {X, Y, Z} 형식의 문자열을 가져옵니다.
        /// </summary>
        /// <param name="format"> 서식 문자열을 전달합니다. </param>
        /// <param name="formatProvider"> 문화권 정보를 전달합니다. </param>
        /// <returns> 생성된 문자열이 반환됩니다. </returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("{{{0}, {1}, {2}}}",
                X.ToString(format, formatProvider),
                Y.ToString(format, formatProvider),
                Z.ToString(format, formatProvider)
            );
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
                Z = vector.GetComponentOrDefault(2);
            }
            else
            {
                X = 0;
                Y = 0;
                Z = 0;
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
            return index >= 0 && index < 3;
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
            get => 3;
        }

        /// <summary>
        /// 위치가 대상 축 정렬 육면체 내부에 존재하는지 검사합니다.
        /// </summary>
        /// <param name="cube"> 축 정렬 육면체를 전달합니다. </param>
        /// <returns> 내부에 존재할 경우 true를 반환합니다. </returns>
        public bool IsOverlap(AxisAlignedCube cube)
        {
            return cube.IsOverlap(this);
        }

        /// <summary>
        /// 벡터의 길이의 제곱을 가져옵니다.
        /// </summary>
        public float LengthSq
        {
            get => X * X + Y * Y + Z * Z;
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
        public Vector3 Normalized
        {
            get => this / Length;
        }

        /// <summary>
        /// 정규화된 벡터 방향을 설정하거나 가져옵니다.
        /// </summary>
        public Vector3 Direction
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
        public static float DistanceSq(Vector3 left, Vector3 right)
        {
            return (right - left).LengthSq;
        }

        /// <summary>
        /// 두 벡터의 거리를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 거리 값이 반환됩니다. </returns>
        public static float Distance(Vector3 left, Vector3 right)
        {
            return (right - left).Length;
        }

        /// <summary>
        /// 두 벡터의 내적 연산한 결과를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 연산 결과가 반환됩니다. </returns>
        public static float DotProduct(Vector3 left, Vector3 right)
        {
            return left.X * right.X + left.Y * right.Y + left.Z * right.Z;
        }

        /// <summary>
        /// 두 벡터의 외적 연산한 결과를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 연산 결과가 반환됩니다. </returns>
        public static Vector3 CrossProduct(Vector3 left, Vector3 right)
        {
            return new Vector3(
                left.Y * right.Z - left.Z * right.Y,
                left.Z * right.X - left.X * right.Z,
                left.X * right.Y - left.Y * right.X
            );
        }

        /// <summary>
        /// 부호가 변경된 벡터 값을 가져옵니다.
        /// </summary>
        /// <param name="left"> 벡터를 전달합니다. </param>
        /// <returns> 벡터가 반환됩니다. </returns>
        public static Vector3 operator -(Vector3 left)
        {
            return new Vector3(-left.X, -left.Y, -left.Z);
        }

        /// <summary>
        /// 두 벡터를 단순 덧셈한 벡터를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 계산된 벡터가 반환됩니다. </returns>
        public static Vector3 operator +(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }

        /// <summary>
        /// 두 벡터를 단순 뺄셈한 벡터를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 계산된 벡터가 반환됩니다. </returns>
        public static Vector3 operator -(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }

        /// <summary>
        /// 두 벡터를 단순 곱셈한 벡터를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 계산된 벡터가 반환됩니다. </returns>
        public static Vector3 operator *(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
        }

        /// <summary>
        /// 두 벡터를 단순 곱셈한 벡터를 가져옵니다. 스칼라 값은 모든 원소가 동일한 벡터로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 계산된 벡터가 반환됩니다. </returns>
        public static Vector3 operator *(float left, Vector3 right)
        {
            return new Vector3(left * right.X, left * right.Y, left * right.Z);
        }

        /// <summary>
        /// 두 벡터를 단순 곱셈한 벡터를 가져옵니다. 스칼라 값은 모든 원소가 동일한 벡터로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 계산된 벡터가 반환됩니다. </returns>
        public static Vector3 operator *(Vector3 left, float right)
        {
            return new Vector3(left.X * right, left.Y * right, left.Z * right);
        }

        /// <summary>
        /// 두 벡터를 단순 나눗셈한 벡터를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 계산된 벡터가 반환됩니다. </returns>
        public static Vector3 operator /(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X / right.X, left.Y / right.Y, left.Z / right.Z);
        }

        /// <summary>
        /// 두 벡터를 단순 나눗셈한 벡터를 가져옵니다. 스칼라 값은 모든 원소가 동일한 벡터로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 계산된 벡터가 반환됩니다. </returns>
        public static Vector3 operator /(float left, Vector3 right)
        {
            return new Vector3(left / right.X, left / right.Y, left / right.Z);
        }

        /// <summary>
        /// 두 벡터를 단순 나눗셈한 벡터를 가져옵니다. 스칼라 값은 모든 원소가 동일한 벡터로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 계산된 벡터가 반환됩니다. </returns>
        public static Vector3 operator /(Vector3 left, float right)
        {
            return new Vector3(left.X / right, left.Y / right, left.Z / right);
        }

        /// <summary>
        /// 두 벡터의 내적 연산 결과 벡터를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 계산된 벡터가 반환됩니다. </returns>
        public static Vector3 operator ^(Vector3 left, Vector3 right)
        {
            return CrossProduct(left, right);
        }

        /// <summary>
        /// 두 벡터의 내적 연산 결과를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 계산된 스칼라가 반환됩니다. </returns>
        public static float operator |(Vector3 left, Vector3 right)
        {
            return DotProduct(left, right);
        }

        /// <summary>
        /// 두 벡터가 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator ==(Vector3 left, Vector3 right)
        {
            return left.X == right.X && left.Y == right.Y && left.Z == right.Z;
        }

        /// <summary>
        /// 두 벡터가 서로 같지 않은지 비교합니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator !=(Vector3 left, Vector3 right)
        {
            return left.X != right.X || left.Y != right.Y || left.Z != right.Z;
        }

        /// <summary>
        /// 엔진이 정의하는 정규화된 오른쪽 벡터를 가져옵니다.
        /// </summary>
        public static Vector3 Right
        {
            get => new Vector3(1, 0, 0);
        }

        /// <summary>
        /// 엔진이 정의하는 정규화된 상향 벡터를 가져옵니다.
        /// </summary>
        public static Vector3 Up
        {
            get => new Vector3(0, 1, 0);
        }

        /// <summary>
        /// 엔진이 정의하는 정규화된 정면 벡터를 가져옵니다.
        /// </summary>
        public static Vector3 Forward
        {
            get => new Vector3(0, 0, 1);
        }

        /// <summary>
        /// 모든 값이 0인 벡터를 가져옵니다.
        /// </summary>
        public static Vector3 Zero
        {
            get => new Vector3(0, 0, 0);
        }

        /// <summary>
        /// 모든 값이 1인 벡터를 가져옵니다.
        /// </summary>
        public static Vector3 One
        {
            get => new Vector3(1, 1, 1);
        }
    }
}
