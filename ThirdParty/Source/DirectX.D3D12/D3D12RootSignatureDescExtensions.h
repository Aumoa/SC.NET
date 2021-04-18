// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	/// <summary>
	/// <see cref="D3D12RootSignatureDesc"/> ����ü�� ���� Ȯ�� �޼��带 �����մϴ�.
	/// </summary>
	[System::Runtime::CompilerServices::Extension]
	public ref class D3D12RootSignatureDescExtensions abstract sealed
	{
	public:
		/// <summary>
		/// ��Ʈ �Է� ���� ��ü�� ����ȭ�մϴ�.
		/// </summary>
		/// <param name="_this"> ��ü�� �����մϴ�. </param>
		/// <returns> ����ȭ�� ������ ����� ��ȯ�˴ϴ�. </returns>
		[System::Runtime::CompilerServices::Extension]
		static ID3DBlob^ Serialize( D3D12RootSignatureDesc _this );
	};
}