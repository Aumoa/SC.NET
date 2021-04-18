// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D2D1 알파 처리 방식을 표현합니다.
    /// </summary>
    public enum D2D1AlphaMode
	{
		/// <summary>
		/// 알파 처리 모드가 암묵적으로 지정됩니다.
		/// </summary>
		Unknown = 0,

		/// <summary>
		/// 미리 계산된 알파를 사용합니다.
		/// </summary>
		Premultiplied = 1,

		/// <summary>
		/// A 컴포넌트에만 알파를 적용합니다.
		/// </summary>
		Straight = 2,

		/// <summary>
		/// 알파 채널을 무시합니다.
		/// </summary>
		Ignore = 3
	}
}
