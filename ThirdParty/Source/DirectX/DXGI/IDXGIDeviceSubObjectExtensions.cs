// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// <see cref="IDXGIDeviceSubObject"/> 인터페이스 개체의 확장 메서드를 제공합니다.
    /// </summary>
    public static class IDXGIDeviceSubObjectExtensions
	{
		/// <summary>
		/// 이 개체를 생성한 장치 인터페이스 개체를 가져옵니다.
		/// </summary>
		/// <typeparam name="T"> 장치 인터페이스의 유형을 전달합니다. </typeparam>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="riid"> 장치 인터페이스 ID를 전달합니다. </param>
		public static T GetDevice<T>( this IDXGIDeviceSubObject @this, Guid riid ) where T : class
		{
			@this.GetDevice( riid, out var unknown );
			return unknown as T;
		}

		/// <summary>
		/// 이 개체를 생성한 장치 인터페이스 개체를 가져옵니다.
		/// </summary>
		/// <typeparam name="T"> 장치 인터페이스의 유형을 전달합니다. </typeparam>
		/// <param name="this"> 개체를 전달합니다. </param>
		public static T GetDevice<T>( this IDXGIDeviceSubObject @this ) where T : class
		{
			@this.GetDevice( typeof( T ).GUID, out var unknown );
			return unknown as T;
		}
	}
}
