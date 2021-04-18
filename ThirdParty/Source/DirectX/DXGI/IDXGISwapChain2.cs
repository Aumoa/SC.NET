// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

using SC.Engine.Runtime.Core.Numerics;
using SC.ThirdParty.WinAPI;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// 화면에 내용을 출력하는 스왑 체인에 대한 공통 함수를 제공합니다.
    /// </summary>
    [Guid( "A8BE2AC4-199F-4946-B331-79599FB98DE7" )]
	[ComVisible( true )]
	public interface IDXGISwapChain2 : IDXGISwapChain1
	{
		/// <summary>
		/// 스왑 체인에 사용될 소스의 크기를 설정합니다.
		/// </summary>
		/// <param name="size"> 크기를 전달합니다. </param>
		void SetSourceSize( Vector2 size );

		/// <summary>
		/// 스왑 체인에 사용될 소스의 크기를 가져옵니다.
		/// </summary>
		/// <returns> 크기 구조체를 반환합니다. </returns>
		Vector2 GetSourceSize();

		/// <summary>
		/// 스왑 체인이 렌더링을 위해 대기할 수 있는 프레임 수를 설정합니다.
		/// </summary>
		/// <param name="maxLatency"> 프레임 수를 전달합니다. </param>
		void SetMaximumFrameLatency( uint maxLatency );

		/// <summary>
		/// 스왑 체인이 렌더링을 위해 대기할 수 있는 프레임 수를 가져옵니다.
		/// </summary>
		/// <returns> 프레임 수를 반환합니다. </returns>
		uint GetMaximumFrameLatency();

		/// <summary>
		/// DXGI가 새로운 프레임 출력 시간까지 대기할 수 있는 대기 가능 오브젝트의 핸들을 반환합니다.
		/// </summary>
		/// <returns> 핸들 개체를 반환합니다. </returns>
		IPlatformHandle GetFrameLatencyWaitableObject();

		/// <summary>
		/// 컴포지션 스왑 체인일 경우, 다음 프레임 렌더링 시 사용될 변환 행렬을 설정합니다.
		/// </summary>
		/// <param name="matrix"> 변환 행렬을 전달합니다. </param>
		void SetMatrixTransform( Matrix3x2 matrix );

		/// <summary>
		/// 컴포지션 스왑 체인일 경우, 프레임 렌더링에 사용될 변환 행렬을 가져옵니다.
		/// </summary>
		/// <returns> 변환 행렬 개체가 반환됩니다. </returns>
		Matrix3x2 GetMatrixTransform();
	}
}
