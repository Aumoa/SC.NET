// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
	/// <summary>
	/// D2D1 DXGI 호환 가능한 비트맵 개체에 대한 공통 메서드를 제공합니다.
	/// </summary>
	[Guid( "a898a84c-3873-4588-b08b-ebbf978df041" )]
	[ComVisible( true )]
	public interface ID2D1Bitmap1 : ID2D1Bitmap
	{
		/// <summary>
		/// DXGI 표면 개체를 가져옵니다.
		/// </summary>
		/// <returns> 표면 개체가 반환됩니다. </returns>
		IDXGISurface GetSurface();
	}
}
