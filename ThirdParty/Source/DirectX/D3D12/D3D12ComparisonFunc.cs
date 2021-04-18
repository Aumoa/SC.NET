// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 비교 함수를 나타냅니다.
    /// </summary>
    public enum D3D12ComparisonFunc
	{
		/// <summary>
		/// 항상 false를 반환합니다.
		/// </summary>
		Never = 1,

		/// <summary>
		/// 원본이 대상보다 작으면 true를 반환합니다.
		/// </summary>
		Less = 2,

		/// <summary>
		/// 원본과 대상이 같으면 true를 반환합니다.
		/// </summary>
		Equal =3,

		/// <summary>
		/// 원본이 대상보다 작거나 같으면 true를 반환합니다.
		/// </summary>
		LessEqual = 4,

		/// <summary>
		/// 원본이 대상보다 크면 true를 반환합니다.
		/// </summary>
		Greater = 5,

		/// <summary>
		/// 원본과 대상이 같지 않으면 true를 반환합니다.
		/// </summary>
		NotEqual = 6,

		/// <summary>
		/// 원본이 대상보다 크거나 같으면 true를 반환합니다.
		/// </summary>
		GreaterEqual = 7,

		/// <summary>
		/// 항상 true를 반환합니다.
		/// </summary>
		Always = 8
	}
}
