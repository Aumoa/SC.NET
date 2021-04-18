// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 명령 목록 유형을 나타냅니다.
    /// </summary>
    public enum D3D12CommandListType
	{
		/// <summary>
		/// 명령 대기열에 직접 사용되는 유형입니다. 대부분의 작업을 수행할 수 있습니다.
		/// </summary>
		Direct = 0,

		/// <summary>
		/// 명령 대기열에 간접적으로 제공되는 유형입니다. 이 명령은 다른 직접 명령에 의해 실행되어야 합니다.
		/// </summary>
		Bundle = 1,

		/// <summary>
		/// 계산 및 복사 유형의 명령을 실행할 수 있는 유형입니다.
		/// </summary>
		Compute = 2,

		/// <summary>
		/// 복사 유형의 명령을 실행할 수 있는 유형입니다.
		/// </summary>
		Copy = 3,

		/// <summary>
		/// 비디오 복호화 명령을 실행할 수 있는 유형입니다.
		/// </summary>
		VideoDecode = 4,

		/// <summary>
		/// 비디오 연산 명령을 실행할 수 있는 유형입니다.
		/// </summary>
		VideoProcess = 5,

		/// <summary>
		/// 비디오 암호화 명령을 실행할 수 있는 유형입니다.
		/// </summary>
		VideoEncode = 6
	}
}
