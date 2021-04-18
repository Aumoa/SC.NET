// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 3차원 텍스처 렌더 타겟 서술자 정보를 표현합니다.
    /// </summary>
    public struct D3D12Tex3DRTV
	{
		/// <summary>
		/// 사용할 MIP 단계를 나타냅니다.
		/// </summary>
		public uint MipSlice;

		/// <summary>
		/// 처음 W축 조각 인덱스를 나타냅니다.
		/// </summary>
		public uint FirstWSlice;

		/// <summary>
		/// W축 크기를 나타냅니다.
		/// </summary>
		public uint WSize;
	}
}
