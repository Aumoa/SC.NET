// Copyright 2020-2021 Aumoa.lib. All right reserved.

#include "pch.h"
#include "ImagingFactory.h"

using namespace SC::ThirdParty::WindowsCodecs;

ImagingFactory::ImagingFactory() : Super()
{
	HR(CoInitializeEx(nullptr, COINIT_MULTITHREADED));
	ComPtr<IWICImagingFactory> factory;
	HR(CoCreateInstance(CLSID_WICImagingFactory, nullptr, CLSCTX_INPROC_SERVER, IID_PPV_ARGS(&factory)));

	_factory = factory.Detach();
}

ImagingFactory::~ImagingFactory()
{
	SafeRelease(_factory);
}