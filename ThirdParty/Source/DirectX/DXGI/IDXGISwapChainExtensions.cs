// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// <see cref="IDXGISwapChain"/> 인터페이스의 확장 메서드를 제공합니다.
    /// </summary>
    public static class IDXGISwapChainExtensions
	{
		/// <summary>
		/// 후면 버퍼를 가져옵니다.
		/// </summary>
		/// <typeparam name="T"> <see cref="IUnknown"/> 인터페이스를 구현하는 원하는 대상 타입을 전달합니다. </typeparam>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="index"> 후면 버퍼 인덱스를 전달합니다. </param>
		/// <param name="riid"> 후면 버퍼의 인터페이스 GUID를 전달합니다.  </param>
		/// <returns> 지정한 형식으로 변환 된 개체를 반환합니다. </returns>
		public static T GetBuffer<T>( this IDXGISwapChain @this, int index, Guid riid ) where T : class
		{
			@this.GetBuffer( index, riid, out var unknown );
			return unknown as T;
		}

		/// <summary>
		/// 후면 버퍼를 가져옵니다.
		/// </summary>
		/// <typeparam name="T"> <see cref="IUnknown"/> 인터페이스를 구현하는 원하는 대상 타입을 전달합니다. </typeparam>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="index"> 후면 버퍼 인덱스를 전달합니다. </param>
		/// <returns> 지정한 형식으로 변환 된 개체를 반환합니다. </returns>
		public static T GetBuffer<T>( this IDXGISwapChain @this, int index ) where T : class
		{
			return @this.GetBuffer<T>( index, typeof( T ).GUID );
		}

		/// <summary>
		/// 후면 버퍼의 크기를 변경합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="width"> 변경할 버퍼의 너비를 전달합니다. </param>
		/// <param name="height"> 변경할 버퍼의 높이를 전달합니다. </param>
		/// <remarks> 이 메서드를 호출하기 전, 반드시 모든 후면 버퍼의 참조가 제거되어야 합니다. <see cref="IUnknown.Release"/> 메서드를 참조하십시오. </remarks>
		public static void ResizeBuffers( this IDXGISwapChain @this, int width, int height )
		{
			@this.ResizeBuffers( null, width, height, null, null );
		}

		/// <summary>
		/// 현재 스왑 체인에 지정된 전체 화면 설정 정보를 가져옵니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <returns> 전체 화면 상태가 반환됩니다. </returns>
		public static bool GetFullscreenState( this IDXGISwapChain @this )
		{
			return @this.GetFullscreenState( out var _ );
		}
	}
}
