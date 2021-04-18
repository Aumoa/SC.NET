// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 래스터라이저 서술 구조체를 표현합니다.
    /// </summary>
    public struct D3D12RasterizerDesc
	{
		/// <summary>
		/// 내부 채움 모드를 나타냅니다.
		/// </summary>
		public D3D12FillMode FillMode;

		/// <summary>
		/// 선별 모드를 나타냅니다.
		/// </summary>
		public D3D12CullMode CullMode;

		/// <summary>
		/// 반시계방향으로 삼각형을 생성합니다.
		/// </summary>
		public bool FrontCounterClockwise;

		/// <summary>
		/// 깊이 바이어스 값을 나타냅니다.
		/// </summary>
		public int DepthBias;

		/// <summary>
		/// 깊이 바이어스 한정 값을 나타냅니다.
		/// </summary>
		public float DepthBiasClamp;

		/// <summary>
		/// 기울기 비례 깊이 바이어스 값을 나타냅니다.
		/// </summary>
		public float SlopeScaledDepthBias;

		/// <summary>
		/// 깊이 자르기를 활성화합니다.
		/// </summary>
		public bool DepthClipEnable;

		/// <summary>
		/// 멀티샘플을 활성화합니다.
		/// </summary>
		public bool MultisampleEnable;

		/// <summary>
		/// 안티앨리어싱 선분을 활성화합니다.
		/// </summary>
		public bool AntialiasedLineEnable;

		/// <summary>
		/// 강제 샘플 횟수를 나타냅니다.
		/// </summary>
		public uint ForcedSampleCount;

		/// <summary>
		/// 전통적 래스터라이즈 모드를 나타냅니다.
		/// </summary>
		public D3D12ConservativeRasterizationMode ConservativeRaster;

		/// <summary>
		/// 기본 래스터라이즈 상태를 가져옵니다.
		/// </summary>
		public static D3D12RasterizerDesc Default
		{
			get => new D3D12RasterizerDesc
			{
				FillMode = D3D12FillMode.Solid,
				CullMode = D3D12CullMode.Back,
				FrontCounterClockwise = false,
				DepthBias = 0,
				DepthBiasClamp = 0,
				SlopeScaledDepthBias = 0,
				DepthClipEnable = false,
				MultisampleEnable = false,
				AntialiasedLineEnable = false,
				ForcedSampleCount = 0,
				ConservativeRaster = D3D12ConservativeRasterizationMode.Off
			};
		}

		/// <summary>
		/// 와이어프레임 래스터라이즈 상태를 가져옵니다.
		/// </summary>
		public static D3D12RasterizerDesc Wireframe
		{
			get => new D3D12RasterizerDesc
			{
				FillMode = D3D12FillMode.Wireframe,
				CullMode = D3D12CullMode.None,
				FrontCounterClockwise = false,
				DepthBias = 0,
				DepthBiasClamp = 0,
				SlopeScaledDepthBias = 0,
				DepthClipEnable = false,
				MultisampleEnable = false,
				AntialiasedLineEnable = false,
				ForcedSampleCount = 0,
				ConservativeRaster = D3D12ConservativeRasterizationMode.Off
			};
		}
	}
}
