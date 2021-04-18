// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 자원의 순서없는 접근 장벽을 표현합니다.
    /// </summary>
    public struct D3D12ResourceUAVBarrier
	{
		/// <summary>
		/// 대상 자원을 전달합니다.
		/// </summary>
		public ID3D12Resource pResource;

		/// <summary>
		/// <see cref="D3D12ResourceUAVBarrier"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="resource"> 대상 자원 개체를 전달합니다. </param>
		public D3D12ResourceUAVBarrier( ID3D12Resource resource )
		{
			this.pResource = resource;
		}
	}
}
