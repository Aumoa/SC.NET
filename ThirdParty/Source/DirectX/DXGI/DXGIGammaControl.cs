// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// 감마 제어에 대한 정보를 표현합니다.
    /// </summary>
    public struct DXGIGammaControl
	{
		DXGIRGB[] gammaCurve;

		/// <summary>
		/// 색상 비례 값을 표현합니다.
		/// </summary>
		public DXGIRGB Scale;

		/// <summary>
		/// 색상 오프셋 값을 표현합니다.
		/// </summary>
		public DXGIRGB Offset;

		/// <summary>
		/// 감마 커브 목록을 가져옵니다. 값은 1025개의 <see cref="DXGIRGB"/> 배열입니다.
		/// </summary>
		public DXGIRGB[] GammaCurve { get => gammaCurve ??= new DXGIRGB[1025]; }
	}
}
