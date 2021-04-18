// Copyright 2020 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI RGB 값을 간단하게 표현합니다.
    /// </summary>
    public struct DXGIRGB
	{
		/// <summary>
		/// 빨간색 값을 표현합니다.
		/// </summary>
		public float R;

		/// <summary>
		/// 초록색 값을 표현합니다.
		/// </summary>
		public float G;

		/// <summary>
		/// 파란색 값을 표현합니다.
		/// </summary>
		public float B;

		/// <summary>
		/// <see cref="DXGIRGB"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="r"> 빨간색 값을 전달합니다. </param>
		/// <param name="g"> 초록색 값을 전달합니다. </param>
		/// <param name="b"> 파란색 값을 전달합니다. </param>
		public DXGIRGB( float r, float g, float b )
		{
			this.R = r;
			this.G = g;
			this.B = b;
		}

		/// <summary>
		/// 구조체의 간단한 텍스트 형식을 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public override string ToString()
		{
			return string.Format( "{0}: R = {1}, G = {2}, B = {3}", base.ToString(), R, G, B );
		}

		/// <summary>
		/// <see cref="Color"/> 구조체로부터 색상 정보를 가져옵니다.
		/// </summary>
		/// <param name="color"> 색상을 전달합니다. </param>
		/// <returns> 변환된 색상 개체가 반환됩니다. </returns>
		public static DXGIRGB FromColor( Color color )
		{
			return new DXGIRGB( (float)color.R, (float)color.G, (float)color.B );
		}
	}
}
