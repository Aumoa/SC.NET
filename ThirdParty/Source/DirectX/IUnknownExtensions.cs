// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
	/// <summary>
	/// <see cref="IUnknown"/> 인터페이스 개체에 대한 확장 메서드를 제공합니다.
	/// </summary>
	public static class IUnknownExtensions
	{
		/// <summary>
		/// 사용 가능한 대상 인터페이스 개체를 조회합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="riid"> 대상 인터페이스의 GUID를 전달합니다. </param>
		/// <returns> 인터페이스 요청에 성공한 경우 해당 인터페이스 개체를 가져옵니다. </returns>
		/// <exception cref="NotSupportedException"> 요청한 GUID가 지원되지 않는 인터페이스를 나타내는 경우 발생합니다. </exception>
		public static T QueryInterface<T>(this IUnknown @this, Guid riid) where T : class
		{
			@this.QueryInterface(riid, out var unknown);
			return unknown as T;
		}

		/// <summary>
		/// 사용 가능한 대상 인터페이스 개체를 조회합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <returns> 인터페이스 요청에 성공한 경우 해당 인터페이스 개체를 가져옵니다. </returns>
		/// <exception cref="NotSupportedException"> 요청한 GUID가 지원되지 않는 인터페이스를 나타내는 경우 발생합니다. </exception>
		public static T QueryInterface<T>(this IUnknown @this) where T : class
		{
			@this.QueryInterface(typeof(T).GUID, out var unknown);
			return unknown as T;
		}

		/// <summary>
		/// 사용 가능한 대상 인터페이스 개체를 조회합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <returns> 인터페이스 요청에 성공한 경우 해당 인터페이스 개체를 가져옵니다. </returns>
		/// <exception cref="NotSupportedException"> 요청한 GUID가 지원되지 않는 인터페이스를 나타내는 경우 발생합니다. </exception>
		public static T As<T>(this IUnknown @this) where T : class
			=> @this.QueryInterface<T>();
	}
}
