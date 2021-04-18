// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 텍스처 복사 위치에 대한 정보를 서술합니다.
    /// </summary>
    public struct D3D12TextureCopyLocation
	{
		ValueType valueType;

		/// <summary>
		/// 복사 위치를 나타내는 자원 개체를 나타냅니다.
		/// </summary>
		public ID3D12Resource pResource;

		/// <summary>
		/// 복사 위치 자원의 형식을 나타냅니다.
		/// </summary>
		public D3D12TextureCopyType Type;

		/// <summary>
		/// 복사 형식이 <see cref="D3D12TextureCopyType.PlacedFootprint"/>일 때, 자세한 정보를 서술합니다.
		/// </summary>
		public D3D12PlacedSubresourceFootprint PlacedFootprint
		{
			get => ( D3D12PlacedSubresourceFootprint )( valueType ??= new D3D12PlacedSubresourceFootprint() );
			set => valueType = value;
		}

		/// <summary>
		/// 복사 형식이 <see cref="D3D12TextureCopyType.SubresourceIndex"/>일 때, 자세한 정보를 서술합니다.
		/// </summary>
		public uint SubresourceIndex
		{
			get => ( uint )( valueType ??= new uint() );
			set => valueType = value;
		}

		/// <summary>
		/// <see cref="D3D12TextureCopyLocation"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="pResource"> 자원을 전달합니다. </param>
		/// <param name="layout"> 배치 정보를 전달합니다. </param>
		public D3D12TextureCopyLocation( ID3D12Resource pResource, D3D12PlacedSubresourceFootprint layout )
		{
			this.valueType = layout;
			this.pResource = pResource;
			this.Type = D3D12TextureCopyType.PlacedFootprint;
		}

		/// <summary>
		/// <see cref="D3D12TextureCopyLocation"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="pResource"> 자원을 전달합니다. </param>
		/// <param name="subresourceIndex"> 서브리소스 인덱스를 전달합니다. </param>
		public D3D12TextureCopyLocation( ID3D12Resource pResource, uint subresourceIndex )
		{
			this.valueType = subresourceIndex;
			this.pResource = pResource;
			this.Type = D3D12TextureCopyType.SubresourceIndex;
		}
	}
}
