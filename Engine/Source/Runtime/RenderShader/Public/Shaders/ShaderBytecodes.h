// Copyright 2020-2021 Aumoa.lib. All right reserved.

#pragma once

namespace SC::Engine::Runtime::RenderShader::Shaders
{
	/// <summary>
	/// 셰이더 바이트코드를 표현합니다.
	/// </summary>
	public value struct ShaderBytecodes
	{
        /// <summary>
        /// 정점 셰이더 바이트코드를 나타냅니다.
        /// </summary>
        cli::array<unsigned char>^ VertexShaderBytecode;

        /// <summary>
        /// 픽셀 셰이더 바이트코드를 나타냅니다.
        /// </summary>
        cli::array<unsigned char>^ PixelShaderBytecode;

        /// <summary>
        /// 도메인 셰이더 바이트코드를 나타냅니다.
        /// </summary>
        cli::array<unsigned char>^ DomainShaderBytecode;

        /// <summary>
        /// 덮개 셰이더 바이트코드를 나타냅니다.
        /// </summary>
        cli::array<unsigned char>^ HullShaderBytecode;

        /// <summary>
        /// 기하 셰이더 바이트코드를 나타냅니다.
        /// </summary>
        cli::array<unsigned char>^ GeometryShaderBytecode;
	};
}