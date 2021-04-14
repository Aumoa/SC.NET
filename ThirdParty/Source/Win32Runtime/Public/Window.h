// Copyright 2020-2021 Aumoa.lib. All right reserved.

#pragma once

#include "IPlatformHandle.h"

namespace SC::ThirdParty::Win32Runtime
{
	/// <summary>
	/// 창 개체를 표현합니다.
	/// </summary>
	public ref class Window abstract : public IPlatformHandle
	{
	public:
		using Super = System::Object;

	public:
		/// <summary>
		/// 새 개체를 초기화합니다.
		/// </summary>
		Window();

		/// <inheritdoc/>
		virtual void Close() = 0;

		/// <inheritdoc/>
		virtual System::IntPtr GetHandle() = 0;

		/// <summary>
		/// 창의 타이틀을 설정하거나 가져옵니다.
		/// </summary>
		property System::String^ Title
		{
			System::String^ get();
			void set(System::String^ value);
		}

		/// <summary>
		/// 창의 보이기 상태를 설정하거나 가져옵니다.
		/// </summary>
		property bool IsVisible
		{
			bool get();
			void set(bool value);
		}
	};
}