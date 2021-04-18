// Copyright 2020-2021 Aumoa.lib. All right reserved.

#pragma once

#include "pch.h"
#include "DeviceChild.h"

namespace SC::ThirdParty::DirectX
{
	/// <summary>
	/// 그래픽 명령 대기열을 표현합니다.
	/// </summary>
	public ref class CommandQueue : public DeviceChild
	{
		using Super = DeviceChild;

		ID3D12CommandQueue* _queue;

	internal:
		CommandQueue(DeviceBundle^ parent);
		~CommandQueue();

	public:
        /// <inheritdoc/>
		void SetDebugName(System::String^ name) override;

	internal:
		ID3D12CommandQueue* GetCommandQueue();
	};
}