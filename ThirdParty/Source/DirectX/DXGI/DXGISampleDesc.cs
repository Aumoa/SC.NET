// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI 샘플링 정보를 서술합니다.
    /// </summary>
    public struct DXGISampleDesc
	{
		/// <summary>
		/// 샘플 횟수를 표현합니다.
		/// </summary>
		public uint Count;

		/// <summary>
		/// 샘플 품질을 표현합니다.
		/// </summary>
		public uint Quality;

		/// <summary>
		/// <see cref="DXGISampleDesc"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="count"> 샘플 횟수를 전달합니다. </param>
		/// <param name="quality"> 샘플 품질을 전달합니다. </param>
		public DXGISampleDesc( uint count, uint quality )
		{
			this.Count = count;
			this.Quality = quality;
		}

		/// <summary>
		/// 구조체의 간단한 텍스트 형식을 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public override string ToString()
		{
			return string.Format( "{0}: SampleCount = {1}, Quality = {2}", base.ToString(), Count, Quality );
		}

		/// <summary>
		/// 단일 샘플을 수행하는 서술 구조체를 가져옵니다.
		/// </summary>
		public static DXGISampleDesc One
		{
			get => new DXGISampleDesc( 1, 0 );
		}
	}
}
