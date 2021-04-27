// Copyright 2020-2021 Aumoa.lib. All right reserved.

#ifndef __GEOMETRY_COMMON_HLSLI__
#define __GEOMETRY_COMMON_HLSLI__

struct Fragment
{
	float4 Position : SV_POSITION;
	float2 TexCoord : TEXCOORD;
	float3 Normal : NORMAL;
	float4 Tangent : TANGENT;
};

struct Pixel
{
	float4 Color : SV_TARGET0;
};

#endif
