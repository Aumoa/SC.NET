// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 타일 영역 크기를 표현합니다.
    /// </summary>
    public struct D3D12TileRegionSize
	{
		/// <summary>
		/// 타일 개수를 나타냅니다.
		/// </summary>
		public uint NumTiles;

		/// <summary>
		/// 박스 형태의 기하를 사용합니다.
		/// </summary>
		public bool UseBox;

		/// <summary>
		/// 타일의 넓이를 표현합니다.
		/// </summary>
		public uint Width;

		/// <summary>
		/// 타일의 높이를 표현합니다.
		/// </summary>
		public ushort Height;

		/// <summary>
		/// 타일의 깊이를 표현합니다.
		/// </summary>
		public ushort Depth;

		/// <summary>
		/// <see cref="D3D12TileRegionSize"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="numTiles"> 타일 개수를 전달합니다. </param>
		/// <param name="useBox"> 박스 형태의 기하를 사용합니다. </param>
		/// <param name="width"> 타일의 넓이를 전달합니다. </param>
		/// <param name="height"> 타일의 높이를 전달합니다. </param>
		/// <param name="depth"> 타일의 깊이를 전달합니다. </param>
		public D3D12TileRegionSize( uint numTiles, bool useBox, uint width, ushort height, ushort depth )
		{
			this.NumTiles = numTiles;
			this.UseBox = useBox;
			this.Width = width;
			this.Height = height;
			this.Depth = depth;
		}

		/// <summary>
		/// 구조체의 간단한 텍스트 형식을 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public override string ToString()
		{
			return string.Format( "{0}: NumTiles = {1}, UseBox = {2}, Width = {3}, Height = {4}, Depth = {5}", base.ToString(), NumTiles, UseBox, Width, Height, Depth );
		}
	}
}
