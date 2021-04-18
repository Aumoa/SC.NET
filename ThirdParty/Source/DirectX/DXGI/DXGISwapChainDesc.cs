// Copyright 2020 Aumoa.lib. All right reserved.

using SC.ThirdParty.WinAPI;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// 스왑 체인에 대한 정보를 서술합니다.
    /// </summary>
    public struct DXGISwapChainDesc
	{
		/// <summary>
		/// 화면 버퍼에 대한 정보를 표현합니다.
		/// </summary>
		public DXGIModeDesc BufferDesc;

		/// <summary>
		/// 화면의 샘플링 방식을 표현합니다.
		/// </summary>
		public DXGISampleDesc SampleDesc;

		/// <summary>
		/// 후면 버퍼의 사용 방식을 표현합니다.
		/// </summary>
		public DXGIUsage BufferUsage;

		/// <summary>
		/// 후면 버퍼의 개수를 표현합니다.
		/// </summary>
		public uint BufferCount;

		/// <summary>
		/// 후면 버퍼의 출력 대상 창 핸들을 표현합니다.
		/// </summary>
		public IPlatformHandle OutputWindow;

		/// <summary>
		/// 출력 대상 창이 창 화면을 사용하도록 지정하는 값을 표현합니다.
		/// </summary>
		public bool Windowed;

		/// <summary>
		/// 스왑 체인의 스왑 효과를 표현합니다.
		/// </summary>
		public DXGISwapEffect SwapEffect;

		/// <summary>
		/// 스왑 체인의 속성을 표현합니다.
		/// </summary>
		public DXGISwapChainFlag Flags;

		/// <summary>
		/// <see cref="DXGISwapChainDesc"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="bufferDesc"> 버퍼의 모드 정보를 전달합니다. </param>
		/// <param name="bufferUsage"> 버퍼의 사용 방식을 전달합니다. </param>
		/// <param name="bufferCount"> 버퍼의 개수를 전달합니다. </param>
		/// <param name="outputWindow"> 출력 대상 창의 핸들을 전달합니다. </param>
		/// <param name="swapEffect"> 스왑 체인의 스왑 효과를 전달합니다. </param>
		public DXGISwapChainDesc( DXGIModeDesc bufferDesc, DXGIUsage bufferUsage, uint bufferCount, IPlatformHandle outputWindow, DXGISwapEffect swapEffect )
		{
			this.BufferDesc = bufferDesc;
			this.SampleDesc = DXGISampleDesc.One;
			this.BufferUsage = bufferUsage;
			this.BufferCount = bufferCount;
			this.OutputWindow = outputWindow;
			this.Windowed = true;
			this.SwapEffect = swapEffect;
			this.Flags = DXGISwapChainFlag.None;
		}

		/// <summary>
		/// 구조체의 간단한 텍스트 형식을 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public override string ToString()
		{
			return string.Format( "{0}: {{{1}}}, {{{2}}}, BufferCount = {3}, SwapEffect = {4}", base.ToString(), BufferDesc, SampleDesc, BufferCount, SwapEffect );
		}
	}
}
