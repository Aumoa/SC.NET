// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 기본 기하 도형의 유형을 나타냅니다.
    /// </summary>
    public enum D3D12PrimitiveTopologyType
	{
		/// <summary>
		/// 정의되지 않은 형식입니다.
		/// </summary>
		Undefined = 0,

		/// <summary>
		/// 점 형식을 나타냅니다.
		/// </summary>
		Point = 1,

		/// <summary>
		/// 선 형식을 나타냅니다.
		/// </summary>
		Line = 2,

		/// <summary>
		/// 삼각형 형식을 나타냅니다.
		/// </summary>
		Triangle = 3,

		/// <summary>
		/// 패치 컨트롤 형식을 나타냅니다.
		/// </summary>
		Patch = 4
	}
}
