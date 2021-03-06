﻿// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 깊이 스텐실 서술자의 차원을 표현합니다.
    /// </summary>
    public enum D3D12DSVDimension
	{
		/// <summary>
		/// 알 수 없는 형식을 나타냅니다.
		/// </summary>
		Unknown = 0,

		/// <summary>
		/// 1차원 텍스처 형식을 나타냅니다.
		/// </summary>
		Texture1D = 1,

		/// <summary>
		/// 1차원 텍스처 배열 형식을 나타냅니다.
		/// </summary>
		Texture1DArray = 2,

		/// <summary>
		/// 2차원 텍스처 형식을 나타냅니다.
		/// </summary>
		Texture2D = 3,

		/// <summary>
		/// 2차원 텍스처 배열 형식을 나타냅니다.
		/// </summary>
		Texture2DArray = 4,

		/// <summary>
		/// 2차원 멀티샘플 텍스처 형식을 나타냅니다.
		/// </summary>
		Texture2DMS = 5,

		/// <summary>
		/// 2차원 멀티샘플 텍스처 배열 형식을 나타냅니다.
		/// </summary>
		Texture2DMSArray = 6,
	}
}
