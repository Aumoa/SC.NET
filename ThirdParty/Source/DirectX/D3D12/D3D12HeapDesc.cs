// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 힙 정보를 표현합니다.
    /// </summary>
    public struct D3D12HeapDesc
	{
		/// <summary>
		/// 힙의 크기를 나타냅니다.
		/// </summary>
		public ulong SizeInBytes;

		/// <summary>
		/// 힙의 속성을 나타냅니다.
		/// </summary>
		public D3D12HeapProperties Properties;

		/// <summary>
		/// 힙의 배치 정렬 단위를 나타냅니다.
		/// </summary>
		public ulong Alignment;

		/// <summary>
		/// 힙의 속성을 나타냅니다.
		/// </summary>
		public D3D12HeapFlags Flags;

		/// <summary>
		/// <see cref="D3D12HeapDesc"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="sizeInBytes"> 힙의 크기를 전달합니다. </param>
		/// <param name="type"> 힙의 유형을 전달합니다. </param>
		public D3D12HeapDesc( ulong sizeInBytes, D3D12HeapType type )
		{
			this.SizeInBytes = sizeInBytes;
			this.Properties = new D3D12HeapProperties( type );
			this.Alignment = 0;
			this.Flags = D3D12HeapFlags.None;
		}

		/// <summary>
		/// 구조체의 간단한 텍스트 형식을 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public override string ToString()
			=> $"{base.ToString()}: SizeInBytes = {SizeInBytes}, HeapType = {Properties.Type}, Flags = {Flags}";
	}
}
