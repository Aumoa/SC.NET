// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D2D1 디바이스 컨텍스트 개체의 추가 옵션을 표현합니다.
    /// </summary>
    public enum D2D1DeviceContextOptions
	{
		/// <summary>
		/// 아무 옵션을 지정하지 않습니다.
		/// </summary>
		None = 0,

		/// <summary>
		/// 기하 렌더링이 여러 스레드에서 병렬로 수행됩니다. 단일 스레드가 기본값입니다.
		/// </summary>
		EnableMultithreadedOptimizations = 1
	}
}
