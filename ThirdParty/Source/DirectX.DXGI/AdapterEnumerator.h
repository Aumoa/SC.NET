// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class AdapterEnumerator : System::Collections::Generic::IEnumerator<IDXGIAdapter^>
	{
		::IDXGIFactory* pRef;
		int index = -1;

		IDXGIAdapter^ pCurrent;

	public:
		AdapterEnumerator( ::IDXGIFactory* pAdapter );
		~AdapterEnumerator();
		!AdapterEnumerator();

		virtual bool MoveNext();
		virtual void Reset();

		property IDXGIAdapter^ Current
		{
			virtual IDXGIAdapter^ get();
		}

	private:
		property System::Object^ Current1
		{
			virtual System::Object^ get() sealed = System::Collections::IEnumerator::Current::get;
		}
	};
}