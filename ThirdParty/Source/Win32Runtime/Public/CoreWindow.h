// Copyright 2020-2021 Aumoa.lib. All right reserved.

#pragma once

#include "Window.h"

namespace SC::ThirdParty::Win32Runtime
{
	ref class Application;

	/// <summary>
	/// 응용 프로그램의 주 대화 창입니다.
	/// </summary>
	public ref class CoreWindow : public Window
	{
	public:
		using Super = Window;

	public:
		/// <summary>
		/// 창이 파괴될 때 호출되는 이벤트의 대리자입니다.
		/// </summary>
		delegate void DestroyDelegate();

	internal:
		static CoreWindow^ _globalItem;

	private:
		Application^ _app;
		void* _handle;
		bool _disposed;

	public:
		/// <summary>
		/// 새 개체를 초기화합니다.
		/// </summary>
		/// <param name="app"> 애플리케이션 개체를 전달합니다. </param>
		/// <param name="title"> 창의 제목을 전달합니다. </param>
		CoreWindow(Application^ app, [System::Runtime::InteropServices::Optional] [System::Runtime::InteropServices::DefaultParameterValue("")] System::String^ title);
		~CoreWindow();

		/// <inheritdoc/>
		void Close() override;

		/// <inheritdoc/>
		System::IntPtr GetHandle() override;

		/// <summary>
		/// 창이 파괴될 때 호출되는 이벤트입니다.
		/// </summary>
		event DestroyDelegate^ Destroy;

	internal:
		void BroadcastDestroy();

	private:
		void* CreateCoreWindow();
		void CheckDisposed();
	};
}