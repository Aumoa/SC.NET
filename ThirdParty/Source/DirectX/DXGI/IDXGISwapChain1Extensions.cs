// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// <see cref="IDXGISwapChain1"/> 인터페이스의 확장 메서드를 제공합니다.
    /// </summary>
    public static class IDXGISwapChain1Extensions
	{
		/// <summary>
		/// 출력 대상 CoreWindow 개체를 가져옵니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <typeparam name="T"> <see cref="IUnknown"/> 인터페이스를 구현하는 원하는 대상 타입을 전달합니다. </typeparam>
		/// <param name="riid"> CoreWindow 개체의 GUID를 전달합니다. </param>
		/// <returns> 지정한 형식으로 변환 된 개체를 반환합니다. </returns>
		public static T GetCoreWindow<T>( this IDXGISwapChain1 @this, Guid riid ) where T : class
		{
			@this.GetCoreWindow( riid, out var unknown );
			return unknown as T;
		}

		/// <summary>
		/// 출력 대상 CoreWindow 개체를 가져옵니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <typeparam name="T"> <see cref="IUnknown"/> 인터페이스를 구현하는 원하는 대상 타입을 전달합니다. </typeparam>
		/// <returns> 지정한 형식으로 변환 된 개체를 반환합니다. </returns>
		public static T GetCoreWindow<T>( this IDXGISwapChain1 @this ) where T : class
		{
			return @this.GetCoreWindow<T>( typeof( T ).GUID );
		}
	}
}
