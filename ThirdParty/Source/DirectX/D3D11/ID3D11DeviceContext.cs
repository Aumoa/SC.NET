// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D11 디바이스에 명령을 전달하는 디바이스 컨텍스트 개체에 대한 공통 메서드를 제공합니다.
    /// </summary>
    [Guid( "c0bfa96c-e089-44fb-8eaf-26f8796190da" )]
	[ComVisible( true )]
	public interface ID3D11DeviceContext : ID3D11DeviceChild
	{
		/// <summary>
		/// 디바이스 컨텍스트의 현재 설정된 모든 상태를 초기화합니다.
		/// </summary>
		void ClearState();

		/// <summary>
		/// 지금까지의 명령을 즉시 전송합니다. 즉시 명령을 전송하는 디바이스 컨텍스트 개체에서만 사용할 수 있습니다.
		/// </summary>
		void Flush();
	}
}
