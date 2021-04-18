// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CDXGIOutput : CDXGIObject, IDXGIOutput
	{
		::IDXGIOutput* pOutput;

	public:
		CDXGIOutput( ::IDXGIOutput* pOutput );
		static void RegisterClass();

		void GetParent( System::Guid iid, IUnknown^% ppUnknown ) override;

		virtual DXGIOutputDesc GetDesc();
		virtual cli::array<DXGIModeDesc>^ GetDisplayModeList( DXGIFormat enumFormat, DXGIEnumModeFlags flags );
		virtual DXGIModeDesc FindClosestMatchingMode( DXGIModeDesc modeToMatch, IUnknown^ concernedDevice );
		virtual void WaitForVBlank();
		virtual void TakeOwnership( IUnknown^ device, bool exclusive );
		virtual void ReleaseOwnership();
		virtual DXGIGammaControlCapabilities GetGammaControlCapabilities();
		virtual void SetGammaControl( DXGIGammaControl gammaControl );
		virtual DXGIGammaControl GetGammaControl();
		virtual void SetDisplaySurface( IDXGISurface^ scanoutSurface );
		virtual void GetDisplaySurfaceData( IDXGISurface^ destination );
		virtual DXGIFrameStatistics GetFrameStatistics();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown )
		{
			return gcnew CDXGIOutput( ( ::IDXGIOutput* )pUnknown.ToPointer() );
		}
	};
}