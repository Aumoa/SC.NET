// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;

using SC.Engine.Runtime.Core.Mathematics;

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

        /// <summary>
        /// 4차원 벡터로 값을 설정합니다.
        /// </summary>
        /// <param name="index"> 행 번호를 전달합니다. </param>
        /// <param name="value"> 값을 전달합니다. </param>
        public void SetRow(int index, Vector4 value)
        {
            switch (index)
            {
                case 0:
                    _11 = value.X;
                    _12 = value.Y;
                    _13 = value.Z;
                    _14 = value.W;
                    break;
                case 1:
                    _21 = value.X;
                    _22 = value.Y;
                    _23 = value.Z;
                    _24 = value.W;
                    break;
                case 2:
                    _31 = value.X;
                    _32 = value.Y;
                    _33 = value.Z;
                    _34 = value.W;
                    break;
                case 3:
                    _41 = value.X;
                    _42 = value.Y;
                    _43 = value.Z;
                    _44 = value.W;
                    break;
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
        public unsafe Matrix4x4 Inverse
        {
            get
            {
                if (Sse.IsSupported)
                {
                    Matrix4x4 result;

                    // Load the matrix values into rows
                    Vector128<float> row1 = Sse.LoadVector128(&result._11);
                    Vector128<float> row2 = Sse.LoadVector128(&result._21);
                    Vector128<float> row3 = Sse.LoadVector128(&result._31);
                    Vector128<float> row4 = Sse.LoadVector128(&result._41);

                    // Transpose the matrix
                    Vector128<float> vTemp1 = Sse.Shuffle(row1, row2, 0x44); //_MM_SHUFFLE(1, 0, 1, 0)
                    Vector128<float> vTemp3 = Sse.Shuffle(row1, row2, 0xEE); //_MM_SHUFFLE(3, 2, 3, 2)
                    Vector128<float> vTemp2 = Sse.Shuffle(row3, row4, 0x44); //_MM_SHUFFLE(1, 0, 1, 0)
                    Vector128<float> vTemp4 = Sse.Shuffle(row3, row4, 0xEE); //_MM_SHUFFLE(3, 2, 3, 2)

                    row1 = Sse.Shuffle(vTemp1, vTemp2, 0x88); //_MM_SHUFFLE(2, 0, 2, 0)
                    row2 = Sse.Shuffle(vTemp1, vTemp2, 0xDD); //_MM_SHUFFLE(3, 1, 3, 1)
                    row3 = Sse.Shuffle(vTemp3, vTemp4, 0x88); //_MM_SHUFFLE(2, 0, 2, 0)
                    row4 = Sse.Shuffle(vTemp3, vTemp4, 0xDD); //_MM_SHUFFLE(3, 1, 3, 1)

                    Vector128<float> V00 = Sse.Shuffle(row3, row3, 0x50);           //_MM_SHUFFLE(1, 1, 0, 0)
                    Vector128<float> V10 = Sse.Shuffle(row4, row4, 0xEE);           //_MM_SHUFFLE(3, 2, 3, 2)
                    Vector128<float> V01 = Sse.Shuffle(row1, row1, 0x50);           //_MM_SHUFFLE(1, 1, 0, 0)
                    Vector128<float> V11 = Sse.Shuffle(row2, row2, 0xEE);           //_MM_SHUFFLE(3, 2, 3, 2)
                    Vector128<float> V02 = Sse.Shuffle(row3, row1, 0x88); //_MM_SHUFFLE(2, 0, 2, 0)
                    Vector128<float> V12 = Sse.Shuffle(row4, row2, 0xDD); //_MM_SHUFFLE(3, 1, 3, 1)

                    Vector128<float> D0 = Sse.Multiply(V00, V10);
                    Vector128<float> D1 = Sse.Multiply(V01, V11);
                    Vector128<float> D2 = Sse.Multiply(V02, V12);

                    V00 = Sse.Shuffle(row3, row3, 0xEE);           //_MM_SHUFFLE(3, 2, 3, 2)
                    V10 = Sse.Shuffle(row4, row4, 0x50);           //_MM_SHUFFLE(1, 1, 0, 0)
                    V01 = Sse.Shuffle(row1, row1, 0xEE);           //_MM_SHUFFLE(3, 2, 3, 2)
                    V11 = Sse.Shuffle(row2, row2, 0x50);           //_MM_SHUFFLE(1, 1, 0, 0)
                    V02 = Sse.Shuffle(row3, row1, 0xDD); //_MM_SHUFFLE(3, 1, 3, 1)
                    V12 = Sse.Shuffle(row4, row2, 0x88); //_MM_SHUFFLE(2, 0, 2, 0)

                    // Note:  We use this expansion pattern instead of Fused Multiply Add
                    // in order to support older hardware
                    D0 = Sse.Subtract(D0, Sse.Multiply(V00, V10));
                    D1 = Sse.Subtract(D1, Sse.Multiply(V01, V11));
                    D2 = Sse.Subtract(D2, Sse.Multiply(V02, V12));

                    // V11 = D0Y,D0W,D2Y,D2Y
                    V11 = Sse.Shuffle(D0, D2, 0x5D);  //_MM_SHUFFLE(1, 1, 3, 1)
                    V00 = Sse.Shuffle(row2, row2, 0x49);        //_MM_SHUFFLE(1, 0, 2, 1)
                    V10 = Sse.Shuffle(V11, D0, 0x32); //_MM_SHUFFLE(0, 3, 0, 2)
                    V01 = Sse.Shuffle(row1, row1, 0x12);        //_MM_SHUFFLE(0, 1, 0, 2)
                    V11 = Sse.Shuffle(V11, D0, 0x99); //_MM_SHUFFLE(2, 1, 2, 1)

                    // V13 = D1Y,D1W,D2W,D2W
                    Vector128<float> V13 = Sse.Shuffle(D1, D2, 0xFD); //_MM_SHUFFLE(3, 3, 3, 1)
                    V02 = Sse.Shuffle(row4, row4, 0x49);                        //_MM_SHUFFLE(1, 0, 2, 1)
                    V12 = Sse.Shuffle(V13, D1, 0x32);                 //_MM_SHUFFLE(0, 3, 0, 2)
                    Vector128<float> V03 = Sse.Shuffle(row3, row3, 0x12);       //_MM_SHUFFLE(0, 1, 0, 2)
                    V13 = Sse.Shuffle(V13, D1, 0x99);                 //_MM_SHUFFLE(2, 1, 2, 1)

                    Vector128<float> C0 = Sse.Multiply(V00, V10);
                    Vector128<float> C2 = Sse.Multiply(V01, V11);
                    Vector128<float> C4 = Sse.Multiply(V02, V12);
                    Vector128<float> C6 = Sse.Multiply(V03, V13);

                    // V11 = D0X,D0Y,D2X,D2X
                    V11 = Sse.Shuffle(D0, D2, 0x4);    //_MM_SHUFFLE(0, 0, 1, 0)
                    V00 = Sse.Shuffle(row2, row2, 0x9e);         //_MM_SHUFFLE(2, 1, 3, 2)
                    V10 = Sse.Shuffle(D0, V11, 0x93);  //_MM_SHUFFLE(2, 1, 0, 3)
                    V01 = Sse.Shuffle(row1, row1, 0x7b);         //_MM_SHUFFLE(1, 3, 2, 3)
                    V11 = Sse.Shuffle(D0, V11, 0x26);  //_MM_SHUFFLE(0, 2, 1, 2)

                    // V13 = D1X,D1Y,D2Z,D2Z
                    V13 = Sse.Shuffle(D1, D2, 0xa4);   //_MM_SHUFFLE(2, 2, 1, 0)
                    V02 = Sse.Shuffle(row4, row4, 0x9e);         //_MM_SHUFFLE(2, 1, 3, 2)
                    V12 = Sse.Shuffle(D1, V13, 0x93);  //_MM_SHUFFLE(2, 1, 0, 3)
                    V03 = Sse.Shuffle(row3, row3, 0x7b);         //_MM_SHUFFLE(1, 3, 2, 3)
                    V13 = Sse.Shuffle(D1, V13, 0x26);  //_MM_SHUFFLE(0, 2, 1, 2)

                    C0 = Sse.Subtract(C0, Sse.Multiply(V00, V10));
                    C2 = Sse.Subtract(C2, Sse.Multiply(V01, V11));
                    C4 = Sse.Subtract(C4, Sse.Multiply(V02, V12));
                    C6 = Sse.Subtract(C6, Sse.Multiply(V03, V13));

                    V00 = Sse.Shuffle(row2, row2, 0x33); //_MM_SHUFFLE(0, 3, 0, 3)

                    // V10 = D0Z,D0Z,D2X,D2Y
                    V10 = Sse.Shuffle(D0, D2, 0x4A); //_MM_SHUFFLE(1, 0, 2, 2)
                    V10 = Sse.Shuffle(V10, V10, 0x2C);        //_MM_SHUFFLE(0, 2, 3, 0)
                    V01 = Sse.Shuffle(row1, row1, 0x8D);       //_MM_SHUFFLE(2, 0, 3, 1)

                    // V11 = D0X,D0W,D2X,D2Y
                    V11 = Sse.Shuffle(D0, D2, 0x4C); //_MM_SHUFFLE(1, 0, 3, 0)
                    V11 = Sse.Shuffle(V11, V11, 0x93);        //_MM_SHUFFLE(2, 1, 0, 3)
                    V02 = Sse.Shuffle(row4, row4, 0x33);       //_MM_SHUFFLE(0, 3, 0, 3)

                    // V12 = D1Z,D1Z,D2Z,D2W
                    V12 = Sse.Shuffle(D1, D2, 0xEA); //_MM_SHUFFLE(3, 2, 2, 2)
                    V12 = Sse.Shuffle(V12, V12, 0x2C);        //_MM_SHUFFLE(0, 2, 3, 0)
                    V03 = Sse.Shuffle(row3, row3, 0x8D);       //_MM_SHUFFLE(2, 0, 3, 1)

                    // V13 = D1X,D1W,D2Z,D2W
                    V13 = Sse.Shuffle(D1, D2, 0xEC); //_MM_SHUFFLE(3, 2, 3, 0)
                    V13 = Sse.Shuffle(V13, V13, 0x93);        //_MM_SHUFFLE(2, 1, 0, 3)

                    V00 = Sse.Multiply(V00, V10);
                    V01 = Sse.Multiply(V01, V11);
                    V02 = Sse.Multiply(V02, V12);
                    V03 = Sse.Multiply(V03, V13);

                    Vector128<float> C1 = Sse.Subtract(C0, V00);
                    C0 = Sse.Add(C0, V00);
                    Vector128<float> C3 = Sse.Add(C2, V01);
                    C2 = Sse.Subtract(C2, V01);
                    Vector128<float> C5 = Sse.Subtract(C4, V02);
                    C4 = Sse.Add(C4, V02);
                    Vector128<float> C7 = Sse.Add(C6, V03);
                    C6 = Sse.Subtract(C6, V03);

                    C0 = Sse.Shuffle(C0, C1, 0xD8); //_MM_SHUFFLE(3, 1, 2, 0)
                    C2 = Sse.Shuffle(C2, C3, 0xD8); //_MM_SHUFFLE(3, 1, 2, 0)
                    C4 = Sse.Shuffle(C4, C5, 0xD8); //_MM_SHUFFLE(3, 1, 2, 0)
                    C6 = Sse.Shuffle(C6, C7, 0xD8); //_MM_SHUFFLE(3, 1, 2, 0)

                    C0 = Sse.Shuffle(C0, C0, 0xD8); //_MM_SHUFFLE(3, 1, 2, 0)
                    C2 = Sse.Shuffle(C2, C2, 0xD8); //_MM_SHUFFLE(3, 1, 2, 0)
                    C4 = Sse.Shuffle(C4, C4, 0xD8); //_MM_SHUFFLE(3, 1, 2, 0)
                    C6 = Sse.Shuffle(C6, C6, 0xD8); //_MM_SHUFFLE(3, 1, 2, 0)

                    // Get the determinant
                    vTemp2 = row1;
                    float det = System.Numerics.Vector4.Dot(C0.AsVector4(), vTemp2.AsVector4());

                    // Check determinate is not zero
                    if (MathF.Abs(det) < float.Epsilon)
                    {
                        result = new Matrix4x4(float.NaN, float.NaN, float.NaN, float.NaN,
                                    float.NaN, float.NaN, float.NaN, float.NaN,
                                    float.NaN, float.NaN, float.NaN, float.NaN,
                                    float.NaN, float.NaN, float.NaN, float.NaN);
                        return result;
                    }

                    // Create Vector128<float> copy of the determinant and invert them.
                    var ones = Vector128.Create(1.0f);
                    var vTemp = Vector128.Create(det);
                    vTemp = Sse.Divide(ones, vTemp);

                    row1 = Sse.Multiply(C0, vTemp);
                    row2 = Sse.Multiply(C2, vTemp);
                    row3 = Sse.Multiply(C4, vTemp);
                    row4 = Sse.Multiply(C6, vTemp);

                    Unsafe.SkipInit(out result);
                    ref Vector128<float> vResult = ref Unsafe.As<Matrix4x4, Vector128<float>>(ref result);

                    vResult = row1;
                    Unsafe.Add(ref vResult, 1) = row2;
                    Unsafe.Add(ref vResult, 2) = row3;
                    Unsafe.Add(ref vResult, 3) = row4;

                    return result;
                }
                else
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
        }

        struct VectorBasis
        {
            public unsafe Vector3* Element0;
            public unsafe Vector3* Element1;
            public unsafe Vector3* Element2;
        }

        struct CanonicalBasis
        {
            public Vector3 Row0;
            public Vector3 Row1;
            public Vector3 Row2;
        };

        const float DecomposeEpsilon = 0.0001f;

        /// <summary>
        /// 행렬을 비례, 회전, 이동 값으로 분리합니다.
        /// </summary>
        /// <param name="scale"> 비례 벡터가 제공됩니다. </param>
        /// <param name="rotation"> 회전 사원수가 제공됩니다. </param>
        /// <param name="translation"> 이동 벡터가 제공됩니다. </param>
        public unsafe void Decompose(out Vector3 scale, out Quaternion rotation, out Vector3 translation)
        {
            unsafe
            {
                fixed (Vector3* scaleBase = &scale)
                {
                    float* pfScales = (float*)scaleBase;
                    float det;

                    VectorBasis vectorBasis;
                    var pVectorBasis = (Vector3**)&vectorBasis;

                    Matrix4x4 matTemp = Identity;
                    CanonicalBasis canonicalBasis = default;
                    Vector3* pCanonicalBasis = &canonicalBasis.Row0;

                    canonicalBasis.Row0 = new Vector3(1.0f, 0.0f, 0.0f);
                    canonicalBasis.Row1 = new Vector3(0.0f, 1.0f, 0.0f);
                    canonicalBasis.Row2 = new Vector3(0.0f, 0.0f, 1.0f);

                    translation = new Vector3(
                        _41,
                        _42,
                        _43);

                    pVectorBasis[0] = (Vector3*)&matTemp._11;
                    pVectorBasis[1] = (Vector3*)&matTemp._21;
                    pVectorBasis[2] = (Vector3*)&matTemp._31;

                    *(pVectorBasis[0]) = new Vector3(_11, _12, _13);
                    *(pVectorBasis[1]) = new Vector3(_21, _22, _23);
                    *(pVectorBasis[2]) = new Vector3(_31, _32, _33);

                    scale.X = pVectorBasis[0]->Length;
                    scale.Y = pVectorBasis[1]->Length;
                    scale.Z = pVectorBasis[2]->Length;

                    uint a, b, c;
                    float x = pfScales[0], y = pfScales[1], z = pfScales[2];
                    if (x < y)
                    {
                        if (y < z)
                        {
                            a = 2;
                            b = 1;
                            c = 0;
                        }
                        else
                        {
                            a = 1;

                            if (x < z)
                            {
                                b = 2;
                                c = 0;
                            }
                            else
                            {
                                b = 0;
                                c = 2;
                            }
                        }
                    }
                    else
                    {
                        if (x < z)
                        {
                            a = 2;
                            b = 0;
                            c = 1;
                        }
                        else
                        {
                            a = 0;

                            if (y < z)
                            {
                                b = 2;
                                c = 1;
                            }
                            else
                            {
                                b = 1;
                                c = 2;
                            }
                        }
                    }

                    if (pfScales[a] < DecomposeEpsilon)
                    {
                        *(pVectorBasis[a]) = pCanonicalBasis[a];
                    }

                    *pVectorBasis[a] = pVectorBasis[a]->Normalized;

                    if (pfScales[b] < DecomposeEpsilon)
                    {
                        uint cc;
                        float fAbsX, fAbsY, fAbsZ;

                        fAbsX = MathF.Abs(pVectorBasis[a]->X);
                        fAbsY = MathF.Abs(pVectorBasis[a]->Y);
                        fAbsZ = MathF.Abs(pVectorBasis[a]->Z);

                        #region Ranking
                        if (fAbsX < fAbsY)
                        {
                            if (fAbsY < fAbsZ)
                            {
                                cc = 0;
                            }
                            else
                            {
                                if (fAbsX < fAbsZ)
                                {
                                    cc = 0;
                                }
                                else
                                {
                                    cc = 2;
                                }
                            }
                        }
                        else
                        {
                            if (fAbsX < fAbsZ)
                            {
                                cc = 1;
                            }
                            else
                            {
                                if (fAbsY < fAbsZ)
                                {
                                    cc = 1;
                                }
                                else
                                {
                                    cc = 2;
                                }
                            }
                        }
                        #endregion

                        *pVectorBasis[b] = Vector3.CrossProduct(*pVectorBasis[a], *(pCanonicalBasis + cc));
                    }

                    *pVectorBasis[b] = pVectorBasis[b]->Normalized;

                    if (pfScales[c] < DecomposeEpsilon)
                    {
                        *pVectorBasis[c] = Vector3.CrossProduct(*pVectorBasis[a], *pVectorBasis[b]);
                    }

                    *pVectorBasis[c] = pVectorBasis[c]->Normalized;

                    det = matTemp.Determinant;

                    // use Kramer's rule to check for handedness of coordinate system
                    if (det < 0.0f)
                    {
                        // switch coordinate system by negating the scale and inverting the basis vector on the x-axis
                        pfScales[a] = -pfScales[a];
                        *pVectorBasis[a] = -(*pVectorBasis[a]);

                        det = -det;
                    }

                    det -= 1.0f;
                    det *= det;

                    if ((DecomposeEpsilon < det))
                    {
                        // Non-SRT matrix encountered
                        rotation = Quaternion.Identity;
                    }
                    else
                    {
                        // generate the quaternion from the matrix
                        rotation = Quaternion.FromMatrix(matTemp);
                    }
                }
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
        /// 비례 행렬을 계산합니다.
        /// </summary>
        /// <param name="scale"> 비례 벡터를 전달합니다. </param>
        /// <returns> 행렬 값이 반환됩니다. </returns>
        public static Matrix4x4 Scale(Vector3 scale)
        {
            return new Matrix4x4(
                scale.X, 0, 0, 0,
                0, scale.Y, 0, 0,
                0, 0, scale.Z, 0,
                0, 0, 0, 1.0f
                );
        }

        /// <summary>
        /// 이동 행렬을 계선합니다.
        /// </summary>
        /// <param name="translation"> 이동 벡터를 전달합니다. </param>
        /// <returns> 행렬 값이 반환됩니다. </returns>
        public static Matrix4x4 Translation(Vector3 translation)
        {
            return new Matrix4x4(
                1.0f, 0, 0, 0,
                0, 1.0f, 0, 0,
                0, 0, 1.0f, 0,
                translation.X, translation.Y, translation.Z, 1.0f
                );
        }

        /// <summary>
        /// 아핀 트랜스폼을 가져옵니다.
        /// </summary>
        /// <param name="t"> 이동 벡터를 전달합니다. </param>
        /// <param name="s"> 비례 벡터를 전달합니다. </param>
        /// <param name="q"> 회전 사원수를 전달합니다. </param>
        /// <returns> 행렬 값이 반환됩니다. </returns>
        public static unsafe Matrix4x4 AffineTransformation(Vector3 t, Vector3 s, Quaternion q)
        {
            Matrix4x4 S = Scale(s);
            Matrix4x4 R = q.ToMatrix();
            Matrix4x4 M = Multiply(S, R);

            if (AdvSimd.IsSupported)
            {
                Vector4 v4 = t.Convert<Vector4>();
                AdvSimd.Store(&M._41, AdvSimd.Add(AdvSimd.LoadVector128(&M._41), AdvSimd.LoadVector128(&t.X)));
                return M;
            }
            else if (Sse.IsSupported)
            {
                Vector4 v4 = t.Convert<Vector4>();
                Sse.Store(&M._11, Sse.Add(Sse.LoadVector128(&M._11), Sse.LoadVector128(&v4.X)));
            }

            M._41 += t.X;
            M._42 += t.Y;
            M._43 += t.Z;
            return M;
        }

        /// <summary>
        /// 회전 축과 라디안 단위를 이용하여 회전 행렬을 생성합니다.
        /// </summary>
        /// <param name="axis"> 회전 축을 전달합니다. </param>
        /// <param name="angle"> 회전 라디안 값을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public static Matrix4x4 AxisAngle(Vector3 axis, float angle)
        {
            float x = axis.X, y = axis.Y, z = axis.Z;
            float sa = MathEx.Sin(angle), ca = MathEx.Cos(angle);
            float xx = x * x, yy = y * y, zz = z * z;
            float xy = x * y, xz = x * z, yz = y * z;

            Matrix4x4 result = Identity;

            result._11 = xx + ca * (1.0f - xx);
            result._12 = xy - ca * xy + sa * z;
            result._13 = xz - ca * xz - sa * y;

            result._21 = xy - ca * xy - sa * z;
            result._22 = yy + ca * (1.0f - yy);
            result._23 = yz - ca * yz + sa * x;

            result._31 = xz - ca * xz + sa * y;
            result._32 = yz - ca * yz - sa * x;
            result._33 = zz + ca * (1.0f - zz);

            return result;
        }

        /// <summary>
        /// 원근 투영 행렬을 생성합니다.
        /// </summary>
        /// <param name="FovAngleY"> 시야각을 전달합니다. </param>
        /// <param name="AspectRatio"> 종횡비를 전달합니다. </param>
        /// <param name="NearZ"> 최소 깊이를 전달합니다. </param>
        /// <param name="FarZ"> 최대 깊이를 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public static Matrix4x4 PerspectiveFovLH(float FovAngleY, float AspectRatio, float NearZ, float FarZ)
        {
            float SinFov;
            float CosFov;
            MathEx.SinCos(out SinFov, out CosFov, 0.5f * FovAngleY);

            float Height = CosFov / SinFov;
            float Width = Height / AspectRatio;
            float fRange = FarZ / (FarZ - NearZ);

            Matrix4x4 M;
            M._11 = Width;
            M._12 = 0.0f;
            M._13 = 0.0f;
            M._14 = 0.0f;

            M._21 = 0.0f;
            M._22 = Height;
            M._23 = 0.0f;
            M._24 = 0.0f;

            M._31 = 0.0f;
            M._32 = 0.0f;
            M._33 = fRange;
            M._34 = 1.0f;

            M._41 = 0.0f;
            M._42 = 0.0f;
            M._43 = -fRange * NearZ;
            M._44 = 0.0f;
            return M;
        }

        /// <summary>
        /// 직교 투영 행렬을 생성합니다.
        /// </summary>
        /// <param name="ViewWidth"> 뷰 너비를 전달합니다. </param>
        /// <param name="ViewHeight"> 뷰 높이를 전달합니다. </param>
        /// <param name="NearZ"> 최소 깊이를 전달합니다. </param>
        /// <param name="FarZ"> 최대 깊이를 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public static Matrix4x4 OrthographicLH(float ViewWidth, float ViewHeight, float NearZ, float FarZ)
        {
            float fRange = 1.0f / (FarZ - NearZ);

            Matrix4x4 M;
            M._11 = 2.0f / ViewWidth;
            M._12 = 0.0f;
            M._13 = 0.0f;
            M._14 = 0.0f;

            M._21 = 0.0f;
            M._22 = 2.0f / ViewHeight;
            M._23 = 0.0f;
            M._24 = 0.0f;

            M._31 = 0.0f;
            M._32 = 0.0f;
            M._33 = fRange;
            M._34 = 0.0f;

            M._41 = 0.0f;
            M._42 = 0.0f;
            M._43 = -fRange * NearZ;
            M._44 = 1.0f;
            return M;
        }

        /// <summary>
        /// 카메라에서 대상 방향을 바라보는 행렬을 생성합니다.
        /// </summary>
        /// <param name="eyePosition"> 카메라 위치를 전달합니다. </param>
        /// <param name="eyeDirection"> 카메라가 바라보는 방향을 전달합니다. </param>
        /// <param name="upDirection"> 카메라 방향의 상향 벡터를 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public static Matrix4x4 LookToLH(Vector3 eyePosition, Vector3 eyeDirection, Vector3 upDirection)
        {
            Vector3 R2 = eyeDirection;
            Vector3 R0 = Vector3.CrossProduct(upDirection, R2).Normalized;
            var     R1 = Vector3.CrossProduct(R2, R0);
            Vector3 NegEyePosition = -eyePosition;

            float D0 = Vector3.DotProduct(R0, NegEyePosition);
            float D1 = Vector3.DotProduct(R1, NegEyePosition);
            float D2 = Vector3.DotProduct(R2, NegEyePosition);

            Matrix4x4 M = Identity;
            M.SetRow(0, new Vector4(R0, D0));
            M.SetRow(1, new Vector4(R1, D1));
            M.SetRow(2, new Vector4(R2, D2));
            return M.Transposed;
        }

        /// <summary>
        /// 두 행렬을 행렬 곱셈 방식에 따라 곱합니다.
        /// </summary>
        /// <param name="lh"> 첫 번째 값을 전달합니다. </param>
        /// <param name="rh"> 두 번째 값을 전달합니다. </param>
        /// <returns> 계산 결과가 반환됩니다. </returns>
        public static unsafe Matrix4x4 Multiply(Matrix4x4 lh, Matrix4x4 rh)
        {
            if (AdvSimd.Arm64.IsSupported)
            {
                Unsafe.SkipInit(out Matrix4x4 result);

                Vector128<float> M11 = AdvSimd.LoadVector128(&lh._11);

                Vector128<float> vX = AdvSimd.MultiplyBySelectedScalar(AdvSimd.LoadVector128(&rh._11), M11, 0);
                Vector128<float> vY = AdvSimd.MultiplyBySelectedScalar(AdvSimd.LoadVector128(&rh._21), M11, 1);
                Vector128<float> vZ = AdvSimd.Arm64.FusedMultiplyAddBySelectedScalar(vX, AdvSimd.LoadVector128(&rh._31), M11, 2);
                Vector128<float> vW = AdvSimd.Arm64.FusedMultiplyAddBySelectedScalar(vY, AdvSimd.LoadVector128(&rh._41), M11, 3);

                AdvSimd.Store(&result._11, AdvSimd.Add(vZ, vW));

                Vector128<float> M21 = AdvSimd.LoadVector128(&lh._21);

                vX = AdvSimd.MultiplyBySelectedScalar(AdvSimd.LoadVector128(&rh._11), M21, 0);
                vY = AdvSimd.MultiplyBySelectedScalar(AdvSimd.LoadVector128(&rh._21), M21, 1);
                vZ = AdvSimd.Arm64.FusedMultiplyAddBySelectedScalar(vX, AdvSimd.LoadVector128(&rh._31), M21, 2);
                vW = AdvSimd.Arm64.FusedMultiplyAddBySelectedScalar(vY, AdvSimd.LoadVector128(&rh._41), M21, 3);

                AdvSimd.Store(&result._21, AdvSimd.Add(vZ, vW));

                Vector128<float> M31 = AdvSimd.LoadVector128(&lh._31);

                vX = AdvSimd.MultiplyBySelectedScalar(AdvSimd.LoadVector128(&rh._11), M31, 0);
                vY = AdvSimd.MultiplyBySelectedScalar(AdvSimd.LoadVector128(&rh._21), M31, 1);
                vZ = AdvSimd.Arm64.FusedMultiplyAddBySelectedScalar(vX, AdvSimd.LoadVector128(&rh._31), M31, 2);
                vW = AdvSimd.Arm64.FusedMultiplyAddBySelectedScalar(vY, AdvSimd.LoadVector128(&rh._41), M31, 3);

                AdvSimd.Store(&result._31, AdvSimd.Add(vZ, vW));

                Vector128<float> M41 = AdvSimd.LoadVector128(&lh._41);

                vX = AdvSimd.MultiplyBySelectedScalar(AdvSimd.LoadVector128(&rh._11), M41, 0);
                vY = AdvSimd.MultiplyBySelectedScalar(AdvSimd.LoadVector128(&rh._21), M41, 1);
                vZ = AdvSimd.Arm64.FusedMultiplyAddBySelectedScalar(vX, AdvSimd.LoadVector128(&rh._31), M41, 2);
                vW = AdvSimd.Arm64.FusedMultiplyAddBySelectedScalar(vY, AdvSimd.LoadVector128(&rh._41), M41, 3);

                AdvSimd.Store(&result._41, AdvSimd.Add(vZ, vW));

                return result;
            }
            else if (Sse.IsSupported)
            {
                Vector128<float> row = Sse.LoadVector128(&lh._11);
                Sse.Store(&lh._11,
                    Sse.Add(Sse.Add(Sse.Multiply(Sse.Shuffle(row, row, 0x00), Sse.LoadVector128(&rh._11)),
                                    Sse.Multiply(Sse.Shuffle(row, row, 0x55), Sse.LoadVector128(&rh._21))),
                            Sse.Add(Sse.Multiply(Sse.Shuffle(row, row, 0xAA), Sse.LoadVector128(&rh._31)),
                                    Sse.Multiply(Sse.Shuffle(row, row, 0xFF), Sse.LoadVector128(&rh._41)))));

                row = Sse.LoadVector128(&lh._21);
                Sse.Store(&lh._21,
                    Sse.Add(Sse.Add(Sse.Multiply(Sse.Shuffle(row, row, 0x00), Sse.LoadVector128(&rh._11)),
                                    Sse.Multiply(Sse.Shuffle(row, row, 0x55), Sse.LoadVector128(&rh._21))),
                            Sse.Add(Sse.Multiply(Sse.Shuffle(row, row, 0xAA), Sse.LoadVector128(&rh._31)),
                                    Sse.Multiply(Sse.Shuffle(row, row, 0xFF), Sse.LoadVector128(&rh._41)))));

                row = Sse.LoadVector128(&lh._31);
                Sse.Store(&lh._31,
                    Sse.Add(Sse.Add(Sse.Multiply(Sse.Shuffle(row, row, 0x00), Sse.LoadVector128(&rh._11)),
                                    Sse.Multiply(Sse.Shuffle(row, row, 0x55), Sse.LoadVector128(&rh._21))),
                            Sse.Add(Sse.Multiply(Sse.Shuffle(row, row, 0xAA), Sse.LoadVector128(&rh._31)),
                                    Sse.Multiply(Sse.Shuffle(row, row, 0xFF), Sse.LoadVector128(&rh._41)))));

                row = Sse.LoadVector128(&lh._41);
                Sse.Store(&lh._41,
                    Sse.Add(Sse.Add(Sse.Multiply(Sse.Shuffle(row, row, 0x00), Sse.LoadVector128(&rh._11)),
                                    Sse.Multiply(Sse.Shuffle(row, row, 0x55), Sse.LoadVector128(&rh._21))),
                            Sse.Add(Sse.Multiply(Sse.Shuffle(row, row, 0xAA), Sse.LoadVector128(&rh._31)),
                                    Sse.Multiply(Sse.Shuffle(row, row, 0xFF), Sse.LoadVector128(&rh._41)))));
                return lh;
            }

            Matrix4x4 m;

            // First row
            m._11 = lh._11 * rh._11 + lh._12 * rh._21 + lh._13 * rh._31 + lh._14 * rh._41;
            m._12 = lh._11 * rh._12 + lh._12 * rh._22 + lh._13 * rh._32 + lh._14 * rh._42;
            m._13 = lh._11 * rh._13 + lh._12 * rh._23 + lh._13 * rh._33 + lh._14 * rh._43;
            m._14 = lh._11 * rh._14 + lh._12 * rh._24 + lh._13 * rh._34 + lh._14 * rh._44;

            // Second row
            m._21 = lh._21 * rh._11 + lh._22 * rh._21 + lh._23 * rh._31 + lh._24 * rh._41;
            m._22 = lh._21 * rh._12 + lh._22 * rh._22 + lh._23 * rh._32 + lh._24 * rh._42;
            m._23 = lh._21 * rh._13 + lh._22 * rh._23 + lh._23 * rh._33 + lh._24 * rh._43;
            m._24 = lh._21 * rh._14 + lh._22 * rh._24 + lh._23 * rh._34 + lh._24 * rh._44;

            // Third row
            m._31 = lh._31 * rh._11 + lh._32 * rh._21 + lh._33 * rh._31 + lh._34 * rh._41;
            m._32 = lh._31 * rh._12 + lh._32 * rh._22 + lh._33 * rh._32 + lh._34 * rh._42;
            m._33 = lh._31 * rh._13 + lh._32 * rh._23 + lh._33 * rh._33 + lh._34 * rh._43;
            m._34 = lh._31 * rh._14 + lh._32 * rh._24 + lh._33 * rh._34 + lh._34 * rh._44;

            // Fourth row
            m._41 = lh._41 * rh._11 + lh._42 * rh._21 + lh._43 * rh._31 + lh._44 * rh._41;
            m._42 = lh._41 * rh._12 + lh._42 * rh._22 + lh._43 * rh._32 + lh._44 * rh._42;
            m._43 = lh._41 * rh._13 + lh._42 * rh._23 + lh._43 * rh._33 + lh._44 * rh._43;
            m._44 = lh._41 * rh._14 + lh._42 * rh._24 + lh._43 * rh._34 + lh._44 * rh._44;

            return m;
        }

        /// <summary>
        /// 두 행렬을 단순 덧셈한 행렬을 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 계산된 행렬이 반환됩니다. </returns>
        public static unsafe Matrix4x4 operator +(Matrix4x4 left, Matrix4x4 right)
        {
            if (AdvSimd.IsSupported)
            {
                AdvSimd.Store(&left._11, AdvSimd.Add(AdvSimd.LoadVector128(&left._11), AdvSimd.LoadVector128(&right._11)));
                AdvSimd.Store(&left._21, AdvSimd.Add(AdvSimd.LoadVector128(&left._21), AdvSimd.LoadVector128(&right._21)));
                AdvSimd.Store(&left._31, AdvSimd.Add(AdvSimd.LoadVector128(&left._31), AdvSimd.LoadVector128(&right._31)));
                AdvSimd.Store(&left._41, AdvSimd.Add(AdvSimd.LoadVector128(&left._41), AdvSimd.LoadVector128(&right._41)));
                return left;
            }
            else if (Sse.IsSupported)
            {
                Sse.Store(&left._11, Sse.Add(Sse.LoadVector128(&left._11), Sse.LoadVector128(&right._11)));
                Sse.Store(&left._21, Sse.Add(Sse.LoadVector128(&left._21), Sse.LoadVector128(&right._21)));
                Sse.Store(&left._31, Sse.Add(Sse.LoadVector128(&left._31), Sse.LoadVector128(&right._31)));
                Sse.Store(&left._41, Sse.Add(Sse.LoadVector128(&left._41), Sse.LoadVector128(&right._41)));
                return left;
            }
            else
            {
                return new Matrix4x4(
                    left._11 + right._11, left._12 + right._12, left._13 + right._13, left._14 + right._14,
                    left._21 + right._21, left._22 + right._22, left._23 + right._23, left._24 + right._24,
                    left._31 + right._31, left._32 + right._32, left._33 + right._33, left._34 + right._34,
                    left._41 + right._41, left._42 + right._42, left._43 + right._43, left._44 + right._44
                );
            }
        }

        /// <summary>
        /// 두 행렬을 단순 뺄셈한 행렬을 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 계산된 행렬이 반환됩니다. </returns>
        public static unsafe Matrix4x4 operator -(Matrix4x4 left, Matrix4x4 right)
        {
            if (AdvSimd.IsSupported)
            {
                AdvSimd.Store(&left._11, AdvSimd.Subtract(AdvSimd.LoadVector128(&left._11), AdvSimd.LoadVector128(&right._11)));
                AdvSimd.Store(&left._21, AdvSimd.Subtract(AdvSimd.LoadVector128(&left._21), AdvSimd.LoadVector128(&right._21)));
                AdvSimd.Store(&left._31, AdvSimd.Subtract(AdvSimd.LoadVector128(&left._31), AdvSimd.LoadVector128(&right._31)));
                AdvSimd.Store(&left._41, AdvSimd.Subtract(AdvSimd.LoadVector128(&left._41), AdvSimd.LoadVector128(&right._41)));
                return left;
            }
            else if (Sse.IsSupported)
            {
                Sse.Store(&left._11, Sse.Subtract(Sse.LoadVector128(&left._11), Sse.LoadVector128(&right._11)));
                Sse.Store(&left._21, Sse.Subtract(Sse.LoadVector128(&left._21), Sse.LoadVector128(&right._21)));
                Sse.Store(&left._31, Sse.Subtract(Sse.LoadVector128(&left._31), Sse.LoadVector128(&right._31)));
                Sse.Store(&left._41, Sse.Subtract(Sse.LoadVector128(&left._41), Sse.LoadVector128(&right._41)));
                return left;
            }
            else
            {
                return new Matrix4x4(
                    left._11 - right._11, left._12 - right._12, left._13 - right._13, left._14 - right._14,
                    left._21 - right._21, left._22 - right._22, left._23 - right._23, left._24 - right._24,
                    left._31 - right._31, left._32 - right._32, left._33 - right._33, left._34 - right._34,
                    left._41 - right._41, left._42 - right._42, left._43 - right._43, left._44 - right._44
                );
            }
        }

        /// <summary>
        /// 두 행렬을 단순 곱셈한 행렬을 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 계산된 행렬이 반환됩니다. </returns>
        public static unsafe Matrix4x4 operator *(Matrix4x4 left, Matrix4x4 right)
        {
            if (AdvSimd.IsSupported)
            {
                AdvSimd.Store(&left._11, AdvSimd.Multiply(AdvSimd.LoadVector128(&left._11), AdvSimd.LoadVector128(&right._11)));
                AdvSimd.Store(&left._21, AdvSimd.Multiply(AdvSimd.LoadVector128(&left._21), AdvSimd.LoadVector128(&right._21)));
                AdvSimd.Store(&left._31, AdvSimd.Multiply(AdvSimd.LoadVector128(&left._31), AdvSimd.LoadVector128(&right._31)));
                AdvSimd.Store(&left._41, AdvSimd.Multiply(AdvSimd.LoadVector128(&left._41), AdvSimd.LoadVector128(&right._41)));
                return left;
            }
            else if (Sse.IsSupported)
            {
                Sse.Store(&left._11, Sse.Multiply(Sse.LoadVector128(&left._11), Sse.LoadVector128(&right._11)));
                Sse.Store(&left._21, Sse.Multiply(Sse.LoadVector128(&left._21), Sse.LoadVector128(&right._21)));
                Sse.Store(&left._31, Sse.Multiply(Sse.LoadVector128(&left._31), Sse.LoadVector128(&right._31)));
                Sse.Store(&left._41, Sse.Multiply(Sse.LoadVector128(&left._41), Sse.LoadVector128(&right._41)));
                return left;
            }
            else
            {
                return new Matrix4x4(
                    left._11 * right._11, left._12 * right._12, left._13 * right._13, left._14 * right._14,
                    left._21 * right._21, left._22 * right._22, left._23 * right._23, left._24 * right._24,
                    left._31 * right._31, left._32 * right._32, left._33 * right._33, left._34 * right._34,
                    left._41 * right._41, left._42 * right._42, left._43 * right._43, left._44 * right._44
                );
            }
        }

        /// <summary>
        /// 두 행렬을 단순 곱셈한 행렬을 가져옵니다. 스칼라 값은 모든 원소가 동일한 행렬으로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 행렬을 전달합니다. </param>
        /// <param name="right"> 두 번째 행렬을 전달합니다. </param>
        /// <returns> 계산된 행렬이 반환됩니다. </returns>
        public static unsafe Matrix4x4 operator *(float left, Matrix4x4 right)
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
        public static unsafe Matrix4x4 operator /(Matrix4x4 left, Matrix4x4 right)
        {
            if (AdvSimd.Arm64.IsSupported)
            {
                AdvSimd.Store(&left._11, AdvSimd.Arm64.Divide(AdvSimd.LoadVector128(&left._11), AdvSimd.LoadVector128(&right._11)));
                AdvSimd.Store(&left._21, AdvSimd.Arm64.Divide(AdvSimd.LoadVector128(&left._21), AdvSimd.LoadVector128(&right._21)));
                AdvSimd.Store(&left._31, AdvSimd.Arm64.Divide(AdvSimd.LoadVector128(&left._31), AdvSimd.LoadVector128(&right._31)));
                AdvSimd.Store(&left._41, AdvSimd.Arm64.Divide(AdvSimd.LoadVector128(&left._41), AdvSimd.LoadVector128(&right._41)));
                return left;
            }
            else if (Sse.IsSupported)
            {
                Sse.Store(&left._11, Sse.Divide(Sse.LoadVector128(&left._11), Sse.LoadVector128(&right._11)));
                Sse.Store(&left._21, Sse.Divide(Sse.LoadVector128(&left._21), Sse.LoadVector128(&right._21)));
                Sse.Store(&left._31, Sse.Divide(Sse.LoadVector128(&left._31), Sse.LoadVector128(&right._31)));
                Sse.Store(&left._41, Sse.Divide(Sse.LoadVector128(&left._41), Sse.LoadVector128(&right._41)));
                return left;
            }
            else
            {
                return new Matrix4x4(
                    left._11 / right._11, left._12 / right._12, left._13 / right._13, left._14 / right._14,
                    left._21 / right._21, left._22 / right._22, left._23 / right._23, left._24 / right._24,
                    left._31 / right._31, left._32 / right._32, left._33 / right._33, left._34 / right._34,
                    left._41 / right._41, left._42 / right._42, left._43 / right._43, left._44 / right._44
                );
            }
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