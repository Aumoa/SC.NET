// Copyright 2020-2021 Aumoa.lib. All right reserved.

#include "pch.h"
#include "DeviceBundle.h"

#include "SwapChain.h"
#include "CommandQueue.h"

using namespace System;
using namespace System::Runtime::InteropServices;
using namespace SC::ThirdParty::DirectX;
using namespace SC::ThirdParty::WinAPI;

DeviceBundle::DeviceBundle(bool debugEnabled)
{
	UINT flag = 0;

	if (TComPtr<ID3D12Debug> debug; debugEnabled && SUCCEEDED(D3D12GetDebugInterface(IID_PPV_ARGS(&debug))))
	{
		debug->EnableDebugLayer();
	}

	// Initialize DirectX Graphics Infrastructure Factory.
	TComPtr<IDXGIFactory2> dxgiFactory;
	HR(CreateDXGIFactory2(flag, IID_PPV_ARGS(&dxgiFactory)));

	TComPtr<IDXGIAdapter1> adapter;
	TComPtr<ID3D12Device5> device;
	for (int i = 0; SUCCEEDED(dxgiFactory->EnumAdapters1((UINT)i, &adapter)); ++i)
	{
		if (!IsAdapterSuitable(adapter.Get()))
		{
			continue;
		}

		if (FAILED(D3D12CreateDevice(adapter.Get(), D3D_FEATURE_LEVEL_12_1, IID_PPV_ARGS(&device))))
		{
			continue;
		}

		if (!IsDeviceSuitable(device.Get()))
		{
			continue;
		}

		DXGI_ADAPTER_DESC1 desc = { };
		HR(adapter->GetDesc1(&desc));
		break;
	}

	if (!device.IsValid())
	{
		throw gcnew COMException("Cannot found suitable device.", E_NOINTERFACE);
	}

	_dxgiFactory = dxgiFactory.Detach();
	_device = device.Detach();
}

DeviceBundle::~DeviceBundle()
{
	RELEASE(_dxgiFactory);
	RELEASE(_device);
}

CommandQueue^ DeviceBundle::CreateCommandQueue()
{
	return gcnew CommandQueue(this);
}

SwapChain^ DeviceBundle::CreateSwapChain(CoreWindow^ target, CommandQueue^ queue)
{
	auto chain = gcnew SwapChain(this);
	chain->Init(target, queue);
	return chain;
}

IDXGIFactory2* DeviceBundle::GetFactory()
{
	return _dxgiFactory;
}

ID3D12Device5* DeviceBundle::GetDevice()
{
	return _device;
}

bool DeviceBundle::IsAdapterSuitable(IDXGIAdapter1* adapter)
{
	DXGI_ADAPTER_DESC1 desc = { };
	HR(adapter->GetDesc1(&desc));

	if (desc.Flags == DXGI_ADAPTER_FLAG_REMOTE || desc.Flags == DXGI_ADAPTER_FLAG_SOFTWARE)
	{
		// Is remote or software implement.
		return false;
	}

	return true;
}

bool DeviceBundle::IsDeviceSuitable(ID3D12Device5* device)
{
	D3D12_FEATURE_DATA_D3D12_OPTIONS5 options = { };
	HR(device->CheckFeatureSupport(D3D12_FEATURE_D3D12_OPTIONS5, &options, sizeof(options)));

	// Must support raytracing tier 1.0.
	if (options.RaytracingTier >= D3D12_RAYTRACING_TIER_1_0)
	{
		return true;
	}

	return false;
}