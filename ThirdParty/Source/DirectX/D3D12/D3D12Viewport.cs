// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 뷰포트 정보를 나타냅니다.
    /// </summary>
    public struct D3D12Viewport
	{
		/// <summary>
		/// 왼쪽 시작 위치를 표현합니다.
		/// </summary>
		public float TopLeftX;

		/// <summary>
		/// 위쪽 시작 위치를 표현합니다.
		/// </summary>
		public float TopLeftY;

		/// <summary>
		/// 뷰포트의 넓이를 표현합니다.
		/// </summary>
		public float Width;

		/// <summary>
		/// 뷰포트의 높이를 표현합니다.
		/// </summary>
		public float Height;

		/// <summary>
		/// 최소 깊이를 표현합니다.
		/// </summary>
		public float MinDepth;

		/// <summary>
		/// 최대 깊이를 표현합니다.
		/// </summary>
		public float MaxDepth;

		/// <summary>
		/// <see cref="D3D12Viewport"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="left"> 왼쪽 위치를 전달합니다. </param>
		/// <param name="top"> 위쪽 위치를 전달합니다. </param>
		/// <param name="right"> 오른쪽 위치를 전달합니다. </param>
		/// <param name="bottom"> 아래쪽 위치를 전달합니다. </param>
		public D3D12Viewport( float left, float top, float right, float bottom )
		{
			this.TopLeftX = left;
			this.TopLeftY = top;
			this.Width = right - left;
			this.Height = bottom - top;
			this.MinDepth = 0.0f;
			this.MaxDepth = 1.0f;
		}

		/// <summary>
		/// <see cref="D3D12Viewport"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="width"> 넓이를 전달합니다. </param>
		/// <param name="height"> 높이를 전달합니다. </param>
		public D3D12Viewport( float width, float height )
		{
			this.TopLeftX = 0;
			this.TopLeftY = 0;
			this.Width = width;
			this.Height = height;
			this.MinDepth = 0.0f;
			this.MaxDepth = 1.0f;
		}

		/// <summary>
		/// 구조체의 간단한 텍스트 형식을 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public override string ToString()
		{
			return string.Format( "{0}: TopLeft = {{{1}, {2}}}, Width = {3}, Height = {4}", base.ToString(), TopLeftX, TopLeftY, Width, Height );
		}
	}
}
