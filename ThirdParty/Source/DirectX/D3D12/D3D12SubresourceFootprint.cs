// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 서브리소스 배치 형식을 표현합니다.
    /// </summary>
    public struct D3D12SubresourceFootprint
	{
		/// <summary>
		/// 자원의 형식을 나타냅니다.
		/// </summary>
		public DXGIFormat Format;

		/// <summary>
		/// 자원의 넓이를 나타냅니다.
		/// </summary>
		public uint Width;

		/// <summary>
		/// 자원의 높이를 나타냅니다.
		/// </summary>
		public uint Height;

		/// <summary>
		/// 자원의 깊이를 나타냅니다.
		/// </summary>
		public uint Depth;

		/// <summary>
		/// 자원의 바이트 단위 너비의 크기를 나타냅니다.
		/// </summary>
		public uint RowPitch;
	}
}
