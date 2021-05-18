// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using SC.Engine.Runtime.Core.Mathematics;
using SC.Engine.Runtime.Core.Numerics;

namespace SC.Engine.Runtime.RenderCore.Slate.Layout
{
    /// <summary>
    /// 2차원 회전 트랜스폼을 나타냅니다.
    /// </summary>
    public readonly struct Quaternion2D : ILayoutTransform2D, IEquatable<Quaternion2D>, INearlyEquatable<Quaternion2D, float>, IFormattable
    {
        /// <summary>
        /// 회전 벡터를 나타냅니다.
        /// </summary>
        public readonly Vector2 Rotation;

        /// <summary>
        /// 단위 회전 트랜스폼을 가져옵니다.
        /// </summary>
        public static readonly Quaternion2D Identity = new Quaternion2D(new Vector2(1.0f, 0.0f));

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="rotRadians"> 회전 각도를 전달합니다. </param>
        public Quaternion2D(float rotRadians)
        {
            MathEx.SinCos(out float sin, out float cos, rotRadians);
            Rotation.X = cos;
            Rotation.Y = sin;
        }

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="inRotComplex"> 복소수를 나타내는 벡터를 전달합니다. </param>
        public Quaternion2D(Vector2 inRotComplex)
        {
            Rotation = inRotComplex;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is Shear2D scale)
            {
                return Equals(scale);
            }
            else
            {
                return base.Equals(obj);
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Rotation: {Rotation}";
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return Rotation.GetHashCode();
        }

        /// <inheritdoc/>
        public bool Equals(Quaternion2D rhs)
        {
            return Rotation.Equals(rhs.Rotation);
        }

        /// <inheritdoc/>
        public bool NearlyEquals(Quaternion2D rhs, float epsilon)
        {
            return Rotation.NearlyEquals(rhs.Rotation, epsilon);
        }

        /// <inheritdoc/>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"Rotation: {Rotation.ToString(format, formatProvider)}";
        }

        /// <inheritdoc/>
        public T TransformPoint<T>(T point) where T : IVectorType, new()
        {
            T v = new();
            v[0] = point[0] * Rotation.X - point[1] * Rotation.Y;
            v[1] = point[0] * Rotation.Y + point[1] * Rotation.X;
            return v;
        }

        /// <inheritdoc/>
        public T TransformVector<T>(T vector) where T : IVectorType, new() => TransformPoint(vector);

        /// <summary>
        /// 두 회전 트랜스폼을 더합니다.
        /// </summary>
        /// <param name="rhs"> 회전 트랜스폼을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public Quaternion2D Concatenate(Quaternion2D rhs)
        {
            return new Quaternion2D(TransformPoint(rhs.Rotation));
        }

        /// <summary>
        /// 역 트랜스폼을 가져옵니다.
        /// </summary>
        /// <returns> 행렬 값이 반환됩니다. </returns>
        public Quaternion2D Inverse()
        {
            return new Quaternion2D(new Vector2(Rotation.X, -Rotation.Y));
        }

        /// <summary>
        /// 행렬값으로 변환합니다.
        /// </summary>
        /// <returns> 값이 반환됩니다. </returns>
        public Matrix2x2 ToMatrix()
        {
            return new Matrix2x2(
                Rotation.X, Rotation.Y,
                -Rotation.Y, Rotation.X
                );
        }

        /// <summary>
        /// 두 값이 같은지 비교합니다.
        /// </summary>
        /// <param name="lhs"> 값을 전달합니다. </param>
        /// <param name="rhs"> 값을 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator ==(Quaternion2D lhs, Quaternion2D rhs) => lhs.Rotation == rhs.Rotation;

        /// <summary>
        /// 두 값이 같지 않은지 비교합니다.
        /// </summary>
        /// <param name="lhs"> 값을 전달합니다. </param>
        /// <param name="rhs"> 값을 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator !=(Quaternion2D lhs, Quaternion2D rhs) => lhs.Rotation != rhs.Rotation;
    }
}
