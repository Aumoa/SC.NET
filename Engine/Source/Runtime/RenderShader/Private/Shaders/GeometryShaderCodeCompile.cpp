// Copyright 2020-2021 Aumoa.lib. All right reserved.

#include "pch.h"
#include "Shaders/GeometryShaderCodeCompile.h"

using BYTE = unsigned char;
#include "GeometryVertexShader.hlsl.h"
#include "GeometryPixelShader.hlsl.h"
#include <cstring>

using namespace SC::Engine::Runtime::RenderShader::Shaders;
using namespace cli;

GeometryShaderCodeCompile::GeometryShaderCodeCompile() : Super()
{
}

void GeometryShaderCodeCompile::CompileShader()
{
	_bytecodes.VertexShaderBytecode = gcnew array<BYTE>(sizeof(pGeometryVertexShader));
	pin_ptr<BYTE> pVertexShaderBytecode = &_bytecodes.VertexShaderBytecode[0];
	memcpy(pVertexShaderBytecode, pGeometryVertexShader, sizeof(pGeometryVertexShader));
	pVertexShaderBytecode = nullptr;

	_bytecodes.PixelShaderBytecode = gcnew array<BYTE>(sizeof(pGeometryPixelShader));
	pin_ptr<BYTE> pPixelShaderBytecode = &_bytecodes.PixelShaderBytecode[0];
	memcpy(pPixelShaderBytecode, pGeometryPixelShader, sizeof(pGeometryPixelShader));
	pPixelShaderBytecode = nullptr;
}

ShaderBytecodes GeometryShaderCodeCompile::GetBytecodes()
{
	return _bytecodes;
}