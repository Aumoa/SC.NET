// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 셰이더 관측 가능성을 표현합니다.
    /// </summary>
    public enum D3D12ShaderVisibility
	{
		/// <summary>
		/// 모든 셰이더에서 관측 가능합니다.
		/// </summary>
		All = 0,

		/// <summary>
		/// 정점 셰이더에서만 관측 가능합니다.
		/// </summary>
		Vertex = 1,

		/// <summary>
		/// 덮개 셰이더에서만 관측 가능합니다.
		/// </summary>
		Hull = 2,

		/// <summary>
		/// 영역 셰이더에서만 관측 가능합니다.
		/// </summary>
		Domain = 3,

		/// <summary>
		/// 기하 셰이더에서만 관측 가능합니다.
		/// </summary>
		Geometry = 4,

		/// <summary>
		/// 픽셀 셰이더에서만 관측 가능합니다.
		/// </summary>
		Pixel = 5
	}
}
