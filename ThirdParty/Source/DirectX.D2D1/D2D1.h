// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	/// <summary>
	/// D2D1 인터페이스 개체의 인스턴스화를 수행하는 클래스를 나타냅니다.
	/// </summary>
	public ref class D2D1
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
		/// D2D1 장치 개체를 생성합니다.
		/// </summary>
		/// <param name="dxgiDevice"> DXGI 장치 개체를 전달합니다. </param>
		/// <param name="creationProperties"> 장치의 생성 속성을 전달합니다. </param>
		/// <returns> 생성된 장치 개체가 반환됩니다. </returns>
		static ID2D1Device^ D2D1CreateDevice( IDXGIDevice^ dxgiDevice, D2D1CreationProperties creationProperties );
	};
}