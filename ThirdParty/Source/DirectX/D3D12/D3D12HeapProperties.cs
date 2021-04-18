// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 힙 속성을 나타냅니다.
    /// </summary>
    public struct D3D12HeapProperties
	{
		/// <summary>
		/// 힙 유형을 나타냅니다.
		/// </summary>
		public D3D12HeapType Type;

		/// <summary>
		/// CPU 엑세스 가능성을 나타냅니다.
		/// </summary>
		public D3D12CPUPageProperty CPUPageProperty;

		/// <summary>
		/// GPU 메모리 위치에 대한 속성을 나타냅니다.
		/// </summary>
		public D3D12MemoryPool MemoryPoolPreference;

		/// <summary>
		/// 생성 노드 마스크를 전달합니다.
		/// </summary>
		public uint CreationNodeMask;

		/// <summary>
		/// 관측 노드 마스크를 전달합니다.
		/// </summary>
		public uint VisibleNodeMask;

		/// <summary>
		/// <see cref="D3D12HeapProperties"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="heapType"> 힙 유형을 전달합니다. </param>
		public D3D12HeapProperties( D3D12HeapType heapType )
		{
			this.Type = heapType;
			this.CPUPageProperty = D3D12CPUPageProperty.Unknown;
			this.MemoryPoolPreference = D3D12MemoryPool.Unknown;
			this.CreationNodeMask = 0;
			this.VisibleNodeMask = 0;
		}
	}
}
