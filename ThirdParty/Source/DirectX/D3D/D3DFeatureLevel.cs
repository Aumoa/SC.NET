// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D 기능 레벨을 표현합니다.
    /// </summary>
    public enum D3DFeatureLevel
	{
		/// <summary>
		/// 알 수 없는 기능 레벨입니다. 일반적으로 이 값은 오류입니다.
		/// </summary>
		Unspecified = 0,

		/// <summary>
		/// MCDM 장치를 사용합니다. MCDM은 계산 전용 드라이버 모델입니다.
		/// </summary>
		Level1_0_Core = 0x1000,

		/// <summary>
		/// 
		/// </summary>
		Level9_1 = 0x9100,

		/// <summary>
		/// 
		/// </summary>
		Level9_2 = 0x9200,

		/// <summary>
		/// 
		/// </summary>
		Level9_3 = 0x9300,

		/// <summary>
		/// 
		/// </summary>
		Level10_0 = 0xA000,

		/// <summary>
		/// 
		/// </summary>
		Level10_1 = 0xA100,

		/// <summary>
		/// 
		/// </summary>
		Level11_0 = 0xB000,

		/// <summary>
		/// 
		/// </summary>
		Level11_1 = 0xB100,

		/// <summary>
		/// 
		/// </summary>
		Level12_0 = 0xC000,

		/// <summary>
		/// 
		/// </summary>
		Level12_1 = 0xC100
	}
}
