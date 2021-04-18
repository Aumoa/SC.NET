// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D11 리소스의 차원을 나타냅니다.
    /// </summary>
    public enum D3D11ResourceDimension
	{
		/// <summary>
		/// 알 수 없는 차원 형식입니다.
		/// </summary>
		Unknown = 0,

		/// <summary>
		/// 버퍼 형식을 나타냅니다.
		/// </summary>
		Buffer = 1,

		/// <summary>
		/// 1차원 텍스처 형식을 나타냅니다.
		/// </summary>
		Texture1D = 2,

		/// <summary>
		/// 2차원 텍스처 형식을 나타냅니다.
		/// </summary>
		Texture2D = 3,

		/// <summary>
		/// 3차원 텍스처 형식을 나타냅니다.
		/// </summary>
		Texture3D = 4
	}
}
