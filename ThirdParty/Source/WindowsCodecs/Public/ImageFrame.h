// Copyright 2020-2021 Aumoa.lib. All right reserved.

#pragma once

#include "pch.h"
#include "Image.h"

namespace SC::ThirdParty::WindowsCodecs
{
	/// <summary>
	/// 이미지 프레임을 표현합니다.
	/// </summary>
	public ref class ImageFrame : public Image
	{
		using Super = Image;

	internal:
		IWICBitmapFrameDecode* _frame;

	internal:
		ImageFrame();

	public:
		~ImageFrame();
	};
}