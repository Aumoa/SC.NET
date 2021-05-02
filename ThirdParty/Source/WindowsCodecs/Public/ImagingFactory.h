// Copyright 2020-2021 Aumoa.lib. All right reserved.

#pragma once

#include "pch.h"

namespace SC::ThirdParty::WindowsCodecs
{
	/// <summary>
	/// Windows Imaging Component 구성 요소의 리소스 관리 함수를 제공합니다.
	/// </summary>
	public ref class ImagingFactory : public System::Object
	{
		using Super = System::Object;

	internal:
		IWICImagingFactory* _factory;

	public:
		/// <summary>
		/// 개체를 초기화합니다.
		/// </summary>
		ImagingFactory();
		~ImagingFactory();
	};
}