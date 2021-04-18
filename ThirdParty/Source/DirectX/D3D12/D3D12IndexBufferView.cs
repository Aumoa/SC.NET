// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 인덱스 버퍼 서술자 정보를 나타냅니다.
    /// </summary>
    public struct D3D12IndexBufferView
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
		/// 인덱스 버퍼의 인덱스 형식을 나타냅니다.
		/// </summary>
		public DXGIFormat Format;

		/// <summary>
		/// <see cref="D3D12IndexBufferView"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="bufferLocation"> 버퍼의 바이트 단위 위치를 전달합니다. </param>
		/// <param name="format"> 인덱스 버퍼의 인덱스 형식을 전달합니다. </param>
		/// <param name="indexCount"> 인덱스 버퍼의 인덱스 개수를 전달합니다. </param>
		public D3D12IndexBufferView( ulong bufferLocation, DXGIFormat format, uint indexCount )
		{
			var stride = format switch
			{
				DXGIFormat.R32_UINT => 4U,
				DXGIFormat.R16_UINT => 2U,
				_ => throw new ArgumentException( "인덱스 버퍼의 형식은 R32_UINT 또는 R16_UINT가 되어야 합니다." )
			};

			this.BufferLocation = bufferLocation;
			this.SizeInBytes = stride * indexCount;
			this.Format = format;
		}

		/// <summary>
		/// 구조체의 간단한 텍스트 형식을 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public override string ToString()
		{
			var stride = Format switch
			{
				DXGIFormat.R32_UINT => 4U,
				DXGIFormat.R16_UINT => 2U,
				_ => throw new ArgumentException( "인덱스 버퍼의 형식은 R32_UINT 또는 R16_UINT가 되어야 합니다." )
			};

			return string.Format( "{0}: Format = {1}, BufferLocation = {2}, IndexCount = {3}", base.ToString(), Format, BufferLocation, SizeInBytes / stride );
		}
	}
}
