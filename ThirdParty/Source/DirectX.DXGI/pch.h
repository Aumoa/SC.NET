// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

#undef _MANAGED

#include <Windows.h>
#include <dxgi1_6.h>
#include <wrl/client.h>
#include <vector>
#include <msclr/marshal.h>
#include <string>

#undef RegisterClass

using Microsoft::WRL::ComPtr;

#include "CComObject.h"
#include "CDXGIObject.h"
#include "CDXGIOutput.h"
#include "CDXGIAdapter.h"
#include "OutputEnumerator.h"
#include "CDXGIAdapter1.h"
#include "CDXGIDevice.h"
#include "CDXGIDeviceSubObject.h"
#include "CDXGISurface.h"
#include "CDXGISwapChain.h"
#include "AdapterEnumerator.h"
#include "CDXGIFactory.h"
#include "DXGI.h"
#include "CDXGISwapChain1.h"
#include "CDXGISwapChain2.h"
#include "CDXGISwapChain3.h"
#include "CDXGIFactory1.h"

template< class T >
T* Take( SC::ThirdParty::DirectX::IUnknown^ pUnknown )
{
	auto ref = ( SC::ThirdParty::DirectX::ComObject^ )pUnknown;
	return ( T* )ref->Handle.ToPointer();
}

template< class T >
void SafeDeleteArray( T*& ptr )
{
	if ( ptr )
	{
		delete[] ptr;
		ptr = nullptr;
	}
}

template< class T >
void SafeDelete( T*& ptr )
{
	if ( ptr )
	{
		delete ptr;
		ptr = nullptr;
	}
}

System::Guid FromGUID( const _GUID& guid );
_GUID ToGUID( System::Guid& guid );
SC::Engine::Runtime::Core::Numerics::Rectangle ToRectangle( const RECT& rect );

void Assign( SC::ThirdParty::DirectX::DXGIRational% left, const DXGI_RATIONAL& right );
void Assign( DXGI_RATIONAL& left, SC::ThirdParty::DirectX::DXGIRational% right );
void Assign( SC::ThirdParty::DirectX::DXGIModeDesc% left, const DXGI_MODE_DESC& right );
void Assign( DXGI_MODE_DESC& left, SC::ThirdParty::DirectX::DXGIModeDesc% right );
void Assign( SC::ThirdParty::DirectX::DXGIGammaControlCapabilities% left, const DXGI_GAMMA_CONTROL_CAPABILITIES& right );
void Assign( DXGI_GAMMA_CONTROL_CAPABILITIES& left, SC::ThirdParty::DirectX::DXGIGammaControlCapabilities% right );
void Assign( DXGI_GAMMA_CONTROL& left, SC::ThirdParty::DirectX::DXGIGammaControl% right );
void Assign( SC::ThirdParty::DirectX::DXGIGammaControl% left, DXGI_GAMMA_CONTROL& right );
void Assign( DXGI_GAMMA_CONTROL& left, SC::ThirdParty::DirectX::DXGIGammaControl% right );
void Assign( SC::ThirdParty::DirectX::DXGIGammaControl% left, DXGI_GAMMA_CONTROL& right );
void Assign( DXGI_RGB& left, SC::ThirdParty::DirectX::DXGIRGB% right );
void Assign( SC::ThirdParty::DirectX::DXGIRGB% left, DXGI_RGB& right );
void Assign( DXGI_FRAME_STATISTICS& left, SC::ThirdParty::DirectX::DXGIFrameStatistics% right );
void Assign( SC::ThirdParty::DirectX::DXGIFrameStatistics% left, DXGI_FRAME_STATISTICS& right );
void Assign( DXGI_ADAPTER_DESC& left, SC::ThirdParty::DirectX::DXGIAdapterDesc% right );
void Assign( SC::ThirdParty::DirectX::DXGIAdapterDesc% left, DXGI_ADAPTER_DESC& right );
void Assign( std::wstring& left, System::String^ right );
void Assign( System::String^% left, const std::wstring& right );
void Assign( SC::ThirdParty::DirectX::Luid% left, LUID& right );
void Assign( LUID& left, SC::ThirdParty::DirectX::Luid% right );
void Assign( DXGI_ADAPTER_DESC1& left, SC::ThirdParty::DirectX::DXGIAdapterDesc1% right );
void Assign( SC::ThirdParty::DirectX::DXGIAdapterDesc1% left, DXGI_ADAPTER_DESC1& right );
void Assign( SC::ThirdParty::DirectX::DXGISurfaceDesc% left, DXGI_SURFACE_DESC& right );
void Assign( DXGI_SURFACE_DESC& left, SC::ThirdParty::DirectX::DXGISurfaceDesc% right );
void Assign( DXGI_SAMPLE_DESC& left, SC::ThirdParty::DirectX::DXGISampleDesc% right );
void Assign( SC::ThirdParty::DirectX::DXGISampleDesc% left, DXGI_SAMPLE_DESC& right );
void Assign( DXGI_SWAP_CHAIN_DESC& left, SC::ThirdParty::DirectX::DXGISwapChainDesc% right );
void Assign( SC::ThirdParty::DirectX::DXGISwapChainDesc% left, DXGI_SWAP_CHAIN_DESC& right );
void Assign( DXGI_SWAP_CHAIN_DESC1& left, SC::ThirdParty::DirectX::DXGISwapChainDesc1% right );
void Assign( SC::ThirdParty::DirectX::DXGISwapChainDesc1% left, DXGI_SWAP_CHAIN_DESC1& right );
void Assign( DXGI_SWAP_CHAIN_FULLSCREEN_DESC& left, SC::ThirdParty::DirectX::DXGISwapChainFullscreenDesc% right );
void Assign( SC::ThirdParty::DirectX::DXGISwapChainFullscreenDesc% left, DXGI_SWAP_CHAIN_FULLSCREEN_DESC& right );
void Assign( DXGI_PRESENT_PARAMETERS& left, SC::ThirdParty::DirectX::DXGIPresentParameters% right );
void Assign( SC::ThirdParty::DirectX::DXGIPresentParameters% left, DXGI_PRESENT_PARAMETERS& right );
void Assign( RECT& left, SC::Engine::Runtime::Core::Numerics::Rectangle% right);
void Assign(SC::Engine::Runtime::Core::Numerics::Rectangle% left, RECT& right );
void Assign( POINT& left, SC::Engine::Runtime::Core::Numerics::Vector2% right );
void Assign( SC::Engine::Runtime::Core::Numerics::Vector2% left, POINT& right );
void Assign( DXGI_RGBA& left, SC::ThirdParty::DirectX::DXGIRGBA% right );
void Assign( SC::ThirdParty::DirectX::DXGIRGBA% left, DXGI_RGBA& right );
void Assign( DXGI_MATRIX_3X2_F& left, SC::Engine::Runtime::Core::Numerics::Matrix3x2% right );
void Assign( SC::Engine::Runtime::Core::Numerics::Matrix3x2% left, DXGI_MATRIX_3X2_F& right );