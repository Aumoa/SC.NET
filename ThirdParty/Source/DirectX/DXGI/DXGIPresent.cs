// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI 스왑 체인의 출력 속성을 표현합니다.
    /// </summary>
    [Flags]
	public enum DXGIPresent
	{
		/// <summary>
		/// 아무 속성도 지정하지 않습니다.
		/// </summary>
		None = 0,

		/// <summary>
		/// 프레임을 출력하지 않고, 출력 가능한 상태인지 검사합니다.
		/// </summary>
		Test = 0x01,

		/// <summary>
		/// 
		/// </summary>
		DoNotSequence = 0x02,

		/// <summary>
		/// 대기중인 출력을 제거하도록 지정합니다.
		/// </summary>
		Restart = 0x04,

		/// <summary>
		/// 호출 스레드가 차단될 경우 런타임이 오류 코드와 함께 출력에 실패함을 지정합니다.
		/// </summary>
		DoNotWait = 0x08,

		/// <summary>
		/// 출력된 내용이 특정 디스플레이에만 표시될 수 있음을 지정합니다.
		/// </summary>
		RestrictToOuptut = 0x10,

		/// <summary>
		/// 
		/// </summary>
		StereopreferRight = 0x20,

		/// <summary>
		/// 
		/// </summary>
		StereoTemporaryMono = 0x40,

		/// <summary>
		/// 
		/// </summary>
		UseDuration = 0x100,

		/// <summary>
		/// 
		/// </summary>
		AllowTearing = 0x200,
	}
}
