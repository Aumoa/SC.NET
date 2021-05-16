// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using SC.Engine.Runtime.Core.Mathematics;
using SC.Engine.Runtime.Core.Numerics;

namespace SC.Engine.Runtime.RenderCore.Slate.Layout
{
    /// <summary>
    /// 2차원 전단 트랜스폼을 나타냅니다.
    /// </summary>
    public readonly struct Shear2D : ILayoutTransform2D, IEquatable<Shear2D>, INearlyEquatable<Shear2D, float>, IFormattable
    {
        /// <summary>
        /// 전단 벡터를 나타냅니다.
        /// </summary>
        public readonly Vector2 Shear;

        /// <summary>
        /// 단위 전단 트랜스폼을 가져옵니다.
        /// </summary>
        public static readonly Shear2D Identity = new Shear2D(0, 0);

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="inShearX"> X 전단 값을 전달합니다. </param>
        /// <param name="inShearY"> Y 전단 값을 전달합니다. </param>
        public Shear2D(float inShearX, float inShearY)
        {
            Shear.X = inShearX;
            Shear.Y = inShearY;
        }

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="inShear"> 전단 값을 전달합니다. </param>
        public Shear2D(Vector2 inShear)
        {
            Shear = inShear;
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
            return $"Shear: {Shear}";
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return Shear.GetHashCode();
        }

        /// <inheritdoc/>
        public bool Equals(Shear2D rhs)
        {
            return Shear.Equals(rhs.Shear);
        }

        /// <inheritdoc/>
        public bool NearlyEquals(Shear2D rhs, float epsilon)
        {
            return Shear.NearlyEquals(rhs.Shear, epsilon);
        }

        /// <inheritdoc/>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"Shear: {Shear.ToString(format, formatProvider)}";
        }

        /// <summary>
        /// 전단 각도로부터 전단 트랜스폼을 생성합니다.
        /// </summary>
        /// <param name="inShearAngles"> 각도를 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public static Shear2D FromShearAngles(Vector2 inShearAngles)
        {
            // Compute the M (Shear Slot) = CoTan(90 - SlopeAngle)

            // 0 is a special case because Tan(90) == infinity
            float shearX = inShearAngles.X == 0 ? 0 : (1.0f / MathEx.Tan((90.0f - Math.Clamp(inShearAngles.X, -89.0f, 89.0f)).ToRadians()));
            float shearY = inShearAngles.Y == 0 ? 0 : (1.0f / MathEx.Tan((90.0f - Math.Clamp(inShearAngles.Y, -89.0f, 89.0f)).ToRadians()));

            return new Shear2D(shearX, shearY);
        }

        /// <inheritdoc/>
        public T TransformPoint<T>(T point) where T : IVectorType, new()
        {
            // Point + new Vector2(point.Y, point.X) * Shear
            T v = new();
            v[0] = point[0] + point[1] * Shear.X;
            v[1] = point[1] + point[0] * Shear.Y;
            return v;
        }

        /// <inheritdoc/>
        public T TransformVector<T>(T vector) where T : IVectorType, new() => TransformPoint(vector);

        /// <summary>
        /// 두 전단 트랜스폼을 더합니다.
        /// </summary>
        /// <param name="rhs"> 전단 트랜스폼을 전달합니다. </param>
        /// <returns> 행렬 값이 반환됩니다. </returns>
        public Matrix3x2 Concatenate(Shear2D rhs)
        {
            float XXA = Shear.X;
            float YYA = Shear.Y;
            float XXB = rhs.Shear.X;
            float YYB = rhs.Shear.Y;
            return new Matrix3x2(
                1 + YYA * XXB, YYB * YYA,
                XXA + XXB, XXA * XXB + 1,
                0, 0);
        }

        /// <summary>
        /// 역 트랜스폼을 가져옵니다.
        /// </summary>
        /// <returns> 행렬 값이 반환됩니다. </returns>
        public Matrix3x2 Inverse()
        {
            float invDet = 1.0f / (1.0f - Shear.X * Shear.Y);
            return new Matrix3x2(
                invDet, -Shear.Y * invDet,
                -Shear.X * invDet, invDet,
                0, 0);
        }

        /// <summary>
        /// 두 값이 같은지 비교합니다.
        /// </summary>
        /// <param name="lhs"> 값을 전달합니다. </param>
        /// <param name="rhs"> 값을 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator ==(Shear2D lhs, Shear2D rhs) => lhs.Shear == rhs.Shear;

        /// <summary>
        /// 두 값이 같지 않은지 비교합니다.
        /// </summary>
        /// <param name="lhs"> 값을 전달합니다. </param>
        /// <param name="rhs"> 값을 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator !=(Shear2D lhs, Shear2D rhs) => lhs.Shear != rhs.Shear;
    }
}
