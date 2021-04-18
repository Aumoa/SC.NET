// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 셰이더 자원 서술자의 차원을 표현합니다.
    /// </summary>
    public enum D3D12SRVDimension
	{
		/// <summary>
		/// 알 수 없는 형식을 나타냅니다.
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
		/// 1차원 텍스처 배열 형식을 나타냅니다.
		/// </summary>
		Texture1DArray = 3,

		/// <summary>
		/// 2차원 텍스처 형식을 나타냅니다.
		/// </summary>
		Texture2D = 4,

		/// <summary>
		/// 2차원 텍스처 배열 형식을 나타냅니다.
		/// </summary>
		Texture2DArray = 5,

		/// <summary>
		/// 2차원 멀티샘플 텍스처 형식을 나타냅니다.
		/// </summary>
		Texture2DMS = 6,

		/// <summary>
		/// 2차원 멀티셈플 텍스처 배열 형식을 나타냅니다.
		/// </summary>
		Texture2DMSArray = 7,

		/// <summary>
		/// 3차원 텍스처 형식을 나타냅니다.
		/// </summary>
		Texture3D = 8,

		/// <summary>
		/// 텍스처 큐브 형식을 나타냅니다.
		/// </summary>
		TextureCube = 9,

		/// <summary>
		/// 텍스처 큐브 배열 형식을 나타냅니다.
		/// </summary>
		TextureCubeArray = 10,

		/// <summary>
		/// 레이트레이싱 가속화 구조체 형식을 나타냅니다.
		/// </summary>
		RaytracingAccelerationStructure = 11
	}
}
