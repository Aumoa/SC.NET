// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD3D12Debug : CComObject, ID3D12Debug
	{
		::ID3D12Debug* pDebug;

	public:
		CD3D12Debug( ::ID3D12Debug* pDebug );
		static void RegisterClass();

		virtual void EnableDebugLayer();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}