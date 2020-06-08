// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

namespace SC.Engine.Runtime.Core.Numerics
{
    /// <summary>
    /// 평면을 표현합니다.
    /// </summary>
    public struct Plane : INearlyEquatable<Plane, float>, IFormattable
    {
        /// <summary>
        /// 평면이 바라보는 방향을 나타냅니다.
        /// </summary>
        public Vector3 Normal;

        /// <summary>
        /// 원점에서부터의 평면 거리를 나타냅니다.
        /// </summary>
        public float Distance;

        /// <summary>
        /// 모든 값을 지정하여 <see cref="Plane"/> 구조체의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="normal"> 평면이 바라보는 방향을 전달합니다. </param>
        /// <param name="distance"> 원점으로부터의 평면 거리를 나타냅니다. </param>
        public Plane(Vector3 normal, float distance)
        {
            Normal = normal;
            Distance = distance;
        }

        /// <summary>
        /// 모든 값을 지정하여 <see cref="Plane"/> 구조체의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="x"> 평면이 바라보는 방향을 전달합니다. </param>
        /// <param name="y"> 평면이 바라보는 방향을 전달합니다. </param>
        /// <param name="z"> 평면이 바라보는 방향을 전달합니다. </param>
        /// <param name="distance"> 원점으로부터의 평면 거리를 나타냅니다. </param>
        public Plane(float x, float y, float z, float distance)
        {
            Normal = new Vector3(x, y, z);
            Distance = distance;
        }

        /// <summary>
        /// 대상 오브젝트가 평면일 경우, 두 평면이 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="obj"> 대상 오브젝트를 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public override bool Equals(object obj)
        {
            if (obj is Plane plane)
            {
                return Equals(plane);
            }
            else
            {
                return base.Equals(obj);
            }
        }

        /// <summary>
        /// 전체 값의 해시 코드를 가져옵니다.
        /// </summary>
        /// <returns> 해시 코드가 반환됩니다. </returns>
        public override int GetHashCode()
        {
            return Normal.GetHashCode() ^ Distance.GetHashCode();
        }

        /// <summary>
        /// {Normal: {Normal}, Distance: {Distance}} 형식의 문자열을 가져옵니다.
        /// </summary>
        /// <returns> 생성된 문자열이 반환됩니다. </returns>
        public override string ToString()
        {
            return string.Format("{{Normal: {0}, Distance: {1}}}", Normal, Distance);
        }

        /// <summary>
        /// 두 평면이 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="plane"> 대상 평면을 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public bool Equals(Plane plane)
        {
            return this == plane;
        }

        /// <inheritdoc/>
        public bool NearlyEquals(in Plane cube, float epsilon)
        {
            return Normal.NearlyEquals(cube.Normal, epsilon)
                && Math.Abs(cube.Distance - Distance) <= epsilon;
        }

        /// <summary>
        /// 서식을 지정하여 {Normal: {Normal}, Distance: {Distance}} 형식의 문자열을 가져옵니다.
        /// </summary>
        /// <param name="format"> 서식 문자열을 전달합니다. </param>
        /// <param name="formatProvider"> 문화권 정보를 전달합니다. </param>
        /// <returns> 생성된 문자열이 반환됩니다. </returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format(
                "{{Normal: {0}, Distance: {1}}}",
                Normal.ToString(format, formatProvider),
                Distance.ToString(format, formatProvider)
            );
        }

        /// <summary>
        /// 두 평면이 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="left"> 첫 번째 평면을 전달합니다. </param>
        /// <param name="right"> 두 번째 평면을 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator ==(in Plane left, in Plane right)
        {
            return
                left.Normal == right.Normal &&
                left.Distance == right.Distance;
        }

        /// <summary>
        /// 두 평면이 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="left"> 첫 번째 평면을 전달합니다. </param>
        /// <param name="right"> 두 번째 평면을 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator !=(in Plane left, in Plane right)
        {
            return
                left.Normal != right.Normal ||
                left.Distance != right.Distance;
        }
    }
}