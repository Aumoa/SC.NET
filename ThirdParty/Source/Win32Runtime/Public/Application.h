// Copyright 2020-2021 Aumoa.lib. All right reserved.

#pragma once

#include "IPlatformHandle.h"

namespace SC::ThirdParty::Win32Runtime
{
	ref class CoreWindow;

	/// <summary>
	/// 애플리케이션을 정의합니다.
	/// </summary>
	public ref class Application : public IPlatformHandle
	{
	public:
		using Super = System::Object;

		/// <summary>
		/// 애플리케이션이 초기화될 때 호출되는 이벤트의 대리자입니다.
		/// </summary>
		delegate void InitializeDelegate();

		/// <summary>
		/// 애플리케이션이 종료될 때 호출되는 이벤트의 대리자입니다.
		/// </summary>
		delegate void ShutdownDelegate();

		/// <summary>
		/// 애플리케이션이 메시지를 처리하지 않는 유휴 시간동안 호출되는 이벤트의 대리자입니다.
		/// </summary>
		delegate void IdleDelegate();


	private:
		bool _disposed;
		void* _handle;

	public:
		/// <summary>
		/// 개체를 초기화합니다.
		/// </summary>
		Application();
		~Application();

		/// <inheritdoc/>
		virtual void Close();

		/// <inheritdoc/>
		virtual System::IntPtr GetHandle();

		/// <summary>
		/// 애플리케이션의 주 루프를 실행합니다.
		/// </summary>
		/// <param name="dialog"> 애플리케이션이 표시하는 주 대화 상자를 나타냅니다. </param>
		void Run(CoreWindow^ dialog);

		/// <summary>
		/// 애플리케이션이 초기화될 때 호출되는 이벤트입니다.
		/// </summary>
		event InitializeDelegate^ Initialize;

		/// <summary>
		/// 애플리케이션이 종료될 때 호출되는 이벤트입니다.
		/// </summary>
		event ShutdownDelegate^ Shutdown;

		/// <summary>
		/// 애플리케이션이 메시지를 처리하지 않는 유휴 시간동안 호출되는 이벤트입니다.
		/// </summary>
		event IdleDelegate^ Idle;

	private:
		void CheckDisposed();
	};
}