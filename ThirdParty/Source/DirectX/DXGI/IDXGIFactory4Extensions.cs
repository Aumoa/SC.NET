// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// <see cref="IDXGIFactory4"/> 인터페이스에 대한 추가 기능을 제공합니다.
    /// </summary>
    public static class IDXGIFactory4Extensions
	{
		/// <summary>
		/// 어댑터를 LUID 정보를 이용해 조회합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="adapterLuid"> 어댑터 LUID 정보를 전달합니다. </param>
		/// <returns> 검색된 어댑터 개체가 반환됩니다. 개체를 찾지 못했을 경우 null이 반환됩니다. </returns>
		public static IDXGIAdapter GetAdapterByLuid( this IDXGIFactory4 @this, Luid adapterLuid )
		{
			if ( @this.GetAdapterByLuid( adapterLuid, typeof( IDXGIAdapter ).GUID, out var unknown ) )
			{
				return unknown as IDXGIAdapter;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// WRAP 어댑터를 조회합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <returns> 검색된 어댑터 개체가 반환됩니다. 개체를 찾지 못했을 경우 null이 반환됩니다. </returns>
		public static IDXGIAdapter GetWarpAdapter( this IDXGIFactory4 @this )
		{
			if ( @this.GetWarpAdapter( typeof( IDXGIAdapter ).GUID, out var unknown ) )
			{
				return unknown as IDXGIAdapter;
			}
			else
			{
				return null;
			}
		}
	}
}
