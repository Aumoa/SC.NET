// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D2D1 비트맵 옵션을 나타냅니다.
    /// </summary>
    public enum D2D1BitmapOptions
	{
		/// <summary>
		/// 기본 옵션을 나타냅니다.
		/// </summary>
		None = 0x0,

		/// <summary>
		/// 비트맵이 렌더 타겟으로 지정될 수 있음을 나타냅니다.
		/// </summary>
		Target = 0x1,

		/// <summary>
		/// 비트맵이 디바이스 컨텍스트 개체를 통해 그려질 수 있음을 나타냅니다.
		/// </summary>
		CannotDraw = 0x2,

		/// <summary>
		/// 비트맵 데이터를 CPU에서 읽을 수 있음을 나타냅니다.
		/// </summary>
		CPURead = 0x4,

		/// <summary>
		/// GDI와 호환되어 작동합니다.
		/// </summary>
		GDICompatible = 0x8
	}
}
