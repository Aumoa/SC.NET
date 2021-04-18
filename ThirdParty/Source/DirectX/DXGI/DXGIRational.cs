// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI 분모 및 분자로 표현되는 실수를 나타냅니다.
    /// </summary>
    public struct DXGIRational
	{
		/// <summary>
		/// 분자 값을 표현합니다.
		/// </summary>
		public int Numerator;

		/// <summary>
		/// 분모 값을 표현합니다.
		/// </summary>
		public int Denominator;

		/// <summary>
		/// <see cref="DXGIRational"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="numerator"> 분자 값을 전달합니다. </param>
		/// <param name="denominator"> 분모 값을 전달합니다. </param>
		public DXGIRational( int numerator, int denominator )
		{
			Numerator = numerator;
			Denominator = denominator;
		}

		/// <summary>
		/// <see cref="DXGIRational"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="value"> 계산된 실수 값을 전달합니다. </param>
		public DXGIRational( float value )
		{
			Numerator = ( int )( value * 100.0f );
			Denominator = 100;
		}

		/// <summary>
		/// 계산된 실수 값을 가져옵니다.
		/// </summary>
		public float Value
		{
			get => ( float )Numerator / Denominator;
		}

		/// <summary>
		/// 구조체의 간단한 텍스트 형식을 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public override string ToString()
		{
			return string.Format( "{0}: {1:D}Hz", base.ToString(), Value );
		}
	}
}
