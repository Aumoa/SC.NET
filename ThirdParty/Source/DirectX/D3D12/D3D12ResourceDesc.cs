// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 자원의 정보를 서술하는 구조체를 표현합니다.
    /// </summary>
    public struct D3D12ResourceDesc
	{
		/// <summary>
		/// 자원의 차원 형식을 나타냅니다.
		/// </summary>
		public D3D12ResourceDimension Dimension;

		/// <summary>
		/// 자원의 정렬 바이트 단위를 나타냅니다.
		/// </summary>
		public ulong Alignment;

		/// <summary>
		/// 자원의 너비를 나타냅니다. 버퍼 및 1차원 자원의 경우 이 값은 바이트 단위 크기가 됩니다.
		/// </summary>
		public ulong Width;

		/// <summary>
		/// 자원의 높이를 나타냅니다. 버퍼 및 1차원 자원의 경우 이 값은 1이 되어야 합니다.
		/// </summary>
		public uint Height;

		/// <summary>
		/// 자원의 깊이를 나타냅니다. 버퍼 및 1차원, 2차원 자원의 경우 이 값은 1이 되어야 합니다.
		/// </summary>
		public ushort DepthOrArraySize;

		/// <summary>
		/// 자원의 MIP 레벨 개수를 나타냅니다.
		/// </summary>
		public ushort MipLevels;

		/// <summary>
		/// 자원의 형식을 나타냅니다.
		/// </summary>
		public DXGIFormat Format;

		/// <summary>
		/// 자원의 샘플 정보를 나타냅니다.
		/// </summary>
		public DXGISampleDesc SampleDesc;

		/// <summary>
		/// 자원의 배치 형식을 나타냅니다.
		/// </summary>
		public D3D12TextureLayout Layout;

		/// <summary>
		/// 자원의 속성을 나타냅니다.
		/// </summary>
		public D3D12ResourceFlags Flags;

		/// <summary>
		/// <see cref="D3D12ResourceDesc"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="dimension"> 자원의 차원 형식을 전달합니다. </param>
		/// <param name="width"> 자원의 너비를 전달합니다. </param>
		/// <param name="height"> 자원의 높이를 전달합니다. </param>
		/// <param name="format"> 자원의 형식을 전달합니다. </param>
		/// <param name="layout"> 자원의 배치 형식을 전달합니다. </param>
		/// <param name="flags"> 자원의 속성을 전달합니다. </param>
		public D3D12ResourceDesc( D3D12ResourceDimension dimension, ulong width, uint height, DXGIFormat format, D3D12TextureLayout layout, D3D12ResourceFlags flags = D3D12ResourceFlags.None )
		{
			this.Dimension = dimension;
			this.Alignment = 0;
			this.Width = width;
			this.Height = height;
			this.DepthOrArraySize = 1;
			this.MipLevels = 1;
			this.Format = format;
			this.SampleDesc = DXGISampleDesc.One;
			this.Layout = layout;
			this.Flags = flags;
		}

		/// <summary>
		/// 구조체의 간단한 텍스트 형식을 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public override string ToString()
		{
			switch ( Dimension )
			{
				case D3D12ResourceDimension.Buffer:
					return string.Format(
						"{0}: Dimension = {1}, BufferSize = {2:N}KB, Flags = {3}",
						base.ToString(),
						Dimension,
						( double )Width / 1024.0,
						Flags
						);
				case D3D12ResourceDimension.Texture1D:
					return string.Format(
						"{0}: Dimension = {1}, Width = {2}, MipLevels = {3}, Format = {4}, SampleDesc = {5}, Flags = {6}",
						base.ToString(),
						Dimension,
						Width,
						MipLevels,
						Format,
						SampleDesc,
						Flags
						);
				case D3D12ResourceDimension.Texture2D:
					return string.Format(
						"{0}: Dimension = {1}, Width = {2}, Height = {3}, MipLevels = {4}, Format = {5}, SampleDesc = {6}, Flags = {7}",
						base.ToString(),
						Dimension,
						Width,
						Height,
						MipLevels,
						Format,
						SampleDesc,
						Flags
						);
				case D3D12ResourceDimension.Texture3D:
					return string.Format(
						"{0}: Dimension = {1}, Width = {2}, Height = {3}, Depth = {8}, MipLevels = {4}, Format = {5}, SampleDesc = {6}, Flags = {7}",
						base.ToString(),
						Dimension,
						Width,
						Height,
						MipLevels,
						Format,
						SampleDesc,
						Flags,
						DepthOrArraySize
						);
				default:
					return string.Format( "{0}: Dimension = {1}", base.ToString(), Dimension );
			}
		}

		/// <summary>
		/// 버퍼 형식의 자원에 대한 서술 구조체로 초기화합니다.
		/// </summary>
		/// <param name="sizeInBytes"> 버퍼의 바이트 단위 크기를 전달합니다. </param>
		/// <param name="flags"> 버퍼의 속성을 전달합니다. </param>
		/// <returns> 생성된 서술 구조체가 반환됩니다. </returns>
		public static D3D12ResourceDesc Buffer( ulong sizeInBytes, D3D12ResourceFlags flags = D3D12ResourceFlags.None )
		{
			return new D3D12ResourceDesc
			{
				Dimension = D3D12ResourceDimension.Buffer,
				Width = sizeInBytes,
				Height = 1,
				DepthOrArraySize = 1,
				MipLevels = 1,
				Format = DXGIFormat.Unknown,
				SampleDesc = DXGISampleDesc.One,
				Layout = D3D12TextureLayout.RowMajor,
				Flags = flags
			};
		}

		/// <summary>
		/// 2차원 텍스처 형식의 자원에 대한 서술 구조체로 초기화합니다.
		/// </summary>
		/// <param name="width"> 2차원 텍스처의 너비를 전달합니다. </param>
		/// <param name="height"> 2차원 텍스처의 높이를 전달합니다. </param>
		/// <param name="format"> 2차원 텍스처의 형식을 전달합니다. </param>
		/// <param name="flags"> 2차원 텍스처의 속성을 전달합니다. </param>
		/// <param name="mipLevels"> 2차원 텍스처의 MIP 레벨 개수를 전달합니다. </param>
		/// <returns> 생성된 서술 구조체가 반환됩니다. </returns>
		public static D3D12ResourceDesc Texture2D( ulong width, uint height, DXGIFormat format, D3D12ResourceFlags flags = D3D12ResourceFlags.None, ushort mipLevels = 1 )
		{
			return new D3D12ResourceDesc
			{
				Dimension = D3D12ResourceDimension.Texture2D,
				Width = width,
				Height = height,
				DepthOrArraySize = 1,
				MipLevels = mipLevels,
				Format = format,
				SampleDesc = DXGISampleDesc.One,
				Layout = D3D12TextureLayout.Unknown,
				Flags = flags
			};
		}
	}
}
