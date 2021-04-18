// Copyright 2020 Aumoa.lib. All right reserved.

using namespace System;
using namespace System::Collections::Generic;

using SC::ThirdParty::DirectX::OutputEnumerator;

OutputEnumerator::OutputEnumerator( ::IDXGIAdapter* pAdapter )
{
	this->pRef = pAdapter;
	pAdapter->AddRef();
}

OutputEnumerator::~OutputEnumerator()
{
	this->!OutputEnumerator();
}

OutputEnumerator::!OutputEnumerator()
{
	pRef->Release();
}

bool OutputEnumerator::MoveNext()
{
	index += 1;

	ComPtr<::IDXGIOutput> p;
	if ( SUCCEEDED( pRef->EnumOutputs( ( UINT )index, &p ) ) )
	{
		pCurrent = gcnew CDXGIOutput( p.Detach() );
		return true;
	}
	else
	{
		return false;
	}
}

void OutputEnumerator::Reset()
{
	index = -1;
}

auto OutputEnumerator::Current::get() -> IDXGIOutput^
{
	return pCurrent;
}

Object^ OutputEnumerator::Current1::get()
{
	return Current;
}