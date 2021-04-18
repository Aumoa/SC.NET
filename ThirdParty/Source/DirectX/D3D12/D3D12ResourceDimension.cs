// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// 자원의 차원을 표현합니다.
    /// </summary>
    public enum D3D12ResourceDimension
	{
		/// <summary>
		/// 자원이 알 수 없는 형식을 사용합니다.
		/// </summary>
		Unknown = 0,

		/// <summary>
		/// 자원이 버퍼임을 표현합니다.
		/// </summary>
		Buffer = 1,

		/// <summary>
		/// 자원이 1차원 텍스처임을 표현합니다.
		/// </summary>
		Texture1D = 2,

		/// <summary>
		/// 자원이 2차원 텍스처임을 표현합니다.
		/// </summary>
		Texture2D = 3,

		/// <summary>
		/// 자원이 3차원 텍스처임을 표현합니다.
		/// </summary>
		Texture3D = 4,
	}
}
