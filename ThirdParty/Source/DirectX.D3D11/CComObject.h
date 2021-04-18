// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CComObject : ComObject
	{
		::IUnknown* pUnknown = nullptr;

	protected:
		void OnDisposing() override;

	public:
		CComObject( ::IUnknown* pUnknown );

		void QueryInterface( System::Guid riid, IUnknown^% ppUnknown ) override;
	};
}