// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI 표면 정보를 서술합니다.
    /// </summary>
    public struct DXGISurfaceDesc
	{
		/// <summary>
		/// 표면의 너비를 표현합니다.
		/// </summary>
		public uint Width;

		/// <summary>
		/// 표면의 높이를 표현합니다..
		/// </summary>
		public uint Height;

		/// <summary>
		/// 표면의 픽셀 형식을 표현합니다.
		/// </summary>
		public DXGIFormat Format;

		/// <summary>
		/// 표면의 샘플링 정보를 표현합니다.
		/// </summary>
		public DXGISampleDesc SampleDesc;

		/// <summary>
		/// <see cref="DXGISurfaceDesc"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="width"> 표면의 너비를 전달합니다.</param>
		/// <param name="height"> 표면의 높이를 전달합니다. </param>
		/// <param name="format"> 표면의 픽셀 형식을 전달합니다. </param>
		public DXGISurfaceDesc( uint width, uint height, DXGIFormat format )
		{
			this.Width = width;
			this.Height = height;
			this.Format = format;
			this.SampleDesc = DXGISampleDesc.One;
		}

		/// <summary>
		/// 구조체의 간단한 텍스트 형식을 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public override string ToString()
		{
			return string.Format( "{0}: Width = {1}, Height = {2}, Format = {3}", base.ToString(), Width, Height, Format );
		}
	}
}
