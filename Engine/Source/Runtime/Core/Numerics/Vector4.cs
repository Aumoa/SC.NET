// Copyright 2020 Aumoa.lib. All right reserved.

using System;

using SC.Engine.Runtime.Core.Mathematics;

namespace SC.Engine.Runtime.Core.Numerics
{
    /// <summary>
    /// 4차원 벡터를 정의합니다.
    /// </summary>
    public struct Vector4 : INearlyEquatable<Vector4, float>, IFormattable, IVectorType
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
        /// 벡터의 W 값을 나타냅니다.
        /// </summary>
        public float W;

        /// <summary>
        /// 벡터의 모든 값을 지정하여 <see cref="Vector4"/> 구조체의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="x"> X 값을 전달합니다. </param>
        /// <param name="y"> Y 값을 전달합니다. </param>
        /// <param name="z"> Z 값을 전달합니다. </param>
        /// <param name="w"> W 값을 전달합니다. </param>
        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// 벡터의 모든 값을 지정하여 <see cref="Vector4"/> 구조체의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="xyz"> XYZ 값을 전달합니다. </param>
        /// <param name="w"> W 값을 전달합니다. </param>
        public Vector4(Vector3 xyz, float w)
        {
            X = xyz.X;
            Y = xyz.Y;
            Z = xyz.Z;
            W = w;
        }

        /// <summary>
        /// 벡터의 모든 값을 스칼라 값으로 지정하여 <see cref="Vector4"/> 구조체의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="splat"> 단일 값으로 지정할 스칼라 값을 전달합니다. </param>
        public Vector4(float splat)
        {
            X = splat;
            Y = splat;
            Z = splat;
            W = splat;
        }

        /// <summary>
        /// 대상 오브젝트가 벡터일 경우, 두 벡터가 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="obj"> 대상 오브젝트를 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public override bool Equals(object obj)
        {
            if (obj is Vector4 v)
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
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode() ^ W.GetHashCode();
        }

        /// <summary>
        /// {X, Y, Z, W} 형식의 문자열을 가져옵니다.
        /// </summary>
        /// <returns> 생성된 문자열이 반환됩니다. </returns>
        public override string ToString()
        {
            return string.Format("{{{0}, {1}, {2}, {3}}}", X, Y, Z, W);
        }

        /// <summary>
        /// 두 벡터가 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="v"> 대상 벡터를 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public bool Equals(Vector4 v)
        {
            return this == v;
        }

        /// <inheritdoc/>
        public bool NearlyEquals(Vector4 right, float epsilon)
        {
            return Math.Abs(X - right.X) <= epsilon
                && Math.Abs(Y - right.Y) <= epsilon
                && Math.Abs(Z - right.Z) <= epsilon
                && Math.Abs(W - right.W) <= epsilon;
        }

        /// <summary>
        /// 서식을 지정하여 {X, Y, Z, W} 형식의 문자열을 가져옵니다.
        /// </summary>
        /// <param name="format"> 서식 문자열을 전달합니다. </param>
        /// <param name="formatProvider"> 문화권 정보를 전달합니다. </param>
        /// <returns> 생성된 문자열이 반환됩니다. </returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("{{{0}, {1}, {2}, {3}}}",
                X.ToString(format, formatProvider),
                Y.ToString(format, formatProvider),
                Z.ToString(format, formatProvider),
                W.ToString(format, formatProvider));
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
                W = vector.GetComponentOrDefault(3);
            }
            else
            {
                X = 0;
                Y = 0;
                Z = 0;
                W = 0;
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
            get => 4;
        }

        /// <summary>
        /// 벡터의 길이의 제곱을 가져옵니다.
        /// </summary>
        public float LengthSq
        {
            get => X * X + Y * Y + Z * Z + W * W;
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
        public Vector4 Normalized
        {
            get => this / Length;
        }

        /// <summary>
        /// 정규화된 벡터 방향을 설정하거나 가져옵니다.
        /// </summary>
        public Vector4 Direction
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
        public static float DistanceSq(Vector4 left, Vector4 right)
        {
            return (right - left).LengthSq;
        }

        /// <summary>
        /// 두 벡터의 거리를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 거리 값이 반환됩니다. </returns>
        public static float Distance(Vector4 left, Vector4 right)
        {
            return (right - left).Length;
        }

        /// <summary>
        /// 두 벡터의 내적 연산한 결과를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 연산 결과가 반환됩니다. </returns>
        public static float DotProduct(Vector4 left, Vector4 right)
        {
            return left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.X * right.W;
        }

        /// <summary>
        /// 부호가 변경된 벡터 값을 가져옵니다.
        /// </summary>
        /// <param name="left"> 벡터를 전달합니다. </param>
        /// <returns> 벡터가 반환됩니다. </returns>
        public static Vector4 operator -(Vector4 left)
        {
            return new Vector4(-left.X, -left.Y, -left.Z, -left.W);
        }

        /// <summary>
        /// 두 벡터를 단순 덧셈한 벡터를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 계산된 벡터가 반환됩니다. </returns>
        public static Vector4 operator +(Vector4 left, Vector4 right)
        {
            return new Vector4(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
        }

        /// <summary>
        /// 두 벡터를 단순 뺄셈한 벡터를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 계산된 벡터가 반환됩니다. </returns>
        public static Vector4 operator -(Vector4 left, Vector4 right)
        {
            return new Vector4(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);
        }

        /// <summary>
        /// 두 벡터를 단순 곱셈한 벡터를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 계산된 벡터가 반환됩니다. </returns>
        public static Vector4 operator *(Vector4 left, Vector4 right)
        {
            return new Vector4(left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W * right.W);
        }

        /// <summary>
        /// 두 벡터를 단순 곱셈한 벡터를 가져옵니다. 스칼라 값은 모든 원소가 동일한 벡터로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 계산된 벡터가 반환됩니다. </returns>
        public static Vector4 operator *(float left, Vector4 right)
        {
            return new Vector4(left * right.X, left * right.Y, left * right.Z, left * right.W);
        }

        /// <summary>
        /// 두 벡터를 단순 곱셈한 벡터를 가져옵니다. 스칼라 값은 모든 원소가 동일한 벡터로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 계산된 벡터가 반환됩니다. </returns>
        public static Vector4 operator *(Vector4 left, float right)
        {
            return new Vector4(left.X * right, left.Y * right, left.Z * right, left.W * right);
        }

        /// <summary>
        /// 두 벡터를 단순 나눗셈한 벡터를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 계산된 벡터가 반환됩니다. </returns>
        public static Vector4 operator /(Vector4 left, Vector4 right)
        {
            return new Vector4(left.X / right.X, left.Y / right.Y, left.Z / right.Z, left.W / right.W);
        }

        /// <summary>
        /// 두 벡터를 단순 나눗셈한 벡터를 가져옵니다. 스칼라 값은 모든 원소가 동일한 벡터로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 계산된 벡터가 반환됩니다. </returns>
        public static Vector4 operator /(float left, Vector4 right)
        {
            return new Vector4(left / right.X, left / right.Y, left / right.Z, left / right.W);
        }

        /// <summary>
        /// 두 벡터를 단순 나눗셈한 벡터를 가져옵니다. 스칼라 값은 모든 원소가 동일한 벡터로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 계산된 벡터가 반환됩니다. </returns>
        public static Vector4 operator /(Vector4 left, float right)
        {
            return new Vector4(left.X / right, left.Y / right, left.Z / right, left.W / right);
        }

        /// <summary>
        /// 두 벡터의 내적 연산 결과를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 계산된 스칼라가 반환됩니다. </returns>
        public static float operator |(Vector4 left, Vector4 right)
        {
            return DotProduct(left, right);
        }

        /// <summary>
        /// 두 벡터가 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator ==(Vector4 left, Vector4 right)
        {
            return left.X == right.X && left.Y == right.Y && left.Z == right.Z && left.W == right.W;
        }

        /// <summary>
        /// 두 벡터가 서로 같지 않은지 비교합니다.
        /// </summary>
        /// <param name="left"> 첫 번째 벡터를 전달합니다. </param>
        /// <param name="right"> 두 번째 벡터를 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator !=(Vector4 left, Vector4 right)
        {
            return left.X != right.X || left.Y != right.Y || left.Z != right.Z || left.W != right.W;
        }

        /// <summary>
        /// 모든 값이 0인 벡터를 가져옵니다.
        /// </summary>
        public static Vector4 Zero
        {
            get => new Vector4(0, 0, 0, 0);
        }

        /// <summary>
        /// 모든 값이 1인 벡터를 가져옵니다.
        /// </summary>
        public static Vector4 One
        {
            get => new Vector4(1, 1, 1, 1);
        }
    }
}
