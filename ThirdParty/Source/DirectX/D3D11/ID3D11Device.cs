// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D11 디바이스 개체에 대한 공통 메서드를 제공합니다.
    /// </summary>
    [Guid( "db6f6ddb-ac77-4e88-8253-819df9bbf140" )]
	[ComVisible( true )]
	public interface ID3D11Device : IUnknown
	{
		/// <summary>
		/// 디바이스로 즉시 전송되는 명령 컨텍스트 개체를 가져옵니다.
		/// </summary>
		/// <returns> 디바이스 컨텍스트 개체가 반환됩니다. </returns>
		ID3D11DeviceContext GetImmediateContext();
	}
}
