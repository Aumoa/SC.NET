// Copyright 2020-2021 Aumoa.lib. All right reserved.

#include "pch.h"
#include "ImageFrame.h"

using namespace SC::ThirdParty::WindowsCodecs;

ImageFrame::ImageFrame() : Super()
{
}

ImageFrame::~ImageFrame()
{
	SafeRelease(_frame);
}