// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D11 리소스 기타 속성을 나타냅니다.
    /// </summary>
    [Flags]
	public enum D3D11ResourceMiscFlags
	{
		/// <summary>
		/// 아무 속성도 지정하지 않습니다.
		/// </summary>
		None = 0,

		/// <summary>
		/// 
		/// </summary>
		GenerateMips = 0x1,

		/// <summary>
		/// 
		/// </summary>
		Shared = 0x2,

		/// <summary>
		/// 
		/// </summary>
		TextureCube = 0x4,

		/// <summary>
		/// 
		/// </summary>
		DrawIndirectArgs = 0x10,

		/// <summary>
		/// 
		/// </summary>
		BufferAllowRawViews = 0x20,

		/// <summary>
		/// 
		/// </summary>
		BufferStructured = 0x40,

		/// <summary>
		/// 
		/// </summary>
		ResourceClamp = 0x80,

		/// <summary>
		/// 
		/// </summary>
		SharedKeyedMutex = 0x100,

		/// <summary>
		/// 
		/// </summary>
		GDICompatible = 0x200,

		/// <summary>
		/// 
		/// </summary>
		SharedNTHandle = 0x800,

		/// <summary>
		/// 
		/// </summary>
		RestrictedContent = 0x1000,

		/// <summary>
		/// 
		/// </summary>
		RestrictSharedResource = 0x2000,

		/// <summary>
		/// 
		/// </summary>
		RestrictSharedResourceDriver = 0x4000,

		/// <summary>
		/// 
		/// </summary>
		Guarded = 0x8000,

		/// <summary>
		/// 
		/// </summary>
		TilePool = 0x20000,

		/// <summary>
		/// 
		/// </summary>
		Tiled = 0x40000,

		/// <summary>
		/// 
		/// </summary>
		HWProtected = 0x80000
	}
}
