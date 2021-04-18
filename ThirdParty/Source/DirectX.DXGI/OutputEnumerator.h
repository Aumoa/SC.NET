// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class OutputEnumerator : System::Collections::Generic::IEnumerator<IDXGIOutput^>
	{
		::IDXGIAdapter* pRef;
		int index = -1;

		IDXGIOutput^ pCurrent;

	public:
		OutputEnumerator( ::IDXGIAdapter* pAdapter );
		~OutputEnumerator();
		!OutputEnumerator();

		virtual bool MoveNext();
		virtual void Reset();

		property IDXGIOutput^ Current
		{
			virtual IDXGIOutput^ get();
		}

	private:
		property System::Object^ Current1
		{
			virtual System::Object^ get() sealed = System::Collections::IEnumerator::Current::get;
		}
	};
}