// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 깊이 및 스텐실 쌍을 표현합니다.
    /// </summary>
    public struct D3D12DepthStencilValue
	{
		/// <summary>
		/// 깊이 값을 나타냅니다.
		/// </summary>
		public float Depth;

		/// <summary>
		/// 스텐실 값을 나타냅니다.
		/// </summary>
		public byte Stencil;
	}
}
