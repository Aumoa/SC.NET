// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 명령 서명 개체에 대한 공통 메서드를 제공합니다.
    /// </summary>
    [Guid( "C36A797C-EC80-4F0A-8985-A7B2475082D1" )]
	[ComVisible( true )]
	public interface ID3D12CommandSignature : ID3D12Pageable
	{
	}
}
