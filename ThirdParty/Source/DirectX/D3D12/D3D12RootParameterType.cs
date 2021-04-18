// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 입력 서명 매개변수의 유형을 나타냅니다.
    /// </summary>
    public enum D3D12RootParameterType
	{
		/// <summary>
		/// 서술자 테이블 개체에 대한 매개변수를 사용합니다.
		/// </summary>
		DescriptorTable = 0,

		/// <summary>
		/// 32비트 상수 매개변수를 사용합니다.
		/// </summary>
		Constants32Bit,

		/// <summary>
		/// 상수 버퍼 서술자 매개변수를 사용합니다.
		/// </summary>
		CBV,

		/// <summary>
		/// 셰이더 자원 서술자 매개변수를 사용합니다.
		/// </summary>
		SRV,

		/// <summary>
		/// 순서없는 접근 서술자 매개변수를 사용합니다.
		/// </summary>
		UAV
	}
}
