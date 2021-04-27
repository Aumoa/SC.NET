// Copyright 2020-2021 Aumoa.lib. All right reserved.

#ifndef __SHADER_COMMON_HLSLI__
#define __SHADER_COMMON_HLSLI__

struct Vertex
{
	float3 Position : POSITION;
	float2 TexCoord : TEXCOORD;
	float3 Normal : NORMAL;
	float4 Tangent : TANGENT;
};

#endif