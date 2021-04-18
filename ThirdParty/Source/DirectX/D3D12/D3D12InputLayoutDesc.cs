// Copyright 2020 Aumoa.lib. All right reserved.

using System.Collections.Generic;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 입력 배치 서술 구조체를 표현합니다.
    /// </summary>
    public struct D3D12InputLayoutDesc
	{
		/// <summary>
		/// 입력 요소 서술 구조체 목록을 나타냅니다.
		/// </summary>
		public IList<D3D12InputElementDesc> InputElementDescs;

		/// <summary>
		/// 구조체에 새 요소를 추가합니다. <see cref="InputElementDescs"/> 개체가 null일 경우 새 <see cref="List{T}"/> 개체가 생성됩니다.
		/// </summary>
		/// <param name="name"> 요소 이름을 전달합니다. </param>
		/// <param name="format"> 요소 형식을 전달합니다. </param>
		/// <param name="offset"> 요소 오프셋을 전달합니다. </param>
		public void Add( string name, DXGIFormat format, uint offset )
			=> ( InputElementDescs ??= new List<D3D12InputElementDesc>() )
			.Add( new D3D12InputElementDesc( name, format, offset ) );

		/// <summary>
		/// 구조체에 새 요소를 추가합니다. <see cref="InputElementDescs"/> 개체가 null일 경우 새 <see cref="List{T}"/> 개체가 생성됩니다.
		/// </summary>
		/// <param name="desc"> 요소 서술 구조체를 전달합니다. </param>
		public void Add( D3D12InputElementDesc desc )
			=> ( InputElementDescs ??= new List<D3D12InputElementDesc>() )
			.Add( desc );

		/// <summary>
		/// 구조체에 새 요소를 추가합니다. <see cref="InputElementDescs"/> 개체가 null일 경우 새 <see cref="List{T}"/> 개체가 생성됩니다. 요소 오프셋이 자동으로 설정됩니다.
		/// </summary>
		/// <param name="name"> 요소 이름을 전달합니다. </param>
		/// <param name="format"> 요소 형식을 전달합니다. </param>
		public void Add( string name, DXGIFormat format )
		{
			InputElementDescs ??= new List<D3D12InputElementDesc>();

			if ( InputElementDescs.Count == 0 ) InputElementDescs.Add( new D3D12InputElementDesc( name, format, 0 ) );
			else
			{
				var lastElement = InputElementDescs[InputElementDescs.Count - 1];
				var sizeInBytes = lastElement.Format.GetSizeInBytes();
				Add( name, format, lastElement.AlignedByteOffset + sizeInBytes );
			}
		}
	}
}
