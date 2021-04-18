// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D11 자원에 대한 속성을 나타냅니다.
    /// </summary>
    public struct D3D11ResourceFlags
	{
		/// <summary>
		/// 리소스 바인딩 속성을 나타냅니다.
		/// </summary>
		public D3D11BindFlags BindFlags;

		/// <summary>
		/// 특수 속성을 나타냅니다.
		/// </summary>
		public D3D11ResourceMiscFlags MiscFlags;

		/// <summary>
		/// CPU 엑세스 속성을 나타냅니다.
		/// </summary>
		public D3D11CPUAccessFlags CPUAccessFlags;

		/// <summary>
		/// 구조체 바이트 보폭을 나타냅니다.
		/// </summary>
		public uint StructureByteStride;

		/// <summary>
		/// <see cref="D3D11ResourceFlags"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="bindFlags"> 바인딩 속성을 전달합니다. </param>
		public D3D11ResourceFlags( D3D11BindFlags bindFlags )
		{
			this.BindFlags = bindFlags;
			this.MiscFlags = D3D11ResourceMiscFlags.None;
			this.CPUAccessFlags = D3D11CPUAccessFlags.None;
			this.StructureByteStride = 0;
		}
	}
}
