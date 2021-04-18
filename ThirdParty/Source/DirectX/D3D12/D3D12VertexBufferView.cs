// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 정점 버퍼 서술자 정보를 나타냅니다.
    /// </summary>
    public struct D3D12VertexBufferView
	{
		/// <summary>
		/// 버퍼의 바이트 단위 위치를 나타냅니다.
		/// </summary>
		public ulong BufferLocation;

		/// <summary>
		/// 버퍼의 바이트 단위 크기를 나타냅니다.
		/// </summary>
		public uint SizeInBytes;

		/// <summary>
		/// 각 정점의 바이트 단위 크기를 나타냅니다.
		/// </summary>
		public uint StrideInBytes;

		/// <summary>
		/// <see cref="D3D12IndexBufferView"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="bufferLocation"> 버퍼의 바이트 단위 위치를 전달합니다. </param>
		/// <param name="strideInBytes"> 정점 버퍼의 각 정점의 바이트 단위 크기를 전달합니다. </param>
		/// <param name="vertexCount"> 인덱스 버퍼의 인덱스 개수를 전달합니다. </param>
		public D3D12VertexBufferView( ulong bufferLocation, uint strideInBytes, uint vertexCount )
		{
			this.BufferLocation = bufferLocation;
			this.StrideInBytes = strideInBytes;
			this.SizeInBytes = strideInBytes * vertexCount;
		}

		/// <summary>
		/// 구조체의 간단한 텍스트 형식을 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public override string ToString()
		{
			return string.Format( "{0}: BufferLocation = {2}, VertexCount = {2}", base.ToString(), BufferLocation, SizeInBytes / StrideInBytes );
		}
	}
}
