// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 2차원 텍스처 배열 셰이더 자원 서술자 정보를 표현합니다.
    /// </summary>
    public struct D3D12Tex2DArraySRV
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
		/// 배열의 첫 인덱스를 나타냅니다.
		/// </summary>
		public uint FirstArraySlice;

		/// <summary>
		/// 배열의 개수를 나타냅니다.
		/// </summary>
		public uint ArraySize;

		/// <summary>
		/// 평면 조각의 인덱스를 나타냅니다.
		/// </summary>
		public uint PlaneSlice;

		/// <summary>
		/// 최소 LOD 한정 값을 나타냅니다.
		/// </summary>
		public float ResourceMinLODClamp;

		/// <summary>
		/// 기본값을 가져옵니다.
		/// </summary>
		public static D3D12Tex2DArraySRV Default
		{
			get => new D3D12Tex2DArraySRV
			{
				MostDetailedMip = 0,
				MipLevels = 1,
				FirstArraySlice = 0,
				ArraySize = 1,
				PlaneSlice = 0,
				ResourceMinLODClamp = 0.0f
			};
		}
	}
}
