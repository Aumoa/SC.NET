// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI 개체의 교환 효과를 표현합니다.
    /// </summary>
    public enum DXGISwapEffect
	{
		/// <summary>
		/// 비트 블록 전송 모델을 사용하며, 버퍼 내용을 출력 후 DXGI가 버퍼의 내용을 제거하도록 지정합니다. 이 값을 지정할 경우 응용 프로그램은 0번 버퍼에 대한 읽기 및 쓰기 권한만 갖습니다.
		/// </summary>
		Discard = 0,

		/// <summary>
		/// 비트 블록 전송 모델을 사용하며, 버퍼 내용을 출력 후 DXGI가 버퍼의 내용을 유지하도록 지정합니다. 첫 번째 버퍼에서 마지막 버퍼의 내용까지 순차적으로 표시할 경우 이 값을 사용합니다.
		/// </summary>
		Sequential = 1,

		/// <summary>
		/// Flip 전송 모델을 사용하며, 버퍼 내용을 출력 후 DXGI가 버퍼의 내용을 유지하도록 지정합니다.
		/// </summary>
		FlipSequential = 2,

		/// <summary>
		/// Flip 전송 모델을 사용하며, 버퍼 내용을 출력 후 DXGI가 버퍼의 내용을 제거하도록 지정합니다.
		/// </summary>
		FlipDiscard =  3,
	}
}
