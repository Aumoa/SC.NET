// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI GPU에서 사용하는 표면 데이터를 표현합니다.
    /// </summary>
    [Guid( "CAFCB56C-6AC3-4889-BF47-9E23BBD260EC" )]
	[ComVisible( true )]
	public interface IDXGISurface : IDXGIDeviceSubObject
	{
		/// <summary>
		/// 표면의 정보를 서술하는 구조체를 가져옵니다.
		/// </summary>
		/// <returns> 표면의 정보를 서술하는 구조체를 반환합니다. </returns>
		DXGISurfaceDesc GetDesc();

		/// <summary>
		/// 표면을 매핑합니다.
		/// </summary>
		/// <param name="flags"> 매핑 속성을 전달합니다. </param>
		/// <returns> 매핑 데이터 정보 구조체를 반환합니다. </returns>
		DXGIMappedRect Map( DXGIMapFlags flags );

		/// <summary>
		/// 표면의 매핑을 종료합니다.
		/// </summary>
		void Unmap();
	}
}
