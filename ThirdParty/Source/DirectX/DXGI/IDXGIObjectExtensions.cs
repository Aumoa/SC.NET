// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// <see cref="IDXGIObject"/> 인터페이스 개체에 대한 확장 메서드를 제공합니다.
    /// </summary>
    public static class IDXGIObjectExtensions
	{
		/// <summary>
		/// 개체의 부모 개체를 가져옵니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="iid"> 부모 개체의 형식 인터페이스 GUID를 전달합니다. </param>
		public static T GetParent<T>( this IDXGIObject @this, Guid iid ) where T : class
		{
			@this.GetParent( iid, out var unknown );
			return unknown as T;
		}

		/// <summary>
		/// 개체의 부모 개체를 가져옵니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		public static T GetParent<T>( this IDXGIObject @this ) where T : class
		{
			return GetParent<T>( @this, typeof( T ).GUID );
		}
	}
}
