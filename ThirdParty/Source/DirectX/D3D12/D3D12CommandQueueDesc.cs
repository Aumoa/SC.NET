// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 명령 대기열 정보를 서술합니다.
    /// </summary>
    public struct D3D12CommandQueueDesc
	{
		/// <summary>
		/// 명령 대기열에서 실행할 명령 목록 유형을 나타냅니다.
		/// </summary>
		public D3D12CommandListType Type;

		/// <summary>
		/// 명령 대기열의 우선 순위를 나타냅니다.
		/// </summary>
		public D3D12CommandQueuePriority Priority;

		/// <summary>
		/// 명령 대기열의 속성을 나타냅니다.
		/// </summary>
		public D3D12CommandQueueFlags Flags;

		/// <summary>
		/// 명령 대기열의 관측 비트 마스크를 나타냅니다.
		/// </summary>
		public uint NodeMask;

		/// <summary>
		/// <see cref="D3D12CommandQueueDesc"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="type"> 명령 목록 유형을 전달합니다. </param>
		/// <param name="priority"> 우선 순위를 전달합니다. </param>
		public D3D12CommandQueueDesc( D3D12CommandListType type, D3D12CommandQueuePriority priority = D3D12CommandQueuePriority.Normal )
		{
			this.Type = type;
			this.Priority = priority;
			this.Flags = D3D12CommandQueueFlags.None;
			this.NodeMask = 0;
		}

		/// <summary>
		/// 구조체의 간단한 텍스트 형식을 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public override string ToString()
			=> $"{base.ToString()}: Type = {Type}, Priority = {Priority}";
	}
}
