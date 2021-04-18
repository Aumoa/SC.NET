// Copyright 2020-2021 Aumoa.lib. All right reserved.

#include "pch.h"
#include "CommandQueue.h"

#include "DeviceBundle.h"

using namespace System;
using namespace SC::ThirdParty::DirectX;

CommandQueue::CommandQueue(DeviceBundle^ parent) : Super(parent)
{
	ID3D12Device5* dev = parent->GetDevice();
	
	D3D12_COMMAND_QUEUE_DESC queueDesc = { };
	queueDesc.Type = D3D12_COMMAND_LIST_TYPE_DIRECT;

	TComPtr<ID3D12CommandQueue> queue;
	HR(dev->CreateCommandQueue(&queueDesc, IID_PPV_ARGS(&queue)));

	_queue = queue.Detach();
}

CommandQueue::~CommandQueue()
{
	RELEASE(_queue);
}

void CommandQueue::SetDebugName(String^ name)
{
	SetDebugNameInternal(_queue, name);
}

ID3D12CommandQueue* CommandQueue::GetCommandQueue()
{
	return _queue;
}