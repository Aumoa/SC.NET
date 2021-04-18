// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 타일 리소스의 위치를 표현합니다.
    /// </summary>
    public struct D3D12TiledResourceCoordinate
	{
		/// <summary>
		/// 자원의 X축 시작 위치를 나타냅니다.
		/// </summary>
		public uint X;

		/// <summary>
		/// 자원의 Y축 시작 위치를 나타냅니다.
		/// </summary>
		public uint Y;

		/// <summary>
		/// 자원의 Z축 시작 위치를 나타냅니다.
		/// </summary>
		public uint Z;

		/// <summary>
		/// 자원의 서브리소스 인덱스를 나타냅니다.
		/// </summary>
		public uint Subresource;

		/// <summary>
		/// <see cref="D3D12TiledResourceCoordinate"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="x"> X축 시작 위치를 전달합니다. </param>
		/// <param name="y"> Y축 시작 위치를 전달합니다. </param>
		/// <param name="z"> Z축 시작 위치를 전달합니다. </param>
		/// <param name="subresource"> 서브리소스 인덱스를 전달합니다. </param>
		public D3D12TiledResourceCoordinate( uint x, uint y, uint z = 0, uint subresource = 0 )
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
			this.Subresource = subresource;
		}

		/// <summary>
		/// 구조체의 간단한 텍스트 형식을 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public override string ToString()
		{
			return string.Format( "{0}: (X: {1}, Y:{2}, Z: {3}), Subresource = {4}", base.ToString(), X, Y, Z, Subresource );
		}
	}
}
