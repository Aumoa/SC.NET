// Copyright 2020-2021 Aumoa.lib. All right reserved.

#include "pch.h"
#include "ImageFormatConverter.h"

#include "ImagingFactory.h"
#include "ImagePixelFormat.h"

using namespace System;
using namespace SC::ThirdParty::WindowsCodecs;

ImageFormatConverter::ImageFormatConverter(ImagingFactory^ factory) : Super()
{
	ComPtr<IWICFormatConverter> converter;
	HR(factory->_factory->CreateFormatConverter(&converter));

	_converter = converter.Detach();
	_source = _converter;
}

ImageFormatConverter::~ImageFormatConverter()
{
	SafeRelease(_converter);
}

void ImageFormatConverter::Initialize(Image^ image, ImagePixelFormat format)
{
	WICPixelFormatGUID guid = GetPixelFormatGUID(format);
	HR(_converter->Initialize(image->_source, guid, WICBitmapDitherTypeNone, nullptr, 0.0, WICBitmapPaletteTypeCustom));

	_width = image->Width;
	_height = image->Height;
	CalcFormat();
}

WICPixelFormatGUID ImageFormatConverter::GetPixelFormatGUID(ImagePixelFormat format)
{
	switch (format)
	{
	case ImagePixelFormat::R8G8B8A8_UNORM:
		return GUID_WICPixelFormat32bppPRGBA;
	default:
		throw gcnew FormatException("지원하지 않는 이미지 픽셀 형식입니다.");
	}
}