// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 2차원 텍스처 배열 순서없는 접근 서술자 정보를 표현합니다.
    /// </summary>
    public struct D3D12Tex2DArrayUAV
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

		/// <summary>
		/// 평면 조각의 인덱스를 나타냅니다.
		/// </summary>
		public uint PlaneSlice;
	}
}
