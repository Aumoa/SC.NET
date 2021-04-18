// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D11On12 디바이스 개체에 대한 공통 메서드를 제공합니다.
    /// </summary>
    [Guid( "85611e73-70a9-490e-9614-a9e302777904" )]
	[ComVisible( true )]
	public interface ID3D11On12Device : IUnknown
	{
		/// <summary>
		/// D3D12 호환 자원 개체를 생성합니다.
		/// </summary>
		/// <param name="pResource12"> 원본 D3D12 자원 개체를 전달합니다. </param>
		/// <param name="resourceFlags"> 리소스 속성을 전달합니다. </param>
		/// <param name="inState"> 입력 상태를 전달합니다. </param>
		/// <param name="outState"> 출력 상태를 전달합니다. </param>
		/// <param name="riid"> 개체의 GUID를 전달합니다. </param>
		/// <param name="ppResource11"> 인터페이스 개체를 받을 변수의 참조를 전달합니다. </param>
		void CreateWrappedResource(
			IUnknown pResource12,
			D3D11ResourceFlags resourceFlags,
			D3D12ResourceStates inState,
			D3D12ResourceStates outState,
			Guid riid,
			out IUnknown ppResource11
			);

		/// <summary>
		/// 자원을 Direct3D 11에서 사용할 수 있도록 승인합니다.
		/// </summary>
		/// <param name="ppResources"> 승인할 자원 목록을 전달합니다. </param>
		void AcquireWrappedResources( IList<ID3D11Resource> ppResources );

		/// <summary>
		/// 자원의 승인을 해제합니다.
		/// </summary>
		/// <param name="ppResources"> 승인 해제할 자원 목록을 전달합니다. </param>
		void ReleaseWrappedResources( IList<ID3D11Resource> ppResources );
	}
}
