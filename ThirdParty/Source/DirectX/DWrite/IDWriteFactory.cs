// Copyright 2020 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DWrite 자원을 관리하는 팩토리 개체에 대한 공통 메서드를 제공합니다.
    /// </summary>
    [Guid( "b859ee5a-d838-4b5b-a2e8-1adc7d93db48" )]
	[ComVisible( true )]
	public interface IDWriteFactory : IUnknown
	{
		/// <summary>
		/// Create a text format object used for text layout.
		/// </summary>
		/// <param name="fontFamilyName"> Name of the font family. </param>
		/// <param name="fontCollection"> Font collection. <c>null</c> indicates the system font collection. </param>
		/// <param name="fontWeight"> Font weight. </param>
		/// <param name="fontStyle"> Font style. </param>
		/// <param name="fontStretch"> Font stretch. </param>
		/// <param name="fontSize"> Logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch. </param>
		/// <param name="localeName"> Locale name. </param>
		/// <returns> Return created text format object, or <c>null</c> in case of failure. </returns>
		IDWriteTextFormat CreateTextFormat(
			string fontFamilyName,
			IDWriteFontCollection fontCollection,
			DWriteFontWeight fontWeight,
			DWriteFontStyle fontStyle,
			DWriteFontStretch fontStretch,
			float fontSize,
			string localeName
			);

		/// <summary>
		/// CreateTextLayout takes a string, format, and associated constraints and produces an object representing the fully analyzed and formatted result.
		/// </summary>
		/// <param name="string"> The string to layout. </param>
		/// <param name="textFormat"> The format to apply to the string. </param>
		/// <param name="maxSize"> Size of the layout box. </param>
		/// <returns> Return the resultant object. </returns>
		IDWriteTextLayout CreateTextLayout(
			string @string,
			IDWriteTextFormat textFormat,
			Vector2 maxSize
			);
	}
}
