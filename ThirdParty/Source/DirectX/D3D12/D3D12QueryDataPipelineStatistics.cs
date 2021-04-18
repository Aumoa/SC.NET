// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 파이프라인 통계 정보를 표현합니다.
    /// </summary>
    public struct D3D12QueryDataPipelineStatistics
	{
		/// <summary>
		/// IA 스테이지에서 읽은 정점 수를 나타냅니다.
		/// </summary>
		public ulong IAVertices;

		/// <summary>
		/// IA 스테이지에서 읽은 기본 기하 모형 수를 나타냅니다.
		/// </summary>
		public ulong IAPrimitives;

		/// <summary>
		/// 정점 셰이더 호출 수를 나타냅니다.
		/// </summary>
		public ulong VSInvocations;

		/// <summary>
		/// 기하 셰이더 호출 수를 나타냅니다. 기하 셰이더가 설정되지 않았을 경우 이 통계는 그래픽 어댑터 종류에 따라 증가하거나 증가하지 않을 수 있습니다.
		/// </summary>
		public ulong GSInvocations;

		/// <summary>
		/// 기하 셰이더가 출력한 기본 기하 모형 수를 나타냅니다.
		/// </summary>
		public ulong GSPrimitives;

		/// <summary>
		/// 래스터라이저 스테이지로 전송된 기본 기하 모형 수를 나타냅니다. 래스터라이저가 설정되지 않았을 경우 증가하지 않습니다.
		/// </summary>
		public ulong CInvocations;

		/// <summary>
		/// 렌더링이 완료된 기본 기하 모형 수를 나타냅니다. 기본 기하 모형은 클리핑 및 분할 등에 의해 <see cref="CInvocations"/> 값보다 크거나 작을 수 있습니다.
		/// </summary>
		public ulong CPrimitives;

		/// <summary>
		/// 픽셀 셰이더 호출 수를 나타냅니다.
		/// </summary>
		public ulong PSInvocations;

		/// <summary>
		/// 덮개 셰이더 호출 수를 나타냅니다.
		/// </summary>
		public ulong HSInvocations;

		/// <summary>
		/// 영역 셰이더 호출 수를 나타냅니다.
		/// </summary>
		public ulong DSInvocations;

		/// <summary>
		/// 계산 셰이더 호출 수를 나타냅니다.
		/// </summary>
		public ulong CSInvocations;
	}
}
