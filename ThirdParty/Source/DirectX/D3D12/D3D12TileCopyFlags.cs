// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 타일 리소스 복사 속성을 표현합니다.
    /// </summary>
    [Flags]
	public enum D3D12TileCopyFlags
	{
		/// <summary>
		/// 아무 속성도 지정하지 않습니다.
		/// </summary>
		None = 0,

		/// <summary>
		/// GPU가 현재 대상 메모리 부분을 참조하고 있지 않음을 나타냅니다.
		/// </summary>
		NoHazard = 0x1,

		/// <summary>
		/// 
		/// </summary>
		LinearBufferToSwizzledTiledResource = 0x2,

		/// <summary>
		/// 
		/// </summary>
		SwizzledTiledResourceToLinearBuffer = 0x4
	}
}
