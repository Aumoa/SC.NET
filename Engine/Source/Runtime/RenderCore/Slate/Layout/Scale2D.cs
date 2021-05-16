// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using SC.Engine.Runtime.Core.Numerics;

namespace SC.Engine.Runtime.RenderCore.Slate.Layout
{
    /// <summary>
    /// 2차원 비례 트랜스폼을 나타냅니다.
    /// </summary>
    public readonly struct Scale2D : ILayoutTransform2D, IEquatable<Scale2D>, INearlyEquatable<Scale2D, float>, IFormattable
    {
        /// <summary>
        /// 비례 벡터를 나타냅니다.
        /// </summary>
        public readonly Vector2 Scale;

        /// <summary>
        /// 단위 비례 트랜스폼을 가져옵니다.
        /// </summary>
        public static readonly Scale2D Identity = new Scale2D(1, 1);

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="inUniformScale"> 단일 초기화 값을 전달합니다. </param>
        public Scale2D(float inUniformScale)
        {
            Scale.X = inUniformScale;
            Scale.Y = inUniformScale;
        }

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="inScaleX"> X 비례 값을 전달합니다. </param>
        /// <param name="inScaleY"> Y 비례 값을 전달합니다. </param>
        public Scale2D(float inScaleX, float inScaleY)
        {
            Scale.X = inScaleX;
            Scale.Y = inScaleY;
        }

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="inScale"> 비례 값을 전달합니다. </param>
        public Scale2D(Vector2 inScale)
        {
            Scale = inScale;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is Scale2D scale)
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
            return $"Scale: {Scale}";
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return Scale.GetHashCode();
        }

        /// <inheritdoc/>
        public bool Equals(Scale2D rhs)
        {
            return Scale.Equals(rhs.Scale);
        }

        /// <inheritdoc/>
        public bool NearlyEquals(Scale2D rhs, float epsilon)
        {
            return Scale.NearlyEquals(rhs.Scale, epsilon);
        }

        /// <inheritdoc/>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"Scale: {Scale.ToString(format, formatProvider)}";
        }

        /// <inheritdoc/>
        public T TransformPoint<T>(T point) where T : IVectorType, new()
        {
            // Scale * point
            T v = new();
            v[0] = Scale.X * point[0];
            v[1] = Scale.Y * point[1];
            return v;
        }

        /// <inheritdoc/>
        public T TransformVector<T>(T vector) where T : IVectorType, new() => TransformPoint(vector);

        /// <summary>
        /// 두 비례 트랜스폼을 더합니다.
        /// </summary>
        /// <param name="rhs"> 비례 트랜스폼을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public Scale2D Concatenate(Scale2D rhs)
        {
            return new Scale2D(Scale * rhs.Scale);
        }

        /// <summary>
        /// 두 비례 트랜스폼을 더합니다.
        /// </summary>
        /// <param name="rhs"> 비례 트랜스폼을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public Scale2D Concatenate(float rhs)
        {
            return new Scale2D(Scale * rhs);
        }

        /// <summary>
        /// 두 비례 트랜스폼을 더합니다.
        /// </summary>
        /// <param name="lhs"> 비례 트랜스폼을 전달합니다. </param>
        /// <param name="rhs"> 비례 트랜스폼을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public static float Concatenate(float lhs, float rhs)
        {
            return lhs * rhs;
        }

        /// <summary>
        /// 역 트랜스폼을 가져옵니다.
        /// </summary>
        /// <returns> 값이 반환됩니다. </returns>
        public Scale2D Inverse()
        {
            return new Scale2D(1.0f / Scale.X, 1.0f / Scale.Y);
        }

        /// <summary>
        /// 두 값이 같은지 비교합니다.
        /// </summary>
        /// <param name="lhs"> 값을 전달합니다. </param>
        /// <param name="rhs"> 값을 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator ==(Scale2D lhs, Scale2D rhs) => lhs.Scale == rhs.Scale;

        /// <summary>
        /// 두 값이 같지 않은지 비교합니다.
        /// </summary>
        /// <param name="lhs"> 값을 전달합니다. </param>
        /// <param name="rhs"> 값을 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator !=(Scale2D lhs, Scale2D rhs) => lhs.Scale != rhs.Scale;
    }
}
