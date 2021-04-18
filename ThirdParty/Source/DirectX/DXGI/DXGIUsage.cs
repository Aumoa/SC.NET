// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI 버퍼의 사용 방식을 표현합니다.
    /// </summary>
    [Flags]
	public enum DXGIUsage
	{
		/// <summary>
		/// 셰이더 입력 자원으로 사용됩니다.
		/// </summary>
		ShaderInput = 0x10,

		/// <summary>
		/// 렌더 타겟의 출력 자원으로 사용됩니다.
		/// </summary>
		RenderTargetOutput = 0x20,

		/// <summary>
		/// 후면 버퍼로 사용됩니다.
		/// </summary>
		BackBuffer = 0x40,

		/// <summary>
		/// 공유된 자원으로 사용됩니다.
		/// </summary>
		Shared = 0x80,

		/// <summary>
		/// 읽기 전용 자원으로 사용됩니다.
		/// </summary>
		ReadOnly = 0x100,

		/// <summary>
		/// 출력된 후 버려지는 자원으로 사용됩니다.
		/// </summary>
		DiscardOnPresent = 0x200,

		/// <summary>
		/// 순서없는 접근 자원으로 사용됩니다.
		/// </summary>
		UnorderedAccess = 0x400
	}
}
