// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 2차원 텍스처 렌더 타겟 서술자 정보를 표현합니다.
    /// </summary>
    public struct D3D12Tex2DRTV
	{
		/// <summary>
		/// 사용할 MIP 단계를 나타냅니다.
		/// </summary>
		public uint MipSlice;

		/// <summary>
		/// 평면 조각의 인덱스를 나타냅니다.
		/// </summary>
		public uint PlaneSlice;
	}
}
