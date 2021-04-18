// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 정보 요청 유형을 나타냅니다.
    /// </summary>
    public enum D3D12QueryType
	{
		/// <summary>
		/// 정보가 깊이 및 스텐실 검사에 통과한 횟수를 나타냅니다.
		/// </summary>
		Occlusion = 0,

		/// <summary>
		/// 정보가 깊이 및 스텐실 검사에 통과하였는지 여부를 나타냅니다.
		/// </summary>
		/// <remarks> 이 유형은 0, 1의 결과만 반환한다는 점을 제외하고 <see cref="Occlusion"/> 유형과 같이 작동합니다. 0은 샘플이 깊이 및 스텐실 테스트를 통과하지 않음을 나타내고, 1은 하나 이상의 샘플이 깊이 및 스텐실 테스트를 통과했음을 나타냅니다. </remarks>
		BinaryOcclusion = 1,

		/// <summary>
		/// 정보가 고성능 GPU 시간임을 나타냅니다.
		/// </summary>
		Timestamp = 2,

		/// <summary>
		/// 정보가 그래픽 파이프라인 통계에 대한 것임을 나타냅니다. <see cref="D3D12QueryDataPipelineStatistics"/> 구조체 정보를 가져옵니다.
		/// </summary>
		PipelineStatistics = 3,

		/// <summary>
		/// 
		/// </summary>
		SOStatisticsStream0 = 4,

		/// <summary>
		/// 
		/// </summary>
		SOStatisticsStream1 = 5,

		/// <summary>
		/// 
		/// </summary>
		SOStatisticsStream2 = 6,

		/// <summary>
		/// 
		/// </summary>
		SOStatisticsStream3 = 7,

		/// <summary>
		/// 
		/// </summary>
		VideoDecodeStatistics = 8
	}
}
