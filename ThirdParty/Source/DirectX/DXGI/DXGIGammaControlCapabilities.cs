// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// 감마 컨트롤 호환 정보 구조를 표현합니다.
    /// </summary>
    public struct DXGIGammaControlCapabilities
	{
		float[] controlPointPositions;

		/// <summary>
		/// 
		/// </summary>
		public bool ScaleAndOffsetSupported;

		/// <summary>
		/// 
		/// </summary>
		public float MaxConvertedValue;

		/// <summary>
		/// 
		/// </summary>
		public float MinConvertedValue;

		/// <summary>
		/// 
		/// </summary>
		public int NumGammaControlPoints;

		/// <summary>
		/// 감마 제어점 값 목록을 가져옵니다. 값은 1025개의 <see cref="float"/> 배열입니다.
		/// </summary>
		public float[] ControlPointPositions { get => controlPointPositions ??= new float[1025]; }
	}
}
