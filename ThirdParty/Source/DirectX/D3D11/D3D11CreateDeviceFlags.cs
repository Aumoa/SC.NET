// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D11 장치를 생성하는데 지정하는 속성을 표현합니다.
    /// </summary>
    public enum D3D11CreateDeviceFlags
	{
		/// <summary>
		/// 싱글 스레드 형식으로 작동합니다.
		/// </summary>
		SingleThreaded = 0x1,

		/// <summary>
		/// 디버그 레이어를 사용합니다.
		/// </summary>
		Debug = 0x2,

		/// <summary>
		/// 
		/// </summary>
		SwitchToRef = 0x4,

		/// <summary>
		/// 
		/// </summary>
		PreventInternalThreadingOptimizations = 0x8,

		/// <summary>
		/// BGRA 형식을 지원합니다. Direct2D와 상호 운용을 위해서 이 속성이 필요할 수 있습니다.
		/// </summary>
		BGRASupport = 0x20,

		/// <summary>
		/// 
		/// </summary>
		Debuggable = 0x40,

		/// <summary>
		/// 
		/// </summary>
		PreventAlteringLayerSettingsFromRegistry = 0x80,

		/// <summary>
		/// 
		/// </summary>
		DisableGPUTimeout = 0x100,

		/// <summary>
		/// 
		/// </summary>
		VideoSupport = 0x800
	}
}
