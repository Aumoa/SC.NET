// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 서브리소스 타일링 정보를 서술합니다.
    /// </summary>
    public struct D3D12SubresourceTiling
	{
		/// <summary>
		/// 
		/// </summary>
		public uint WidthInTiles;

		/// <summary>
		/// 
		/// </summary>
		public ushort HeightInTiles;

		/// <summary>
		/// 
		/// </summary>
		public ushort DepthInTiles;

		/// <summary>
		/// 
		/// </summary>
		public uint StartTileIndexInOverallResource;
	}
}
