// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DWrite 텍스트 레이아웃에 사용되는 측정 모드를 표현합니다.
    /// </summary>
    public enum DWriteMeasuringMode
	{
		/// <summary>
		/// Text is measured using glyph ideal metrics whose values are independent to the current display resolution.
		/// </summary>
		Natural,

		/// <summary>
		/// Text is measured using glyph display compatible metrics whose values tuned for the current display resolution.
		/// </summary>
		GDIClassic,

		/// <summary>
		/// Text is measured using the same glyph display metrics as text measured by GDI using a font created with CLEARTYPE_NATURAL_QUALITY.
		/// </summary>
		GDINatural
	}
}
