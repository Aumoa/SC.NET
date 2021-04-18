// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 상수 버퍼 서술자에 대한 정보를 서술합니다.
    /// </summary>
    public struct D3D12ConstantBufferViewDesc
	{
		/// <summary>
		/// 버퍼의 GPU 가상 주소를 전달합니다.
		/// </summary>
		public ulong BufferLocation;

		/// <summary>
		/// 버퍼의 크기를 전달합니다.
		/// </summary>
		public uint SizeInBytes;

		/// <summary>
		/// <see cref="D3D12ConstantBufferViewDesc"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="constantBuffer"> 상수 버퍼 리소스를 전달합니다. </param>
		public D3D12ConstantBufferViewDesc( ID3D12Resource constantBuffer )
		{
			BufferLocation = constantBuffer.GetGPUVirtualAddress();
			SizeInBytes = ( uint )constantBuffer.GetDesc().Width;
		}

		/// <summary>
		/// <see cref="D3D12ConstantBufferViewDesc"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="bufferLocation"> 버퍼의 GPU 가상 주소를 전달합니다. </param>
		/// <param name="sizeInBytes"> 버퍼의 크기를 전달합니다. </param>
		public D3D12ConstantBufferViewDesc( ulong bufferLocation, uint sizeInBytes )
		{
			this.BufferLocation = bufferLocation;
			this.SizeInBytes = sizeInBytes;
		}
	}
}
