// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// 알파 값의 처리 방식을 표현합니다.
    /// </summary>
    public enum DXGIAlphaMode
	{
		/// <summary>
		/// 처리 방식을 지정하지 않습니다.
		/// </summary>
		Unspecified = 0,

		/// <summary>
		/// 미리 계산된 값을 사용합니다.
		/// </summary>
		Premultiplied = 1,

		/// <summary>
		/// 알파 값이 계산되지 않은 값임을 나타냅니다.
		/// </summary>
		Straight = 2,

		/// <summary>
		/// 알파 값을 무시합니다.
		/// </summary>
		Ignore = 3,
	}
}
