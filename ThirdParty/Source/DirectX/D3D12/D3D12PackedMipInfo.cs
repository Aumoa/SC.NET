// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 포장된 MIP 정보를 나타냅니다.
    /// </summary>
    public struct D3D12PackedMipInfo
	{
		/// <summary>
		/// 
		/// </summary>
		public byte NumStandardMips;

		/// <summary>
		/// 
		/// </summary>
		public byte NumPackedMips;

		/// <summary>
		/// 
		/// </summary>
		public uint NumTilesForPackedMips;

		/// <summary>
		/// 
		/// </summary>
		public uint StartTileIndexInOverallResource;
	}
}
