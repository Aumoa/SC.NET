// Copyright 2020 Aumoa.lib. All right reserved.

using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 4개의 부호 없는 정수형을 나타냅니다.
    /// </summary>
    [StructLayout( LayoutKind.Explicit )]
	public struct D3D12UInt4
	{
		/// <summary>
		/// 첫 번째 값을 나타냅니다.
		/// </summary>
		[FieldOffset( 0 )]
		public uint X;

		/// <summary>
		/// 두 번째 값을 나타냅니다.
		/// </summary>
		[FieldOffset( 4 )]
		public uint Y;

		/// <summary>
		/// 세 번째 값을 나타냅니다.
		/// </summary>
		[FieldOffset( 8 )]
		public uint Z;

		/// <summary>
		/// 네 번째 값을 나타냅니다.
		/// </summary>
		[FieldOffset( 12 )]
		public uint W;

		/// <summary>
		/// <see cref="D3D12UInt4"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="x"> 첫 번째 값을 전달합니다. </param>
		/// <param name="y"> 두 번째 값을 전달합니다. </param>
		/// <param name="z"> 세 번째 값을 전달합니다. </param>
		/// <param name="w"> 네 번째 값을 전달합니다. </param>
		public D3D12UInt4( uint x, uint y, uint z, uint w )
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
			this.W = w;
		}
	}
}
