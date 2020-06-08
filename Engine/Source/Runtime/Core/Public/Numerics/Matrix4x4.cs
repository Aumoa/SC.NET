// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.Engine.Runtime.Core.Numerics
{
    /// <summary>
    /// 4x4 형태의 행렬을 정의합니다.
    /// </summary>
    public struct Matrix4x4 : INearlyEquatable<Matrix4x4, float>, IFormattable, IMatrixType
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
        /// [1, 3] 요소를 나타냅니다.
        /// </summary>
        public float _13;

        /// <summary>
        /// [1, 4] 요소를 나타냅니다.
        /// </summary>
        public float _14;

        /// <summary>
        /// [2, 1] 요소를 나타냅니다.
        /// </summary>
        public float _21;

        /// <summary>
        /// [2, 2] 요소를 나타냅니다.
        /// </summary>
        public float _22;

        /// <summary>
        /// [2, 3] 요소를 나타냅니다.
        /// </summary>
        public float _23;

        /// <summary>
        /// [2, 4] 요소를 나타냅니다.
        /// </summary>
        public float _24;

        /// <summary>
        /// [3, 1] 요소를 나타냅니다.
        /// </summary>
        public float _31;

        /// <summary>
        /// [3, 2] 요소를 나타냅니다.
        /// </summary>
        public float _32;

        /// <summary>
        /// [3, 3] 요소를 나타냅니다.
        /// </summary>
        public float _33;

        /// <summary>
        /// [3, 4] 요소를 나타냅니다.
        /// </summary>
        public float _34;

        /// <summary>
        /// [4, 1] 요소를 나타냅니다.
        /// </summary>
        public float _41;

        /// <summary>
        /// [4, 2] 요소를 나타냅니다.
        /// </summary>
        public float _42;

        /// <summary>
        /// [4, 3] 요소를 나타냅니다.
        /// </summary>
        public float _43;

        /// <summary>
        /// [4, 4] 요소를 나타냅니다.
        /// </summary>
        public float _44;

        /// <summary>
        /// 값을 모두 지정하여 <see cref="Matrix4x4"/> 구조체의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="_11"> [1, 1] 요소를 전달합니다. </param>
        /// <param name="_12"> [1, 2] 요소를 전달합니다. </param>
        /// <param name="_13"> [1, 3] 요소를 전달합니다. </param>
        /// <param name="_14"> [1, 4] 요소를 전달합니다. </param>
        /// <param name="_21"> [2, 1] 요소를 전달합니다. </param>
        /// <param name="_22"> [2, 2] 요소를 전달합니다. </param>
        /// <param name="_23"> [2, 3] 요소를 전달합니다. </param>
        /// <param name="_24"> [2, 4] 요소를 전달합니다. </param>
        /// <param name="_31"> [3, 1] 요소를 전달합니다. </param>
        /// <param name="_32"> [3, 2] 요소를 전달합니다. </param>
        /// <param name="_33"> [3, 3] 요소를 전달합니다. </param>
        /// <param name="_34"> [3, 4] 요소를 전달합니다. </param>
        /// <param name="_41"> [4, 1] 요소를 전달합니다. </param>
        /// <param name="_42"> [4, 2] 요소를 전달합니다. </param>
        /// <param name="_43"> [4, 3] 요소를 전달합니다. </param>
        /// <param name="_44"> [4, 4] 요소를 전달합니다. </param>
        public Matrix4x4(
            float _11, float _12, float _13, float _14,
            float _21, float _22, float _23, float _24,
            float _31, float _32, float _33, float _34,
            float _41, float _42, float _43, float _44
        )
        {
            this._11 = _11;
            this._12 = _12;
            this._13 = _13;
            this._14 = _14;
            this._21 = _21;
            this._22 = _22;
            this._23 = _23;
            this._24 = _24;
            this._31 = _31;
            this._32 = _32;
            this._33 = _33;
            this._34 = _34;
            this._41 = _41;
            this._42 = _42;
            this._43 = _43;
            this._44 = _44;
        }

        /// <summary>
        /// 각 행에 대한 벡터를 지정하여 <see cref="Matrix4x4"/> 구조체의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="v1"> 1행을 채우는 벡터를 전달합니다. </param>
        /// <param name="v2"> 2행을 채우는 벡터를 전달합니다. </param>
        /// <param name="v3"> 3행을 채우는 벡터를 전달합니다. </param>
        /// <param name="v4"> 4행을 채우는 벡터를 전달합니다. </param>
        public Matrix4x4(Vector4 v1, Vector4 v2, Vector4 v3, Vector4 v4)
        {
            _11 = v1.X;
            _12 = v1.Y;
            _13 = v1.Z;
            _14 = v1.W;

            _21 = v2.X;
            _22 = v2.Y;
            _23 = v2.Z;
            _24 = v2.W;

            _31 = v3.X;
            _32 = v3.Y;
            _33 = v3.Z;
            _34 = v3.W;

            _41 = v4.X;
            _42 = v4.Y;
            _43 = v4.Z;
            _44 = v4.W;
        }

        /// <summary>
        /// 대상 오브젝트가 행렬일 경우, 두 행렬이 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="obj"> 대상 오브젝트를 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public override bool Equals(object obj)
        {
            if (obj is Matrix4x4 m)
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
            return _11.GetHashCode() ^ _12.GetHashCode() ^ _13.GetHashCode() ^ _14.GetHashCode()
                ^ _21.GetHashCode() ^ _22.GetHashCode() ^ _23.GetHashCode() ^ _24.GetHashCode()
                ^ _31.GetHashCode() ^ _32.GetHashCode() ^ _33.GetHashCode() ^ _34.GetHashCode()
                ^ _41.GetHashCode() ^ _42.GetHashCode() ^ _43.GetHashCode() ^ _44.GetHashCode();
        }

        /// <summary>
        /// { {_11, _12, _13, _14} {_21, _22, _23, _24} {_31, _32, _33, _34} {_41, _42, _43, _44} } 형식의 문자열을 가져옵니다.
        /// </summary>
        /// <returns> 생성된 문자열이 반환됩니다. </returns>
        public override string ToString()
        {
            return string.Format("{{ {{{0}, {1}, {2}, {3}}} {{{4}, {5}, {6}, {7}}} {{{8}, {9}, {10}, {11}}} {{{12}, {13}, {14}, {15}}} }}",
                _11, _12, _13, _14,
                _21, _22, _23, _24,
                _31, _32, _33, _34,
                _41, _42, _43, _44
            );
        }

        /// <summary>
        /// 두 행렬이 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="v"> 대상 행렬을 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public bool Equals(Matrix4x4 v)
        {
            return this == v;
        }

        /// <inheritdoc/>
        public bool NearlyEquals(in Matrix4x4 right, float epsilon)
        {
            return Math.Abs(_11 - right._11) <= epsilon
                && Math.Abs(_12 - right._12) <= epsilon
                && Math.Abs(_13 - right._13) <= epsilon
                && Math.Abs(_14 - right._14) <= epsilon
                && Math.Abs(_21 - right._21) <= epsilon
                && Math.Abs(_22 - right._22) <= epsilon
                && Math.Abs(_23 - right._23) <= epsilon
                && Math.Abs(_24 - right._24) <= epsilon
                && Math.Abs(_31 - right._31) <= epsilon
                && Math.Abs(_32 - right._32) <= epsilon
                && Math.Abs(_33 - right._33) <= epsilon
                && Math.Abs(_34 - right._34) <= epsilon
                && Math.Abs(_41 - right._41) <= epsilon
                && Math.Abs(_42 - right._42) <= epsilon
                && Math.Abs(_43 - right._43) <= epsilon
                && Math.Abs(_44 - right._44) <= epsilon;
        }

        /// <summary>
        /// 서식을 지정하여 { {_11, _12, _13, _14} {_21, _22, _23, _24} {_31, _32, _33, _34} {_41, _42, _43, _44} } 형식의 문자열을 가져옵니다.
        /// </summary>
        /// <param name="format"> 서식 문자열을 전달합니다. </param>
        /// <param name="formatProvider"> 문화권 정보를 전달합니다. </param>
        /// <returns> 생성된 문자열이 반환됩니다. </returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("{{ {{{0}, {1}, {2}, {3}}} {{{4}, {5}, {6}, {7}}} {{{8}, {9}, {10}, {11}}} {{{12}, {13}, {14}, {15}}} }}",
                _11.ToString(format, formatProvider),
                _12.ToString(format, formatProvider),
                _13.ToString(format, formatProvider),
                _14.ToString(format, formatProvider),
                _21.ToString(format, formatProvider),
                _22.ToString(format, formatProvider),
                _23.ToString(format, formatProvider),
                _24.ToString(format, formatProvider),
                _31.ToString(format, formatProvider),
                _32.ToString(format, formatProvider),
                _33.ToString(format, formatProvider),
                _34.ToString(format, formatProvider),
                _41.ToString(format, formatProvider),
                _42.ToString(format, formatProvider),
                _43.ToString(format, formatProvider),
                _44.ToString(format, formatProvider));
        }

        /// <inheritdoc/>
        public T GetComponentOrDefault<T>(int index) where T : IVectorType, new()
        {
            var v = new T();
            v.Construct(index switch
            {
                0 => new Vector4(_11, _12, _13, _14),
                1 => new Vector4(_21, _22, _23, _24),
                2 => new Vector4(_31, _32, _33, _34),
                3 => new Vector4(_41, _42, _43, _44),
                _ => default
            });
            return v;
        }

        /// <inheritdoc/>
        public void Construct<T>(in T matrix) where T : IMatrixType
        {
            Vector4 v1;
            Vector4 v2;
            Vector4 v3;
            Vector4 v4;

            if (matrix is not null)
            {
                v1 = matrix.GetComponentOrDefault<Vector4>(0);
                v2 = matrix.GetComponentOrDefault<Vector4>(1);
                v3 = matrix.GetComponentOrDefault<Vector4>(2);
                v4 = matrix.GetComponentOrDefault<Vector4>(3);
            }
            else
            {
                v1 = default;
                v2 = default;
                v3 = default;
                v4 = default;
            }

            _11 = v1.X;
            _12 = v1.Y;
            _13 = v1.Z;
            _14 = v1.W;

            _21 = v2.X;
            _22 = v2.Y;
            _23 = v2.Z;
            _24 = v2.W;

            _31 = v3.X;
            _32 = v3.Y;
            _33 = v3.Z;
            _34 = v3.W;

            _41 = v4.X;
            _42 = v4.Y;
            _43 = v4.Z;
            _44 = v4.W;
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
            return index >= 0 && index < 4;
        }

        /// <inheritdoc/>
        public bool Contains(int row, int column)
        {
            return row >= 0 && row < 4 && column >= 0 && column < 4;
        }

        /// <inheritdoc/>
        public IVectorType this[int index]
        {
            get => GetComponentOrDefault<Vector4>(index);
            set
            {
                switch (index)
                {
                    case 0:
                        _11 = value[0];
                        _12 = value[1];
                        _13 = value[2];
                        _14 = value[3];
                        break;
                    case 1:
                        _21 = value[0];
                        _22 = value[1];
                        _23 = value[2];
                        _24 = value[3];
                        break;
                    case 2:
                        _31 = value[0];
                        _32 = value[1];
                        _33 = value[2];
                        _34 = value[3];
                        break;
                    case 3:
                        _41 = value[0];
                        _42 = value[1];
                        _43 = value[2];
                        _44 = value[3];
                        break;
                }
            }
        }

        /// <inheritdoc/>
        public int Count
        {
            get => 4;
        }

        /// <inheritdoc/>
        public int Rows
        {
            get => 4;
        }

        /// <inheritdoc/>
        public int Columns
        {
            get => 4;
        }

        /// <summary>
        /// 이 행렬을 이 행렬의 전치 행렬로 변환합니다.
        /// </summary>
        public void Transpose()
        {
            Swap(ref _12, ref _21);
            Swap(ref _13, ref _31);
            Swap(ref _14, ref _41);
            Swap(ref _23, ref _32);
            Swap(ref _24, ref _42);
            Swap(ref _34, ref _43);
        }

        /// <summary>
        /// 이 행렬을 이 행렬의 역행렬로 변환합니다.
        /// </summary>
        public void Invert()
        {
            this = Inverse;
        }

        /// <summary>
        /// 이 행렬이 <see cref="Identity"/>와 거의 일치하는지 검사합니다.
        /// </summary>
        public bool IsIdentity
        {
            get => NearlyEquals(Identity, 0.0001f);
        }

        /// <summary>
        /// 이 행렬의 행렬식을 계산합니다.
        /// </summary>
        public float Determinant
        {
            get =>
                _14 * _23 * _32 * _41 - _13 * _24 * _32 * _41 -
                _14 * _22 * _33 * _41 + _12 * _24 * _33 * _41 +
                _13 * _22 * _34 * _41 - _12 * _23 * _34 * _41 -
                _14 * _23 * _31 * _42 + _13 * _24 * _31 * _42 +
                _14 * _21 * _33 * _42 - _11 * _24 * _33 * _42 -
                _13 * _21 * _34 * _42 + _11 * _23 * _34 * _42 +
                _14 * _22 * _31 * _43 - _12 * _24 * _31 * _43 -
                _14 * _21 * _32 * _43 + _11 * _24 * _32 * _43 +
                _12 * _21 * _34 * _43 - _11 * _22 * _34 * _43 -
                _13 * _22 * _31 * _44 + _12 * _23 * _31 * _44 +
                _13 * _21 * _32 * _44 - _11 * _23 * _32 * _44 -
                _12 * _21 * _33 * _44 + _11 * _22 * _33 * _44;
        }

        /// <summary>
        /// 이 행렬의 역행렬을 가져옵니다.
        /// </summary>
        public Matrix4x4 Inverse
        {
            get
            {
                var A2323 = _33 * _44 - _34 * _43;
                var A1323 = _32 * _44 - _34 * _42;
                var A1223 = _32 * _43 - _33 * _42;
                var A0323 = _31 * _44 - _34 * _41;
                var A0223 = _31 * _43 - _33 * _41;
                var A0123 = _31 * _42 - _32 * _41;
                var A2313 = _23 * _44 - _24 * _43;
                var A1313 = _22 * _44 - _24 * _42;
                var A1213 = _22 * _43 - _23 * _42;
                var A2312 = _23 * _34 - _24 * _33;
                var A1312 = _22 * _34 - _24 * _32;
                var A1212 = _22 * _33 - _23 * _32;
                var A0313 = _21 * _44 - _24 * _41;
                var A0213 = _21 * _43 - _23 * _41;
                var A0312 = _21 * _34 - _24 * _31;
                var A0212 = _21 * _33 - _23 * _31;
                var A0113 = _21 * _42 - _22 * _41;
                var A0112 = _21 * _32 - _22 * _31;

                var det
                    = _11 * (_22 * A2323 - _23 * A1323 + _24 * A1223)
                    - _12 * (_21 * A2323 - _23 * A0323 + _24 * A0223)
                    + _13 * (_21 * A1323 - _22 * A0323 + _24 * A0123)
                    - _14 * (_21 * A1223 - _22 * A0223 + _23 * A0123);
                det = 1 / det;

                return new Matrix4x4(
                    det * (_22 * A2323 - _23 * A1323 + _24 * A1223),
                    det * -(_12 * A2323 - _13 * A1323 + _14 * A1223),
                    det * (_12 * A2313 - _13 * A1313 + _14 * A1213),
                    det * -(_12 * A2312 - _13 * A1312 + _14 * A1212),
                    det * -(_21 * A2323 - _23 * A0323 + _24 * A0223),
                    det * (_11 * A2323 - _13 * A0323 + _14 * A0223),
                    det * -(_11 * A2313 - _13 * A0313 + _14 * A0213),
                    det * (_11 * A2312 - _13 * A0312 + _14 * A0212),
                    det * (_21 * A1323 - _22 * A0323 + _24 * A0123),
                    det * -(_11 * A1323 - _12 * A0323 + _14 * A0123),
                    det * (_11 * A1313 - _12 * A0313 + _14 * A0113),
                    det * -(_11 * A1312 - _12 * A0312 + _14 * A0112),
                    det * -(_21 * A1223 - _22 * A0223 + _23 * A0123),
                    det * (_11 * A1223 - _12 * A0223 + _13 * A0123),
                    det * -(_11 * A1213 - _12 * A0213 + _13 * A0113),
                    det * (_11 * A1212 - _12 * A0212 + _13 * A0112)
                    );
            }
        }

        /// <summary>
        /// 이 행렬의 전치 행렬을 가져옵니다.
        /// </summary>
        public Matrix4x4 Transposed
        {
            get => new Matrix4x4(
                _11, _21, _31, _41,
                _12, _22, _32, _42,
                _13, _23, _33, _43,
                _14, _24, _34, _44
            );
        }

        /// <summary>
        /// 단위 행렬을 가져옵니다.
        /// </summary>
        public static Matrix4x4 Identity
        {
            get => new Matrix4x4(
                1, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1
            );
        }

        /// <summary>
        /// 두 행렬을 단순 덧셈한 행렬을 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 계산된 행렬이 반환됩니다. </returns>
        public static Matrix4x4 operator +(Matrix4x4 left, Matrix4x4 right)
        {
            return new Matrix4x4(
                left._11 + right._11, left._12 + right._12, left._13 + right._13, left._14 + right._14,
                left._21 + right._21, left._22 + right._22, left._23 + right._23, left._24 + right._24,
                left._31 + right._31, left._32 + right._32, left._33 + right._33, left._34 + right._34,
                left._41 + right._41, left._42 + right._42, left._43 + right._43, left._44 + right._44
            );
        }

        /// <summary>
        /// 두 행렬을 단순 뺄셈한 행렬을 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 계산된 행렬이 반환됩니다. </returns>
        public static Matrix4x4 operator -(Matrix4x4 left, Matrix4x4 right)
        {
            return new Matrix4x4(
                left._11 - right._11, left._12 - right._12, left._13 - right._13, left._14 - right._14,
                left._21 - right._21, left._22 - right._22, left._23 - right._23, left._24 - right._24,
                left._31 - right._31, left._32 - right._32, left._33 - right._33, left._34 - right._34,
                left._41 - right._41, left._42 - right._42, left._43 - right._43, left._44 - right._44
            );
        }

        /// <summary>
        /// 두 행렬을 단순 곱셈한 행렬을 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 계산된 행렬이 반환됩니다. </returns>
        public static Matrix4x4 operator *(Matrix4x4 left, Matrix4x4 right)
        {
            return new Matrix4x4(
                left._11 * right._11, left._12 * right._12, left._13 * right._13, left._14 * right._14,
                left._21 * right._21, left._22 * right._22, left._23 * right._23, left._24 * right._24,
                left._31 * right._31, left._32 * right._32, left._33 * right._33, left._34 * right._34,
                left._41 * right._41, left._42 * right._42, left._43 * right._43, left._44 * right._44
            );
        }

        /// <summary>
        /// 두 행렬을 단순 곱셈한 행렬을 가져옵니다. 스칼라 값은 모든 원소가 동일한 행렬으로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 계산된 행렬이 반환됩니다. </returns>
        public static Matrix4x4 operator *(float left, Matrix4x4 right)
        {
            return new Matrix4x4(
                left * right._11, left * right._12, left * right._13, left * right._14,
                left * right._21, left * right._22, left * right._23, left * right._24,
                left * right._31, left * right._32, left * right._33, left * right._34,
                left * right._41, left * right._42, left * right._43, left * right._44
            );
        }

        /// <summary>
        /// 두 행렬을 단순 곱셈한 행렬을 가져옵니다. 스칼라 값은 모든 원소가 동일한 행렬으로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 계산된 행렬이 반환됩니다. </returns>
        public static Matrix4x4 operator *(Matrix4x4 left, float right)
        {
            return new Matrix4x4(
                left._11 * right, left._12 * right, left._13 * right, left._14 * right,
                left._21 * right, left._22 * right, left._23 * right, left._24 * right,
                left._31 * right, left._32 * right, left._33 * right, left._34 * right,
                left._41 * right, left._42 * right, left._43 * right, left._44 * right
            );
        }

        /// <summary>
        /// 두 행렬을 단순 나눗셈한 행렬을 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 계산된 행렬이 반환됩니다. </returns>
        public static Matrix4x4 operator /(Matrix4x4 left, Matrix4x4 right)
        {
            return new Matrix4x4(
                left._11 / right._11, left._12 / right._12, left._13 / right._13, left._14 / right._14,
                left._21 / right._21, left._22 / right._22, left._23 / right._23, left._24 / right._24,
                left._31 / right._31, left._32 / right._32, left._33 / right._33, left._34 / right._34,
                left._41 / right._41, left._42 / right._42, left._43 / right._43, left._44 / right._44
            );
        }

        /// <summary>
        /// 두 행렬을 단순 나눗셈한 행렬을 가져옵니다. 스칼라 값은 모든 원소가 동일한 행렬으로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 계산된 행렬이 반환됩니다. </returns>
        public static Matrix4x4 operator /(float left, Matrix4x4 right)
        {
            return new Matrix4x4(
                left / right._11, left / right._12, left / right._13, left / right._14,
                left / right._21, left / right._22, left / right._23, left / right._24,
                left / right._31, left / right._32, left / right._33, left / right._34,
                left / right._41, left / right._42, left / right._43, left / right._44
            );
        }

        /// <summary>
        /// 두 행렬을 단순 나눗셈한 행렬을 가져옵니다. 스칼라 값은 모든 원소가 동일한 행렬으로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 계산된 행렬이 반환됩니다. </returns>
        public static Matrix4x4 operator /(Matrix4x4 left, float right)
        {
            return new Matrix4x4(
                left._11 / right, left._12 / right, left._13 / right, left._14 / right,
                left._21 / right, left._22 / right, left._23 / right, left._24 / right,
                left._31 / right, left._32 / right, left._33 / right, left._34 / right,
                left._41 / right, left._42 / right, left._43 / right, left._44 / right
            );
        }

        /// <summary>
        /// 두 행렬이 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator ==(Matrix4x4 left, Matrix4x4 right)
        {
            return left._11 == right._11 && left._12 == right._12 && left._13 == right._13 && left._14 == right._14
                && left._21 == right._21 && left._22 == right._22 && left._23 == right._23 && left._24 == right._24
                && left._31 == right._31 && left._32 == right._32 && left._33 == right._33 && left._34 == right._34
                && left._41 == right._41 && left._42 == right._42 && left._43 == right._43 && left._44 == right._44;
        }

        /// <summary>
        /// 두 행렬이 서로 같지 않은지 비교합니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator !=(Matrix4x4 left, Matrix4x4 right)
        {
            return left._11 != right._11 || left._12 != right._12 || left._13 != right._13 || left._14 != right._14
                || left._21 != right._21 || left._22 != right._22 || left._23 != right._23 || left._24 != right._24
                || left._31 != right._31 || left._32 != right._32 || left._33 != right._33 || left._34 != right._34
                || left._41 != right._41 || left._42 != right._42 || left._43 != right._43 || left._44 != right._44;
        }

        static void Swap(ref float left, ref float right)
        {
            float temp = left;
            left = right;
            right = temp;
        }
    };
}