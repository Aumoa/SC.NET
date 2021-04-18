// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 명령 대기열 속성을 표현합니다.
    /// </summary>
    public enum D3D12CommandQueueFlags
	{
		/// <summary>
		/// 속성을 사용하지 않습니다.
		/// </summary>
		None = 0,

		/// <summary>
		/// GPU 타임아웃을 비활성화합니다.
		/// </summary>
		DisableGPUTimeout = 0x1
	}
}
