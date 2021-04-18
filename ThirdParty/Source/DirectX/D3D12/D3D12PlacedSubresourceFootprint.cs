// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 배치된 서브리소스 자원의 배치 형식을 표현합니다.
    /// </summary>
    public struct D3D12PlacedSubresourceFootprint
	{
		/// <summary>
		/// 바이트 단위 오프셋을 나타냅니다.
		/// </summary>
		public ulong Offset;

		/// <summary>
		/// 배치 형식을 나타냅니다.
		/// </summary>
		public D3D12SubresourceFootprint Footprint;
	}
}
