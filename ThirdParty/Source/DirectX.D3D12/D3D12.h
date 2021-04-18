// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	/// <summary>
	/// D3D12 �������̽� ��ü�� �ν��Ͻ�ȭ�� �����ϴ� Ŭ������ ��Ÿ���ϴ�.
	/// </summary>
	public ref class D3D12
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
		/// D3D12 ��ġ ��ü�� �����մϴ�.
		/// </summary>
		/// <param name="pAdapter"> ��ġ�� ����� ���� ����͸� �����մϴ�. null�� ������ ��� �⺻ ����͸� ����մϴ�. </param>
		/// <param name="minimumFeatureLevel"> �ʿ��� �ּ� ��� ������ �����մϴ�. ������ ���� ���� ������ ���Ǹ�, �ʿ��� ����� �������� ���� ��� ��ġ ������ �����մϴ�. </param>
		/// <returns> ������ ��ġ ��ü�� ��ȯ�˴ϴ�. </returns>
		static ID3D12Device^ D3D12CreateDevice( IUnknown^ pAdapter, D3DFeatureLevel minimumFeatureLevel );

		/// <summary>
		/// ��Ʈ ���� ��ü�� ����ȭ�մϴ�.
		/// </summary>
		/// <param name="rootSignature"> �Է� ���� ��ü�� ���� ���� ���� ����ü�� �����մϴ�. </param>
		/// <returns> ����ȭ�� ������ ��� ��ü�� ��ȯ�˴ϴ�. </returns>
		static ID3DBlob^ D3D12SerializeRootSignature( D3D12RootSignatureDesc rootSignature );
	};
}