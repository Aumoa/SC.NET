// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DWrite Specifies a range of text positions where format is applied.
    /// </summary>
    public struct DWriteTextRange
	{
		/// <summary>
		/// The start text position of the range.
		/// </summary>
		public uint StartPosition;

		/// <summary>
		/// The number of text positions in the range.
		/// </summary>
		public uint Length;

		/// <summary>
		/// Gets or sets the end text position of the range.
		/// </summary>
		public uint EndPosition
		{
			get => StartPosition + Length;
			set => Length = value - StartPosition;
		}

		/// <summary>
		/// 구조체의 간단한 텍스트 형식을 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public override string ToString()
			=> $"{base.ToString()}: [{StartPosition}, {EndPosition})";
	}
}
