// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 스트림 출력 대상 버퍼를 서술합니다.
    /// </summary>
    public struct D3D12StreamOutputBufferView
	{
		/// <summary>
		/// 버퍼의 바이트 단위 위치를 전달합니다.
		/// </summary>
		public ulong BufferLocation;

		/// <summary>
		/// 버퍼의 바이트 단위 크기를 전달합니다.
		/// </summary>
		public ulong SizeInBytes;

		/// <summary>
		/// 
		/// </summary>
		public ulong BufferFilledSizeLocation;

		/// <summary>
		/// <see cref="D3D12StreamOutputBufferView"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="bufferLocation"> 버퍼의 바이트 단위 위치를 전달합니다. </param>
		/// <param name="sizeInBytes"> 버퍼의 바이트 단위 크기를 전달합니다. </param>
		/// <param name="bufferFilledSizeLocation"> </param>
		public D3D12StreamOutputBufferView( ulong bufferLocation, ulong sizeInBytes, ulong bufferFilledSizeLocation )
		{
			this.BufferLocation = bufferLocation;
			this.SizeInBytes = sizeInBytes;
			this.BufferFilledSizeLocation = bufferFilledSizeLocation;
		}
	}
}
