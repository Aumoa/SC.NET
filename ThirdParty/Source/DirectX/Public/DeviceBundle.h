// Copyright 2020-2021 Aumoa.lib. All right reserved.

#pragma once

#include "pch.h"

namespace SC::ThirdParty::DirectX
{
	ref class SwapChain;
	ref class CommandQueue;

	/// <summary>
	/// DirectX 디바이스 집합을 표현합니다.
	/// </summary>
	public ref class DeviceBundle
	{
		IDXGIFactory2* _dxgiFactory;
		ID3D12Device5* _device;

	public:
		/// <summary>
		/// 개체를 초기화합니다.
		/// </summary>
		/// <param name="debugEnabled"> 디버그 모드로 개체를 생성합니다. </param>
		DeviceBundle(bool debugEnabled);
		~DeviceBundle();

		/// <summary>
		/// 명령 대기열 개체를 생성합니다.
		/// </summary>
		/// <returns> 개체가 반환됩니다. </returns>
		CommandQueue^ CreateCommandQueue();

		/// <summary>
		/// 스왑 체인을 생성합니다.
		/// </summary>
		/// <param name="target"> 렌더 타겟을 전달합니다. </param>
		/// <param name="queue"> 명령 대기열 개체를 전달합니다. </param>
		/// <returns> 생성된 개체가 반환됩니다. </returns>
		SwapChain^ CreateSwapChain(WinAPI::CoreWindow^ target, CommandQueue^ queue);

	internal:
		IDXGIFactory2* GetFactory();
		ID3D12Device5* GetDevice();

	private:
		bool IsAdapterSuitable(IDXGIAdapter1* adapter);
		bool IsDeviceSuitable(ID3D12Device5* device);
	};
}