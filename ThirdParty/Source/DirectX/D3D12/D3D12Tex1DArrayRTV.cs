// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 1차원 텍스처 배열 렌더 타겟 서술자 정보를 표현합니다.
    /// </summary>
    public struct D3D12Tex1DArrayRTV
	{
		/// <summary>
		/// 사용할 MIP 단계를 나타냅니다.
		/// </summary>
		public uint MipSlice;

		/// <summary>
		/// 배열의 첫 인덱스를 나타냅니다.
		/// </summary>
		public uint FirstArraySlice;

		/// <summary>
		/// 배열의 개수를 나타냅니다.
		/// </summary>
		public uint ArraySize;
	}
}
