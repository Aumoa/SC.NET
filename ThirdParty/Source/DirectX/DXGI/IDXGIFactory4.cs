// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI 개체를 통합 관리하는 개체에 대한 공통 함수를 제공합니다.
    /// </summary>
    [Guid( "1BC6EA02-EF36-464F-BF0C-21CA39E5168A" )]
	[ComVisible( true )]
	public interface IDXGIFactory4 : IDXGIFactory3
	{
		/// <summary>
		/// 어댑터를 LUID 정보를 이용해 조회합니다.
		/// </summary>
		/// <param name="adapterLuid"> 어댑터 LUID 정보를 전달합니다. </param>
		/// <param name="iid"> 어댑터 개체의 GUID를 전달합니다. </param>
		/// <param name="ppUnknown"> 어댑터 개체를 받을 변수의 참조를 전달합니다. </param>
		/// <returns> 어댑터가 검색되었을 경우 true를, 아닐 경우 false를 반환합니다. </returns>
		bool GetAdapterByLuid( Luid adapterLuid, Guid iid, out IUnknown ppUnknown );
	
		/// <summary>
		/// WARP 어댑터를 조회합니다.
		/// </summary>
		/// <param name="iid"> 어댑터 개체의 GUID를 전달합니다. </param>
		/// <param name="ppUnknown"> 어댑터 개체를 받을 변수의 참조를 전달합니다. </param>
		/// <returns> 어댑터가 검색되었을 경우 true를, 아닐 경우 false를 반환합니다. </returns>
		bool GetWarpAdapter( Guid iid, out IUnknown ppUnknown );
	}
}
