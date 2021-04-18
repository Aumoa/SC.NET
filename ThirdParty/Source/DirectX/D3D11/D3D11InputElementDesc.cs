// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D11 입력 원소에 대한 저옵를 서술합니다.
    /// </summary>
    public struct D3D11InputElementDesc
	{
		/// <summary>
		/// 의미소 이름을 나타냅니다.
		/// </summary>
		public string SemanticName;

		/// <summary>
		/// 의미소 인덱스를 나타냅니다.
		/// </summary>
		public uint SemanticIndex;

		/// <summary>
		/// 원소의 형식을 나타냅니다.
		/// </summary>
		public DXGIFormat Format;

		/// <summary>
		/// 입력 슬롯을 나타냅니다.
		/// </summary>
		public uint InputSlot;

		/// <summary>
		/// 정렬된 바이트 오프셋을 나타냅니다.
		/// </summary>
		public uint AlignedByteOffset;

		/// <summary>
		/// 입력 슬롯 분류를 나타냅니다.
		/// </summary>
		public D3D11InputClassification InputSlotClass;

		/// <summary>
		/// 
		/// </summary>
		public uint InstanceDataStepRate;

		/// <summary>
		/// <see cref="D3D11InputElementDesc"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="name"> 의미소 이름을 전달합니다. </param>
		/// <param name="format"> 의미소 형식을 전달합니다. </param>
		/// <param name="offset"> 의미소가 이전 의미소에서 얼마만큼 이동하는지 나타내는 값을 전달합니다. </param>
		public D3D11InputElementDesc( string name, DXGIFormat format, uint offset )
		{
			this.SemanticName = name;
			this.SemanticIndex = 0;
			this.Format = format;
			this.InputSlot = 0;
			this.AlignedByteOffset = offset;
			this.InputSlotClass = D3D11InputClassification.PerVertexData;
			this.InstanceDataStepRate = 0;
		}
	}
}
