// Copyright 2020 Aumoa.lib. All right reserved.

using System.Collections.Generic;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 입력 서명 개체에 대한 정보를 서술합니다.
    /// </summary>
    public struct D3D12RootSignatureDesc
	{
		/// <summary>
		/// 루트 서명 매개변수 목록을 나타냅니다.
		/// </summary>
		public IList<D3D12RootParameter> Parameters;

		/// <summary>
		/// 정적 샘플러 목록을 나타냅니다.
		/// </summary>
		public IList<D3D12StaticSamplerDesc> StaticSamplers;

		/// <summary>
		/// 루트 서명 개체의 속성을 나타냅니다.
		/// </summary>
		public D3D12RootSignatureFlags Flags;

		/// <summary>
		/// 루트 서명 매개변수 목록에 32비트 상수 정보를 추가합니다.
		/// </summary>
		/// <param name="shaderRegister"> 레지스터 번호를 전달합니다. </param>
		/// <param name="num32BitValues"> 32비트 데이터 개수를 전달합니다. </param>
		/// <param name="shaderVisibility"> 셰이더 관측 가능성을 전달합니다. </param>
		/// <param name="registerSpace"> 레지스터 공간을 전달합니다. </param>
		public void AddRoot32BitConstants( uint shaderRegister, uint num32BitValues, D3D12ShaderVisibility shaderVisibility = D3D12ShaderVisibility.All, uint registerSpace = 0 )
		{
			Parameters ??= new List<D3D12RootParameter>();
			Parameters.Add( new D3D12RootParameter( new D3D12RootConstants
			{
				ShaderRegister = shaderRegister,
				Num32BitValues = num32BitValues,
				RegisterSpace = registerSpace
			}, shaderVisibility ) );
		}

		/// <summary>
		/// 루트 상수 버퍼 서술자를 매개변수 목록에 추가합니다.
		/// </summary>
		/// <param name="shaderRegister"> 레지스터 번호를 전달합니다. </param>
		/// <param name="shaderVisibility"> 셰이더 관측 가능성을 전달합니다. </param>
		public void AddConstantBufferView( uint shaderRegister, D3D12ShaderVisibility shaderVisibility = D3D12ShaderVisibility.All )
		{
			Parameters ??= new List<D3D12RootParameter>();
			Parameters.Add( new D3D12RootParameter( D3D12RootParameterType.CBV, shaderRegister, shaderVisibility ) );
		}

		/// <summary>
		/// 루트 셰이더 자원 서술자를 매개변수 목록에 추가합니다.
		/// </summary>
		/// <param name="shaderRegister"> 레지스터 번호를 전달합니다. </param>
		/// <param name="shaderVisibility"> 셰이더 관측 가능성을 전달합니다. </param>
		public void AddShaderResourceView( uint shaderRegister, D3D12ShaderVisibility shaderVisibility = D3D12ShaderVisibility.All )
		{
			Parameters ??= new List<D3D12RootParameter>();
			Parameters.Add( new D3D12RootParameter( D3D12RootParameterType.SRV, shaderRegister, shaderVisibility ) );
		}

		/// <summary>
		/// 루트 순서없는 접근 서술자를 매개변수 목록에 추가합니다.
		/// </summary>
		/// <param name="shaderRegister"> 레지스터 번호를 전달합니다. </param>
		/// <param name="shaderVisibility"> 셰이더 관측 가능성을 전달합니다. </param>
		public void AddUnorderedAccessView( uint shaderRegister, D3D12ShaderVisibility shaderVisibility = D3D12ShaderVisibility.All )
		{
			Parameters ??= new List<D3D12RootParameter>();
			Parameters.Add( new D3D12RootParameter( D3D12RootParameterType.UAV, shaderRegister, shaderVisibility ) );
		}

		/// <summary>
		/// 서술자 목록에 서술자 테이블 목록을 추가합니다.
		/// </summary>
		/// <param name="descriptorRanges"> 서술자 테이블 목록을 전달합니다. </param>
		/// <param name="shaderVisibility"> 셰이더 관측 가능성을 전달합니다. </param>
		public void AddDescriptorTable( IList<D3D12DescriptorRange> descriptorRanges, D3D12ShaderVisibility shaderVisibility = D3D12ShaderVisibility.All )
		{
			Parameters ??= new List<D3D12RootParameter>();
			Parameters.Add( new D3D12RootParameter( new D3D12RootDescriptorTable
			{
				DescriptorRanges = descriptorRanges
			}, shaderVisibility ) );
		}

		/// <summary>
		/// 서술자 목록에 서술자 테이블 목록을 추가합니다.
		/// </summary>
		/// <param name="shaderVisibility"> 셰이더 관측 가능성을 전달합니다. </param>
		/// <param name="descriptorRanges"> 서술자 테이블 목록을 전달합니다. </param>

		public void AddDescriptorTable( D3D12ShaderVisibility shaderVisibility, params D3D12DescriptorRange[] descriptorRanges )
			=> AddDescriptorTable( descriptorRanges, shaderVisibility );

		/// <summary>
		/// 정적 샘플러 목록에 새 샘플러 정보를 추가합니다.
		/// </summary>
		/// <param name="staticSamplerDesc"> 샘플러 정보를 전달합니다. </param>
		public void AddStaticSampler( D3D12StaticSamplerDesc staticSamplerDesc )
		{
			StaticSamplers ??= new List<D3D12StaticSamplerDesc>();
			StaticSamplers.Add( staticSamplerDesc );
		}
		
		/// <summary>
		/// 입력 어셈블러 및 입력 배치의 루트 서명 접근을 허용하는 값을 설정하거나 가져옵니다.
		/// </summary>
		public bool AllowInputAssemblerInputLayout
		{
			get => ( Flags & D3D12RootSignatureFlags.AllowInputAssemblerInputLayout ) != 0;
			set
			{
				if ( value )
				{
					Flags |= D3D12RootSignatureFlags.AllowInputAssemblerInputLayout;
				}
				else
				{
					Flags &= ~D3D12RootSignatureFlags.AllowInputAssemblerInputLayout;
				}
			}
		}

		/// <summary>
		/// 정점 셰이더에서 루트 서명에 엑세스하는 것을 비허용합니다.
		/// </summary>
		public bool DenyVertexShaderRootAccess
		{
			get => ( Flags & D3D12RootSignatureFlags.DenyVertexShaderRootAccess ) != 0;
			set
			{
				if ( value )
				{
					Flags |= D3D12RootSignatureFlags.DenyVertexShaderRootAccess;
				}
				else
				{
					Flags &= ~D3D12RootSignatureFlags.DenyVertexShaderRootAccess;
				}
			}
		}

		/// <summary>
		/// 픽셀 셰이더에서 루트 서명에 엑세스하는 것을 비허용합니다.
		/// </summary>
		public bool DenyPixelShaderRootAccess
		{
			get => ( Flags & D3D12RootSignatureFlags.DenyPixelShaderRootAccess ) != 0;
			set
			{
				if ( value )
				{
					Flags |= D3D12RootSignatureFlags.DenyPixelShaderRootAccess;
				}
				else
				{
					Flags &= ~D3D12RootSignatureFlags.DenyPixelShaderRootAccess;
				}
			}
		}

		/// <summary>
		/// 영역 셰이더에서 루트 서명에 엑세스하는 것을 비허용합니다.
		/// </summary>
		public bool DenyDomainShaderRootAccess
		{
			get => ( Flags & D3D12RootSignatureFlags.DenyDomainShaderRootAccess ) != 0;
			set
			{
				if ( value )
				{
					Flags |= D3D12RootSignatureFlags.DenyDomainShaderRootAccess;
				}
				else
				{
					Flags &= ~D3D12RootSignatureFlags.DenyDomainShaderRootAccess;
				}
			}
		}

		/// <summary>
		/// 덮개 셰이더에서 루트 서명에 엑세스하는 것을 비허용합니다.
		/// </summary>
		public bool DenyHullShaderRootAccess
		{
			get => ( Flags & D3D12RootSignatureFlags.DenyHullShaderRootAccess ) != 0;
			set
			{
				if ( value )
				{
					Flags |= D3D12RootSignatureFlags.DenyHullShaderRootAccess;
				}
				else
				{
					Flags &= ~D3D12RootSignatureFlags.DenyHullShaderRootAccess;
				}
			}
		}

		/// <summary>
		/// 기하 셰이더에서 루트 서명에 엑세스하는 것을 비허용합니다.
		/// </summary>
		public bool DenyGeometryShaderRootAccess
		{
			get => ( Flags & D3D12RootSignatureFlags.DenyGeometryShaderRootAccess ) != 0;
			set
			{
				if ( value )
				{
					Flags |= D3D12RootSignatureFlags.DenyGeometryShaderRootAccess;
				}
				else
				{
					Flags &= ~D3D12RootSignatureFlags.DenyGeometryShaderRootAccess;
				}
			}
		}
	}
}
