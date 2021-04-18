// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// <see cref="ID3D11On12Device"/> 인터페이스 개체에 대한 확장 메서드를 제공합니다.
    /// </summary>
    public static class ID3D11On12DeviceExtensions
	{
		/// <summary>
		/// D3D12 호환 자원 개체를 생성합니다.
		/// </summary>
		/// <typeparam name="T"> 변환할 형식을 전달합니다. </typeparam>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="pResource12"> 원본 D3D12 자원 개체를 전달합니다. </param>
		/// <param name="bindFlags"> 리소스 바이딩 속성을 전달합니다. </param>
		/// <param name="inState"> 입력 상태를 전달합니다. </param>
		/// <param name="outState"> 출력 상태를 전달합니다. </param>
		public static T CreateWrappedResource<T>( this ID3D11On12Device @this, IUnknown pResource12, D3D11BindFlags bindFlags, D3D12ResourceStates inState, D3D12ResourceStates outState ) where T : class
		{
			@this.CreateWrappedResource( pResource12, new D3D11ResourceFlags( bindFlags ), inState, outState, typeof( T ).GUID, out var ppUnknown );
			return ppUnknown as T;
		}

		/// <summary>
		/// D3D12 호환 자원 개체를 생성합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="pResource12"> 원본 D3D12 자원 개체를 전달합니다. </param>
		/// <param name="bindFlags"> 리소스 바이딩 속성을 전달합니다. </param>
		/// <param name="inState"> 입력 상태를 전달합니다. </param>
		/// <param name="outState"> 출력 상태를 전달합니다. </param>
		public static ID3D11Resource CreateWrappedResource( this ID3D11On12Device @this, IUnknown pResource12, D3D11BindFlags bindFlags, D3D12ResourceStates inState, D3D12ResourceStates outState )
			=> @this.CreateWrappedResource<ID3D11Resource>( pResource12, bindFlags, inState, outState );

		/// <summary>
		/// 자원을 Direct3D 11에서 사용할 수 있도록 승인합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="ppResources"> 승인할 자원 목록을 전달합니다. </param>
		public static void AcquireWrappedResources( this ID3D11On12Device @this, params ID3D11Resource[] ppResources )
			=> @this.AcquireWrappedResources( ppResources );

		/// <summary>
		/// 자원의 승인을 해제합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="ppResources"> 승인 해제할 자원 목록을 전달합니다. </param>
		public static void ReleaseWrappedResources( this ID3D11On12Device @this, params ID3D11Resource[] ppResources )
			=> @this.ReleaseWrappedResources( ppResources );
	}
}
