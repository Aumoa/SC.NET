// Copyright 2020 Aumoa.lib. All right reserved.

using System;

using SC.Engine.Runtime.Core.Mathematics;

namespace SC.Engine.Runtime.Core.Numerics
{
    /// <summary>
    /// 3x2 형태의 행렬을 정의합니다.
    /// </summary>
    public struct Matrix3x2 : INearlyEquatable<Matrix3x2, float>, IFormattable, IMatrixType
    {
        /// <summary>
        /// [1, 1] 요소를 나타냅니다.
        /// </summary>
        public float _11;

        /// <summary>
        /// [1, 2] 요소를 나타냅니다.
        /// </summary>
        public float _12;

        /// <summary>
        /// [2, 1] 요소를 나타냅니다.
        /// </summary>
        public float _21;

        /// <summary>
        /// [2, 2] 요소를 나타냅니다.
        /// </summary>
        public float _22;

        /// <summary>
        /// [3, 1] 요소를 나타냅니다.
        /// </summary>
        public float _31;

        /// <summary>
        /// [3, 2] 요소를 나타냅니다.
        /// </summary>
        public float _32;

        /// <summary>
        /// 값을 모두 지정하여 <see cref="Matrix3x2"/> 구조체의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="_11"> [1, 1] 요소를 전달합니다. </param>
        /// <param name="_12"> [1, 2] 요소를 전달합니다. </param>
        /// <param name="_21"> [2, 1] 요소를 전달합니다. </param>
        /// <param name="_22"> [2, 2] 요소를 전달합니다. </param>
        /// <param name="_31"> [3, 1] 요소를 전달합니다. </param>
        /// <param name="_32"> [3, 2] 요소를 전달합니다. </param>
        public Matrix3x2(
            float _11, float _12,
            float _21, float _22,
            float _31, float _32
        )
        {
            this._11 = _11;
            this._12 = _12;
            this._21 = _21;
            this._22 = _22;
            this._31 = _31;
            this._32 = _32;
        }

        /// <summary>
        /// 각 행에 대한 벡터를 지정하여 <see cref="Matrix3x2"/> 구조체의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="v1"> 1행을 채우는 벡터를 전달합니다. </param>
        /// <param name="v2"> 2행을 채우는 벡터를 전달합니다. </param>
        /// <param name="v3"> 3행을 채우는 벡터를 전달합니다. </param>
        public Matrix3x2(Vector2 v1, Vector2 v2, Vector2 v3)
        {
            _11 = v1.X;
            _12 = v1.Y;
            _21 = v2.X;
            _22 = v2.Y;
            _31 = v3.X;
            _32 = v3.Y;
        }

        /// <summary>
        /// <see cref="Matrix3x2"/> 구조체의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="m2x2"> 2x2 행렬을 전달합니다. </param>
        /// <param name="v3"> 3행을 채우는 벡터를 전달합니다. </param>
        public Matrix3x2(Matrix2x2 m2x2, Vector2 v3)
        {
            _11 = m2x2._11;
            _12 = m2x2._12;
            _21 = m2x2._21;
            _22 = m2x2._22;
            _31 = v3.X;
            _32 = v3.Y;
        }

        /// <summary>
        /// 대상 오브젝트가 행렬일 경우, 두 행렬이 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="obj"> 대상 오브젝트를 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public override bool Equals(object obj)
        {
            if (obj is Matrix3x2 m)
            {
                return Equals(m);
            }
            else
            {
                return base.Equals(obj);
            }
        }

        /// <summary>
        /// 행렬의 전체 값의 해시 코드를 가져옵니다.
        /// </summary>
        /// <returns> 해시 코드가 반환됩니다. </returns>
        public override int GetHashCode()
        {
            return _11.GetHashCode() ^ _12.GetHashCode()
                ^ _21.GetHashCode() ^ _22.GetHashCode()
                ^ _31.GetHashCode() ^ _32.GetHashCode();
        }

        /// <summary>
        /// { {_11, _12} {_21, _22} {_31, _32} } 형식의 문자열을 가져옵니다.
        /// </summary>
        /// <returns> 생성된 문자열이 반환됩니다. </returns>
        public override string ToString()
        {
            return string.Format(
                "{{ {{{0}, {1}}} {{{2}, {3}}} {{{4}, {5}}} }}",
                _11, _12,
                _21, _22,
                _31, _32
            );
        }

        /// <summary>
        /// 두 행렬이 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="v"> 대상 행렬을 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public bool Equals(Matrix3x2 v)
        {
            return this == v;
        }

        /// <inheritdoc/>
        public bool NearlyEquals(Matrix3x2 right, float epsilon)
        {
            return Math.Abs(_11 - right._11) <= epsilon
                && Math.Abs(_12 - right._12) <= epsilon
                && Math.Abs(_21 - right._21) <= epsilon
                && Math.Abs(_22 - right._22) <= epsilon
                && Math.Abs(_31 - right._31) <= epsilon
                && Math.Abs(_32 - right._32) <= epsilon;
        }

        /// <summary>
        /// 서식을 지정하여 { {_11, _12} {_21, _22} {_31, _32} } 형식의 문자열을 가져옵니다.
        /// </summary>
        /// <param name="format"> 서식 문자열을 전달합니다. </param>
        /// <param name="formatProvider"> 문화권 정보를 전달합니다. </param>
        /// <returns> 생성된 문자열이 반환됩니다. </returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("{{ {{{0}, {1}}} {{{2}, {3}}} {{{4}, {5}}} }}",
                _11.ToString(format, formatProvider),
                _12.ToString(format, formatProvider),
                _21.ToString(format, formatProvider),
                _22.ToString(format, formatProvider),
                _31.ToString(format, formatProvider),
                _32.ToString(format, formatProvider)
                );
        }

        /// <inheritdoc/>
        public unsafe T GetComponentOrDefault<T>(int index) where T : IVectorType, new()
        {
            var v = new T();
            if (index < Count)
            {
                fixed (float* ptr = &_11)
                {
                    v.Construct(new Vector2(ptr[index * 2 + 0], ptr[index * 2 + 1]));
                }
            }
            return v;
        }

        /// <inheritdoc/>
        public void Construct<T>(T matrix) where T : IMatrixType
        {
            Vector2 v1;
            Vector2 v2;
            Vector2 v3;

            if (matrix is not null)
            {
                v1 = matrix.GetComponentOrDefault<Vector2>(0);
                v2 = matrix.GetComponentOrDefault<Vector2>(1);
                v3 = matrix.GetComponentOrDefault<Vector2>(2);
            }
            else
            {
                v1 = new Vector2();
                v2 = new Vector2();
                v3 = new Vector2();
            }

            _11 = v1.X;
            _12 = v1.Y;
            _21 = v2.X;
            _22 = v2.Y;
            _31 = v3.X;
            _32 = v3.Y;
        }

        /// <inheritdoc/>
        public T Convert<T>() where T : IMatrixType, new()
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
        public bool Contains(int row, int column)
        {
            return row >= 0 && row < 3 && column >= 0 && column < 2;
        }

        /// <inheritdoc/>
        public unsafe IVectorType this[int index]
        {
            get => GetComponentOrDefault<Vector2>(index);
            set
            {
                fixed (float* ptr = &_11)
                {
                    if (index < Count)
                    {
                        ptr[index * 2 + 0] = value[0];
                        ptr[index * 2 + 1] = value[1];
                    }
                }
            }
        }

        /// <inheritdoc/>
        public int Count
        {
            get => 3;
        }

        /// <inheritdoc/>
        public int Rows
        {
            get => 3;
        }

        /// <inheritdoc/>
        public int Columns
        {
            get => 2;
        }

        /// <summary>
        /// 이 행렬이 <see cref="Identity"/>와 거의 일치하는지 검사합니다.
        /// </summary>
        public bool IsIdentity
        {
            get => NearlyEquals(Identity, 0.0001f);
        }

        /// <summary>
        /// 두 행렬을 곱합니다.
        /// </summary>
        /// <param name="lhs"> 값을 전달합니다. </param>
        /// <param name="rhs"> 값을 전달합니다. </param>
        /// <returns> 행렬 값이 반환됩니다. </returns>
        public static Matrix3x2 Multiply(Matrix3x2 lhs, Matrix3x2 rhs)
        {
            Matrix3x2 m;

            m._11 = lhs._11 * rhs._11 + lhs._12 * rhs._21;
            m._12 = lhs._11 * rhs._12 + lhs._12 * rhs._22;

            // Second row
            m._21 = lhs._21 * rhs._11 + lhs._22 * rhs._21;
            m._22 = lhs._21 * rhs._12 + lhs._22 * rhs._22;

            // Third row
            m._31 = lhs._31 * rhs._11 + lhs._32 * rhs._21 + rhs._31;
            m._32 = lhs._31 * rhs._12 + lhs._32 * rhs._22 + rhs._32;

            return m;
        }

        /// <summary>
        /// 단위 행렬을 가져옵니다.
        /// </summary>
        public static Matrix3x2 Identity
        {
            get => new Matrix3x2(
                1, 0,
                0, 1,
                0, 0
            );
        }

        /// <summary>
        /// 두 행렬을 단순 덧셈한 행렬을 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 계산된 행렬이 반환됩니다. </returns>
        public static Matrix3x2 operator +(Matrix3x2 left, Matrix3x2 right)
        {
            return new Matrix3x2(
                left._11 + right._11, left._12 + right._12,
                left._21 + right._21, left._22 + right._22,
                left._31 + right._31, left._32 + right._32
                );
        }

        /// <summary>
        /// 두 행렬을 단순 뺄셈한 행렬을 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 계산된 행렬이 반환됩니다. </returns>
        public static Matrix3x2 operator -(Matrix3x2 left, Matrix3x2 right)
        {
            return new Matrix3x2(
                left._11 - right._11, left._12 - right._12,
                left._21 - right._21, left._22 - right._22,
                left._31 - right._31, left._32 - right._32
                );
        }

        /// <summary>
        /// 두 행렬을 단순 곱셈한 행렬을 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 계산된 행렬이 반환됩니다. </returns>
        public static Matrix3x2 operator *(Matrix3x2 left, Matrix3x2 right)
        {
            return new Matrix3x2(
                left._11 * right._11, left._12 * right._12,
                left._21 * right._21, left._22 * right._22,
                left._31 * right._31, left._32 * right._32
                );
        }

        /// <summary>
        /// 두 행렬을 단순 곱셈한 행렬을 가져옵니다. 스칼라 값은 모든 원소가 동일한 행렬으로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 계산된 행렬이 반환됩니다. </returns>
        public static Matrix3x2 operator *(float left, Matrix3x2 right)
        {
            return new Matrix3x2(
                left * right._11, left * right._12,
                left * right._21, left * right._22,
                left * right._31, left * right._32
                );
        }

        /// <summary>
        /// 두 행렬을 단순 곱셈한 행렬을 가져옵니다. 스칼라 값은 모든 원소가 동일한 행렬으로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 계산된 행렬이 반환됩니다. </returns>
        public static Matrix3x2 operator *(Matrix3x2 left, float right)
        {
            return new Matrix3x2(
                left._11 * right, left._12 * right,
                left._21 * right, left._22 * right,
                left._31 * right, left._32 * right
                );
        }

        /// <summary>
        /// 두 행렬을 단순 나눗셈한 행렬을 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 계산된 행렬이 반환됩니다. </returns>
        public static Matrix3x2 operator /(Matrix3x2 left, Matrix3x2 right)
        {
            return new Matrix3x2(
                left._11 / right._11, left._12 / right._12,
                left._21 / right._21, left._22 / right._22,
                left._31 / right._31, left._32 / right._32
                );
        }

        /// <summary>
        /// 두 행렬을 단순 나눗셈한 행렬을 가져옵니다. 스칼라 값은 모든 원소가 동일한 행렬으로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 계산된 행렬이 반환됩니다. </returns>
        public static Matrix3x2 operator /(float left, Matrix3x2 right)
        {
            return new Matrix3x2(
                left / right._11, left / right._12,
                left / right._21, left / right._22,
                left / right._31, left / right._32
                );
        }

        /// <summary>
        /// 두 행렬을 단순 나눗셈한 행렬을 가져옵니다. 스칼라 값은 모든 원소가 동일한 행렬으로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 계산된 행렬이 반환됩니다. </returns>
        public static Matrix3x2 operator /(Matrix3x2 left, float right)
        {
            return new Matrix3x2(
                left._11 / right, left._12 / right,
                left._21 / right, left._22 / right,
                left._31 / right, left._32 / right
                );
        }

        /// <summary>
        /// 두 행렬이 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator ==(Matrix3x2 left, Matrix3x2 right)
        {
            return left._11 == right._11 && left._12 == right._12
                && left._21 == right._21 && left._22 == right._22
                && left._31 == right._31 && left._32 == right._32;
        }

        /// <summary>
        /// 두 행렬이 서로 같지 않은지 비교합니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator !=(Matrix3x2 left, Matrix3x2 right)
        {
            return left._11 != right._11 || left._12 != right._12
                || left._21 != right._21 || left._22 != right._22
                || left._31 != right._31 || left._32 != right._32;
        }

        /// <summary>
        /// 이동 행렬을 계선합니다.
        /// </summary>
        /// <param name="translation"> 이동 벡터를 전달합니다. </param>
        /// <returns> 행렬 값이 반환됩니다. </returns>
        public static Matrix3x2 Translation(Vector2 translation)
        {
            return new Matrix3x2(
                1.0f, 0.0f,
                0.0f, 1.0f,
                translation.X, translation.Y
                );
        }

        /// <summary>
        /// 비례 행렬을 계산합니다.
        /// </summary>
        /// <param name="scale"> 비례 벡터를 전달합니다. </param>
        /// <returns> 행렬 값이 반환됩니다. </returns>
        public static Matrix3x2 Scale(Vector2 scale)
        {
            return new Matrix3x2(
                scale.X, 0,
                0, scale.Y,
                0, 0
                );
        }

        /// <summary>
        /// 회전 행렬을 계산합니다.
        /// </summary>
        /// <param name="radAngle"> 회전 각도를 전달합니다. </param>
        /// <returns> 행렬 값이 반환됩니다. </returns>
        public static Matrix3x2 Rotation(float radAngle)
        {
            MathEx.SinCos(out float sin, out float cos, radAngle);

            return new Matrix3x2(
                cos, -sin,
                sin, cos,
                0, 0
                );
        }

        /// <summary>
        /// 전단 행렬을 계산합니다.
        /// </summary>
        /// <param name="shear"> 값을 전달합니다. </param>
        /// <returns> 행렬 값이 반환됩니다. </returns>
        public static Matrix3x2 Shear(Vector2 shear)
        {
            return new Matrix3x2(
                1, shear.Y,
                shear.X, 1,
                0, 1
                );
        }
    }
}
