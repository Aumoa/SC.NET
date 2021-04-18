// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	/// <summary>
	/// D3D11 �������̽� ��ü�� �ν��Ͻ�ȭ�� �����ϴ� Ŭ������ ��Ÿ���ϴ�.
	/// </summary>
	public ref class D3D11
	{
	public:
		/// <summary>
		/// COM ���� ��Ҹ� �ʱ�ȭ�մϴ�.
		/// </summary>
		static void CoInitialize();

		/// <summary>
		/// COM ���� ����� ����� �����մϴ�.
		/// </summary>
		static void CoUninitialize();

		/// <summary>
		/// Direct3D ��ġ�� �����մϴ�.
		/// </summary>
		/// <param name="pAdapter"> ����� ��ü�� �����մϴ�. </param>
		/// <param name="driverType"> ����̹� ������ �����մϴ�. �� ������ <see cref="D3DDriverType::Unknown"/> ������ �ƴ� ��� <paramref name="pAdapter"/> �Ű������� ���� �������� �ʾƾ� �մϴ�. </param>
		/// <param name="hSoftware"> ����Ʈ���� ���� ������� ��� ����ü �ڵ��� �����մϴ�. </param>
		/// <param name="flags"> ����̽� ���� �Ӽ��� �����մϴ�. </param>
		/// <param name="featureLevels"> ���� ���� ��� ������ ������������ ������ �����մϴ�. </param>
		/// <param name="featureLevel"> ���õ� ��� ������ ���� ������ ������ �����մϴ�. </param>
		/// <param name="ppImmediateContext"> ��� ����� �����ϴ� ����̽� ���ؽ�Ʈ�� ���� ������ ������ �����մϴ�. </param>
		/// <returns> ������ ��ġ �������̽� ��ü�� ��ȯ�˴ϴ�. </returns>
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
		/// Direct3D ��ġ�� �����մϴ�.
		/// </summary>
		/// <param name="pAdapter"> ����� ��ü�� �����մϴ�. </param>
		/// <param name="flags"> ����̽� ���� �Ӽ��� �����մϴ�. </param>
		/// <param name="ppImmediateContext"> ��� ����� �����ϴ� ����̽� ���ؽ�Ʈ�� ���� ������ ������ �����մϴ�. </param>
		/// <returns> ������ ��ġ �������̽� ��ü�� ��ȯ�˴ϴ�. </returns>
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
		/// Direct3D ��ġ�� �����մϴ�.
		/// </summary>
		/// <param name="pDevice12"> Direct3D12 ��ġ ��ü�� �����մϴ�. </param>
		/// <param name="flags"> ����̽� ���� �Ӽ��� �����մϴ�. </param>
		/// <param name="featureLevels"> ���� ���� ��� ������ ������������ ������ �����մϴ�. </param>
		/// <param name="ppCommandQueues"> ��� ��⿭ ����� �����մϴ�. </param>
		/// <param name="nodeMask"> ��ġ�� ��� ����ũ�� �����մϴ�. </param>
		/// <param name="featureLevel"> ���õ� ��� ������ ���� ������ ������ �����մϴ�. </param>
		/// <param name="ppImmediateContext"> ��� ����� �����ϴ� ����̽� ���ؽ�Ʈ�� ���� ������ ������ �����մϴ�. </param>
		/// <returns> ������ ��ġ �������̽� ��ü�� ��ȯ�˴ϴ�. </returns>
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
		/// Direct3D ��ġ�� �����մϴ�.
		/// </summary>
		/// <param name="pDevice12"> Direct3D12 ��ġ ��ü�� �����մϴ�. </param>
		/// <param name="flags"> ����̽� ���� �Ӽ��� �����մϴ�. </param>
		/// <param name="pCommandQueue"> ��� ��⿭�� �����մϴ�. </param>
		/// <param name="ppImmediateContext"> ��� ����� �����ϴ� ����̽� ���ؽ�Ʈ�� ���� ������ ������ �����մϴ�. </param>
		/// <returns> ������ ��ġ �������̽� ��ü�� ��ȯ�˴ϴ�. </returns>
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