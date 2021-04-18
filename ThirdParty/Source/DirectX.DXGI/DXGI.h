// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	/// <summary>
	/// DXGI 인터페이스 개체의 인스턴스화를 수행하는 클래스를 나타냅니다.
	/// </summary>
	public ref class DXGI
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
	};
}