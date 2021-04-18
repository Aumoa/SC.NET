// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	/// <summary>
	/// D3D12 인터페이스 개체의 인스턴스화를 수행하는 클래스를 나타냅니다.
	/// </summary>
	public ref class D3D12
	{
	public:
		/// <summary>
		/// COM 구성 요소를 초기화합니다.
		/// </summary>
		static void CoInitialize();

		/// <summary>
		/// COM 구성 요소의 사용을 종료합니다.
		/// </summary>
		static void CoUninitialize();

		/// <summary>
		/// D3D12 장치 개체를 생성합니다.
		/// </summary>
		/// <param name="pAdapter"> 장치가 사용할 물리 어댑터를 전달합니다. null을 전달할 경우 기본 어댑터를 사용합니다. </param>
		/// <param name="minimumFeatureLevel"> 필요한 최소 기능 레벨을 전달합니다. 가능한 가장 높은 레벨이 사용되며, 필요한 기능을 지원하지 않을 경우 장치 생성에 실패합니다. </param>
		/// <returns> 생성된 장치 개체가 반환됩니다. </returns>
		static ID3D12Device^ D3D12CreateDevice( IUnknown^ pAdapter, D3DFeatureLevel minimumFeatureLevel );

		/// <summary>
		/// 루트 서명 개체를 직렬화합니다.
		/// </summary>
		/// <param name="rootSignature"> 입력 서명 개체에 대한 정보 서술 구조체를 전달합니다. </param>
		/// <returns> 직렬화된 데이터 블록 개체가 반환됩니다. </returns>
		static ID3DBlob^ D3D12SerializeRootSignature( D3D12RootSignatureDesc rootSignature );
	};
}