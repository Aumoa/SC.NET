// Copyright 2020-2021 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD3DBlob : CComObject, ID3DBlob
	{
	public:
		using Super = CComObject;

	private:
		::ID3DBlob* pBlob;

	public:
		CD3DBlob(::ID3DBlob* pBlob);
		static void RegisterClass();

		virtual System::IntPtr GetBufferPointer();
		virtual unsigned long long GetBufferSize();

	private:
		static IUnknown^ CoCreateInstance(System::IntPtr pUnknown);
	};
}