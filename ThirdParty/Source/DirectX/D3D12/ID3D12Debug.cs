// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 디버그 개체에 대한 공통 메서드를 제공합니다.
    /// </summary>
    [Guid( "344488b7-6846-474b-b989-f027448245e0" )]
	[ComVisible( true )]
	public interface ID3D12Debug : IUnknown
	{
		/// <summary>
		/// 디버그 레이어를 활성화합니다.
		/// </summary>
		void EnableDebugLayer();
	}
}
