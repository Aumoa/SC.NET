// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D2D1 단위 블렌딩 형식을 표현합니다.
    /// </summary>
    public enum D2D1PrimitiveBlend
	{
		/// <summary>
		/// 대상 위에 덮어씁니다. 알파 블렌딩이 기본 적용됩니다.
		/// </summary>
		SourceOver = 0,

		/// <summary>
		/// 대상 위치로 복사합니다.
		/// </summary>
		Copy = 1,

		/// <summary>
		/// 두 값 중 최소 값을 적용합니다.
		/// </summary>
		Min = 2,

		/// <summary>
		/// 두 값을 더합니다.
		/// </summary>
		Add = 3,

		/// <summary>
		/// 두 값 중 최대 값을 적용합니다.
		/// </summary>
		Max = 4,
	}
}
