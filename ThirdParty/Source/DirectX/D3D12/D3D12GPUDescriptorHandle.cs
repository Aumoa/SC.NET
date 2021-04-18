// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 CPU 서술자 핸들을 표현합니다.
    /// </summary>
    public struct D3D12GPUDescriptorHandle
	{
		/// <summary>
		/// 서술자 핸들의 위치를 나타냅니다.
		/// </summary>
		public ulong ptr;

		/// <summary>
		/// <see cref="D3D12GPUDescriptorHandle"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="ptr"> 핸들의 위치를 전달합니다. </param>
		public D3D12GPUDescriptorHandle( ulong ptr )
		{
			this.ptr = ptr;
		}

		/// <summary>
		/// 구조체의 간단한 텍스트 형식을 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public override string ToString()
		{
			return string.Format( "{0}: ptr = {1}", base.ToString(), ptr );
		}

		/// <summary>
		/// 서술자 핸들을 지정한 위치만큼 이동합니다.
		/// </summary>
		/// <param name="stride"> 핸들의 이동 크기를 전달합니다. </param>
		/// <param name="offset"> 이동할 위치를 전달합니다. </param>
		public void Offset( uint stride, int offset )
		{
			var delta = ( long )offset * ( long )stride;
			ptr = ( ulong )( ( long )this.ptr + delta );
		}
	}
}
