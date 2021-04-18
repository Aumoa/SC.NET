// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 셰이더 바이트코드를 표현합니다.
    /// </summary>
    public struct D3D12ShaderBytecode
	{
		/// <summary>
		/// 셰이더 바이트코드에 대한 네이티브 포인터를 나타냅니다.
		/// </summary>
		public IntPtr pShaderBytecode;

		/// <summary>
		/// 바이트코드 길이를 나타냅니다.
		/// </summary>
		public ulong BytecodeLength;

		/// <summary>
		/// <see cref="D3D12ShaderBytecode"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="pShaderBytecode"> 셰이더 바이트코드에 대한 네이티브 포인터를 전달합니다. </param>
		/// <param name="bytecodeLength"> 바이트코드 길이를 전달합니다. </param>
		public D3D12ShaderBytecode( IntPtr pShaderBytecode, ulong bytecodeLength )
		{
			this.pShaderBytecode = pShaderBytecode;
			this.BytecodeLength = bytecodeLength;
		}

		/// <summary>
		/// <see cref="D3D12ShaderBytecode"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="pShaderBytecode"> 셰이더 바이트코드에 대한 바이트 배열을 전달합니다. </param>
		/// <param name="bytecodeLength"> 바이트코드 길이를 전달합니다. </param>
		unsafe public D3D12ShaderBytecode( byte* pShaderBytecode, ulong bytecodeLength )
		{
			this.pShaderBytecode = new IntPtr( pShaderBytecode );
			this.BytecodeLength = bytecodeLength;
		}
	}
}
