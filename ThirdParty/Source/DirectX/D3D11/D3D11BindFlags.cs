// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D11 리소스 바인딩 속성을 표현합니다.
    /// </summary>
    [Flags]
	public enum D3D11BindFlags
	{
		/// <summary>
		/// 정점 버퍼로 바인딩합니다.
		/// </summary>
		VertexBuffer = 0x1,

		/// <summary>
		/// 인덱스 버퍼로 바인딩합니다.
		/// </summary>
		IndexBuffer = 0x2,

		/// <summary>
		/// 상수 버퍼로 바인딩합니다.
		/// </summary>
		ConstantBuffer = 0x4,

		/// <summary>
		/// 셰이더 자원으로 바인딩합니다.
		/// </summary>
		ShaderResource = 0x8,

		/// <summary>
		/// 스트림 출력으로 바인딩합니다.
		/// </summary>
		StreamOutput = 0x10,

		/// <summary>
		/// 렌더 타겟으로 바인딩합니다.
		/// </summary>
		RenderTarget = 0x20,

		/// <summary>
		/// 깊이 스텐실 자원으로 바인딩합니다.
		/// </summary>
		DepthStencil = 0x40,

		/// <summary>
		/// 순서없는 접근으로 바인딩합니다.
		/// </summary>
		UnorderedAccess = 0x80,

		/// <summary>
		/// 디코더 자원으로 바인딩합니다.
		/// </summary>
		Decoder = 0x200,

		/// <summary>
		/// 비디오 인코더 자원으로 바인딩합니다.
		/// </summary>
		VideoEncoder = 0x400
	}
}
