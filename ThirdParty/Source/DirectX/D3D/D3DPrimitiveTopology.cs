// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
	/// <summary>
	/// D3D 최소 기하 모형을 나타냅니다.
	/// </summary>
	public enum D3DPrimitiveTopology
	{
		/// <summary>
		/// 정의되지 않은 형식입니다.
		/// </summary>
		Undefined = 0,

		/// <summary>
		/// 점 목록 형식입니다.
		/// </summary>
		PointList = 1,

		/// <summary>
		/// 선 목록 형식입니다.
		/// </summary>
		LineList = 2,

		/// <summary>
		/// 선 연결 목록 형식입니다.
		/// </summary>
		LineStrip = 3,

		/// <summary>
		/// 삼각형 목록 형식입니다.
		/// </summary>
		TriangleList = 4,

		/// <summary>
		/// 삼각형 연결 목록 형식입니다.
		/// </summary>
		TriangleStrip = 5,

		/// <summary>
		/// 인접 정보를 가지는 선 목록 형식입니다.
		/// </summary>
		LineList_ADJ = 10,

		/// <summary>
		/// 인접 정보를 가지는 선 연결 목록 형식입니다.
		/// </summary>
		LineStrip_ADJ = 11,

		/// <summary>
		/// 인접 정보를 가지는 삼각형 목록 형식입니다.
		/// </summary>
		TriangleList_ADJ = 12,

		/// <summary>
		/// 인접 정보를 가지는 삼각형 연결 목록 형식입니다.
		/// </summary>
		TriangleStrip_ADJ = 13,

		/// <summary>
		/// 1개의 제어점을 가지는 패치 리스트 형식입니다.
		/// </summary>
		ControlPointPatchList1 = 33,

		/// <summary>
		/// 32개의 제어점을 가지는 패치 리스트 형식입니다.
		/// </summary>
		ControlPointPatchList32 = 64,

		/// <summary>
		/// N개의 제어점을 가지는 패치 리스트에서, 1부터 시작하는 시작 위치를 나타냅니다.
		/// </summary>
		ControlPointPatchListBegin = ControlPointPatchList1,

		/// <summary>
		/// N개의 제어점 위치를 가지는 패치 리스트에서, 32로 종료되는 종료 위치를 나타냅니다.
		/// </summary>
		ControlPointPatchListEnd = ControlPointPatchList32,
	}
}
