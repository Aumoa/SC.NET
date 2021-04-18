// Copyright 2020 Aumoa.lib. All right reserved.

using namespace SC::ThirdParty::DirectX;

using namespace System;
using namespace System::Collections::Generic;

CDXGISwapChain3::CDXGISwapChain3( ::IDXGISwapChain3* pSwapChain ) : CDXGISwapChain2( pSwapChain )
{
	this->pSwapChain = pSwapChain;
}

void CDXGISwapChain3::RegisterClass()
{
	RegisterCLSID( IDXGISwapChain3::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

unsigned int CDXGISwapChain3::GetCurrentBackBufferIndex()
{
	return pSwapChain->GetCurrentBackBufferIndex();
}

DXGISwapChainColorSpaceSupportFlags CDXGISwapChain3::CheckColorSpaceSupport( DXGIColorSpaceType colorSpace )
{
	UINT check;
	HR( pSwapChain->CheckColorSpaceSupport( ( DXGI_COLOR_SPACE_TYPE )colorSpace, &check ) );
	return ( DXGISwapChainColorSpaceSupportFlags )check;
}

void CDXGISwapChain3::SetColorSpace1( DXGIColorSpaceType colorSpace )
{
	HR( pSwapChain->SetColorSpace1( ( DXGI_COLOR_SPACE_TYPE )colorSpace ) );
}

void CDXGISwapChain3::ResizeBuffers1( Nullable<unsigned int> bufferCount, int width, int height, Nullable<DXGIFormat> newFormat, Nullable<DXGISwapChainFlag> swapChainFlag, IList<unsigned int>^ creationNodeMask, IList<IUnknown^>^ presentQueues )
{
	UINT bufferCount1 = bufferCount.HasValue ? bufferCount.Value : 0;
	DXGI_FORMAT newFormat1 = newFormat.HasValue ? ( DXGI_FORMAT )newFormat.Value : DXGI_FORMAT_UNKNOWN;
	UINT swapChainFlag1 = swapChainFlag.HasValue ? ( UINT )swapChainFlag.Value : 0;

	std::vector<unsigned int> creationNodeMask1( creationNodeMask->Count );
	for ( int i = 0; i < creationNodeMask->Count; ++i )
	{
		creationNodeMask1[i] = creationNodeMask[i];
	}

	std::vector<::IUnknown*> presentQueues1( presentQueues->Count );
	for ( int i = 0; i < presentQueues->Count; ++i )
	{
		presentQueues1[i] = Take<::IUnknown>( presentQueues[i] );
	}

	HR( pSwapChain->ResizeBuffers1( bufferCount1, width, height, newFormat1, swapChainFlag1, creationNodeMask1.data(), presentQueues1.data() ) );
}

auto CDXGISwapChain3::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CDXGISwapChain3( ( ::IDXGISwapChain3* )pUnknown.ToPointer() );
}