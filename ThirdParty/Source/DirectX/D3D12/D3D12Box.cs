// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 직육면체 형식의 텍스처 크기를 표현합니다.
    /// </summary>
    public struct D3D12Box
	{
		/// <summary>
		/// 자원의 X축 위치의 시작 지점을 표현합니다.
		/// </summary>
		public uint Left;

		/// <summary>
		/// 자원의 Y축 위치의 시작 지점을 표현합니다.
		/// </summary>
		public uint Top;

		/// <summary>
		/// 자원의 Z축 위치의 시작 지점을 표현합니다.
		/// </summary>
		public uint Front;

		/// <summary>
		/// 자원의 X축 위치의 종료 지점을 표현합니다.
		/// </summary>
		public uint Right;

		/// <summary>
		/// 자원의 Y축 위치의 종료 지점을 표현합니다.
		/// </summary>
		public uint Bottom;

		/// <summary>
		/// 자원의 Z축 위치의 종료 지점을 표현합니다.
		/// </summary>
		public uint Back;

		/// <summary>
		/// <see cref="D3D12Box"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="left"> 자원의 X축 위치의 시작 지점을 전달합니다. </param>
		/// <param name="top"> 자원의 Y축 위치의 시작 지점을 전달합니다. </param>
		/// <param name="right"> 자원의 X축 위치의 종료 지점을 전달합니다. </param>
		/// <param name="bottom"> 자원의 Y축 위치의 종료 지점을 전달합니다. </param>
		public D3D12Box( uint left, uint top, uint right, uint bottom )
		{
			this.Left = left;
			this.Top = top;
			this.Front = 0;
			this.Right = right;
			this.Bottom = bottom;
			this.Back = 1;
		}

		/// <summary>
		/// 구조체의 간단한 텍스트 형식을 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public override string ToString()
			=> $"{base.ToString()}: [{{{Left}, {Top}, {Front}}}, {{{Right}, {Bottom}, {Back}}}";
	}
}
