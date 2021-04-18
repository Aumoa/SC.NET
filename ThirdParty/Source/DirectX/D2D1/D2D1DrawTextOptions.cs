// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D2D1 텍스트 렌더링 옵션을 표현합니다.
    /// </summary>
    public enum D2D1DrawTextOptions
	{
		/// <summary>
		/// 아무 옵션도 지정하지 않습니다.
		/// </summary>
		None,

		/// <summary>
		/// Do not snap the baseline of the text vertically.
		/// </summary>
		NoSnap = 0x1,

		/// <summary>
		/// Clip the text to the content bounds.
		/// </summary>
		Clip = 0x2,

		/// <summary>
		/// Render color versions of glyphs if defined by the font.
		/// </summary>
		EnableColorFont = 0x4,

		/// <summary>
		/// Bitmap origins of color glyph bitmaps are not snapped.
		/// </summary>
		DisableColorBitmapSnapping = 0x8,
	}
}
