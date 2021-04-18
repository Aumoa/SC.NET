// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 텍스처 큐브 배열 셰이더 자원 서술자 정보를 표현합니다.
    /// </summary>
    public struct D3D12TexCubeArraySRV
	{
		/// <summary>
		/// 가장 정확한 MIP 단계를 나타냅니다.
		/// </summary>
		public uint MostDetailedMip;

		/// <summary>
		/// MIP 단계 개수를 나타냅니다.
		/// </summary>
		public uint MipLevels;

		/// <summary>
		/// 첫 2차원 배열 표면을 나타냅니다.
		/// </summary>
		public uint First2DArrayFace;

		/// <summary>
		/// 큐브의 개수를 나타냅니다.
		/// </summary>
		public uint NumCubes;

		/// <summary>
		/// 최소 LOD 한정 값을 나타냅니다.
		/// </summary>
		public float ResourceMinLODClamp;
	}
}
