// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 스텐실 연산자 정보를 서술합니다.
    /// </summary>
    public struct D3D12DepthStencilOPDesc
	{
		/// <summary>
		/// 스텐실 테스트에 실패했을 경우에 대한 스텐실 연산자를 나타냅니다.
		/// </summary>
		public D3D12StencilOP StencilFailOp;

		/// <summary>
		/// 깊이 테스트에 실패했을 경우에 대한 스텐실 연산자를 나타냅니다.
		/// </summary>
		public D3D12StencilOP StencilDepthFailOp;

		/// <summary>
		/// 스텐실 테스트에 성공했을 경우에 대한 스텐실 연산자를 나타냅니다.
		/// </summary>
		public D3D12StencilOP StencilPassOp;

		/// <summary>
		/// 스텐실 연산 함수를 나타냅니다.
		/// </summary>
		public D3D12ComparisonFunc StencilFunc;
	}
}
