// Copyright 2020-2021 Aumoa.lib. All right reserved.

#include "../Common/ShaderCommon.hlsli"
#include "SlateCommon.hlsli"

static float4 gPos[] =
{
	float4(-1, +1, 0, 1.0f),
	float4(+1, +1, 0, 1.0f),
	float4(-1, -1, 0, 1.0f),
	float4(+1, -1, 0, 1.0f),
};

static float2 gTex[] =
{
	float2(0, 0),
	float2(1, 0),
	float2(0, 1),
	float2(1, 1)
};

Fragment Main(in uint vId : SV_VERTEXID, in uint iId : SV_INSTANCEID)
{
	Fragment frag;
	frag.Position = gPos[vId];
	frag.TexCoord = gTex[vId];
	return frag;
}