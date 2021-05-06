// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.Engine.Runtime.Core.Numerics
{
    /// <summary>
    /// 3차원 광선 정보를 정의합니다.
    /// </summary>
    public struct Ray3 : INearlyEquatable<Ray3, float>, IFormattable
    {
        /// <summary>
        /// 광선의 시작 위치를 나타냅니다.
        /// </summary>
        public Vector3 Origin;

        /// <summary>
        /// 광선의 방향을 나타냅니다.
        /// </summary>
        public Vector3 Direction;

        /// <summary>
        /// 광선의 길이를 나타냅니다. null일 경우 무한을 나타냅니다.
        /// </summary>
        public float? Distance;

        /// <summary>
        /// 모든 값을 지정하여 <see cref="Ray3"/> 구조체의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="origin"> 광선의 시작 위치를 전달합니다. </param>
        /// <param name="direction"> 광선의 방향을 전달합니다. </param>
        /// <param name="distance"> 광선의 길이를 전달합니다. null을 전달할 경우 무한을 나타냅니다. </param>
        public Ray3(Vector3 origin, Vector3 direction, float? distance = null)
        {
            Origin = origin;
            Direction = direction;
            Distance = distance;
        }

        /// <summary>
        /// 대상 오브젝트가 광선일 경우, 두 광선이 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="obj"> 대상 오브젝트를 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public override bool Equals(object obj)
        {
            if (obj is Ray3 ray)
            {
                return Equals(ray);
            }
            else
            {
                return base.Equals(obj);
            }
        }

        /// <summary>
        /// 광선의 전체 값의 해시 코드를 가져옵니다.
        /// </summary>
        /// <returns> 해시 코드가 반환됩니다. </returns>
        public override int GetHashCode()
        {
            return Origin.GetHashCode() ^ Direction.GetHashCode() ^ Distance.GetHashCode();
        }

        /// <summary>
        /// {Origin: {<see cref="Origin"/>}, Direction: {<see cref="Direction"/>}, Distance: {<see cref="Distance"/>}} 형식의 문자열을 가져옵니다.
        /// </summary>
        /// <returns> 생성된 문자열이 반환됩니다. </returns>
        public override string ToString()
        {
            string dist = Distance.HasValue ? Distance.Value.ToString() : "Inf";
            return string.Format(
                "{{{0}: {1}, {2}: {3}, {4}: {5}}}",
                nameof(Origin),
                Origin,
                nameof(Direction),
                Direction,
                nameof(Distance),
                dist
            );
        }

        /// <summary>
        /// 두 광선이 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="ray"> 대상 광선을 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public bool Equals(Ray3 ray)
        {
            return this == ray;
        }

        /// <inheritdoc/>
        public bool NearlyEquals(in Ray3 ray, float epsilon)
        {
            bool dist = false;

            if (Distance.HasValue && ray.Distance.HasValue)
            {
                dist = Math.Abs(Distance.Value - ray.Distance.Value) <= epsilon;
            }
            else
            {
                dist = Distance.HasValue == ray.Distance.HasValue;
            }

            return Origin.NearlyEquals(ray.Origin, epsilon)
                && Direction.NearlyEquals(ray.Direction, epsilon)
                && dist;
        }

        /// <summary>
        /// 서식을 지정하여 {Origin: {<see cref="Origin"/>}, Direction: {<see cref="Direction"/>}, Distance: {<see cref="Distance"/>}} 형식의 문자열을 가져옵니다.
        /// </summary>
        /// <param name="format"> 서식 문자열을 전달합니다. </param>
        /// <param name="formatProvider"> 문화권 정보를 전달합니다. </param>
        /// <returns> 생성된 문자열이 반환됩니다. </returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            string dist = Distance.HasValue ? Distance.Value.ToString(format, formatProvider) : "Inf";
            return string.Format(
                "{{{0}: {1}, {2}: {3}, {4}: {5}}}",
                nameof(Origin),
                Origin.ToString(format, formatProvider),
                nameof(Direction),
                Direction.ToString(format, formatProvider),
                nameof(Distance),
                dist
            );
        }

        /// <summary>
        /// 지정한 거리만큼 이동된 광선의 위치 벡터를 가져옵니다.
        /// </summary>
        /// <param name="distance"> 이동할 거리를 전달합니다. </param>
        /// <returns> 계산된 위치 벡터가 반환됩니다. </returns>
        public Vector3 GetPoint(float distance)
        {
            return Origin + Direction * distance;
        }

        /// <summary>
        /// 광선이 대상 축 정렬 육면체 내부를 통과하는지 검사합니다.
        /// </summary>
        /// <param name="cube"> 축 정렬 육면체를 전달합니다. </param>
        /// <returns> 내부를 통과할 경우 true를 반환합니다. </returns>
        public bool IsOverlap(in AxisAlignedCube cube)
        {
            return cube.IsOverlap(this);
        }

        /// <summary>
        /// 광선이 대상 축 정렬 육면체 내부를 통과하는지 검사합니다. 통과할 경우 최초 통과 지점까지 가는 광선의 거리가 반환됩니다.
        /// </summary>
        /// <param name="cube"> 축 정렬 육면체를 전달합니다. </param>
        /// <returns> 내부를 통과할 경우 최초 통과 지점까지 가는 광선의 거리가, 그렇지 않을 경우 null을 반환합니다. </returns>
        public float? IsIntersect(in AxisAlignedCube cube)
        {
            return cube.IsIntersect(this);
        }

        /// <summary>
        /// 두 광선이 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="left"> 첫 번째 광선을 전달합니다. </param>
        /// <param name="right"> 두 번째 광선을 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator ==(in Ray3 left, in Ray3 right)
        {
            return left.Origin == right.Origin && left.Direction == right.Direction && left.Distance == right.Distance;
        }

        /// <summary>
        /// 두 광선이 서로 같지 않은지 비교합니다.
        /// </summary>
        /// <param name="left"> 첫 번째 광선을 전달합니다. </param>
        /// <param name="right"> 두 번째 광선을 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator !=(in Ray3 left, in Ray3 right)
        {
            return left.Origin != right.Origin || left.Direction != right.Direction || !(left.Distance == right.Distance);
        }
    };
}
