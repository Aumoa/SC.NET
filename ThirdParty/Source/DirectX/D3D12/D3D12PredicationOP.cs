// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 Predication 연산 방식을 나타냅니다.
    /// </summary>
    public enum D3D12PredicationOP
	{
		/// <summary>
		/// 값이 0과 같을 경우 참을 반환합니다.
		/// </summary>
		EqualZero = 0,

		/// <summary>
		/// 값이 0과 같지 않을 경우 참을 반환합니다.
		/// </summary>
		NotEqualZero = 1
	}
}
