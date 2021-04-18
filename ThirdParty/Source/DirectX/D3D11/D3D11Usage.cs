// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D11 자원의 사용처를 표현합니다.
    /// </summary>
    public enum D3D11Usage
	{
		/// <summary>
		/// 기본 사용처를 나타냅니다.
		/// </summary>
		Default = 0,

		/// <summary>
		/// 불변 자원을 나타냅니다.
		/// </summary>
		Immutable = 1,

		/// <summary>
		/// 동적 자원을 나타냅니다.
		/// </summary>
		Dynamic = 2,

		/// <summary>
		/// 스테이징 자원을 나타냅니다.
		/// </summary>
		Staging = 3
	}
}
