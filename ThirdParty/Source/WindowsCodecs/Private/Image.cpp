// Copyright 2020-2021 Aumoa.lib. All right reserved.

#include "pch.h"
#include "Image.h"

#include "ImagePixelFormat.h"

using namespace System;
using namespace SC::ThirdParty::WindowsCodecs;

void Image::CalcFormat()
{
	WICPixelFormatGUID format;
	HR(_source->GetPixelFormat(&format));

	if (format == GUID_WICPixelFormat32bppPRGBA)
	{
		_bitsPerPixel = 32;
		_format = ImagePixelFormat::R8G8B8A8_UNORM;
	}
	else
	{
		_bitsPerPixel = 0;
	}
}

Image::Image() : Super()
{
}

void Image::CopyPixels(Nullable<System::Drawing::Rectangle> copyRect, int rowStride, int bufferSize, IntPtr buffer)
{
	WICRect wicRect;
	if (copyRect.HasValue)
	{
		wicRect.X = copyRect.Value.Left;
		wicRect.Y = copyRect.Value.Top;
		wicRect.Width = copyRect.Value.Width;
		wicRect.Height = copyRect.Value.Height;
	}

	HR(_source->CopyPixels(copyRect.HasValue ? &wicRect : nullptr, (UINT)rowStride, (UINT)bufferSize, (BYTE*)buffer.ToPointer()));
}