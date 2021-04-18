// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D11 선별 모드를 표현합니다.
    /// </summary>
    public enum D3D11CullMode
	{
		/// <summary>
		/// 선별하지 않음을 나타냅니다.
		/// </summary>
		None = 1,

		/// <summary>
		/// 전면 선별을 나타냅니다.
		/// </summary>
		Front = 2,

		/// <summary>
		/// 후면 선별을 나타냅니다.
		/// </summary>
		Back = 3
	}
}
