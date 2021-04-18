// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Collections.Generic;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 기능 레벨을 점검합니다.
    /// </summary>
    public struct D3D12FeatureDataFeatureLevels
	{
		/// <summary>
		/// (입력 매개변수) 오름차순으로 정렬된 기능 레벨 목록을 나타냅니다. null일 경우, 전체 목록을 사용합니다.
		/// </summary>
		public IList<D3DFeatureLevel> pFeatureLevelsRequest;

		/// <summary>
		/// (출력 매개변수) 점검 결과, 지원 가능한 기능 레벨의 가장 높은 단계입니다.
		/// </summary>
		public D3DFeatureLevel MaxSupportedFeatureLevel;

		/// <summary>
		/// <see cref="D3D12FeatureDataFeatureLevels"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="minimumFeatureLevel"> 필요한 최소 기능 레벨을 전달합니다. </param>
		public D3D12FeatureDataFeatureLevels( D3DFeatureLevel minimumFeatureLevel )
		{
			var featureLevels = new D3DFeatureLevel[]
			{
				D3DFeatureLevel.Level9_1,
				D3DFeatureLevel.Level9_2,
				D3DFeatureLevel.Level9_3,
				D3DFeatureLevel.Level10_0,
				D3DFeatureLevel.Level10_1,
				D3DFeatureLevel.Level11_0,
				D3DFeatureLevel.Level11_1,
				D3DFeatureLevel.Level12_0,
				D3DFeatureLevel.Level12_1,
			};

			var index = minimumFeatureLevel switch
			{
				D3DFeatureLevel.Level9_1 => 0,
				D3DFeatureLevel.Level9_2 => 1,
				D3DFeatureLevel.Level9_3 => 2,
				D3DFeatureLevel.Level10_0 => 3,
				D3DFeatureLevel.Level10_1 => 4,
				D3DFeatureLevel.Level11_0 => 5,
				D3DFeatureLevel.Level11_1 => 6,
				D3DFeatureLevel.Level12_0 => 7,
				D3DFeatureLevel.Level12_1 => 8,
				_ => throw new ArgumentException( "올바른 기능 레벨 단계가 아닙니다." )
			};

			this.pFeatureLevelsRequest = new D3DFeatureLevel[9 - index];
			featureLevels.CopyTo( this.pFeatureLevelsRequest as D3DFeatureLevel[], index );

			this.MaxSupportedFeatureLevel = D3DFeatureLevel.Unspecified;
		}
	}
}
