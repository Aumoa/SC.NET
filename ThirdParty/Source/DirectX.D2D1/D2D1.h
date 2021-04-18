// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	/// <summary>
	/// D2D1 �������̽� ��ü�� �ν��Ͻ�ȭ�� �����ϴ� Ŭ������ ��Ÿ���ϴ�.
	/// </summary>
	public ref class D2D1
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
		/// D2D1 ��ġ ��ü�� �����մϴ�.
		/// </summary>
		/// <param name="dxgiDevice"> DXGI ��ġ ��ü�� �����մϴ�. </param>
		/// <param name="creationProperties"> ��ġ�� ���� �Ӽ��� �����մϴ�. </param>
		/// <returns> ������ ��ġ ��ü�� ��ȯ�˴ϴ�. </returns>
		static ID2D1Device^ D2D1CreateDevice( IDXGIDevice^ dxgiDevice, D2D1CreationProperties creationProperties );
	};
}