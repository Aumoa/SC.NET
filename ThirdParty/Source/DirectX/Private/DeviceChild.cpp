// Copyright 2020-2021 Aumoa.lib. All right reserved.

#include "pch.h"
#include "DeviceChild.h"

using namespace System;
using namespace SC::ThirdParty::DirectX;
using namespace std;
using namespace msclr::interop;

DeviceChild::DeviceChild(DeviceBundle^ parent)
{
	_parent = parent;
}

DeviceChild::~DeviceChild()
{
	_parent = nullptr;
	GC::SuppressFinalize(this);
}

DeviceBundle^ DeviceChild::GetParent()
{
	return _parent;
}

void DeviceChild::SetDebugNameInternal(ID3D12Object* d3dobj, System::String^ name)
{
	auto name_wstr = marshal_as<wstring>(name);
	HR(d3dobj->SetName(name_wstr.c_str()));
}