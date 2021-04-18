// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 명령 대기열의 우선 순위를 표현합니다.
    /// </summary>
    public enum D3D12CommandQueuePriority
	{
		/// <summary>
		/// 기본값을 나타냅니다.
		/// </summary>
		Normal = 0,

		/// <summary>
		/// 높은 우선 순위를 나타냅니다.
		/// </summary>
		High = 100,

		/// <summary>
		/// 실시간 우선 순위를 나타냅니다. 이 우선 순위를 사용하려면 응용 프로그램에 충분한 권한이 있어야 합니다.
		/// </summary>
		GlobalRelatime = 10000
	}
}
