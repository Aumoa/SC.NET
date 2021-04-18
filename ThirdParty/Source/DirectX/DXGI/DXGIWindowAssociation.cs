// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI 개체의 창 연결에 관련된 속성을 표현합니다.
    /// </summary>
    [Flags]
	public enum DXGIWindowAssociation
	{
		/// <summary>
		/// DXGI가 응용 프로그램의 메시지 대기열을 모니터링하지 못하게 합니다. 이 경우 모드 변경에 응답할 수 없습니다.
		/// </summary>
		NoWindowChanges		= 1 << 0,

		/// <summary>
		/// DXGI가 Alt+Enter 키 조합 입력 시퀸스에 응답하지 않도록 합니다.
		/// </summary>
		NoAltEnter			= 1 << 1,

		/// <summary>
		/// DXGI가 PrintScreen 키 입력 시퀸스에 응답하지 않도록 합니다.
		/// </summary>
		NoPrintScreen		= 1 << 2
	}
}
