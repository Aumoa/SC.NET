// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 타일 매핑 속성을 나타냅니다.
    /// </summary>
    public enum D3D12TileMappingFlags
	{
		/// <summary>
		/// 아무 속성도 지정하지 않습니다.
		/// </summary>
		None,

		/// <summary>
		/// GPU가 현재 대상 메모리 부분을 참조하고 있지 않음을 나타냅니다.
		/// </summary>
		NoHazard = 0x1
	}
}
