// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 자원 상태를 나타냅니다.
    /// </summary>
    [Flags]
	public enum D3D12ResourceStates
	{
		/// <summary>
		/// 일반 상태를 나타냅니다.
		/// </summary>
		Common = 0,

		/// <summary>
		/// 정점 및 상수 버퍼를 나타냅니다.
		/// </summary>
		VertexAndConstantBuffer = 0x1,

		/// <summary>
		/// 인덱스 버퍼를 나타냅니다.
		/// </summary>
		IndexBuffer = 0x2,

		/// <summary>
		/// 렌더 타겟 상태를 나타냅니다.
		/// </summary>
		RenderTarget = 0x4,

		/// <summary>
		/// 순서없는 접근 상태를 나타냅니다.
		/// </summary>
		UnorderedAccess = 0x8,

		/// <summary>
		/// 깊이 쓰기 상태를 나타냅니다.
		/// </summary>
		DepthWrite = 0x10,

		/// <summary>
		/// 깊이 읽기 상태를 나타냅니다.
		/// </summary>
		DepthRead = 0x20,

		/// <summary>
		/// 픽셀 셰이더가 아닌 셰이더의 자원으로 사용됨을 나타냅니다.
		/// </summary>
		NonPixelShaderResource = 0x40,

		/// <summary>
		/// 픽셀 셰이더의 자원으로 사용됨을 나타냅니다.
		/// </summary>
		PixelShaderResource = 0x80,

		/// <summary>
		/// 스트림 아웃 자원으로 사용됩니다.
		/// </summary>
		StreamOut = 0x100,

		/// <summary>
		/// 간접 명령 버퍼의 자원으로 사용됩니다.
		/// </summary>
		IndirectArgument = 0x200,

		/// <summary>
		/// 복사 대상으로 사용됩니다.
		/// </summary>
		CopyDest = 0x400,

		/// <summary>
		/// 복사 원본으로 사용됩니다.
		/// </summary>
		CopySource = 0x800,

		/// <summary>
		/// 샘플링 해결 대상으로 사용됩니다.
		/// </summary>
		ResolveDest = 0x1000,

		/// <summary>
		/// 샘플링 원본으로 사용됩니다.
		/// </summary>
		ResolveSource = 0x2000,

		/// <summary>
		/// 레이트레이싱 가속화 구조체 자원으로 사용됩니다.
		/// </summary>
		RaytracingAccelerationStructure = 0x400000,

		/// <summary>
		/// 
		/// </summary>
		ShadingRateSource = 0x1000000,

		/// <summary>
		/// <para> 일반적 읽기 가능 조합을 사용합니다. </para>
		/// <para> <see cref="VertexAndConstantBuffer"/> </para>
		/// <para> <see cref="IndexBuffer"/> </para>
		/// <para> <see cref="NonPixelShaderResource"/> </para>
		/// <para> <see cref="PixelShaderResource"/> </para>
		/// <para> <see cref="IndirectArgument"/> </para>
		/// <para> <see cref="CopySource"/> </para>
		/// </summary>
		GenericRead = VertexAndConstantBuffer | IndexBuffer | NonPixelShaderResource | PixelShaderResource | IndirectArgument | CopySource,

		/// <summary>
		/// 디스플레이 출력 가능 상태를 나타냅니다.
		/// </summary>
		Present = 0,

		/// <summary>
		/// 
		/// </summary>
		Predication = 0x200,

		/// <summary>
		/// 비디오 복호화 읽기 상태를 나타냅니다.
		/// </summary>
		VideoDecodeRead = 0x10000
	}
}
