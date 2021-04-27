// Copyright 2020-2021 Aumoa.lib. All right reserved.

#include "../Common/ShaderCommon.hlsli"
#include "GeometryCommon.hlsli"

Fragment Main(in Vertex vIn)
{
	Fragment frag;
	frag.Position = float4(vIn.Position, 1.0f);
	frag.TexCoord = vIn.TexCoord;
	frag.Normal = vIn.Normal;
	frag.Tangent = vIn.Tangent;
	return frag;
}