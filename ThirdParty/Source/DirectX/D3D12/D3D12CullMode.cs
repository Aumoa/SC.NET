// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 선별 모드를 나타냅니다.
    /// </summary>
    public enum D3D12CullMode
	{
		/// <summary>
		/// 선별하지 않습니다.
		/// </summary>
		None = 1,

		/// <summary>
		/// 전면을 선별합니다.
		/// </summary>
		Front = 2,

		/// <summary>
		/// 후면을 선별합니다.
		/// </summary>
		Back = 3
	}
}
