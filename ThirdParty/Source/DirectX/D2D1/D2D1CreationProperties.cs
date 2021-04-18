// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D2D1 생성 속성을 표현합니다.
    /// </summary>
    public struct D2D1CreationProperties
	{
		/// <summary>
		/// 스레딩 모드를 나타냅니다.
		/// </summary>
		public D2D1ThreadingMode ThreadingMode;

		/// <summary>
		/// 디버그 레벨을 나타냅니다.
		/// </summary>
		public D2D1DebugLevel DebugLevel;

		/// <summary>
		/// 디바이스 컨텍스트 옵션을 나타냅니다.
		/// </summary>
		public D2D1DeviceContextOptions Options;
	}
}
