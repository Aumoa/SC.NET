// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.Engine.Runtime.Core.Numerics
{
    /// <summary>
    /// 축 회전을 가지는 육면체 형식을 정의합니다.
    /// </summary>
    public class ObjectOrientedCube : INearlyEquatable<ObjectOrientedCube, float>, IFormattable
    {
		/// <summary>
		/// 사각형의 중앙 위치를 설정합니다.
		/// </summary>
		public Vector3 Center;

		/// <summary>
		/// 사각형의 확장 범위를 설정합니다.
		/// </summary>
		public Vector3 Extent;

		/// <summary>
		/// 사각형의 회전을 설정합니다.
		/// </summary>
		public Quaternion Rotation;

		/// <summary>
		/// <see cref="ObjectOrientedCube"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="center"> 중앙 위치를 전달합니다. </param>
		/// <param name="extent"> 확장 범위를 전달합니다. </param>
		/// <param name="rotation"> 회전을 전달합니다. </param>
		public ObjectOrientedCube(Vector3 center, Vector3 extent, Quaternion rotation)
		{
			Center = center;
			Extent = extent;
			Rotation = rotation;
		}

		/// <summary>
		/// 대상 오브젝트가 축 회전 육면체일 경우, 두 축 회전 육면체가 서로 같은지 비교합니다.
		/// </summary>
		/// <param name="obj"> 대상 오브젝트를 전달합니다. </param>
		/// <returns> 비교 결과가 반환됩니다. </returns>
		public override bool Equals(object obj)
        {
			if (obj is ObjectOrientedCube cube)
            {
				return Equals(cube);
            }
			else
            {
				return base.Equals(obj);
            }
        }

		/// <summary>
		/// 축 회전 육면체의 전체 값의 해시 코드를 가져옵니다.
		/// </summary>
		/// <returns> 해시 코드가 반환됩니다. </returns>
		public override int GetHashCode()
		{
			return Center.GetHashCode() ^ Extent.GetHashCode() ^ Rotation.GetHashCode();
		}

		/// <summary>
		/// {Center: {X, Y, Z}, Extent: {X, Y, Z}, Rotation: {X, Y, Z, W}} 형식의 문자열을 가져옵니다.
		/// </summary>
		/// <returns> 생성된 문자열이 반환됩니다. </returns>
		public override string ToString()
		{
			return string.Format(
				"{{Center: {0}, Extent: {1}, Rotation: {2}}}",
				Center,
				Extent,
				Rotation
			);
		}

		/// <summary>
		/// 두 축 회전 육면체가 서로 같은지 비교합니다.
		/// </summary>
		/// <param name="cube"> 대상 축 정렬 육면체를 전달합니다. </param>
		/// <returns> 비교 결과가 반환됩니다. </returns>
		public bool Equals(ObjectOrientedCube cube)
		{
			return Center == cube.Center
				&& Extent == cube.Extent
				&& Rotation == cube.Rotation;
		}

		/// <inheritdoc/>
		public bool NearlyEquals(ObjectOrientedCube cube, float epsilon)
		{
			return Center.NearlyEquals(cube.Center, epsilon)
				&& Extent.NearlyEquals(cube.Extent, epsilon)
				&& Rotation.NearlyEquals(cube.Rotation, epsilon);
		}

		/// <summary>
		/// 서식을 지정하여 {Center: {X, Y, Z}, Extent: {X, Y, Z}, Rotation: {X, Y, Z, W}} 형식의 문자열을 가져옵니다.
		/// </summary>
		/// <param name="format"> 서식 문자열을 전달합니다. </param>
		/// <param name="formatProvider"> 문화권 정보를 전달합니다. </param>
		/// <returns> 생성된 문자열이 반환됩니다. </returns>
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format(
				"{{Center: {0}, Extent: {1}, Rotation: {2}}}",
				Center.ToString(format, formatProvider),
				Extent.ToString(format, formatProvider),
				Rotation.ToString(format, formatProvider)
			);
		}

		/// <summary>
		/// 두 축 회전 육면체가 서로 겹치는지 검사합니다.
		/// </summary>
		/// <param name="cube"> 축 회전 육면체를 전달합니다. </param>
		/// <returns> 서로 겹칠 경우 </returns>
		public unsafe bool IsOverlap(ObjectOrientedCube cube)
		{
			Span<Vector3> Axis = stackalloc Vector3[3] { AxisX, AxisY, AxisZ };
			Span<float> pExtent = stackalloc float[3] { Extent.X, Extent.Y, Extent.Z };
			Span<Vector3> OtherAxis = stackalloc Vector3[3] { cube.AxisX, cube.AxisY, cube.AxisZ };
			Span<float> pOtherExtent = stackalloc float[3] { cube.Extent.X, cube.Extent.Y, cube.Extent.Z };

			Vector3 abvec = cube.Center - Center;

			Span<Vector3> cofactor = stackalloc Vector3[3];
			Span<Vector3> absCof = stackalloc Vector3[3];
			Span<float> a_dot = stackalloc float[3];

			// Check A-oriented axes.
			{
				for (int i = 0; i < 3; ++i)
				{
					//
					// Primary assign primitive values.
					cofactor[i][0] = Axis[i] | cube.AxisX;
					cofactor[i][1] = Axis[i] | cube.AxisY;
					cofactor[i][2] = Axis[i] | cube.AxisZ;

					a_dot[i] = Axis[i] | abvec;

					absCof[i][0] = Math.Abs(cofactor[i][0]);
					absCof[i][1] = Math.Abs(cofactor[i][1]);
					absCof[i][2] = Math.Abs(cofactor[i][2]);

					float R = Math.Abs(a_dot[i]);
					float R1 = cube.Extent | new Vector3(absCof[i][0], absCof[i][1], absCof[i][2]);
					float R01 = pExtent[i] + R1;

					if (R > R01)
					{
						return false;
					}
				}
			}

			// Check B-oriented axes.
			{
				for (int i = 0; i < 3; ++i)
				{
					float R = Math.Abs(OtherAxis[i] | abvec);
					float R0 = Extent | new Vector3(absCof[0][i], absCof[1][i], absCof[2][i]);
					float R01 = R0 + pOtherExtent[i];

					if (R > R01)
					{
						return false;
					}
				}
			}

			// Check complex axes.
			{
				Span<int> OrderA = stackalloc int[3] { 2, 0, 1 };
				Span<int> OrderB = stackalloc int[3] { 1, 2, 0 };

				for (int i = 0; i < 3; ++i)
				{
					for (int j = 0; j < 3; ++j)
					{
						float R = Math.Abs(
							a_dot[OrderA[i]] * cofactor[OrderB[i]][j]
							-
							a_dot[OrderB[i]] * cofactor[OrderA[i]][j]
						);

						int nInc = (i == 0) ? 1 : 0;  // 1, 0, 0
						int nExc = 2 - ((i == 2) ? 1 : 0);  // 2, 2, 1
						float R0 = pExtent[nInc] * absCof[nExc][j] + pExtent[nExc] * absCof[nInc][j];

						nInc = (j == 0) ? 1 : 0;
						nExc = 2 - ((j == 2) ? 1 : 0);
						float R1 = pOtherExtent[nInc] * absCof[i][nExc] + pOtherExtent[nExc] * absCof[i][nInc];

						float R01 = R0 + R1;
						if (R > R01)
						{
							return false;
						}
					}
				}
			}

			return true;
		}

		/// <summary>
		/// 이 축 회전 육면체의 각 정점을 가져옵니다.
		/// </summary>
		/// <returns> 정점 배열이 반환됩니다. </returns>
		public unsafe Vector3[] CalcVertices()
		{
			Span<float> Signs = stackalloc float[2];

			var verts = new Vector3[8];
			int index = 0;

			for (int i = 0; i < 2; ++i)
			{
				for (int j = 0; j < 2; ++j)
				{
					for (int k = 0; k < 2; ++k)
					{
						verts[index++] = Center + Signs[i] * AxisX * Extent.X + Signs[j] * AxisY * Extent.Y + Signs[k] * AxisZ * Extent.Z;
					}
				}
			}

			return verts;
		}

		/// <summary>
		/// 설정된 회전의 로컬 X축 방향을 가져옵니다.
		/// </summary>
		public Vector3 AxisX
		{
			get => Rotation.RotateVector(new Vector3(1, 0, 0));
		}

		/// <summary>
		/// 설정된 회전의 로컬 Y축 방향을 가져옵니다.
		/// </summary>
		public Vector3 AxisY
		{
			get => Rotation.RotateVector(new Vector3(0, 1, 0));
		}

		/// <summary>
		/// 설정된 회전의 로컬 Z축 방향을 가져옵니다.
		/// </summary>
		public Vector3 AxisZ
		{
			get => Rotation.RotateVector(new Vector3(0, 0, 1));
		}

		/// <summary>
		/// 두 축 회전 육면체가 같은지 검사합니다. 
		/// </summary>
		/// <param name="left"> 첫 번째 값을 전달합니다. </param>
		/// <param name="right"> 두 번째 값을 전달합니다. </param>
		/// <returns> 비교 결과가 반환됩니다. </returns>
		public static bool operator ==(ObjectOrientedCube left, ObjectOrientedCube right)
        {
			return left.Center == right.Center && left.Extent == right.Extent && left.Rotation == right.Rotation;
		}

		/// <summary>
		/// 두 축 회전 육면체가 다른지 검사합니다. 
		/// </summary>
		/// <param name="left"> 첫 번째 값을 전달합니다. </param>
		/// <param name="right"> 두 번째 값을 전달합니다. </param>
		/// <returns> 비교 결과가 반환됩니다. </returns>
		public static bool operator !=(ObjectOrientedCube left, ObjectOrientedCube right)
        {
			return left.Center != right.Center || left.Extent != right.Extent || left.Rotation != right.Rotation;
		}
    }
}
