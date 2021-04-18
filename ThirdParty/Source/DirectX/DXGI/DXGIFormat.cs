// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI 모든 자원 형식을 표현합니다.
    /// </summary>
    public enum DXGIFormat
	{
		/// <summary>
		/// 알 수 없는 형식을 표현합니다.
		/// </summary>
		Unknown					    = 0,

        /// <summary>
        /// 4개의 32비트 값을 사용합니다.
        /// </summary>
        R32G32B32A32_TYPELESS       = 1,

        /// <summary>
        /// 4개의 32비트 부동소수점 값을 사용합니다.
        /// </summary>
        R32G32B32A32_FLOAT          = 2,

        /// <summary>
        /// 4개의 32비트 부호없는 정수 값을 사용합니다.
        /// </summary>
        R32G32B32A32_UINT           = 3,

        /// <summary>
        /// 4개의 32비트 정수 값을 사용합니다.
        /// </summary>
        R32G32B32A32_SINT           = 4,

        /// <summary>
        /// 3개의 32비트 값을 사용합니다.
        /// </summary>
        R32G32B32_TYPELESS          = 5,
        
        /// <summary>
        /// 3개의 32비트 부동소수점 값을 사용합니다.
        /// </summary>
        R32G32B32_FLOAT             = 6,

        /// <summary>
        /// 3개의 32비트 부호없는 정수 값을 사용합니다.
        /// </summary>
        R32G32B32_UINT              = 7,

        /// <summary>
        /// 3개의 32비트 정수 값을 사용합니다.
        /// </summary>
        R32G32B32_SINT              = 8,

        /// <summary>
        /// 4개의 16비트 값을 사용합니다.
        /// </summary>
        R16G16B16A16_TYPELESS       = 9,

        /// <summary>
        /// 4개의 16비트 부동소수점 값을 사용합니다.
        /// </summary>
        R16G16B16A16_FLOAT          = 10,

        /// <summary>
        /// 4개의 16비트 부호없는 정규화된 실수 값을 사용합니다.
        /// </summary>
        R16G16B16A16_UNORM          = 11,

        /// <summary>
        /// 4개의 16비트 부호없는 정수 값을 사용합니다.
        /// </summary>
        R16G16B16A16_UINT           = 12,

        /// <summary>
        /// 4개의 16비트 정규화된 실수 값을 사용합니다.
        /// </summary>
        R16G16B16A16_SNORM          = 13,

        /// <summary>
        /// 4개의 16비트 정수 값을 사용합니다.
        /// </summary>
        R16G16B16A16_SINT           = 14,

        /// <summary>
        /// 2개의 32비트 값을 사용합니다.
        /// </summary>
        R32G32_TYPELESS             = 15,

        /// <summary>
        /// 2개의 32비트 부동소수점 값을 사용합니다.
        /// </summary>
        R32G32_FLOAT                = 16,

        /// <summary>
        /// 2개의 32비트 부호없는 정수 값을 사용합니다.
        /// </summary>
        R32G32_UINT                 = 17,

        /// <summary>
        /// 2개의 32비트 정수 값을 사용합니다.
        /// </summary>
        R32G32_SINT                 = 18,

        /// <summary>
        /// 1개의 32비트 값, 1개의 8비트 값 및 24비트 채움을 사용합니다.
        /// </summary>
        R32G8X24_TYPELESS           = 19,

        /// <summary>
        /// 깊이를 나타내는 1개의 32비트 부동소수점 값, 스텐실을 나타내는 1개의 8비트 부호없는 정수 값 및 24비트 채움을 사용합니다.
        /// </summary>
        D32_FLOAT_S8X24_UINT        = 20,

        /// <summary>
        /// 1개의 32비트 부동소수점 값, 8비트 채움 및 24비트 채움을 사용합니다.
        /// </summary>
        R32_FLOAT_X8X24_TYPELESS    = 21,

        /// <summary>
        /// 32비트 채움, 1개의 8비트 부호없는 정수 값 및 24비트 채움을 사용합니다.
        /// </summary>
        X32_TYPELESS_G8X24_UINT     = 22,

        /// <summary>
        /// 3개의 10비트 값 및 1개의 2비트 값을 사용합니다.
        /// </summary>
        R10G10B10A2_TYPELESS        = 23,

        /// <summary>
        /// 3개의 10비트 부호없는 정규화된 실수 값 및 1개의 2비트 부호없는 정규화된 실수 값을 사용합니다.
        /// </summary>
        R10G10B10A2_UNORM           = 24,

        /// <summary>
        /// 3개의 10비트 부호없는 정수 값 및 1개의 2비트 부호없는 정수 값을 사용합니다.
        /// </summary>
        R10G10B10A2_UINT            = 25,

        /// <summary>
        /// 11, 11, 10비트를 사용하는 부동소수점 값을 사용합니다.
        /// </summary>
        R11G11B10_FLOAT             = 26,

        /// <summary>
        /// 4개의 8비트 값을 사용합니다.
        /// </summary>
        R8G8B8A8_TYPELESS           = 27,

        /// <summary>
        /// 4개의 8비트 부호없는 정규화된 실수 값을 사용합니다.
        /// </summary>
        R8G8B8A8_UNORM              = 28,

        /// <summary>
        /// 
        /// </summary>
        R8G8B8A8_UNORM_SRGB         = 29,

        /// <summary>
        /// 4개의 8비트 부호없는 정수 값을 사용합니다.
        /// </summary>
        R8G8B8A8_UINT               = 30,

        /// <summary>
        /// 4개의 8비트 정규화된 실수 값을 사용합니다.
        /// </summary>
        R8G8B8A8_SNORM              = 31,

        /// <summary>
        /// 4개의 8비트 정수 값을 사용합니다.
        /// </summary>
        R8G8B8A8_SINT               = 32,

        /// <summary>
        /// 
        /// </summary>
        R16G16_TYPELESS             = 33,

        /// <summary>
        /// 
        /// </summary>
        R16G16_FLOAT                = 34,

        /// <summary>
        /// 
        /// </summary>
        R16G16_UNORM                = 35,

        /// <summary>
        /// 
        /// </summary>
        R16G16_UINT                 = 36,

        /// <summary>
        /// 
        /// </summary>
        R16G16_SNORM                = 37,

        /// <summary>
        /// 
        /// </summary>
        R16G16_SINT                 = 38,

        /// <summary>
        /// 
        /// </summary>
        R32_TYPELESS                = 39,

        /// <summary>
        /// 
        /// </summary>
        D32_FLOAT                   = 40,

        /// <summary>
        /// 
        /// </summary>
        R32_FLOAT                   = 41,

        /// <summary>
        /// 
        /// </summary>
        R32_UINT                    = 42,

        /// <summary>
        /// 
        /// </summary>
        R32_SINT                    = 43,

        /// <summary>
        /// 
        /// </summary>
        R24G8_TYPELESS              = 44,

        /// <summary>
        /// 
        /// </summary>
        D24_UNORM_S8_UINT           = 45,

        /// <summary>
        /// 
        /// </summary>
        R24_UNORM_X8_TYPELESS       = 46,

        /// <summary>
        /// 
        /// </summary>
        X24_TYPELESS_G8_UINT        = 47,

        /// <summary>
        /// 
        /// </summary>
        R8G8_TYPELESS               = 48,

        /// <summary>
        /// 
        /// </summary>
        R8G8_UNORM                  = 49,

        /// <summary>
        /// 
        /// </summary>
        R8G8_UINT                   = 50,

        /// <summary>
        /// 
        /// </summary>
        R8G8_SNORM                  = 51,

        /// <summary>
        /// 
        /// </summary>
        R8G8_SINT                   = 52,

        /// <summary>
        /// 
        /// </summary>
        R16_TYPELESS                = 53,

        /// <summary>
        /// 
        /// </summary>
        R16_FLOAT                   = 54,

        /// <summary>
        /// 
        /// </summary>
        D16_UNORM                   = 55,

        /// <summary>
        /// 
        /// </summary>
        R16_UNORM                   = 56,

        /// <summary>
        /// 
        /// </summary>
        R16_UINT                    = 57,

        /// <summary>
        /// 
        /// </summary>
        R16_SNORM                   = 58,

        /// <summary>
        /// 
        /// </summary>
        R16_SINT                    = 59,

        /// <summary>
        /// 
        /// </summary>
        R8_TYPELESS                 = 60,

        /// <summary>
        /// 
        /// </summary>
        R8_UNORM                    = 61,

        /// <summary>
        /// 
        /// </summary>
        R8_UINT                     = 62,

        /// <summary>
        /// 
        /// </summary>
        R8_SNORM                    = 63,

        /// <summary>
        /// 
        /// </summary>
        R8_SINT                     = 64,

        /// <summary>
        /// 
        /// </summary>
        A8_UNORM                    = 65,

        /// <summary>
        /// 
        /// </summary>
        R1_UNORM                    = 66,

        /// <summary>
        /// 
        /// </summary>
        R9G9B9E5_SHAREDEXP          = 67,

        /// <summary>
        /// 
        /// </summary>
        R8G8_B8G8_UNORM             = 68,

        /// <summary>
        /// 
        /// </summary>
        G8R8_G8B8_UNORM             = 69,

        /// <summary>
        /// 
        /// </summary>
        BC1_TYPELESS                = 70,

        /// <summary>
        /// 
        /// </summary>
        BC1_UNORM                   = 71,

        /// <summary>
        /// 
        /// </summary>
        BC1_UNORM_SRGB              = 72,

        /// <summary>
        /// 
        /// </summary>
        BC2_TYPELESS                = 73,

        /// <summary>
        /// 
        /// </summary>
        BC2_UNORM                   = 74,

        /// <summary>
        /// 
        /// </summary>
        BC2_UNORM_SRGB              = 75,

        /// <summary>
        /// 
        /// </summary>
        BC3_TYPELESS                = 76,

        /// <summary>
        /// 
        /// </summary>
        BC3_UNORM                   = 77,

        /// <summary>
        /// 
        /// </summary>
        BC3_UNORM_SRGB              = 78,

        /// <summary>
        /// 
        /// </summary>
        BC4_TYPELESS                = 79,

        /// <summary>
        /// 
        /// </summary>
        BC4_UNORM                   = 80,

        /// <summary>
        /// 
        /// </summary>
        BC4_SNORM                   = 81,

        /// <summary>
        /// 
        /// </summary>
        BC5_TYPELESS                = 82,

        /// <summary>
        /// 
        /// </summary>
        BC5_UNORM                   = 83,

        /// <summary>
        /// 
        /// </summary>
        BC5_SNORM                   = 84,

        /// <summary>
        /// 
        /// </summary>
        B5G6R5_UNORM                = 85,

        /// <summary>
        /// 
        /// </summary>
        B5G5R5A1_UNORM              = 86,

        /// <summary>
        /// 
        /// </summary>
        B8G8R8A8_UNORM              = 87,

        /// <summary>
        /// 
        /// </summary>
        B8G8R8X8_UNORM              = 88,

        /// <summary>
        /// 
        /// </summary>
        R10G10B10_XR_BIAS_A2_UNORM  = 89,

        /// <summary>
        /// 
        /// </summary>
        B8G8R8A8_TYPELESS           = 90,

        /// <summary>
        /// 
        /// </summary>
        B8G8R8A8_UNORM_SRGB         = 91,

        /// <summary>
        /// 
        /// </summary>
        B8G8R8X8_TYPELESS           = 92,

        /// <summary>
        /// 
        /// </summary>
        B8G8R8X8_UNORM_SRGB         = 93,

        /// <summary>
        /// 
        /// </summary>
        BC6H_TYPELESS               = 94,

        /// <summary>
        /// 
        /// </summary>
        BC6H_UF16                   = 95,

        /// <summary>
        /// 
        /// </summary>
        BC6H_SF16                   = 96,

        /// <summary>
        /// 
        /// </summary>
        BC7_TYPELESS                = 97,

        /// <summary>
        /// 
        /// </summary>
        BC7_UNORM                   = 98,

        /// <summary>
        /// 
        /// </summary>
        BC7_UNORM_SRGB              = 99,

        /// <summary>
        /// 
        /// </summary>
        AYUV                        = 100,

        /// <summary>
        /// 
        /// </summary>
        Y410                        = 101,

        /// <summary>
        /// 
        /// </summary>
        Y416                        = 102,

        /// <summary>
        /// 
        /// </summary>
        NV12                        = 103,

        /// <summary>
        /// 
        /// </summary>
        P010                        = 104,

        /// <summary>
        /// 
        /// </summary>
        P016                        = 105,

        /// <summary>
        /// 
        /// </summary>
        _420_OPAQUE                 = 106,

        /// <summary>
        /// 
        /// </summary>
        YUY2                        = 107,

        /// <summary>
        /// 
        /// </summary>
        Y210                        = 108,

        /// <summary>
        /// 
        /// </summary>
        Y216                        = 109,

        /// <summary>
        /// 
        /// </summary>
        NV11                        = 110,

        /// <summary>
        /// 
        /// </summary>
        AI44                        = 111,

        /// <summary>
        /// 
        /// </summary>
        IA44                        = 112,

        /// <summary>
        /// 
        /// </summary>
        P8                          = 113,

        /// <summary>
        /// 
        /// </summary>
        A8P8                        = 114,

        /// <summary>
        /// 
        /// </summary>
        B4G4R4A4_UNORM              = 115,

        /// <summary>
        /// 
        /// </summary>
        P208                        = 130,

        /// <summary>
        /// 
        /// </summary>
        V208                        = 131,

        /// <summary>
        /// 
        /// </summary>
        V408                        = 132,
    }
}
