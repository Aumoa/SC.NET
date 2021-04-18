// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 셰이더 입력 매개변수를 서술합니다.
    /// </summary>
    public struct D3D12RootParameter
	{
		ValueType valueType;

		/// <summary>
		/// 루트 서명 매개변수의 유형을 나타냅니다.
		/// </summary>
		public D3D12RootParameterType ParameterType;

		/// <summary>
		/// 서술자 테이블에 대한 정보를 나타냅니다.
		/// </summary>
		public D3D12RootDescriptorTable DescriptorTable
		{
			get => ( D3D12RootDescriptorTable )( valueType ??= new D3D12RootDescriptorTable() );
			set => valueType = value;
		}

		/// <summary>
		/// 32비트 상수에 대한 정보를 나타냅니다.
		/// </summary>
		public D3D12RootConstants Constants
		{
			get => ( D3D12RootConstants )( valueType ??= new D3D12RootConstants() );
			set => valueType = value;
		}

		/// <summary>
		/// 루트 서명 서술자에 대한 정보를 나타냅니다.
		/// </summary>
		public D3D12RootDescriptor Descriptor
		{
			get => ( D3D12RootDescriptor )( valueType ??= new D3D12RootDescriptor() );
			set => valueType = value;
		}

		/// <summary>
		/// 셰이더 관측 가능성을 나타냅니다.
		/// </summary>
		public D3D12ShaderVisibility ShaderVisibility;

		/// <summary>
		/// <see cref="D3D12RootParameter"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="descriptorTable"> 서술자 테이블 정보를 전달합니다. </param>
		/// <param name="shaderVisibility"> 셰이더 관측 가능성을 전달합니다. </param>
		public D3D12RootParameter( D3D12RootDescriptorTable descriptorTable, D3D12ShaderVisibility shaderVisibility = D3D12ShaderVisibility.All )
		{
			valueType = descriptorTable;
			ParameterType = D3D12RootParameterType.DescriptorTable;
			ShaderVisibility = shaderVisibility;
		}

		/// <summary>
		/// <see cref="D3D12RootParameter"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="constants"> 32비트 상수에 대한 정보를 전달합니다. </param>
		/// <param name="shaderVisibility"> 셰이더 관측 가능성을 전달합니다. </param>
		public D3D12RootParameter( D3D12RootConstants constants, D3D12ShaderVisibility shaderVisibility = D3D12ShaderVisibility.All )
		{
			valueType = constants;
			ParameterType = D3D12RootParameterType.Constants32Bit;
			ShaderVisibility = shaderVisibility;
		}

		/// <summary>
		/// <see cref="D3D12RootParameter"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="type"> 서술자 유형을 전달합니다. </param>
		/// <param name="shaderRegister"> 레지스터 번호를 전달합니다. </param>
		/// <param name="shaderVisibility"> 셰이더 관측 가능성을 전달합니다. </param>
		public D3D12RootParameter( D3D12RootParameterType type, uint shaderRegister, D3D12ShaderVisibility shaderVisibility = D3D12ShaderVisibility.All )
		{
			valueType = new D3D12RootDescriptor
			{
				ShaderRegister = shaderRegister,
				RegisterSpace = 0
			};
			ParameterType = type;
			ShaderVisibility = shaderVisibility;

			if ( type == D3D12RootParameterType.Constants32Bit || type == D3D12RootParameterType.DescriptorTable )
			{
				throw new ArgumentException();
			}
		}
	}
}
