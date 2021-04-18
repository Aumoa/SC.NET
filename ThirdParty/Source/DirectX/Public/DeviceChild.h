// Copyright 2020-2021 Aumoa.lib. All right reserved.

#pragma once

#include "pch.h"

namespace SC::ThirdParty::DirectX
{
	ref class DeviceBundle;

	/// <summary>
	/// 엔진 개체로부터 생성된 오브젝트를 표현합니다.
	/// </summary>
	public ref class DeviceChild abstract
	{
		DeviceBundle^ _parent;

	internal:
		DeviceChild(DeviceBundle^ parent);

	public:
		~DeviceChild();

		/// <summary>
		/// 디버그 이름을 설정합니다.
		/// </summary>
		/// <param name="name"> 이름 텍스트를 전달합니다. </param>
		virtual void SetDebugName(System::String^ name) abstract;

		/// <summary>
		/// 이 개체를 생성한 부모를 가져옵니다.
		/// </summary>
		/// <returns> 개체가 반환됩니다. </returns>
		DeviceBundle^ GetParent();
		
	internal:
		static void SetDebugNameInternal(ID3D12Object* d3dobj, System::String^ name);
	};
}