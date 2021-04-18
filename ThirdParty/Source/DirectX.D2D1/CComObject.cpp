// Copyright 2020 Aumoa.lib. All right reserved.

using namespace System;

using SC::ThirdParty::DirectX::CComObject;

void CComObject::OnDisposing()
{
	if ( pUnknown )
	{
		pUnknown->Release();
		pUnknown = nullptr;
	}
}

CComObject::CComObject( ::IUnknown* pUnknown ) : ComObject( IntPtr( pUnknown ) )
{
	this->pUnknown = pUnknown;
}

void CComObject::QueryInterface( Guid riid, IUnknown^% ppUnknown )
{
	ComPtr<::IUnknown> pRef;
	HR( pUnknown->QueryInterface( ToGUID( riid ), &pRef ) );

	if ( riid == IUnknown::typeid->GUID )
	{
		ppUnknown = gcnew CComObject( pRef.Detach() );
	}
	else
	{
		ppUnknown = ComObject::CoCreateInstance( riid, IntPtr( pRef.Detach() ) );
	}
}