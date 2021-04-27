// Copyright 2020-2021 Aumoa.lib. All right reserved.

using namespace System;
using namespace SC::ThirdParty::DirectX;

CD3DBlob::CD3DBlob(::ID3DBlob* pBlob) : Super(pBlob)
{
	this->pBlob = pBlob;
}

void CD3DBlob::RegisterClass()
{
	RegisterCLSID(ID3DBlob::typeid->GUID, gcnew CoCreateInstanceDelegate(&CoCreateInstance));
}

IntPtr CD3DBlob::GetBufferPointer()
{
	return IntPtr(pBlob->GetBufferPointer());
}

unsigned long long CD3DBlob::GetBufferSize()
{
	return (unsigned long long )pBlob->GetBufferSize();
}

auto CD3DBlob::CoCreateInstance(IntPtr pUnknown) -> IUnknown^
{
	return gcnew CD3DBlob((::ID3DBlob*)pUnknown.ToPointer());
}