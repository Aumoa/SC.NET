// Copyright 2020 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DWrite Represents a block of text after it has been fully analyzed and formatted.
    /// </summary>
    public interface IDWriteTextLayout : IDWriteTextFormat
	{
		/// <summary>
		/// Set layout maximum width.
		/// </summary>
		/// <param name="maxWidth"> Layout maximum width. </param>
		void SetMaxWidth( float maxWidth );

		/// <summary>
		/// Set layout maximum height.
		/// </summary>
		/// <param name="maxHeight"> Layout maximum height. </param>
		void SetMaxHeight( float maxHeight );

		/// <summary>
		/// Set the font collection.
		/// </summary>
		/// <param name="fontCollection"> The font collection to set. </param>
		/// <param name="textRange"> Text range to which this change applies. </param>
		void SetFontCollection( IDWriteFontCollection fontCollection, DWriteTextRange textRange );

		/// <summary>
		/// Set null-terminated font family name.
		/// </summary>
		/// <param name="fontFamilyName"> Font family name. </param>
		/// <param name="textRange"> Text range to which this change applies. </param>
		void SetFontFamilyName( string fontFamilyName, DWriteTextRange textRange );

		/// <summary>
		/// Set font weight.
		/// </summary>
		/// <param name="fontWeight"> Font weight. </param>
		/// <param name="textRange"> Text range to which this change applies. </param>
		void SetFontWeight( DWriteFontWeight fontWeight, DWriteTextRange textRange );

		/// <summary>
		/// Set font style.
		/// </summary>
		/// <param name="fontStyle"> Font style. </param>
		/// <param name="textRange"> Text range to which this change applies. </param>
		void SetFontStyle( DWriteFontStyle fontStyle, DWriteTextRange textRange );

		/// <summary>
		/// Set font stretch.
		/// </summary>
		/// <param name="fontStretch"> Font stretch. </param>
		/// <param name="textRange"> Text range to which this change applies. </param>
		void SetFontStretch( DWriteFontStretch fontStretch, DWriteTextRange textRange );

		/// <summary>
		/// Set font em height.
		/// </summary>
		/// <param name="fontSize"> Font em height. </param>
		/// <param name="textRange"> Text range to which this change applies. </param>
		void SetFontSize( float fontSize, DWriteTextRange textRange );

		/// <summary>
		/// Set underline.
		/// </summary>
		/// <param name="hasUnderline"> The Boolean flag indicates whether underline takes place. </param>
		/// <param name="textRange"> Text range to which this change applies. </param>
		void SetUnderline( bool hasUnderline, DWriteTextRange textRange );

		/// <summary>
		/// Set strikethrough.
		/// </summary>
		/// <param name="hasStrikethrough"> The Boolean flag indicates whether strikethrough takes place. </param>
		/// <param name="textRange"> Text range to which this change applies. </param>
		void SetStrikethrough( bool hasStrikethrough, DWriteTextRange textRange );

		/// <summary>
		/// Set application-defined drawing effect.
		/// </summary>
		/// <param name="drawingEffect"> Application-defined drawing effect. </param>
		/// <param name="textRange"> Text range to which this change applies. </param>
		void SetDrawingEffect( IUnknown drawingEffect, DWriteTextRange textRange );

		/// <summary>
		/// Set inline object.
		/// </summary>
		/// <param name="inlineObject"> Application-implemented inline object. </param>
		/// <param name="textRange"> Text range to which this change applies. </param>
		void SetInlineObject( IDWriteInlineObject inlineObject, DWriteTextRange textRange );

		/// <summary>
		/// Set font typography features.
		/// </summary>
		/// <param name="typography"> Font typography setting. </param>
		/// <param name="textRange"> Text range to which this change applies. </param>
		void SetTypography( IDWriteTypography typography, DWriteTextRange textRange );

		/// <summary>
		/// Set locale name.
		/// </summary>
		/// <param name="localeName"> Locale name. </param>
		/// <param name="textRange"> Text range to which this change applies. </param>
		void SetLocaleName( string localeName, DWriteTextRange textRange );

		/// <summary>
		/// Get layout maximum width.
		/// </summary>
		/// <returns> Return maximum width. </returns>
		float GetMaxWidth();

		/// <summary>
		/// Get layout maximum height.
		/// </summary>
		/// <returns> Return maximum height. </returns>
		float GetMaxHeight();

		/// <summary>
		/// Get the font collection where the current position is at.
		/// </summary>
		/// <param name="currentPosition"> The current text position. </param>
		/// <param name="textRange"> Text range to which this change applies. </param>
		/// <returns> Return font collection on current position. </returns>
		IDWriteFontCollection GetFontCollection( uint currentPosition, out DWriteTextRange textRange );

		/// <summary>
		/// Copy the font family name where the current position is at.
		/// </summary>
		/// <param name="currentPosition"> The current text position. </param>
		/// <param name="textRange"> Text range to which this change applies. </param>
		/// <returns> Return font family name on current position. </returns>
		string GetFontFamilyName( uint currentPosition, out DWriteTextRange textRange );

		/// <summary>
		/// Get the font weight where the current position is at.
		/// </summary>
		/// <param name="currentPosition"> The current text position. </param>
		/// <param name="textRange"> Text range to which this change applies. </param>
		/// <returns> Return font weight on current position. </returns>
		DWriteFontWeight GetFontWeight( uint currentPosition, out DWriteTextRange textRange );

		/// <summary>
		/// Get the font style where the current position is at.
		/// </summary>
		/// <param name="currentPosition"> The current text position. </param>
		/// <param name="textRange"> Text range to which this change applies. </param>
		/// <returns> Return font style on current position. </returns>
		DWriteFontStyle GetFontStyle( uint currentPosition, out DWriteTextRange textRange );

		/// <summary>
		/// Get the font style where the current position is at.
		/// </summary>
		/// <param name="currentPosition"> The current text position. </param>
		/// <param name="textRange"> Text range to which this change applies. </param>
		/// <returns> Return font stretch on current position. </returns>
		DWriteFontStretch GetFontStretch( uint currentPosition, out DWriteTextRange textRange );

		/// <summary>
		/// Get the font em height where the current position is at.
		/// </summary>
		/// <param name="currentPosition"> The current text position. </param>
		/// <param name="textRange"> Text range to which this change applies. </param>
		/// <returns> Return font em height on current position. </returns>
		float GetFontSize( uint currentPosition, out DWriteTextRange textRange );

		/// <summary>
		/// Get the underline presence where the current position is at.
		/// </summary>
		/// <param name="currentPosition"> The current text position. </param>
		/// <param name="textRange"> Text range to which this change applies. </param>
		/// <returns> Return boolean flag indicates whether text is undelined on current position. </returns>
		bool GetUnderline( uint currentPosition, out DWriteTextRange textRange );

		/// <summary>
		/// Get the strikethrough presence where the current position is at.
		/// </summary>
		/// <param name="currentPosition"> The current text position. </param>
		/// <param name="textRange"> Text range to which this change applies. </param>
		/// <returns> Return boolean flag indicates whether text is strikethrough on current position. </returns>
		bool GetStrikethrough( uint currentPosition, out DWriteTextRange textRange );

		/// <summary>
		/// Get the application-defined drawing effect where the current position is at.
		/// </summary>
		/// <param name="currentPosition"> The current text position. </param>
		/// <param name="textRange"> Text range to which this change applies. </param>
		/// <returns> Return drawing effect on current position. </returns>
		IUnknown GetDrawingEffect( uint currentPosition, out DWriteTextRange textRange );

		/// <summary>
		/// Get the inline object at the given position.
		/// </summary>
		/// <param name="currentPosition"> The current text position. </param>
		/// <param name="textRange"> Text range to which this change applies. </param>
		/// <returns> Return inline object on current position. </returns>
		IDWriteInlineObject GetInlineObject( uint currentPosition, out DWriteTextRange textRange );

		/// <summary>
		/// Get the typography setting where the current position is at.
		/// </summary>
		/// <param name="currentPosition"> The current text position. </param>
		/// <param name="textRange"> Text range to which this change applies. </param>
		/// <returns> Return typography on current position. </returns>
		IDWriteTypography GetTypography( uint currentPosition, out DWriteTextRange textRange );

		/// <summary>
		/// Get the locale name where the current position is at.
		/// </summary>
		/// <param name="currentPosition"> The current text position. </param>
		/// <param name="textRange"> Text range to which this change applies. </param>
		/// <returns> Return locale name on current position. </returns>
		string GetLocaleName( uint currentPosition, out DWriteTextRange textRange );

		/// <summary>
		/// Initiate drawing of the text.
		/// </summary>
		/// <param name="clientDrawingContext"> An application defined value included in rendering callbacks. </param>
		/// <param name="renderer"> The set of application-defined callbacks that do the actual rendering. </param>
		/// <param name="originX"> X-coordinate of the layout's left side. </param>
		/// <param name="originY"> Y-coordinate of the layout's top side. </param>
		void Draw( object clientDrawingContext, IDWriteTextRenderer renderer, float originX, float originY );

		/// <summary>
		/// GetLineMetrics returns properties of each line.
		/// </summary>
		/// <returns> Return the array to fill with line information. </returns>
		DWriteLineMetrics[] GetLineMetrics();

		/// <summary>
		/// GetMetrics retrieves overall metrics for the formatted string.
		/// </summary>
		/// <returns> Return metrics. </returns>
		DWriteTextMetrics GetMetrics();

		/// <summary>
		/// GetOverhangMetrics returns the overhangs (in DIPs) of the layout and all objects contained in it, including text glyphs and inline objects.
		/// </summary>
		/// <returns> Return overshoots of visible extents (in DIPs) outside the layout. </returns>
		DWriteOverhangMetrics GetOverhangMetrics();

		/// <summary>
		/// Retrieve logical properties and measurement of each cluster.
		/// </summary>
		/// <returns> Return array to fill with cluster information. </returns>
		DWriteClusterMetrics[] GetClusterMetrics();

		/// <summary>
		/// Determines the minimum possible width the layout can be set to without emergency breaking between the characters of whole words.
		/// </summary>
		/// <returns> Return minimum width. </returns>
		float DetermineMinWidth();

		/// <summary>
		/// <para> Given a coordinate (in DIPs) relative to the top-left of the layout box, this returns the corresponding hit-test metrics of the text string where the hit-test has occurred. </para>
		/// <para> This is useful for mapping mouse clicks to caret positions. </para>
		/// <para> When the given coordinate is outside the text string, the function sets the output value <c>out isInside</c> to false but returns the nearest character position. </para>
		/// </summary>
		/// <param name="point"> Coordinate to hit-test, relative to the top-left location of the layout box. </param>
		/// <param name="isTrailingHit"> Output flag indicating whether the hit-test location is at the leading or the trailing side of the character. When the output <c>out isInside</c> value is set to false, this value is set according to the output position value to represent the edge closest to the hit-test location. </param>
		/// <param name="isInside"> Output flag indicating whether the hit-test location is inside the text string. When false, the position nearest the text's edge is returned. </param>
		/// <returns> Return geometry fully enclosing the hit-test location. When the output <c>out isInside</c> value is set to false, this structure represents the geometry enclosing the edge closest to the hit-test location. </returns>
		DWriteHitTestMetrics HitTestPoint( Vector2 point, out bool isTrailingHit, out bool isInside );

		/// <summary>
		/// <para>Given a text position and whether the caret is on the leading or trailing edge of that position, this returns the corresponding coordinate (in DIPs) relative to the top-left of the layout box. </para>
		/// <para> This is most useful for drawing the caret's current position, but it could also be used to anchor an IME to the typed text or attach a floating menu near the point of interest. </para>
		/// <para> It may also be used to programmatically obtain the geometry of a particular text position for UI automation. </para>
		/// </summary>
		/// <param name="textPosition"> Text position to get the coordinate of. </param>
		/// <param name="isTrailingHit"> Flag indicating whether the location is of the leading or the trailing side of the specified text position. </param>
		/// <param name="point"> Output caret position, relative to the top-left of the layout box. </param>
		/// <returns> Return geometry fully enclosing the specified text position. </returns>
		DWriteHitTestMetrics HitTestTextPosition( uint textPosition, bool isTrailingHit, out Vector2 point );

		/// <summary>
		/// The application calls this function to get a set of hit-test metrics corresponding to a range of text positions. The main usage for this is to draw highlighted selection of the text string.
		/// </summary>
		/// <param name="textPosition"> First text position of the specified range. </param>
		/// <param name="textLength"> Number of positions of the specified range. </param>
		/// <param name="origin"> Point of origin (left of the layout box) which is added to each of the hit-test metrics returned. </param>
		/// <returns> Return array to a buffer of the output geometry fully enclosing the specified position range. </returns>
		DWriteHitTestMetrics[] HitTestTextRange( uint textPosition, uint textLength, Vector2 origin );
	}
}
