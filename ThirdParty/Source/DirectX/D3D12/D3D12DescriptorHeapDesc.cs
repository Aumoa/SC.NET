// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 서술자 힙에 대한 정보를 서술합니다.
    /// </summary>
    public struct D3D12DescriptorHeapDesc
	{
		/// <summary>
		/// 서술자 힙 유형을 나타냅니다.
		/// </summary>
		public D3D12DescriptorHeapType Type;

		/// <summary>
		/// 서술자 개수를 나타냅니다.
		/// </summary>
		public uint NumDescriptors;

		/// <summary>
		/// 서술자 힙 속성을 나타냅니다.
		/// </summary>
		public D3D12DescriptorHeapFlags Flags;

		/// <summary>
		/// 힙의 노드 마스크를 나타냅니다.
		/// </summary>
		public uint NodeMask;

		/// <summary>
		/// <see cref="D3D12DescriptorHeapDesc"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="type"> 힙 유형을 전달합니다. </param>
		/// <param name="numDescriptors"> 개수를 전달합니다. </param>
		/// <param name="isShaderVisible"> 힙의 셰이더 관측 가능성을 전달합니다. </param>
		public D3D12DescriptorHeapDesc( D3D12DescriptorHeapType type, uint numDescriptors, bool isShaderVisible )
		{
			this.Type = type;
			this.NumDescriptors = numDescriptors;
			this.Flags = isShaderVisible ? D3D12DescriptorHeapFlags.ShaderVisible : D3D12DescriptorHeapFlags.None;
			this.NodeMask = 0;
		}

		/// <summary>
		/// 구조체의 간단한 텍스트 형식을 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public override string ToString()
		{
			return string.Format( "{0}: Type = {1}, NumDescriptors = {2}, Flags = {3}", base.ToString(), Type, NumDescriptors, Flags );
		}
	}
}
