// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D 드라이버 유형을 표현합니다.
    /// </summary>
    public enum D3DDriverType
	{
		/// <summary>
		/// 알 수 없는 드라이버 유형입니다.
		/// </summary>
		Unknown = 0,

		/// <summary>
		/// 하드웨어 유형입니다.
		/// </summary>
		Hardware,

		/// <summary>
		/// 레퍼런스 유형입니다.
		/// </summary>
		Reference,

		/// <summary>
		/// 
		/// </summary>
		Null,

		/// <summary>
		/// 소프트웨어 구현 유형입니다.
		/// </summary>
		Software,

		/// <summary>
		/// WARP(Windows Advance Rasterization Platform) 유형입니다.
		/// </summary>
		Warp
	}
}
