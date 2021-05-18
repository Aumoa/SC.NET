// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using SC.Engine.Runtime.Core.Numerics;

namespace SC.Engine.Runtime.RenderCore.Slate.Layout
{
    /// <summary>
    /// 2차원 트랜스폼을 표현합니다.
    /// </summary>
    public struct SlateRenderTransform : ILayoutTransform2D, IEquatable<SlateRenderTransform>, INearlyEquatable<SlateRenderTransform, float>, IFormattable, IMatrixType
    {
        /// <summary>
        /// 회전 및 비례를 나타내는 행렬입니다.
        /// </summary>
        public Matrix2x2 M;

        /// <summary>
        /// 이동을 나타내는 벡터입니다.
        /// </summary>
        public Vector2 Translation;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="translation"> 이동 벡터를 전달합니다. </param>
        public SlateRenderTransform(Vector2 translation)
        {
            M = Matrix2x2.Identity;
            Translation = translation;
        }

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="uniformScale"> 단일 비례 값을 전달합니다. </param>
        public SlateRenderTransform(float uniformScale) : this(uniformScale, Vector2.Zero)
        {
        }

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="uniformScale"> 단일 비례 값을 전달합니다. </param>
        /// <param name="translation"> 이동 벡터를 전달합니다. </param>
        public SlateRenderTransform(float uniformScale, Vector2 translation) : this(new Scale2D(uniformScale), translation)
        {
        }

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="scale"> 비례 벡터를 전달합니다. </param>
        public SlateRenderTransform(Scale2D scale) : this(scale, Vector2.Zero)
        {
        }

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="scale"> 비례 벡터를 전달합니다. </param>
        /// <param name="translation"> 이동 벡터를 전달합니다. </param>
        public SlateRenderTransform(Scale2D scale, Vector2 translation)
        {
            M = Matrix2x2.Scale(scale.Scale);
            Translation = translation;
        }

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="shear"> 전단 벡터를 전달합니다. </param>
        public SlateRenderTransform(Shear2D shear) : this(shear, Vector2.Zero)
        {
        }

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="shear"> 전단 벡터를 전달합니다. </param>
        /// <param name="translation"> 이동 벡터를 전달합니다. </param>
        public SlateRenderTransform(Shear2D shear, Vector2 translation)
        {
            M = Matrix2x2.Shear(shear.Shear);
            Translation = translation;
        }

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="rotation"> 회전 사원수를 전달합니다. </param>
        public SlateRenderTransform(Quaternion2D rotation) : this(rotation, Vector2.Zero)
        {
        }

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="rotation"> 회전 사원수를 전달합니다. </param>
        /// <param name="translation"> 이동 벡터를 전달합니다. </param>
        public SlateRenderTransform(Quaternion2D rotation, Vector2 translation)
        {
            M = rotation.ToMatrix();
            Translation = translation;
        }

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="transform"> 트랜스폼을 전달합니다. </param>
        public SlateRenderTransform(Matrix2x2 transform) : this(transform, Vector2.Zero)
        {
        }

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="transform"> 트랜스폼을 전달합니다. </param>
        /// <param name="translation"> 이동 벡터를 전달합니다. </param>
        public SlateRenderTransform(Matrix2x2 transform, Vector2 translation)
        {
            M = transform;
            Translation = translation;
        }

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="transform"> 트랜스폼 행렬을 전달합니다. </param>
        public SlateRenderTransform(Matrix3x2 transform)
        {
            M = transform.Convert<Matrix2x2>();
            Translation = transform.GetComponentOrDefault<Vector2>(2); ;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is SlateRenderTransform transform)
            {
                return Equals(transform);
            }
            else
            {
                return base.Equals(obj);
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"M: {M}, Translation: {Translation}";
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return M.GetHashCode() ^ Translation.GetHashCode();
        }

        /// <inheritdoc/>
        public bool Equals(SlateRenderTransform rhs)
        {
            return this == rhs;
        }

        /// <inheritdoc/>
        public bool NearlyEquals(SlateRenderTransform rhs, float epsilon)
        {
            return M.NearlyEquals(rhs.M, epsilon) && Translation.NearlyEquals(rhs.Translation, epsilon);
        }

        /// <inheritdoc/>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"M: {M.ToString(format, formatProvider)}, Translation: {Translation.ToString(format, formatProvider)}";
        }

        /// <inheritdoc/>
        public T TransformPoint<T>(T point) where T : IVectorType, new()
        {
            return TransformCalculus2D.TransformPoint(Translation, M.TransformPoint(point));
        }

        /// <inheritdoc/>
        public T TransformVector<T>(T vector) where T : IVectorType, new()
        {
            return M.TransformVector(vector);
        }

        /// <summary>
        /// 두 트랜스폼을 더합니다.
        /// </summary>
        /// <param name="rhs"> 트랜스폼을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public SlateRenderTransform Concatenate(SlateRenderTransform rhs)
        {
            return new SlateRenderTransform(
                Matrix2x2.Multiply(M, rhs.M),
                rhs.M.TransformPoint(Translation).Concatenate(rhs.Translation)
                );
        }

        /// <summary>
        /// 역 트랜스폼을 가져옵니다.
        /// </summary>
        /// <returns> 값이 반환됩니다. </returns>
        public SlateRenderTransform Inverse()
        {
            Matrix2x2 invM = M.Inverse;
            Vector2 invTrans = invM.TransformPoint(-Translation);
            return new SlateRenderTransform(invM, invTrans);
        }

        /// <summary>
        /// 두 값이 같은지 비교합니다.
        /// </summary>
        /// <param name="lhs"> 값을 전달합니다. </param>
        /// <param name="rhs"> 값을 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator ==(SlateRenderTransform lhs, SlateRenderTransform rhs)
            => lhs.M == rhs.M && lhs.Translation == rhs.Translation;

        /// <summary>
        /// 두 값이 같지 않은지 비교합니다.
        /// </summary>
        /// <param name="lhs"> 값을 전달합니다. </param>
        /// <param name="rhs"> 값을 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator !=(SlateRenderTransform lhs, SlateRenderTransform rhs)
            => lhs.M != rhs.M || lhs.Translation != rhs.Translation;

        /// <summary>
        /// 트랜스폼이 거의 단위 트랜스폼과 일치하는지 검사합니다.
        /// </summary>
        public bool IsIdentity => M.IsIdentity && Translation.NearlyEquals(Vector2.Zero, 0.0001f);

        /// <inheritdoc/>
        public int Count => 3;

        /// <inheritdoc/>
        public int Rows => 3;

        /// <inheritdoc/>
        public int Columns => 2;

        /// <inheritdoc/>
        public unsafe IVectorType this[int index]
        {
            get => GetComponentOrDefault<Vector2>(index);
            set
            {
                fixed (float* ptr = &M._11)
                {
                    if (index < Count)
                    {
                        ptr[index * 2 + 0] = value[0];
                        ptr[index * 2 + 1] = value[1];
                    }
                }
            }
        }

        /// <summary>
        /// 3차원 행렬 값으로 나타냅니다.
        /// </summary>
        /// <returns> 값이 반환됩니다. </returns>
        public Matrix4x4 ToM3DMatrix()
        {
            return new Matrix4x4(
                M._11, M._12, 0.0f, 0.0f,
                M._21, M._22, 0.0f, 0.0f,
                0.0f, 0.0f, 1.0f, 0.0f,
                Translation.X, Translation.Y, 0.0f, 1.0f
                );
        }

        /// <inheritdoc/>
        public T GetComponentOrDefault<T>(int index) where T : IVectorType, new()
        {
            if (index == 2)
            {
                T v = new();
                v.Construct(Translation);
                return v;
            }
            else
            {
                return M.GetComponentOrDefault<T>(index);
            }
        }

        /// <inheritdoc/>
        public void Construct<T>(T matrix) where T : IMatrixType
        {
            M.Construct(matrix);
            Translation = matrix.GetComponentOrDefault<Vector2>(2);
        }

        /// <inheritdoc/>
        public T Convert<T>() where T : IMatrixType, new()
        {
            T v = new();
            v.Construct(this);
            return v;
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

        /// <summary>
        /// 두 트랜스폼을 더합니다.
        /// </summary>
        /// <param name="rhs"> 트랜스폼을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public SlateRenderTransform Concatenate(Vector2 rhs)
        {
            return new SlateRenderTransform(M, Translation + rhs);
        }

        /// <summary>
        /// 두 트랜스폼을 더합니다.
        /// </summary>
        /// <param name="rhs"> 트랜스폼을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public SlateRenderTransform Concatenate(SlateLayoutTransform rhs)
        {
            return new SlateRenderTransform(Matrix2x2.Multiply(M, Matrix2x2.Scale(new Vector2(rhs.Scale))), rhs.TransformPoint(Translation));
        }

        /// <summary>
        /// 단위 트랜스폼을 가져옵니다.
        /// </summary>
        public static readonly SlateRenderTransform Identity = new SlateRenderTransform(Matrix2x2.Identity, Vector2.Zero);
    }
}
