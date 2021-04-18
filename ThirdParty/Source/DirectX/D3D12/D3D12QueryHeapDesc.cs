// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 정보 요청 힙 서술 구조체를 표현합니다.
    /// </summary>
    public struct D3D12QueryHeapDesc
	{
		/// <summary>
		/// 정보 요청 힙 유형을 나타냅니다.
		/// </summary>
		public D3D12QueryHeapType Type;

		/// <summary>
		/// 정보 요청 개수를 나타냅니다.
		/// </summary>
		public uint Count;

		/// <summary>
		/// 노드 마스크를 나타냅니다.
		/// </summary>
		public uint NodeMask;

		/// <summary>
		/// <see cref="D3D12QueryHeapDesc"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="type"> 힙 유형을 전달합니다. </param>
		/// <param name="count"> 요청 개수를 전달합니다. </param>
		public D3D12QueryHeapDesc( D3D12QueryHeapType type, uint count )
		{
			this.Type = type;
			this.Count = count;
			this.NodeMask = 0;
		}
	}
}
