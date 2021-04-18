// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 블렌딩 연산자를 표현합니다.
    /// </summary>
    public enum D3D12BlendOP
	{
		/// <summary>
		/// 원본 값과 대상 값을 더합니다.
		/// </summary>
		Add = 1,

		/// <summary>
		/// 대상 값에서 원본 값을 뺍니다.
		/// </summary>
		Subtract = 2,

		/// <summary>
		/// 원본 값에서 대상 값을 뺀 후, 대상 값을 원본 값으로 설정합니다.
		/// </summary>
		RevSubtract = 3,

		/// <summary>
		/// 두 값 중 작은 값으로 설정합니다.
		/// </summary>
		Min = 4,

		/// <summary>
		/// 두 값 중 큰 값으로 설정합니다.
		/// </summary>
		Max = 5
	}
}
