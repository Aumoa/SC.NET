// Copyright 2020-2021 Aumoa.lib. All right reserved.

#ifndef __SLATE_COMMON_HLSLI__
#define __SLATE_COMMON_HLSLI__

struct Fragment
{
	float4 Position : SV_POSITION;
	float2 TexCoord : TEXCOORD;
};

struct Pixel
{
	float4 Color : SV_TARGET0;
};

#endif