// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{

    /// <summary>
    /// DWrite 텍스트 배치 정보에 대한 서식을 표현합니다.
    /// </summary>
    [Guid( "9c906818-31d7-4fd3-a151-7c5e225db55a" )]
	[ComVisible( true )]
	public interface IDWriteTextFormat : IUnknown
	{
		/// <summary>
		/// 텍스트 정렬 방식을 설정합니다.
		/// </summary>
		/// <param name="textAlignment"> 정렬 방식을 전달합니다. </param>
		void SetTextAlignment( DWriteTextAlignment textAlignment );

		/// <summary>
		/// 텍스트 절 정렬 방식을 설정합니다.
		/// </summary>
		/// <param name="paragraphAlignment"> 절 정렬 방식을 전달합니다. </param>
		void SetParagraphAlignment( DWriteParagraphAlignment paragraphAlignment );

		/// <summary>
		/// 단어 래핑 방식을 설정합니다.
		/// </summary>
		/// <param name="wordWrapping"> 방식을 전달합니다. </param>
		void SetWordWrapping( DWriteWordWrapping wordWrapping );

		/// <summary>
		/// 읽기 방향을 설정합니다.
		/// </summary>
		/// <param name="readingDirection"> 읽기 방향을 전달합니다. </param>
		void SetReadingDirection( DWriteReadingDirection readingDirection );

		/// <summary>
		/// 증분 탭 정지 위치를 설정합니다.
		/// </summary>
		/// <param name="incrementalTabStop"> 값을 전달합니다. </param>
		void SetIncrementalTabStop( float incrementalTabStop );

		/// <summary>
		/// Set trimming options for any trailing text exceeding the layout width or for any far text exceeding the layout height.
		/// </summary>
		/// <param name="trimmingOptions"> Text trimming options. </param>
		/// <param name="trimmingSign"> Application-defined omission sign. This parameter may be <c>null</c> if no trimming sign is desired. </param>
		void SetTrimming( DWriteTrimming trimmingOptions, IDWriteInlineObject trimmingSign );

		/// <summary>
		/// Set line spacing.
		/// </summary>
		/// <param name="lineSpacingMethod"> How to determine line height. </param>
		/// <param name="lineSpacing"> The line height, or rather distance between one baseline to another. </param>
		/// <param name="baseline"> Distance from top of line to baseline. A reasonable ratio to lineSpacing is 80%. </param>
		void SetLineSpacing( DWriteLineSpacingMethod lineSpacingMethod, float lineSpacing, float baseline );

		/// <summary>
		/// Get alignment option of text relative to layout box's leading and trailing edge.
		/// </summary>
		/// <returns> Return text alignment. </returns>
		DWriteTextAlignment GetTextAlignment();

		/// <summary>
		/// Get alignment option of paragraph relative to layout box's top and bottom edge.
		/// </summary>
		/// <returns> Return paragraph alignment. </returns>
		DWriteParagraphAlignment GetParagraphAlignment();

		/// <summary>
		/// Get word wrapping option.
		/// </summary>
		/// <returns> Return word wrapping. </returns>
		DWriteWordWrapping GetWordWrapping();

		/// <summary>
		/// Get paragraph reading direction.
		/// </summary>
		/// <returns> Return reading direction. </returns>
		DWriteReadingDirection GetReadingDirection();

		/// <summary>
		/// Get paragraph flow direction.
		/// </summary>
		/// <returns> Return flow direction. </returns>
		DWriteFlowDirection GetFlowDirection();

		/// <summary>
		/// Get incremental tab stop position.
		/// </summary>
		/// <returns> Return tab stop value. </returns>
		float GetIncrementalTabStop();

		/// <summary>
		/// Get trimming options for text overflowing the layout width.
		/// </summary>
		/// <param name="trimmingOptions"> Text trimming options. </param>
		/// <param name="trimmingSign"> Trimming omission sign. This parameter may be <c>null</c>. </param>
		void GetTrimming( out DWriteTrimming trimmingOptions, out IDWriteInlineObject trimmingSign );

		/// <summary>
		/// Get line spacing.
		/// </summary>
		/// <param name="lineSpacingMethod"> How line height is determined. </param>
		/// <param name="lineSpacing"> The line height, or rather distance between one baseline to another. </param>
		/// <param name="baseline"> Distance from top of line to baseline. </param>
		void GetLineSpacing( out DWriteLineSpacingMethod lineSpacingMethod, out float lineSpacing, out float baseline );

		/// <summary>
		/// Get the font collection.
		/// </summary>
		/// <returns> Return current font collection. </returns>
		IDWriteFontCollection GetFontCollection();

		/// <summary>
		/// Get a copy of the font family name.
		/// </summary>
		/// <returns> Return string that receives the current font family name. </returns>
		string GetFontFamilyName();

		/// <summary>
		/// Get the font weight.
		/// </summary>
		/// <returns> Return font weight. </returns>
		DWriteFontWeight GetFontWeight();

		/// <summary>
		/// Get the font style.
		/// </summary>
		/// <returns> Return font style. </returns>
		DWriteFontStyle GetFontStyle();

		/// <summary>
		/// Get the font stretch.
		/// </summary>
		/// <returns> Return font stretch. </returns>
		DWriteFontStretch GetFontStretch();

		/// <summary>
		/// Get the font em height.
		/// </summary>
		/// <returns> Return font em height. </returns>
		float GetFontSize();

		/// <summary>
		/// Get a copy of the locale name.
		/// </summary>
		/// <returns> Return locale name. </returns>
		string GetLocaleName();
	}
}
