// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 아키텍처에 관한 정보를 조회합니다.
    /// </summary>
    public struct D3D12FeatureDataArchitecture
	{
		/// <summary>
		/// 
		/// </summary>
		public uint NodeIndex;

		/// <summary>
		/// 
		/// </summary>
		public bool TileBasedRenderer;

		/// <summary>
		/// 
		/// </summary>
		public bool UMA;

		/// <summary>
		/// 
		/// </summary>
		public bool CacheCoherentUMA;
	}
}
