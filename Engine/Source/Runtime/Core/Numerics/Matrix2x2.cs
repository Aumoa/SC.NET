// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using SC.Engine.Runtime.Core.Mathematics;

namespace SC.Engine.Runtime.Core.Numerics
{
    /// <summary>
    /// 2x2 형태의 행렬을 정의합니다.
    /// </summary>
    public struct Matrix2x2 : INearlyEquatable<Matrix2x2, float>, IFormattable, IMatrixType
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
        /// 값을 모두 지정하여 <see cref="Matrix2x2"/> 구조체의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="_11"> [1, 1] 요소를 전달합니다. </param>
        /// <param name="_12"> [1, 2] 요소를 전달합니다. </param>
        /// <param name="_21"> [2, 1] 요소를 전달합니다. </param>
        /// <param name="_22"> [2, 2] 요소를 전달합니다. </param>
        public Matrix2x2(
            float _11, float _12,
            float _21, float _22
        )
        {
            this._11 = _11;
            this._12 = _12;
            this._21 = _21;
            this._22 = _22;
        }

        /// <summary>
        /// 각 행에 대한 벡터를 지정하여 <see cref="Matrix2x2"/> 구조체의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="v1"> 1행을 채우는 벡터를 전달합니다. </param>
        /// <param name="v2"> 2행을 채우는 벡터를 전달합니다. </param>
        public Matrix2x2(Vector2 v1, Vector2 v2)
        {
            _11 = v1.X;
            _12 = v1.Y;
            _21 = v2.X;
            _22 = v2.Y;
        }

        /// <summary>
        /// 대상 오브젝트가 행렬일 경우, 두 행렬이 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="obj"> 대상 오브젝트를 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public override bool Equals(object obj)
        {
            if (obj is Matrix2x2 m)
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
                ^ _21.GetHashCode() ^ _22.GetHashCode();
        }

        /// <summary>
        /// { {_11, _12} {_21, _22} } 형식의 문자열을 가져옵니다.
        /// </summary>
        /// <returns> 생성된 문자열이 반환됩니다. </returns>
        public override string ToString()
        {
            return string.Format(
                "{{ {{{0}, {1}}} {{{2}, {3}}} }}",
                _11, _12,
                _21, _22
            );
        }

        /// <summary>
        /// 두 행렬이 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="v"> 대상 행렬을 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public bool Equals(Matrix2x2 v)
        {
            return this == v;
        }

        /// <inheritdoc/>
        public bool NearlyEquals(Matrix2x2 right, float epsilon)
        {
            return Math.Abs(_11 - right._11) <= epsilon
                && Math.Abs(_12 - right._12) <= epsilon
                && Math.Abs(_21 - right._21) <= epsilon
                && Math.Abs(_22 - right._22) <= epsilon;
        }

        /// <summary>
        /// 서식을 지정하여 { {_11, _12} {_21, _22} } 형식의 문자열을 가져옵니다.
        /// </summary>
        /// <param name="format"> 서식 문자열을 전달합니다. </param>
        /// <param name="formatProvider"> 문화권 정보를 전달합니다. </param>
        /// <returns> 생성된 문자열이 반환됩니다. </returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("{{ {{{0}, {1}}} {{{2}, {3}}} }}",
                _11.ToString(format, formatProvider),
                _12.ToString(format, formatProvider),
                _21.ToString(format, formatProvider),
                _22.ToString(format, formatProvider)
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

            if (matrix is not null)
            {
                v1 = matrix.GetComponentOrDefault<Vector2>(0);
                v2 = matrix.GetComponentOrDefault<Vector2>(1);
            }
            else
            {
                v1 = new Vector2();
                v2 = new Vector2();
            }

            _11 = v1.X;
            _12 = v1.Y;
            _21 = v2.X;
            _22 = v2.Y;
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
            return index >= 0 && index < 2;
        }

        /// <inheritdoc/>
        public bool Contains(int row, int column)
        {
            return row >= 0 && row < 2 && column >= 0 && column < 2;
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
            get => 2;
        }

        /// <inheritdoc/>
        public int Rows
        {
            get => 2;
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
        public static Matrix2x2 Multiply(Matrix2x2 lhs, Matrix2x2 rhs)
        {
            Matrix2x2 m;
            m._11 = lhs._11 * rhs._11 + lhs._12 * rhs._21;
            m._12 = lhs._11 * rhs._12 + lhs._12 * rhs._22;
            m._21 = lhs._21 * rhs._11 + lhs._22 * rhs._21;
            m._22 = lhs._21 * rhs._12 + lhs._22 * rhs._22;
            return m;
        }

        /// <summary>
        /// 단위 행렬을 가져옵니다.
        /// </summary>
        public static Matrix2x2 Identity
        {
            get => new Matrix2x2(
                1, 0,
                0, 1
            );
        }

        /// <summary>
        /// 두 행렬을 단순 덧셈한 행렬을 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 계산된 행렬이 반환됩니다. </returns>
        public static Matrix2x2 operator +(Matrix2x2 left, Matrix2x2 right)
        {
            return new Matrix2x2(
                left._11 + right._11, left._12 + right._12,
                left._21 + right._21, left._22 + right._22
                );
        }

        /// <summary>
        /// 두 행렬을 단순 뺄셈한 행렬을 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 계산된 행렬이 반환됩니다. </returns>
        public static Matrix2x2 operator -(Matrix2x2 left, Matrix2x2 right)
        {
            return new Matrix2x2(
                left._11 - right._11, left._12 - right._12,
                left._21 - right._21, left._22 - right._22
                );
        }

        /// <summary>
        /// 두 행렬을 단순 곱셈한 행렬을 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 계산된 행렬이 반환됩니다. </returns>
        public static Matrix2x2 operator *(Matrix2x2 left, Matrix2x2 right)
        {
            return new Matrix2x2(
                left._11 * right._11, left._12 * right._12,
                left._21 * right._21, left._22 * right._22
                );
        }

        /// <summary>
        /// 두 행렬을 단순 곱셈한 행렬을 가져옵니다. 스칼라 값은 모든 원소가 동일한 행렬으로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 계산된 행렬이 반환됩니다. </returns>
        public static Matrix2x2 operator *(float left, Matrix2x2 right)
        {
            return new Matrix2x2(
                left * right._11, left * right._12,
                left * right._21, left * right._22
                );
        }

        /// <summary>
        /// 두 행렬을 단순 곱셈한 행렬을 가져옵니다. 스칼라 값은 모든 원소가 동일한 행렬으로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 계산된 행렬이 반환됩니다. </returns>
        public static Matrix2x2 operator *(Matrix2x2 left, float right)
        {
            return new Matrix2x2(
                left._11 * right, left._12 * right,
                left._21 * right, left._22 * right
                );
        }

        /// <summary>
        /// 두 행렬을 단순 나눗셈한 행렬을 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 계산된 행렬이 반환됩니다. </returns>
        public static Matrix2x2 operator /(Matrix2x2 left, Matrix2x2 right)
        {
            return new Matrix2x2(
                left._11 / right._11, left._12 / right._12,
                left._21 / right._21, left._22 / right._22
                );
        }

        /// <summary>
        /// 두 행렬을 단순 나눗셈한 행렬을 가져옵니다. 스칼라 값은 모든 원소가 동일한 행렬으로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 계산된 행렬이 반환됩니다. </returns>
        public static Matrix2x2 operator /(float left, Matrix2x2 right)
        {
            return new Matrix2x2(
                left / right._11, left / right._12,
                left / right._21, left / right._22
                );
        }

        /// <summary>
        /// 두 행렬을 단순 나눗셈한 행렬을 가져옵니다. 스칼라 값은 모든 원소가 동일한 행렬으로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 계산된 행렬이 반환됩니다. </returns>
        public static Matrix2x2 operator /(Matrix2x2 left, float right)
        {
            return new Matrix2x2(
                left._11 / right, left._12 / right,
                left._21 / right, left._22 / right
                );
        }

        /// <summary>
        /// 두 행렬이 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator ==(Matrix2x2 left, Matrix2x2 right)
        {
            return left._11 == right._11 && left._12 == right._12
                && left._21 == right._21 && left._22 == right._22;
        }

        /// <summary>
        /// 두 행렬이 서로 같지 않은지 비교합니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator !=(Matrix2x2 left, Matrix2x2 right)
        {
            return left._11 != right._11 || left._12 != right._12
                || left._21 != right._21 || left._22 != right._22;
        }

        /// <summary>
        /// 비례 행렬을 계산합니다.
        /// </summary>
        /// <param name="scale"> 비례 벡터를 전달합니다. </param>
        /// <returns> 행렬 값이 반환됩니다. </returns>
        public static Matrix2x2 Scale(Vector2 scale)
        {
            return new Matrix2x2(
                scale.X, 0,
                0, scale.Y
                );
        }

        /// <summary>
        /// 회전 행렬을 계산합니다.
        /// </summary>
        /// <param name="radAngle"> 회전 각도를 전달합니다. </param>
        /// <returns> 행렬 값이 반환됩니다. </returns>
        public static Matrix2x2 Rotation(float radAngle)
        {
            MathEx.SinCos(out float sin, out float cos, radAngle);

            return new Matrix2x2(
                cos, -sin,
                sin, cos
                );
        }

        /// <summary>
        /// 전단 행렬을 계산합니다.
        /// </summary>
        /// <param name="shear"> 값을 전달합니다. </param>
        /// <returns> 행렬 값이 반환됩니다. </returns>
        public static Matrix2x2 Shear(Vector2 shear)
        {
            return new Matrix2x2(
                1, shear.Y,
                shear.X, 1
                );
        }

        /// <summary>
        /// 위치를 변형합니다.
        /// </summary>
        /// <typeparam name="T"> 벡터 형식을 전달합니다. </typeparam>
        /// <param name="point"> 위치를 전달합니다. </param>
        /// <returns> 변형된 값이 반환됩니다. </returns>
        public T TransformPoint<T>(T point) where T : IVectorType, new()
        {
            var t = new T();
            t[0] = point[0] * _11 + point[1] * _21;
            t[1] = point[0] * _12 + point[1] * _22;
            return t;
        }

        /// <summary>
        /// 벡터를 변형합니다.
        /// </summary>
        /// <typeparam name="T"> 벡터 형식을 전달합니다. </typeparam>
        /// <param name="vector"> 벡터를 전달합니다. </param>
        /// <returns> 변형된 값이 반환됩니다. </returns>
        public T TransformVector<T>(T vector) where T : IVectorType, new() => TransformPoint(vector);

        /// <summary>
        /// 이 행렬의 역행렬을 가져옵니다.
        /// </summary>
        public Matrix2x2 Inverse
        {
            get
            {
                float invDet = 1.0f / Determinant;
                return new Matrix2x2(
                    _22 * invDet, -_12 * invDet,
                    -_21 * invDet, _11 * invDet
                    );
            }
        }

        /// <summary>
        /// 이 행렬의 행렬식을 계산합니다.
        /// </summary>
        public float Determinant => _11 * _22 - _12 * _21;
    }
}
