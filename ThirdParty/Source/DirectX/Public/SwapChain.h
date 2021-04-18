// Copyright 2020-2021 Aumoa.lib. All right reserved.

#pragma once

#include "pch.h"
#include "DeviceChild.h"

namespace SC::ThirdParty::DirectX
{
	ref class CommandQueue;

	/// <summary>
	/// DirectX 스왑 체인을 표현합니다.
	/// </summary>
	public ref class SwapChain : public DeviceChild
	{
		using Super = DeviceChild;

		System::String^ _debugName;
		IDXGISwapChain4* _swapChain;

	internal:
		SwapChain(DeviceBundle^ parent);
		~SwapChain();

		void Init(WinAPI::CoreWindow^ target, CommandQueue^ queue);

	public:
		/// <inheritdoc/>
		void SetDebugName(System::String^ name) override;

		/// <summary>
		/// 대기 중인 버퍼를 화면에 출력합니다.
		/// </summary>
		void Present();

	internal:
		IDXGISwapChain4* GetSwapChain();
	};
}