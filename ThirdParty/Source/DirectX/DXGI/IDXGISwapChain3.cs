// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// 화면에 내용을 출력하는 스왑 체인에 대한 공통 함수를 제공합니다.
    /// </summary>
    [Guid( "94D99BDB-F1F8-4AB0-B236-7DA0170EDAB1" )]
	[ComVisible( true )]
	public interface IDXGISwapChain3 : IDXGISwapChain2
	{
		/// <summary>
		/// 현재 프레임 렌더링으로 사용 가능한 후면 버퍼의 인덱스를 가져옵니다.
		/// </summary>
		/// <returns> 후면 버퍼의 인덱스를 반환합니다. </returns>
		uint GetCurrentBackBufferIndex();

		/// <summary>
		/// 컬러 스페이스 지원 여부에 대한 열거형 조합을 가져옵니다.
		/// </summary>
		/// <param name="colorSpace"> 컬러 스페이스 유형을 전달합니다. </param>
		/// <returns> 열거형 조합이 반환됩니다. </returns>
		DXGISwapChainColorSpaceSupportFlags CheckColorSpaceSupport( DXGIColorSpaceType colorSpace );

		/// <summary>
		/// 컬러 스페이스를 설정합니다.
		/// </summary>
		/// <param name="colorSpace"> 컬러 스페이스 유형을 전달합니다. </param>
		void SetColorSpace1( DXGIColorSpaceType colorSpace );

		/// <summary>
		/// 후면 버퍼의 크기를 변경합니다.
		/// </summary>
		/// <param name="bufferCount"> 변경할 버퍼의 개수를 전달합니다. null을 전달할 경우 버퍼의 개수를 변경하지 않습니다. </param>
		/// <param name="width"> 변경할 버퍼의 너비를 전달합니다. </param>
		/// <param name="height"> 변경할 버퍼의 높이를 전달합니다. </param>
		/// <param name="newFormat"> 변경할 버퍼의 픽셀 형식을 전달합니다. null을 전달할 경우 형식을 변경하지 않습니다. </param>
		/// <param name="swapChainFlag"> 변경할 스왑 체인의 속성을 전달합니다. null을 전달할 경우 속성을 변경하지 않습니다. </param>
		/// <param name="creationNodeMask"> 생성 노드 마스크를 전달합니다. 개수는 버퍼의 개수와 일치합니다. </param>
		/// <param name="presentQueues"> 명령 대기열 목록을 전달합니다. 개수는 버퍼의 개수와 일치합니다. </param>
		/// <remarks> 이 메서드를 호출하기 전, 반드시 모든 후면 버퍼의 참조가 제거되어야 합니다. <see cref="IUnknown.Release"/> 메서드를 참조하십시오. </remarks>
		void ResizeBuffers1( uint? bufferCount, int width, int height, DXGIFormat? newFormat, DXGISwapChainFlag? swapChainFlag, IList<uint> creationNodeMask, IList<IUnknown> presentQueues );
	}
}
