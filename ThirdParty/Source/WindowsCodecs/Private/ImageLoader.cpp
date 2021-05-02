// Copyright 2020-2021 Aumoa.lib. All right reserved.

#include "pch.h"
#include "ImageLoader.h"

#include "ImagingFactory.h"
#include "ImageFrame.h"

using namespace System;
using namespace SC::ThirdParty::WindowsCodecs;
using namespace SC::Engine::Runtime::Core::FileSystem;
using namespace std;
using namespace msclr::interop;

ImageLoader::ImageLoader(ImagingFactory^ factory, FileReference^ imageFile) : Super()
{
	wstring path = marshal_as<wstring>(imageFile->FullPath);
	ComPtr<IWICBitmapDecoder> decoder;
	HR(factory->_factory->CreateDecoderFromFilename(path.c_str(), nullptr, GENERIC_READ, WICDecodeMetadataCacheOnDemand, &decoder));

	_decoder = decoder.Detach();
}

ImageLoader::~ImageLoader()
{
	SafeRelease(_decoder);
}

ImageFrame^ ImageLoader::GetFrame(int index)
{
	ComPtr<IWICBitmapFrameDecode> frame;
	HR(_decoder->GetFrame((UINT)index, &frame));

	UINT width;
	UINT height;
	HR(frame->GetSize(&width, &height));

	auto ptr = gcnew ImageFrame();
	ptr->_width = (int)width;
	ptr->_height = (int)height;
	ptr->_source = frame.Get();
	ptr->_frame = frame.Detach();
	ptr->CalcFormat();

	return ptr;
}

int ImageLoader::GetFrameCount()
{
	UINT count;
	HR(_decoder->GetFrameCount(&count));
	return (int)count;
}