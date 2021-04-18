// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D 표준 데이터 전송 방식으로 사용하는 데이터 블록을 표현합니다.
    /// </summary>
    [Guid( "8BA5FB08-5195-40E2-AC58-0D989C3A0102" )]
	[ComVisible( true )]
	public interface ID3DBlob : IUnknown
	{
		/// <summary>
		/// 버퍼의 네이티브 포인터를 가져옵니다.
		/// </summary>
		/// <returns> 네이티브 포인터가 반환됩니다. </returns>
		IntPtr GetBufferPointer();

		/// <summary>
		/// 버퍼의 크기를 가져옵니다.
		/// </summary>
		/// <returns> 버퍼의 크기가 반환됩니다. </returns>
		ulong GetBufferSize();
	}
}
