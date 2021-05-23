// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;

namespace SC.Engine.Runtime.Core.Collision
{
    /// <summary>
    /// 겹침 테스트를 진행하는 함수 집합입니다.
    /// </summary>
    public static class OverlapTest
    {
        /// <summary>
        /// <see cref="Frustum"/> 및 <see cref="AxisAlignedCube"/> 형식의 겹침 테스트를 진행합니다.
        /// </summary>
        /// <param name="inFrustum"> 값을 전달합니다. </param>
        /// <param name="inAABB"> 값을 전달합니다. </param>
        /// <returns> 겹침 테스트 결과가 반환됩니다. </returns>
        public static bool IsOverlap(this Frustum inFrustum, AxisAlignedCube inAABB)
		{
			for (int i = 0; i < 6; i++)
			{
				if (Plane.DotCoord(inFrustum[i], new Vector3(inAABB.Min.X, inAABB.Min.Y, inAABB.Min.Z)) >= 0.0f)
				{
					continue;
				}

				if (Plane.DotCoord(inFrustum[i], new Vector3(inAABB.Max.X, inAABB.Min.Y, inAABB.Min.Z)) >= 0.0f)
				{
					continue;
				}

				if (Plane.DotCoord(inFrustum[i], new Vector3(inAABB.Min.X, inAABB.Max.Y, inAABB.Min.Z)) >= 0.0f)
				{
					continue;
				}

				if (Plane.DotCoord(inFrustum[i], new Vector3(inAABB.Min.X, inAABB.Min.Y, inAABB.Max.Z)) >= 0.0f)
				{
					continue;
				}

				if (Plane.DotCoord(inFrustum[i], new Vector3(inAABB.Max.X, inAABB.Max.Y, inAABB.Min.Z)) >= 0.0f)
				{
					continue;
				}

				if (Plane.DotCoord(inFrustum[i], new Vector3(inAABB.Max.X, inAABB.Min.Y, inAABB.Max.Z)) >= 0.0f)
				{
					continue;
				}

				if (Plane.DotCoord(inFrustum[i], new Vector3(inAABB.Min.X, inAABB.Max.Y, inAABB.Max.Z)) >= 0.0f)
				{
					continue;
				}

				if (Plane.DotCoord(inFrustum[i], new Vector3(inAABB.Max.X, inAABB.Max.Y, inAABB.Max.Z)) >= 0.0f)
				{
					continue;
				}

				return false;
			}

			return true;
		}
    }
}
