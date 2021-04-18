// Copyright 2020 Aumoa.lib. All right reserved.

using namespace SC::Engine::Runtime::Core::Numerics;
using namespace SC::ThirdParty::DirectX;
using namespace SC::ThirdParty::WinAPI;

using namespace System;

CDXGISwapChain2::CDXGISwapChain2( ::IDXGISwapChain2* pSwapChain ) : CDXGISwapChain1( pSwapChain )
{
	this->pSwapChain = pSwapChain;
}

void CDXGISwapChain2::RegisterClass()
{
	RegisterCLSID( IDXGISwapChain2::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

void CDXGISwapChain2::SetSourceSize( Vector2 size )
{
	HR( pSwapChain->SetSourceSize( ( UINT )size.X, ( UINT )size.Y ) );
}

Vector2 CDXGISwapChain2::GetSourceSize()
{
	UINT width, height;
	HR( pSwapChain->GetSourceSize( &width, &height ) );
	return Vector2( ( float )width, ( float )height );
}

void CDXGISwapChain2::SetMaximumFrameLatency( unsigned int maxLatency )
{
	HR( pSwapChain->SetMaximumFrameLatency( maxLatency ) );
}

unsigned int CDXGISwapChain2::GetMaximumFrameLatency()
{
	UINT lat;
	HR( pSwapChain->GetMaximumFrameLatency( &lat ) );
	return lat;
}

IPlatformHandle^ CDXGISwapChain2::GetFrameLatencyWaitableObject()
{
	return gcnew GeneralHandle( IntPtr( pSwapChain->GetFrameLatencyWaitableObject() ) );
}

void CDXGISwapChain2::SetMatrixTransform( Matrix3x2 matrix )
{
	DXGI_MATRIX_3X2_F left;
	Assign( left, matrix );
	HR( pSwapChain->SetMatrixTransform( &left ) );
}

Matrix3x2 CDXGISwapChain2::GetMatrixTransform()
{
	DXGI_MATRIX_3X2_F left;
	HR( pSwapChain->GetMatrixTransform( &left ) );

	Matrix3x2 right;
	Assign( right, left );

	return right;
}

auto CDXGISwapChain2::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CDXGISwapChain2( ( ::IDXGISwapChain2* )pUnknown.ToPointer() );
}