// Copyright 2020-2021 Aumoa.lib. All right reserved.

#pragma once

#include "pch.h"

namespace SC::ThirdParty::WindowsCodecs
{
	ref class ImagingFactory;
	ref class ImageFrame;

	/// <summary>
	/// Windows Imaging Component 구성 요소를 사용하여 이미지를 메모리에 로드합니다.
	/// </summary>
	public ref class ImageLoader : public System::Object
	{
		using Super = System::Object;

	internal:
		IWICBitmapDecoder* _decoder;

	public:
		/// <summary>
		/// 개체를 초기화합니다.
		/// </summary>
		/// <param name="factory"> 팩토리 개체를 전달합니다. </param>
		/// <param name="imageFile"> 이미지 파일 레퍼런스를 전달합니다. </param>
		ImageLoader(ImagingFactory^ factory, Engine::Runtime::Core::FileSystem::FileReference^ imageFile);
		~ImageLoader();

		/// <summary>
		/// 이미지 프레임을 가져옵니다.
		/// </summary>
		/// <param name="index"> 프레임 인덱스를 전달합니다. </param>
		/// <returns> 개체가 반환됩니다. </returns>
		ImageFrame^ GetFrame(int index);

		/// <summary>
		/// 이미지 프레임 개수를 가져옵니다.
		/// </summary>
		/// <returns> 값이 반환됩니다. </returns>
		int GetFrameCount();
	};
}