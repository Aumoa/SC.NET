// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	/// <summary>
	/// D3D11 인터페이스 개체의 인스턴스화를 수행하는 클래스를 나타냅니다.
	/// </summary>
	public ref class D3D11
	{
	public:
		/// <summary>
		/// COM 구성 요소를 초기화합니다.
		/// </summary>
		static void CoInitialize();

		/// <summary>
		/// COM 구성 요소의 사용을 종료합니다.
		/// </summary>
		static void CoUninitialize();

		/// <summary>
		/// Direct3D 장치를 생성합니다.
		/// </summary>
		/// <param name="pAdapter"> 어댑터 개체를 전달합니다. </param>
		/// <param name="driverType"> 드라이버 유형을 전달합니다. 이 유형이 <see cref="D3DDriverType::Unknown"/> 형식이 아닐 경우 <paramref name="pAdapter"/> 매개변수에 값을 지정하지 않아야 합니다. </param>
		/// <param name="hSoftware"> 소프트웨어 구현 어댑터일 경우 구현체 핸들을 전달합니다. </param>
		/// <param name="flags"> 디바이스 생성 속성을 전달합니다. </param>
		/// <param name="featureLevels"> 지원 가능 기능 레벨을 오름차순으로 정렬해 전달합니다. </param>
		/// <param name="featureLevel"> 선택된 기능 레벨을 받을 변수의 참조를 전달합니다. </param>
		/// <param name="ppImmediateContext"> 즉시 명령을 전송하는 디바이스 컨텍스트를 받을 변수의 참조를 전달합니다. </param>
		/// <returns> 생성된 장치 인터페이스 개체가 반환됩니다. </returns>
		static ID3D11Device^ D3D11CreateDevice(
			IDXGIAdapter^ pAdapter,
			D3DDriverType driverType,
			WinAPI::IPlatformHandle^ hSoftware,
			D3D11CreateDeviceFlags flags,
			System::Collections::Generic::IList<D3DFeatureLevel>^ featureLevels,
			[System::Runtime::InteropServices::Out] D3DFeatureLevel% featureLevel,
			[System::Runtime::InteropServices::Out] ID3D11DeviceContext^% ppImmediateContext
		);

		/// <summary>
		/// Direct3D 장치를 생성합니다.
		/// </summary>
		/// <param name="pAdapter"> 어댑터 개체를 전달합니다. </param>
		/// <param name="flags"> 디바이스 생성 속성을 전달합니다. </param>
		/// <param name="ppImmediateContext"> 즉시 명령을 전송하는 디바이스 컨텍스트를 받을 변수의 참조를 전달합니다. </param>
		/// <returns> 생성된 장치 인터페이스 개체가 반환됩니다. </returns>
		static ID3D11Device^ D3D11CreateDevice(
			IDXGIAdapter^ pAdapter,
			D3D11CreateDeviceFlags flags,
			[System::Runtime::InteropServices::Out] ID3D11DeviceContext^% ppImmediateContext
		)
		{
			D3DFeatureLevel _;
			return D3D11CreateDevice( pAdapter, D3DDriverType::Unknown, nullptr, flags, nullptr, _, ppImmediateContext );
		}

		/// <summary>
		/// Direct3D 장치를 생성합니다.
		/// </summary>
		/// <param name="pDevice12"> Direct3D12 장치 개체를 전달합니다. </param>
		/// <param name="flags"> 디바이스 생성 속성을 전달합니다. </param>
		/// <param name="featureLevels"> 지원 가능 기능 레벨을 오름차순으로 정렬해 전달합니다. </param>
		/// <param name="ppCommandQueues"> 명령 대기열 목록을 전달합니다. </param>
		/// <param name="nodeMask"> 장치의 노드 마스크를 전달합니다. </param>
		/// <param name="featureLevel"> 선택된 기능 레벨을 받을 변수의 참조를 전달합니다. </param>
		/// <param name="ppImmediateContext"> 즉시 명령을 전송하는 디바이스 컨텍스트를 받을 변수의 참조를 전달합니다. </param>
		/// <returns> 생성된 장치 인터페이스 개체가 반환됩니다. </returns>
		static ID3D11Device^ D3D11On12CreateDevice(
			IUnknown^ pDevice12,
			D3D11CreateDeviceFlags flags,
			System::Collections::Generic::IList<D3DFeatureLevel>^ featureLevels,
			System::Collections::Generic::IList<IUnknown^>^ ppCommandQueues,
			uint_ nodeMask,
			[System::Runtime::InteropServices::Out] D3DFeatureLevel% featureLevel,
			[System::Runtime::InteropServices::Out] ID3D11DeviceContext^% ppImmediateContext
		);

		/// <summary>
		/// Direct3D 장치를 생성합니다.
		/// </summary>
		/// <param name="pDevice12"> Direct3D12 장치 개체를 전달합니다. </param>
		/// <param name="flags"> 디바이스 생성 속성을 전달합니다. </param>
		/// <param name="pCommandQueue"> 명령 대기열을 전달합니다. </param>
		/// <param name="ppImmediateContext"> 즉시 명령을 전송하는 디바이스 컨텍스트를 받을 변수의 참조를 전달합니다. </param>
		/// <returns> 생성된 장치 인터페이스 개체가 반환됩니다. </returns>
		static ID3D11Device^ D3D11On12CreateDevice(
			IUnknown^ pDevice12,
			D3D11CreateDeviceFlags flags,
			IUnknown^ pCommandQueue,
			[System::Runtime::InteropServices::Out] ID3D11DeviceContext^% ppImmediateContext
		)
		{
			auto ppCommandQueues = gcnew cli::array<IUnknown^>( 1 )
			{
				pCommandQueue
			};

			D3DFeatureLevel _;
			return D3D11On12CreateDevice(
				pDevice12,
				flags,
				nullptr,
				( System::Collections::Generic::IList<IUnknown^>^ )ppCommandQueues,
				0,
				_,
				ppImmediateContext
			);
		}
	};
}