// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 간접 명령에 대한 매개변수 정보를 서술합니다.
    /// </summary>
    public struct D3D12IndirectArgumentDesc
	{
		ValueType valueType;

		/// <summary>
		/// 간접 매개변수 유형을 나타냅니다.
		/// </summary>
		public D3D12IndirectArgumentType Type;

		/// <summary>
		/// 간접 매개변수 정점 버퍼 정보를 설정하거나 가져옵니다.
		/// </summary>
		public D3D12IndirectVertexBufferArgument VertexBuffer
		{
			get => ( D3D12IndirectVertexBufferArgument )( valueType ??= new D3D12IndirectVertexBufferArgument() );
			set => valueType = value;
		}

		/// <summary>
		/// 간접 매개변수 상수 정보를 설정하거나 가져옵니다.
		/// </summary>
		public D3D12IndirectConstantArgument Constant
		{
			get => ( D3D12IndirectConstantArgument )( valueType ??= new D3D12IndirectConstantArgument() );
			set => valueType = value;
		}

		/// <summary>
		/// 간접 매개변수 상수 버퍼 서술 정보를 설정하거나 가져옵니다.
		/// </summary>
		public D3D12IndirectConstantBufferViewArgument ConstantBufferView
		{
			get => ( D3D12IndirectConstantBufferViewArgument )( valueType ??= new D3D12IndirectConstantBufferViewArgument() );
			set => valueType = value;
		}

		/// <summary>
		/// 간접 매개변수 셰이더 자원 서술 정보를 설정하거나 가져옵니다.
		/// </summary>
		public D3D12IndirectShaderResourceViewArgument ShaderResourceView
		{
			get => ( D3D12IndirectShaderResourceViewArgument )( valueType ??= new D3D12IndirectShaderResourceViewArgument() );
			set => valueType = value;
		}

		/// <summary>
		/// 간접 매개변수 순서없는 접근 서술 정보를 설정하거나 가져옵니다.
		/// </summary>
		public D3D12IndirectUnorderedAccessViewArgument UnorderedAccessView
		{
			get => ( D3D12IndirectUnorderedAccessViewArgument )( valueType ??= new D3D12IndirectUnorderedAccessViewArgument() );
			set => valueType = value;
		}
	}
}
