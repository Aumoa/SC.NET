// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

namespace SC.Engine.Runtime.Core.Numerics
{
    /// <summary>
    /// 투영 공간을 정의합니다.
    /// </summary>
    public struct Frustum : INearlyEquatable<Frustum, float>, IFormattable
    {
        /// <summary>
        /// 왼쪽 평면을 나타냅니다.
        /// </summary>
        public Plane Left;

        /// <summary>
        /// 위쪽 평면을 나타냅니다.
        /// </summary>
        public Plane Top;

        /// <summary>
        /// 오른쪽 평면을 나타냅니다.
        /// </summary>
        public Plane Right;

        /// <summary>
        /// 아래쪽 평면을 나타냅니다.
        /// </summary>
        public Plane Bottom;

        /// <summary>
        /// 가까운 평면을 나타냅니다.
        /// </summary>
        public Plane Near;

        /// <summary>
        /// 먼 평면을 나타냅니다.
        /// </summary>
        public Plane Far;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="left"> 왼쪽 평면을 전달합니다. </param>
        /// <param name="top"> 위쪽 평면을 전달합니다. </param>
        /// <param name="right"> 오른쪽 평면을 전달합니다. </param>
        /// <param name="bottom"> 아래쪽 평면을 전달합니다. </param>
        /// <param name="near"> 가까운 평면을 전달합니다. </param>
        /// <param name="far"> 먼 평면을 전달합니다. </param>
        public Frustum(Plane left, Plane top, Plane right, Plane bottom, Plane near, Plane far)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
            Near = near;
            Far = far;
        }

        /// <summary>
        /// 인덱스를 사용하여 평면 값의 참조를 가져옵니다.
        /// </summary>
        /// <param name="index"> 0에서 5사이의 인덱스를 전달합니다. </param>
        /// <returns> 값의 참조가 반환됩니다. </returns>
        public unsafe ref Plane this[int index]
        {
            get
            {
                fixed (Plane* ptr = &Left)
                {
                    if (index < 6)
                    {
                        throw new IndexOutOfRangeException();
                    }

                    return ref ptr[index];
                }
            }
        }

        /// <summary>
        /// 투영 행렬을 사용하여 투영 공간을 생성합니다.
        /// </summary>
        /// <param name="inViewProj"> 투영 행렬을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public static Frustum ConstructFromMatrix(Matrix4x4 inViewProj)
        {
            Frustum f;

            // Left plane.
            f.Left.Normal.X = inViewProj._14 + inViewProj._11;
            f.Left.Normal.Y = inViewProj._24 + inViewProj._21;
            f.Left.Normal.Z = inViewProj._34 + inViewProj._31;
            f.Left.Distance = inViewProj._44 + inViewProj._41;
            f.Left = f.Left.GetNormal();

            // Top plane.
            f.Top.Normal.X = inViewProj._14 - inViewProj._12;
            f.Top.Normal.Y = inViewProj._24 - inViewProj._22;
            f.Top.Normal.Z = inViewProj._34 - inViewProj._32;
            f.Top.Distance = inViewProj._44 - inViewProj._42;
            f.Top = f.Top.GetNormal();

            // Right plane.
            f.Right.Normal.X = inViewProj._14 - inViewProj._11;
            f.Right.Normal.Y = inViewProj._24 - inViewProj._21;
            f.Right.Normal.Z = inViewProj._34 - inViewProj._31;
            f.Right.Distance = inViewProj._44 - inViewProj._41;
            f.Right = f.Right.GetNormal();

            // Bottom plane.
            f.Bottom.Normal.X = inViewProj._14 + inViewProj._12;
            f.Bottom.Normal.Y = inViewProj._24 + inViewProj._22;
            f.Bottom.Normal.Z = inViewProj._34 + inViewProj._32;
            f.Bottom.Distance = inViewProj._44 + inViewProj._42;
            f.Bottom = f.Bottom.GetNormal();

            // Near plane.
            f.Near.Normal.X = inViewProj._14 + inViewProj._13;
            f.Near.Normal.Y = inViewProj._24 + inViewProj._23;
            f.Near.Normal.Z = inViewProj._34 + inViewProj._33;
            f.Near.Distance = inViewProj._44 + inViewProj._43;
            f.Near = f.Near.GetNormal();

            // Far plane.
            f.Far.Normal.X = inViewProj._14 - inViewProj._13;
            f.Far.Normal.Y = inViewProj._24 - inViewProj._23;
            f.Far.Normal.Z = inViewProj._34 - inViewProj._33;
            f.Far.Distance = inViewProj._44 - inViewProj._43;
            f.Far = f.Far.GetNormal();

            return f;
        }

        /// <inheritdoc/>
        public bool Equals(Frustum other)
        {
            return this == other;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is Frustum f)
            {
                return Equals(f);
            }
            else
            {
                return base.Equals(obj);
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int v = this[0].GetHashCode();
            for (int i = 1; i < 6; ++i)
            {
                v ^= this[i].GetHashCode();
            }
            return v;
        }

        /// <inheritdoc/>
        public bool NearlyEquals(Frustum right, float epsilon)
        {
            for (int i = 0; i < 6; ++i)
            {
                if (!this[i].NearlyEquals(right[i], epsilon))
                {
                    return false;
                }
            }

            return true;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Left: {Left}, Bottom: {Bottom}, Right: {Right}, Top: {Top}, Near: {Near}, Far: {Far}";
        }

        /// <inheritdoc/>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"Left: {Left.ToString(format, formatProvider)}, Bottom: {Bottom.ToString(format, formatProvider)}, Right: {Right.ToString(format, formatProvider)}, Top: {Top.ToString(format, formatProvider)}, Near: {Near.ToString(format, formatProvider)}, Far: {Far.ToString(format, formatProvider)}";
        }

        /// <summary>
        /// 두 값이 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="lhs"> 값을 전달합니다. </param>
        /// <param name="rhs"> 값을 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator ==(Frustum lhs, Frustum rhs)
        {
            for (int i = 0; i < 6; ++i)
            {
                if (lhs[i] != rhs[i])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 두 값이 서로 다른지 비교합니다.
        /// </summary>
        /// <param name="lhs"> 값을 전달합니다. </param>
        /// <param name="rhs"> 값을 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator !=(Frustum lhs, Frustum rhs)
        {
            for (int i = 0; i < 6; ++i)
            {
                if (lhs[i] != rhs[i])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
