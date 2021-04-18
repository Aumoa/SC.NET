// Copyright 2020 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 자원 초기화 값을 표현합니다.
    /// </summary>
    public struct D3D12ClearValue
	{
		ValueType valueType;

		/// <summary>
		/// 자원의 유형을 나타냅니다.
		/// </summary>
		public DXGIFormat Format;

		/// <summary>
		/// 색상 초기화 값을 설정하거나 가져옵니다.
		/// </summary>
		public Color Color
		{
			get => (Color)( valueType ??= new Color() );
			set => valueType = value;
		}

		/// <summary>
		/// 깊이 및 스텐실 초기화 값을 설정하거나 가져옵니다.
		/// </summary>
		public D3D12DepthStencilValue DepthStencil
		{
			get => ( D3D12DepthStencilValue )( valueType ??= new D3D12DepthStencilValue() );
			set => valueType = value;
		}

		/// <summary>
		/// 현재 초기화 값으로 설정된 구조체의 값을 가져옵니다.
		/// </summary>
		public Type CurrentType
		{
			get => valueType.GetType();
		}

		/// <summary>
		/// <see cref="D3D12ClearValue"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="format"> 자원의 형식을 전달합니다. </param>
		/// <param name="colorClear"> 자원의 색상 초기화 값을 전달합니다. </param>
		public D3D12ClearValue( DXGIFormat format, Color colorClear )
		{
			this.valueType = colorClear;
			this.Format = format;
		}

		/// <summary>
		/// <see cref="D3D12ClearValue"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="format"> 자원의 형식을 전달합니다. </param>
		/// <param name="depthStencilValue"> 자원의 깊이 및 스텐실 초기화 값을 전달합니다. </param>
		public D3D12ClearValue( DXGIFormat format, D3D12DepthStencilValue depthStencilValue )
		{
			this.valueType = depthStencilValue;
			this.Format = format;
		}
	}
}
