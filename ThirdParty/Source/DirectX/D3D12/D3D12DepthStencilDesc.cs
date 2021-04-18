// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 깊이 스텐실 상태를 서술합니다.
    /// </summary>
    public struct D3D12DepthStencilDesc
	{
		/// <summary>
		/// 깊이 상태의 활성화 여부를 나타냅니다.
		/// </summary>
		public bool DepthEnable;

		/// <summary>
		/// 깊이 쓰기 마스크를 나타냅니다.
		/// </summary>
		public D3D12DepthWriteMask DepthWriteMask;

		/// <summary>
		/// 깊이 비교 함수를 나타냅니다.
		/// </summary>
		public D3D12ComparisonFunc DepthFunc;

		/// <summary>
		/// 스텐실 활성화 여부를 나타냅니다.
		/// </summary>
		public bool StencilEnable;

		/// <summary>
		/// 스텐실 읽기 마스크를 비트 단위로 나타냅니다.
		/// </summary>
		public byte StencilReadMask;

		/// <summary>
		/// 스텐실 쓰기 마스크를 비트 단위로 나타냅니다.
		/// </summary>
		public byte StencilWriteMask;

		/// <summary>
		/// 선별되지 않은 전면 기하 도형에 대한 스텐실 연산 방식을 나타냅니다.
		/// </summary>
		public D3D12DepthStencilOPDesc FrontFace;

		/// <summary>
		/// 선별되지 않은 후면 기하 도형에 대한 스텐실 연산 방식을 나타냅니다.
		/// </summary>
		public D3D12DepthStencilOPDesc BackFace;

		/// <summary>
		/// 기본값을 가져옵니다.
		/// </summary>
		public static D3D12DepthStencilDesc Default
		{
			get => new D3D12DepthStencilDesc
			{
				DepthEnable = false,
				StencilEnable = false
			};
		}

		/// <summary>
		/// 기본 깊이 테스트를 수행하는 서술 구조체를 가져옵니다.
		/// </summary>
		public static D3D12DepthStencilDesc DepthTest
		{
			get => new D3D12DepthStencilDesc
			{
				DepthEnable = true,
				DepthWriteMask = D3D12DepthWriteMask.All,
				DepthFunc = D3D12ComparisonFunc.Less,
				StencilEnable = false
			};
		}
	}
}
