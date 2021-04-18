// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// 스왑 체인의 속성을 표현합니다.
    /// </summary>
    [Flags]
	public enum DXGISwapChainFlag
	{
		/// <summary>
		/// 속성을 지정하지 않습니다.
		/// </summary>
		None = 0,

		/// <summary>
		/// DXGI가 화면을 출력할 때 자동으로 회전하지 않도록 설정합니다. 응용 프로그램 내부에서 회전에 대한 처리를 할 때 이 플래그를 사용합니다.
		/// </summary>
		NonPreRotated = 1,

		/// <summary>
		/// DXGI가 화면 모드 변환을 수행할 수 있도록 허용합니다.
		/// </summary>
		AllowModeSwitch = 2,

		/// <summary>
		/// GDI 호환 가능하도록 허용합니다.
		/// </summary>
		GdiCompatible = 4,

		/// <summary>
		/// 보호된 컨텐츠를 사용하도록 합니다. 운영 체제에서 보호된 컨텐츠를 지원하지 않을 경우 작업이 실패합니다.
		/// </summary>
		RestrictedContent = 8,

		/// <summary>
		/// 스왑 체인 내에서 공유된 자원에 대해 이 자원이 보호되어야 함을 나타냅니다.
		/// </summary>
		RestrictSharedResourceDriver = 16,

		/// <summary>
		/// 제시된 스왑 체인 컨텐츠가 로컬 디스플레이에만 표시됩니다. 복제 또는 원격 데스크탑 API를 통해 엑세스할 수 없습니다.
		/// </summary>
		DisplayOnly = 32,

		/// <summary>
		/// 프레임이 표시되는 동안 대기를 사용할 수 있는 대기 가능 오브젝트를 생성합니다.
		/// </summary>
		FrameLatencyWaitableObject = 64,

		/// <summary>
		/// 다중 평면 렌더링을 위해 포그라운드 레이어에서 스왑 체인을 생성합니다. 이 플래그는 <see cref="IDXGIFactory2.CreateSwapChainForCoreWindow"/>로 작성된 스왑 체인에서만 유효합니다.
		/// </summary>
		ForegroundLayer = 128,

		/// <summary>
		/// 전체 화면 비디오 재생을 위한 스왑 체인을 생성할 경우 사용합니다.
		/// </summary>
		FullscreenVideo = 256,

		/// <summary>
		/// YUV 비디오 재생을 위한 스왑 체인을 생성할 경우 사용합니다.
		/// </summary>
		YUVVideo = 512,

		/// <summary>
		/// <para> 모든 기본 리소스를 하드웨어로 보호할 수 있도록 스왑 체인을 만들어야 함을 나타냅니다. 하드웨어 컨텐츠 보호가 지원되지 않으면 생성에 실패합니다. </para>
		/// <para> 이 플래그는 <see cref="DXGISwapEffect.FlipSequential"/> 스왑 효과에서만 사용할 수 있습니다. </para>
		/// </summary>
		HWProtected = 1024,

		/// <summary>
		/// 화면의 가변 주사율을 지원합니다.
		/// </summary>
		/// <remarks>
		/// 응용 프로그램이 전체 화면 창모드를 사용할 때, 가변 주사율을 지원하는 디스플레이가 제대로 작동하려면 티어링 지원이 필요합니다. 이 플래그는 <see cref="DXGISwapEffect.FlipDiscard"/> 또는 <see cref="DXGISwapEffect.FlipSequential"/> 스왑 효과를 사용해야 합니다.
		/// </remarks>
		AllowTearing = 2048,

		/// <summary>
		/// 
		/// </summary>
		RestrictedToAllHolographicDisplay = 4096,
	}
}
