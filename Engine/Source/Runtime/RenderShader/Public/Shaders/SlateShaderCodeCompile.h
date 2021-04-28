// Copyright 2020-2021 Aumoa.lib. All right reserved.

#pragma once

#include "ShaderBytecodes.h"

namespace SC::Engine::Runtime::RenderShader::Shaders
{
	public ref class SlateShaderCodeCompile : public System::Object
	{
	public:
		using Super = System::Object;

	private:
		ShaderBytecodes _bytecodes;

	public:
		/// <summary>
		/// 개체를 초기화합니다.
		/// </summary>
		SlateShaderCodeCompile();

		/// <summary>
		/// 셰이더를 컴파일합니다.
		/// </summary>
		void CompileShader();

		/// <summary>
		/// 셰이더 바이트코드를 가져옵니다.
		/// </summary>
		/// <returns> 값이 반환됩니다. </returns>
		ShaderBytecodes GetBytecodes();
	};
}