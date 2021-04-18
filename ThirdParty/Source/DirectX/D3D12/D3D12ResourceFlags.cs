// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 자원의 속성을 표현합니다.
    /// </summary>
    public enum D3D12ResourceFlags
	{
		/// <summary>
		/// 아무 속성을 지정하지 않습니다.
		/// </summary>
		None = 0,

		/// <summary>
		/// 자원이 렌더 타겟으로 사용되도록 허용합니다.
		/// </summary>
		AllowRenderTarget = 0x01,

		/// <summary>
		/// 자원이 깊이 스텐실로 사용되도록 허용합니다.
		/// </summary>
		AllowDepthStencil = 0x02,

		/// <summary>
		/// 자원이 순서없는 접근으로 사용되도록 허용합니다.
		/// </summary>
		AllowUnorderedAccess = 0x04,

		/// <summary>
		/// 자원이 셰이더 자원으로 사용될 수 없습니다.
		/// </summary>
		DenyShaderResource = 0x08,

		/// <summary>
		/// 자원이 다중 어댑터에서 사용될 수 있도록 허용합니다.
		/// </summary>
		AllowCrossAdapter = 0x10,

		/// <summary>
		/// 자원이 동시에 엑세스 될 수 있도록 허용합니다.
		/// </summary>
		AllowSimultaneousAccess = 0x20,

		/// <summary>
		/// 자원이 비디오 디코드 전용으로 사용되도록 합니다.
		/// </summary>
		VideoDecodeReferenceOnly = 0x40
	}
}
