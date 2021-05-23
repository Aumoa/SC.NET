﻿// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.Engine.Runtime.Core.Numerics
{
    /// <summary>
    /// 기본 축에 정렬된 육면체 형식을 정의합니다.
    /// </summary>
    public struct AxisAlignedCube : INearlyEquatable<AxisAlignedCube, float>, IFormattable, IVectorType
    {
        /// <summary>
        /// 왼쪽 위치(-X)를 설정하거나 가져옵니다.
        /// </summary>
        public float Left
        {
            get => Min.X;
            set => Min.X = value;
        }

        /// <summary>
        /// 상단 위치(+Y)를 설정하거나 가져옵니다.
        /// </summary>
        public float Top
        {
            get => Max.Y;
            set => Max.Y = value;
        }

        /// <summary>
        /// 오른쪽 위치(+X)를 설정하거나 가져옵니다.
        /// </summary>
        public float Right
        {
            get => Max.X;
            set => Max.X = value;
        }

        /// <summary>
        /// 하단 위치(-Y)를 설정하거나 가져옵니다.
        /// </summary>
        public float Bottom
        {
            get => Min.Y;
            set => Min.Y = value;
        }

        /// <summary>
        /// 화면과 가까운(-Z) 위치를 설정하거나 가져옵니다.
        /// </summary>
        public float Near
        {
            get => Min.Z;
            set => Min.Z = value;
        }

        /// <summary>
        /// 화면과 먼(+Z) 위치를 설정하거나 가져옵니다.
        /// </summary>
        public float Far
        {
            get => Max.Z;
            set => Max.Z = value;
        }

        /// <summary>
        /// 모든 값을 지정하여 <see cref="AxisAlignedCube"/> 구조체의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="min"> 최소 위치를 전달합니다. </param>
        /// <param name="max"> 최대 위치를 전달합니다. </param>
        public AxisAlignedCube(Vector3 min, Vector3 max)
        {
            Min = min;
            Max = max;
        }

        /// <summary>
        /// 대상 오브젝트가 축 정렬 육면체일 경우, 두 축 정렬 육면체가 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="obj"> 대상 오브젝트를 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public override bool Equals(object obj)
        {
            if (obj is AxisAlignedCube cube)
            {
                return Equals(cube);
            }
            else
            {
                return base.Equals(obj);
            }
        }

        /// <summary>
        /// 축 정렬 육면체의 전체 값의 해시 코드를 가져옵니다.
        /// </summary>
        /// <returns> 해시 코드가 반환됩니다. </returns>
        public override int GetHashCode()
        {
            return Min.GetHashCode() ^ Max.GetHashCode();
        }

        /// <summary>
        /// {Center: {X, Y, Z}, Extent: {X, Y, Z}} 형식의 문자열을 가져옵니다.
        /// </summary>
        /// <returns> 생성된 문자열이 반환됩니다. </returns>
        public override string ToString()
        {
            return string.Format("{{{0}: {1}, {2}: {3}}}",
                nameof(Center),
                Center,
                nameof(Extent),
                Extent
            );
        }

        /// <summary>
        /// 두 축 정렬 육면체가 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="cube"> 대상 축 정렬 육면체를 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public bool Equals(AxisAlignedCube cube)
        {
            return this == cube;
        }

        /// <inheritdoc/>
        public bool NearlyEquals(AxisAlignedCube cube, float epsilon)
        {
            return Min.NearlyEquals(cube.Min, epsilon)
                && Max.NearlyEquals(cube.Max, epsilon);
        }

        /// <summary>
        /// 서식을 지정하여 {Center: {X, Y, Z}, Extent: {X, Y, Z}} 형식의 문자열을 가져옵니다.
        /// </summary>
        /// <param name="format"> 서식 문자열을 전달합니다. </param>
        /// <param name="formatProvider"> 문화권 정보를 전달합니다. </param>
        /// <returns> 생성된 문자열이 반환됩니다. </returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format(
                "{{{0}: {1}, {2}: {3}}}",
                nameof(Center),
                Center.ToString(format, formatProvider),
                nameof(Extent),
                Extent.ToString(format, formatProvider)
            );
        }

        /// <inheritdoc/>
        public unsafe float GetComponentOrDefault(int index)
        {
            fixed (float* ptr = &Min.X)
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
            if (vector is null)
            {
                Left = default;
                Top = default;
                Right = default;
                Bottom = default;
                Near = default;
                Far = default;
            }
            else
            {
                Left = vector[0];
                Top = vector[1];
                Right = vector[2];
                Bottom = vector[3];
                Near = vector[4];
                Far = vector[5];
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
            return index >= 0 && index < Count;
        }

        /// <inheritdoc/>
        public unsafe float this[int index]
        {
            get => GetComponentOrDefault(index);
            set
            {
                fixed (float* ptr = &Min.X)
                {
                    if (index < Count)
                    {
                        ptr[index] = value;
                    }
                }
            }
        }

        /// <inheritdoc/>
        public int Count => 6;

        /// <summary>
        /// 위치가 이 축 정렬 육면체 내부에 존재하는지 검사합니다.
        /// </summary>
        /// <param name="point"> 위치 벡터를 전달합니다. </param>
        /// <returns> 내부에 존재할 경우 true를 반환합니다. </returns>
        public bool IsOverlap(in Vector3 point)
        {
            if (point.X >= Left && point.X <= Right &&
                point.Y >= Bottom && point.Y <= Top &&
                point.Z >= Near && point.Y <= Far)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 축 정렬 육면체가 서로 겹치는지 검사합니다.
        /// </summary>
        /// <param name="cube"> 축 정렬 육면체를 전달합니다. </param>
        /// <returns> 서로 겹칠 경우 true를 반환합니다. </returns>
        public bool IsOverlap(in AxisAlignedCube cube)
        {
            return !(
                Left > cube.Right ||
                Right < cube.Left ||
                Bottom > cube.Top ||
                Top < cube.Bottom ||
                Near > cube.Far ||
                Far < cube.Near);
        }

        /// <summary>
        /// 광선이 이 축 정렬 육면체 내부를 통과하는지 검사합니다.
        /// </summary>
        /// <param name="ray"> 광선을 전달합니다. </param>
        /// <returns> 내부를 통과할 경우 true를 반환합니다. </returns>
        public bool IsOverlap(in Ray3 ray)
        {
            return IsIntersect(in ray).HasValue;
        }

        /// <summary>
        /// 축 정렬 육면체가 서로 겹치는지 검사합니다. 겹칠 경우 겹친 영역을 반환합니다.
        /// </summary>
        /// <param name="cube"> 축 정렬 육면체를 전달합니다. </param>
        /// <returns> 서로 겹칠 경우 겹친 영역을, 그렇지 않을 경우 null을 반환합니다. </returns>
        public AxisAlignedCube? IsIntersect(in AxisAlignedCube cube)
        {
            float left = Math.Max(Left, cube.Left);
            float bottom = Math.Max(Bottom, cube.Bottom);
            float near = Math.Max(Near, cube.Near);
            float right = Math.Min(Right, cube.Right);
            float top = Math.Min(Top, cube.Top);
            float far = Math.Min(Far, cube.Far);

            if (right >= left && top >= bottom && far >= near)
            {
                Vector3 min = new(left, bottom, near);
                Vector3 max = new(right, top, far);
                return new AxisAlignedCube(min, max);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 광선이 이 축 정렬 육면체 내부를 통과하는지 검사합니다. 통과할 경우 최초 통과 지점까지 가는 광선의 거리가 반환됩니다.
        /// </summary>
        /// <param name="ray"> 광선을 전달합니다. </param>
        /// <returns> 내부를 통과할 경우 최초 통과 지점까지 가는 광선의 거리가, 그렇지 않을 경우 null을 반환합니다. </returns>
        public float? IsIntersect(in Ray3 ray)
        {
            Vector3 dirinv = 1.0f / ray.Direction;

            float t1 = (Left - ray.Origin.X) * dirinv.X;
            float t2 = (Right - ray.Origin.X) * dirinv.X;
            float t3 = (Bottom - ray.Origin.Y) * dirinv.Y;
            float t4 = (Top - ray.Origin.Y) * dirinv.Y;
            float t5 = (Near - ray.Origin.Z) * dirinv.Z;
            float t6 = (Far - ray.Origin.Z) * dirinv.Z;

            float tmin = Math.Max(Math.Max(Math.Min(t1, t2), Math.Min(t3, t4)), Math.Min(t5, t6));
            float tmax = Math.Min(Math.Min(Math.Max(t1, t2), Math.Max(t3, t4)), Math.Max(t5, t6));

            if (tmax < 0)
            {
                return null;
            }

            if (tmin > tmax)
            {
                return null;
            }

            return tmin;
        }

        /// <summary>
        /// 축 정렬 육면체의 중앙 위치를 설정하거나 가져옵니다.
        /// </summary>
        public Vector3 Center
        {
            get => new Vector3((Left + Right) / 2, (Top + Bottom) / 2, (Near + Far) / 2);
            set
            {
                Vector3 extent = Extent;
                Min = value - extent;
                Max = value + extent;
            }
        }

        /// <summary>
        /// 축 정렬 육면체의 확장 크기를 설정하거나 가져옵니다.
        /// </summary>
        public Vector3 Extent
        {
            get => new Vector3(Math.Abs(Right - Left) / 2, Math.Abs(Top - Bottom) / 2, Math.Abs(Near - Far) / 2);
            set
            {
                Vector3 center = Center;
                Min = center - value;
                Max = center + value;
            }
        }

        /// <summary>
        /// 축 정렬 육면체의 너비를 설정하거나 가져옵니다.
        /// </summary>
        public float Width
        {
            get => Math.Abs(Right - Left);
            set
            {
                float centerX = Center.X;
                float half = value / 2;

                Left = centerX - half;
                Right = centerX + half;
            }
        }

        /// <summary>
        /// 축 정렬 육면체의 높이를 설정하거나 가져옵니다.
        /// </summary>
        public float Height
        {
            get => Math.Abs(Bottom - Top);
            set
            {
                float centerY = Center.Y;
                float half = value / 2;

                Top = centerY + half;
                Bottom = centerY - half;
            }
        }

        /// <summary>
        /// 축 정렬 육면체의 깊이를 설정하거나 가져옵니다.
        /// </summary>
        public float Depth
        {
            get => Math.Abs(Far - Near);
            set
            {
                float centerZ = Center.Z;
                float half = value / 2;

                Near = centerZ - half;
                Far = centerZ + half;
            }
        }

        /// <summary>
        /// 두 축 정렬 육면체가 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="left"> 첫 번째 축 정렬 육면체를 전달합니다. </param>
        /// <param name="right"> 두 번째 축 정렬 육면체를 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator ==(in AxisAlignedCube left, in AxisAlignedCube right)
        {
            return left.Min == right.Min && left.Max == right.Max;
        }

        /// <summary>
        /// 두 축 정렬 육면체가 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="left"> 첫 번째 축 정렬 육면체를 전달합니다. </param>
        /// <param name="right"> 두 번째 축 정렬 육면체를 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator !=(in AxisAlignedCube left, in AxisAlignedCube right)
        {
            return left.Min != right.Min || left.Max != right.Max;
        }

        /// <summary>
        /// 최소 위치 벡터를 나타냅니다.
        /// </summary>
        public Vector3 Min;

        /// <summary>
        /// 최대 위치 벡터를 나타냅니다.
        /// </summary>
        public Vector3 Max;
    }
}
