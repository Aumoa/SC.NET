// Copyright 2020 Aumoa.lib. All right reserved.

using namespace System;
using namespace System::Collections::Generic;

using SC::ThirdParty::DirectX::AdapterEnumerator;

AdapterEnumerator::AdapterEnumerator( ::IDXGIFactory* pAdapter )
{
	this->pRef = pAdapter;
	pAdapter->AddRef();
}

AdapterEnumerator::~AdapterEnumerator()
{
	this->!AdapterEnumerator();
}

AdapterEnumerator::!AdapterEnumerator()
{
	pRef->Release();
}

bool AdapterEnumerator::MoveNext()
{
	index += 1;

	ComPtr<::IDXGIAdapter> p;
	if ( SUCCEEDED( pRef->EnumAdapters( ( UINT )index, &p ) ) )
	{
		pCurrent = gcnew CDXGIAdapter( p.Detach() );
		return true;
	}
	else
	{
		return false;
	}
}

void AdapterEnumerator::Reset()
{
	index = -1;
}

auto AdapterEnumerator::Current::get() -> IDXGIAdapter^
{
	return pCurrent;
}

Object^ AdapterEnumerator::Current1::get()
{
	return Current;
}