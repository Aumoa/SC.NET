// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// <see cref="D3D12ShaderComponentMapping"/> 열거형의 확장 메서드를 제공합니다.
    /// </summary>
    public static class D3D12ShaderComponentMappingExtensions
	{
		const int Mask = 0x7;
		const int Shift = 3;
		const int AlwaysSetBitAvoidingZeroMemMistakes = 1 << ( Shift * 4 );

		/// <summary>
		/// 셰이더 매핑 방식을 인코드합니다.
		/// </summary>
		/// <param name="this"> 열거형을 전달합니다. </param>
		/// <param name="src0"> 0번 컴포넌트 소스를 전달합니다. </param>
		/// <param name="src1"> 1번 컴포넌트 소스를 전달합니다. </param>
		/// <param name="src2"> 2번 컴포넌트 소스를 전달합니다. </param>
		/// <param name="src3"> 3번 컴포넌트 소스를 전달합니다. </param>
		public static D3D12ShaderComponentMapping Encode( this D3D12ShaderComponentMapping @this, D3D12ShaderComponentMapping src0, D3D12ShaderComponentMapping src1, D3D12ShaderComponentMapping src2, D3D12ShaderComponentMapping src3 )
			=> ( D3D12ShaderComponentMapping )
				( ( ( int )src0 & Mask ) |
				( ( ( int )src1 & Mask ) << Shift ) |
				( ( ( int )src2 & Mask ) << Shift * 2 ) |
				( ( ( int )src3 & Mask ) << Shift * 3 ) |
				AlwaysSetBitAvoidingZeroMemMistakes
				);

		/// <summary>
		/// 셰이더 매핑 방식을 디코드합니다.
		/// </summary>
		/// <param name="this"> 열거형을 전달합니다. </param>
		/// <param name="componentToExtract"> 추출할 값을 전달합니다. </param>
		/// <param name="mapping"> 매핑 방식을 전달합니다. </param>
		public static D3D12ShaderComponentMapping Decode( this D3D12ShaderComponentMapping @this, D3D12ShaderComponentMapping componentToExtract, D3D12ShaderComponentMapping mapping )
			=> ( D3D12ShaderComponentMapping )
				( ( ( int )mapping >> ( Shift * ( int )componentToExtract ) ) & ( int )Mask );

		/// <summary>
		/// 기본 셰이더 매핑 값을 가져옵니다.
		/// </summary>
		/// <returns> 값이 반환됩니다. </returns>
		public static D3D12ShaderComponentMapping Default()
			=> D3D12ShaderComponentMapping.None.Encode(
				D3D12ShaderComponentMapping.FromMemoryComponent0,
				D3D12ShaderComponentMapping.FromMemoryComponent1,
				D3D12ShaderComponentMapping.FromMemoryComponent2,
				D3D12ShaderComponentMapping.FromMemoryComponent3
				);
	}
}
