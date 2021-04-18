// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 깊이 스텐실 속성을 표현합니다.
    /// </summary>
    public enum D3D12DSVFlags
	{
		/// <summary>
		/// 아무 속성도 사용하지 않습니다.
		/// </summary>
		None = 0,

		/// <summary>
		/// 깊이 읽기 전용 속성입니다.
		/// </summary>
		ReadOnlyDepth = 0x1,

		/// <summary>
		/// 스텐실 읽기 전용 속성입니다.
		/// </summary>
		ReadOnlyStencil = 0x2
	}
}
