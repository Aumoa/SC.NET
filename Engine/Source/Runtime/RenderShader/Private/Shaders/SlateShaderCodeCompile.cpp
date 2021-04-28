// Copyright 2020-2021 Aumoa.lib. All right reserved.

#include "pch.h"
#include "Shaders/SlateShaderCodeCompile.h"

using BYTE = unsigned char;
#include "SlateVertexShader.hlsl.h"
#include "SlatePixelShader.hlsl.h"
#include <cstring>

using namespace SC::Engine::Runtime::RenderShader::Shaders;
using namespace cli;

SlateShaderCodeCompile::SlateShaderCodeCompile() : Super()
{
}

void SlateShaderCodeCompile::CompileShader()
{
	_bytecodes.VertexShaderBytecode = gcnew array<BYTE>(sizeof(pSlateVertexShader));
	pin_ptr<BYTE> pVertexShaderBytecode = &_bytecodes.VertexShaderBytecode[0];
	memcpy(pVertexShaderBytecode, pSlateVertexShader, sizeof(pSlateVertexShader));
	pVertexShaderBytecode = nullptr;

	_bytecodes.PixelShaderBytecode = gcnew array<BYTE>(sizeof(pSlatePixelShader));
	pin_ptr<BYTE> pPixelShaderBytecode = &_bytecodes.PixelShaderBytecode[0];
	memcpy(pPixelShaderBytecode, pSlatePixelShader, sizeof(pSlatePixelShader));
	pPixelShaderBytecode = nullptr;
}

ShaderBytecodes SlateShaderCodeCompile::GetBytecodes()
{
	return _bytecodes;
}