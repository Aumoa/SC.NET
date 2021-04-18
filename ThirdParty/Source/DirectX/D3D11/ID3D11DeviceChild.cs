// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D11 장치 개체에서 파생된 개체에 대한 공통 메서드를 제공합니다.
    /// </summary>
    [Guid( "1841e5c8-16b0-489b-bcc8-44cfb0d5deae" )]
	[ComVisible( true )]
	public interface ID3D11DeviceChild : IUnknown
	{
	}
}
