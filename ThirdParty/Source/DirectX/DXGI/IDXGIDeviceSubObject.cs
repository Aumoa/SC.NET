// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// <see cref="IDXGIDevice"/> 인터페이스 개체에서 파생된 개체에 대한 공통 메서드를 제공합니다.
    /// </summary>
    [Guid( "3D3E0379-F9DE-4D58-BB6C-18D62992F1A6" )]
	[ComVisible( true )]
	public interface IDXGIDeviceSubObject : IDXGIObject
	{
		/// <summary>
		/// 이 개체를 생성한 장치 인터페이스 개체를 가져옵니다.
		/// </summary>
		/// <param name="riid"> 장치 인터페이스 ID를 전달합니다. </param>
		/// <param name="ppUnknown"> 인터페이스 개체를 받을 변수의 참조를 전달합니다. </param>
		void GetDevice( Guid riid, out IUnknown ppUnknown );
	}
}
