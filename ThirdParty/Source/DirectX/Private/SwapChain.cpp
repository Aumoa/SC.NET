// Copyright 2020-2021 Aumoa.lib. All right reserved.

#include "pch.h"
#include "SwapChain.h"

#include "CommandQueue.h"
#include "DeviceBundle.h"

using namespace System;
using namespace SC::ThirdParty::DirectX;
using namespace SC::ThirdParty::WinAPI;

SwapChain::SwapChain(DeviceBundle^ parent) : Super(parent)
{

}

SwapChain::~SwapChain()
{
	RELEASE(_swapChain);
}

void SwapChain::Init(CoreWindow^ target, CommandQueue^ queue)
{
	DeviceBundle^ parent = GetParent();
	auto hWnd = (HWND)target->GetHandle().ToPointer();

	ID3D12Device5* dev = parent->GetDevice();
	IDXGIFactory2* factory = parent->GetFactory();
	ID3D12CommandQueue* q = queue->GetCommandQueue();

	DXGI_SWAP_CHAIN_DESC1 swapChainDesc = { };
	swapChainDesc.Format = DXGI_FORMAT_B8G8R8A8_UNORM;
	swapChainDesc.SampleDesc = { 1, 0 };
	swapChainDesc.BufferUsage = DXGI_USAGE_RENDER_TARGET_OUTPUT;
	swapChainDesc.BufferCount = 3;
	swapChainDesc.SwapEffect = DXGI_SWAP_EFFECT_FLIP_DISCARD;

	TComPtr<IDXGISwapChain1> chain;
	HR(factory->CreateSwapChainForHwnd(q, hWnd, &swapChainDesc, nullptr, nullptr, &chain));
	TComPtr<IDXGISwapChain4> chain4;
	HR(chain->QueryInterface(&chain4));

	_swapChain = chain4.Detach();
}

void SwapChain::SetDebugName(String^ name)
{
	
}

void SwapChain::Present()
{
	HR(_swapChain->Present(0, 0));
}

IDXGISwapChain4* SwapChain::GetSwapChain()
{
	return _swapChain;
}