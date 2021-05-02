// Copyright 2020-2021 Aumoa.lib. All right reserved.

#pragma once

#include "pch.h"
#include "Image.h"

namespace SC::ThirdParty::WindowsCodecs
{
	ref class ImagingFactory;
	enum class ImagePixelFormat;

	/// <summary>
	/// 이미지 포맷 변환 기능을 제공합니다.
	/// </summary>
	public ref class ImageFormatConverter : public Image
	{
		using Super = Image;

	internal:
		IWICFormatConverter* _converter;

	public:
		/// <summary>
		/// 개체를 초기화합니다.
		/// </summary>
		/// <param name="factory"> 팩토리 개체를 전달합니다. </param>
		ImageFormatConverter(ImagingFactory^ factory);
		~ImageFormatConverter();

		/// <summary>
		/// 이미지로부터 형식 변환을 초기화합니다.
		/// </summary>
		/// <param name="image"> 이미지를 전달합니다. </param>
		/// <param name="format"> 변경할 이미지 픽셀 형식을 전달합니다. </param>
		void Initialize(Image^ image, ImagePixelFormat format);

	private:
		static WICPixelFormatGUID GetPixelFormatGUID(ImagePixelFormat format);
	};
}