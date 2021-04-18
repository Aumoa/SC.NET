// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 정보 요청 힙 유형을 표현합니다.
    /// </summary>
    public enum D3D12QueryHeapType
	{
		/// <summary>
		/// 차폐 정보 요청 힙 유형입니다.
		/// </summary>
		Occlusion = 0,

		/// <summary>
		/// 시간 정보 요청 힙 유형입니다.
		/// </summary>
		Timestamp = 1,

		/// <summary>
		/// 파이프라인 통계 요청 힙 유형입니다.
		/// </summary>
		PipelineStatistics = 2,

		/// <summary>
		/// 스트림 출력 통계 요청 힙 유형입니다.
		/// </summary>
		SOStatistics = 3,

		/// <summary>
		/// 비디오 디코드 통계 요청 힙 유형입니다.
		/// </summary>
		VideoDecodeStatistics = 4,

		/// <summary>
		/// 복사 대기열 시간 정보 요청 힙 유형입니다.
		/// </summary>
		CopyQueueTimestamp = 5
	}
}
