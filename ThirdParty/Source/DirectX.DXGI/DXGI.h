// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	/// <summary>
	/// DXGI �������̽� ��ü�� �ν��Ͻ�ȭ�� �����ϴ� Ŭ������ ��Ÿ���ϴ�.
	/// </summary>
	public ref class DXGI
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
	};
}