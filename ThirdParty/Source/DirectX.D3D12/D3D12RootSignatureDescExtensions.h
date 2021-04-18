// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	/// <summary>
	/// <see cref="D3D12RootSignatureDesc"/> 구조체에 대한 확장 메서드를 제공합니다.
	/// </summary>
	[System::Runtime::CompilerServices::Extension]
	public ref class D3D12RootSignatureDescExtensions abstract sealed
	{
	public:
		/// <summary>
		/// 루트 입력 서명 개체를 직렬화합니다.
		/// </summary>
		/// <param name="_this"> 개체를 전달합니다. </param>
		/// <returns> 직렬화된 데이터 블록이 반환됩니다. </returns>
		[System::Runtime::CompilerServices::Extension]
		static ID3DBlob^ Serialize( D3D12RootSignatureDesc _this );
	};
}