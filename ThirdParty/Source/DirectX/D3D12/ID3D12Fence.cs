// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

using SC.ThirdParty.WinAPI;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 펜스 개체에 대한 공통 메서드를 제공합니다.
    /// </summary>
    [Guid( "0A753DCF-C4D8-4B91-ADF6-BE5A60D95A76" )]
	[ComVisible( true )]
	public interface ID3D12Fence : ID3D12Pageable
	{
		/// <summary>
		/// <see cref="ID3D12CommandQueue"/> 개체 또는 <see cref="Signal(ulong)"/> 메서드를 통해 마지막으로 지정된 값을 반환합니다.
		/// </summary>
		/// <returns> 현재 값이 반환됩니다. </returns>
		ulong GetCompletedValue();

		/// <summary>
		/// 펜스의 값이 지정한 값이 될 경우 이벤트를 활성화 상태로 설정합니다.
		/// </summary>
		/// <param name="value"> 값을 전달합니다. </param>
		/// <param name="hEvent"> 이벤트 개체를 전달합니다. </param>
		void SetEventOnCompletion( ulong value, IPlatformHandle hEvent );

		/// <summary>
		/// 펜스의 값을 설정합니다.
		/// </summary>
		/// <param name="value"> 값을 전달합니다. </param>
		void Signal( ulong value );
	}
}
