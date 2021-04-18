// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// 힙 속성을 나타냅니다.
    /// </summary>
    public enum D3D12HeapFlags
	{
		/// <summary>
		/// <see cref="AllowAllBuffersAndTextures"/> 항목과 동일합니다.
		/// </summary>
		None = 0,

		/// <summary>
		/// 공유된 힙임을 나타냅니다.
		/// </summary>
		Shared = 0x1,

		/// <summary>
		/// 버퍼 사용을 제한합니다.
		/// </summary>
		DenyBuffers = 0x4,

		/// <summary>
		/// 출력으로 사용을 허용합니다.
		/// </summary>
		AllowDisplay = 0x8,

		/// <summary>
		/// 멀티 어댑터 사용을 허용합니다.
		/// </summary>
		SharedCrossAdapter = 0x20,

		/// <summary>
		/// 렌더 타겟 및 깊이 스텐실 텍스처로의 사용을 제한합니다.
		/// </summary>
		DenyRTDSTextures = 0x40,

		/// <summary>
		/// 렌더 타겟 및 깊이 스텐실 대상이 아닌 텍스처로의 사용을 제한합니다.
		/// </summary>
		DenyNonRTDSTextures = 0x80,

		/// <summary>
		/// 하드웨어로 보호됨을 나타냅니다.
		/// </summary>
		HardwareProtected = 0x100,

		/// <summary>
		/// 쓰기 상태를 감시합니다.
		/// </summary>
		AllowWriteWatch = 0x200,

		/// <summary>
		/// 셰이더 원자적 명령을 허용합니다.
		/// </summary>
		AllowShaderAtomics = 0x400,

		/// <summary>
		/// 모든 버퍼 및 텍스처로의 사용을 허용합니다.
		/// </summary>
		AllowAllBuffersAndTextures = 0,

		/// <summary>
		/// 버퍼로의 사용만을 허용합니다.
		/// </summary>
		AllowOnlyBuffers = 0xC0,

		/// <summary>
		/// 렌더 타겟 및 깊이 스텐실이 아닌 텍스처로의 사용만을 허용합니다.
		/// </summary>
		AllowOnlyNonRTDSTextures = 0x44,

		/// <summary>
		/// 렌더 타겟 및 깊이 스텐실 텍스처로의 사용만을 허용합니다.
		/// </summary>
		AllowOnlyRTDSTextures = 0x84
	}
}
