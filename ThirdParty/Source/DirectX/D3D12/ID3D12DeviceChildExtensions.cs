// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// <see cref="ID3D12DeviceChild"/> 인터페이스 개체에 대한 확장 메서드를 제공합니다.
    /// </summary>
    public static class ID3D12DeviceChildExtensions
	{
		/// <summary>
		/// 장치 개체를 가져옵니다.
		/// </summary>
		/// <typeparam name="T"> 장치 개체의 인터페이스 형식을 전달합니다. </typeparam>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="riid"> 장치 인터페이스의 GUID를 전달합니다. </param>
		public static T GetDevice<T>( this ID3D12DeviceChild @this, Guid riid ) where T : class
		{
			@this.GetDevice( riid, out var device );
			return device as T;
		}

		/// <summary>
		/// 장치 개체를 가져옵니다.
		/// </summary>
		/// <typeparam name="T"> 장치 개체의 인터페이스 형식을 전달합니다. </typeparam>
		/// <param name="this"> 개체를 전달합니다. </param>
		public static T GetDevice<T>( this ID3D12DeviceChild @this ) where T : class
		{
			@this.GetDevice( typeof( T ).GUID, out var device );
			return device as T;
		}
	}
}
