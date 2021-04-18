// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
	/// <summary>
	/// D2D1 디바이스 개체에 대한 공통 메서드를 제공합니다.
	/// </summary>
	[Guid( "47dd575d-ac05-4cdd-8049-9b02cd16f44c" )]
	[ComVisible( true )]
	public interface ID2D1Device : ID2D1Resource
	{
		/// <summary>
		/// 디바이스 컨텍스트 개체를 생성합니다.
		/// </summary>
		/// <param name="options"> 디바이스 컨텍스트 옵션을 전달합니다. </param>
		/// <returns> 생성된 개체 인터페이스가 반환됩니다. </returns>
		ID2D1DeviceContext CreateDeviceContext( D2D1DeviceContextOptions options );

		/// <summary>
		/// 팩토리 개체를 가져옵니다.
		/// </summary>
		/// <returns> 개체가 반환됩니다. </returns>
		ID2D1Factory GetFactory();
	}
}
