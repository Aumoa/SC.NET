// Copyright 2020 Aumoa.lib. All right reserved.

using System.Collections.Generic;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 루트 서명 서술자 테이블에 대한 정보를 서술합니다.
    /// </summary>
    public struct D3D12RootDescriptorTable
	{
		/// <summary>
		/// 서술자 범위 목록을 전달합니다.
		/// </summary>
		public IList<D3D12DescriptorRange> DescriptorRanges;
	}
}
