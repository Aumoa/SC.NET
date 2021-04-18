// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 스텐실 연산자를 나타냅니다.
    /// </summary>
    public enum D3D12StencilOP
	{
		/// <summary>
		/// 스텐실 상태를 유지합니다.
		/// </summary>
		Keep = 1,

		/// <summary>
		/// 스텐실 값을 0으로 바꿉니다.
		/// </summary>
		Zero = 2,

		/// <summary>
		/// 스텐실 값을 사용자 지정 스텐실 값으로 설정합니다. 사용자 지정 스텐실 값은 <see cref="ID3D12GraphicsCommandList.OMSetStencilRef(uint)"/> 메서드로 설정합니다.
		/// </summary>
		Replace = 3,

		/// <summary>
		/// 스텐실 값을 증가시키고, 값을 최대값으로 한정합니다.
		/// </summary>
		IncrSat = 4,

		/// <summary>
		/// 스텐실 값을 감소시키고, 값을 최소값으로 한정합니다.
		/// </summary>
		DecrSat = 5,

		/// <summary>
		/// 대상 스텐실 값을 반전합니다.
		/// </summary>
		Invert = 6,

		/// <summary>
		/// 스텐실 값을 증가시키고, 최대값을 넘었을 경우 최소값으로 바꿉니다.
		/// </summary>
		Incr = 7,

		/// <summary>
		/// 스텐실 값을 감소시키고, 최소값보다 작아졌을 경우 최대값으로 바꿉니다.
		/// </summary>
		Decr = 8
	}
}
