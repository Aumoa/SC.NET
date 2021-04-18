// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// 스왑 체인에 대한 정보를 서술합니다.
    /// </summary>
    public struct DXGISwapChainDesc1
	{
		/// <summary>
		/// 화면의 넓이를 표현합니다.
		/// </summary>
		public int Width;

		/// <summary>
		/// 화면의 높이를 표현합니다.
		/// </summary>
		public int Height;

		/// <summary>
		/// 화면의 형식을 표현합니다.
		/// </summary>
		public DXGIFormat Format;

		/// <summary>
		/// 화면이 스테레오 방식으로 작동하는지를 표현합니다.
		/// </summary>
		public bool Stereo;

		/// <summary>
		/// 화면의 샘플링 정보를 표현합니다.
		/// </summary>
		public DXGISampleDesc SampleDesc;

		/// <summary>
		/// 후면 버퍼의 사용 방식을 표현합니다.
		/// </summary>
		public DXGIUsage BufferUsage;

		/// <summary>
		/// 버퍼의 개수를 표현합니다.
		/// </summary>
		public uint BufferCount;

		/// <summary>
		/// 버퍼의 비례 방식을 표현합니다.
		/// </summary>
		public DXGIScaling Scaling;

		/// <summary>
		/// 화면의 스왑 효과를 표현합니다.
		/// </summary>
		public DXGISwapEffect SwapEffect;

		/// <summary>
		/// 화면의 알파 처리 방식을 표현합니다.
		/// </summary>
		public DXGIAlphaMode AlphaMode;

		/// <summary>
		/// 스왑 체인의 속성을 표현합니다.
		/// </summary>
		public DXGISwapChainFlag Flags;

		/// <summary>
		/// <see cref="DXGISwapChainDesc1"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="width"> 화면의 너비를 전달합니다. </param>
		/// <param name="height"> 화면의 높이를 전달합니다. </param>
		/// <param name="format"> 화면의 형식을 전달합니다. </param>
		/// <param name="bufferUsage"> 버퍼의 사용 방식을 전달합니다. </param>
		/// <param name="bufferCount"> 버퍼의 개수를 전달합니다. </param>
		/// <param name="swapEffect"> 스왑 효과를 전달합니다.</param>
		public DXGISwapChainDesc1( int width, int height, DXGIFormat format, DXGIUsage bufferUsage, uint bufferCount, DXGISwapEffect swapEffect )
		{
			this.Width = width;
			this.Height = height;
			this.Format = format;
			this.Stereo = false;
			this.SampleDesc = DXGISampleDesc.One;
			this.BufferUsage = bufferUsage;
			this.BufferCount = bufferCount;
			this.Scaling = DXGIScaling.Stretch;
			this.SwapEffect = swapEffect;
			this.AlphaMode = DXGIAlphaMode.Unspecified;
			this.Flags = DXGISwapChainFlag.None;
		}

		/// <summary>
		/// 구조체의 간단한 텍스트 형식을 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public override string ToString()
		{
			return string.Format( "{0}: Width = {1}, Height = {2}, Format = {3}, {{{4}}}, BufferCount = {5}, SwapEffect = {6}", base.ToString(), Width, Height, Format, SampleDesc, BufferCount, SwapEffect );
		}
	}
}
