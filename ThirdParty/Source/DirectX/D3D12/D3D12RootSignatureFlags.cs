// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 루트 서명 개체의 속성을 나타냅니다.
    /// </summary>
    public enum D3D12RootSignatureFlags
	{
		/// <summary>
		/// 아무 속성도 지정하지 않습니다.
		/// </summary>
		None = 0,

		/// <summary>
		/// 입력 어셈블러 및 입력 배치의 값을 허용합니다.
		/// </summary>
		AllowInputAssemblerInputLayout = 0x1,

		/// <summary>
		/// 정점 셰이더의 루트 서명 엑세스를 차단합니다.
		/// </summary>
		DenyVertexShaderRootAccess = 0x2,

		/// <summary>
		/// 덮개 셰이더의 루트 서명 엑세스를 차단합니다.
		/// </summary>
		DenyHullShaderRootAccess = 0x4,

		/// <summary>
		/// 영역 셰이더의 루트 서명 엑세스를 차단합니다.
		/// </summary>
		DenyDomainShaderRootAccess = 0x8,

		/// <summary>
		/// 기하 셰이더의 루트 서명 엑세스를 차단합니다.
		/// </summary>
		DenyGeometryShaderRootAccess = 0x10,

		/// <summary>
		/// 픽셀 셰이더의 루트 서명 엑세스를 차단합니다.
		/// </summary>
		DenyPixelShaderRootAccess = 0x20,

		/// <summary>
		/// 스트림 출력을 허용합니다.
		/// </summary>
		AllowStreamOutput = 0x40,

		/// <summary>
		/// 지역 루트 서명 개체로 사용합니다.
		/// </summary>
		LocalRootSignature = 0x80
	}
}
