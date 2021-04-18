// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 펜스 속성을 표현합니다.
    /// </summary>
    public enum D3D12FenceFlags
	{
		/// <summary>
		/// 속성을 사용하지 않습니다.
		/// </summary>
		None = 0,

		/// <summary>
		/// 공유된 펜스입을 나타냅니다.
		/// </summary>
		Shared = 0x1,

		/// <summary>
		/// 크로스 어댑터 환경에서 고유된 펜스임을 나타냅니다.
		/// </summary>
		SharedCrossAdapter = 0x2,

		/// <summary>
		/// 모니터링 되지 않는 펜스 유형을 나타냅니다.
		/// </summary>
		NonMonitored = 0x4
	}
}
