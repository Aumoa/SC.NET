// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 셰이더 컴포넌트 매핑 방식을 표현합니다.
    /// </summary>
    public enum D3D12ShaderComponentMapping
	{
		/// <summary>
		/// 값을 지정하지 않습니다.
		/// </summary>
		None = 0,

		/// <summary>
		/// 0번 컴포넌트로부터 값을 가져옵니다.
		/// </summary>
		FromMemoryComponent0 = 0,

		/// <summary>
		/// 1번 컴포넌트로부터 값을 가져옵니다.
		/// </summary>
		FromMemoryComponent1 = 1,

		/// <summary>
		/// 2번 컴포넌트로부터 값을 가져옵니다.
		/// </summary>
		FromMemoryComponent2 = 2,

		/// <summary>
		/// 3번 컴포넌트로부터 값을 가져옵니다.
		/// </summary>
		FromMemoryComponent3 = 3,

		/// <summary>
		/// 강제로 값을 0으로 가져옵니다.
		/// </summary>
		ForceValue0 = 4,

		/// <summary>
		/// 강제로 값을 1로 가져옵니다. 이 값은 입력 형식에 따라 <see cref="int"/> 1 또는 <see cref="float"/> 1.0이 될 수 있습니다.
		/// </summary>
		ForceValue1 = 5
	}
}
