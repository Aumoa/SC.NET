// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace SC.ThirdParty.DirectX
{
	/// <summary>
	/// COM 구성 요소의 실제화를 수행하는 메서드의 대리자입니다.
	/// </summary>
	/// <param name="pUnknown"> 네이티브 COM 구성 요소 개체의 핸들이 전달됩니다. </param>
	/// <returns> 생성된 인스턴스 개체가 반환됩니다. </returns>
	public delegate IUnknown CoCreateInstanceDelegate(IntPtr pUnknown);

	/// <summary>
	/// COM 구성 요소에서 필요한 기본 기능을 제공합니다.
	/// </summary>
	[Guid( "65627D0C-3B28-4550-8604-4EFFA8FCA9A5" )]
	[ComVisible( true )]
	public abstract class ComObject : IUnknown
	{
		long @ref;

		/// <summary>
		/// <see cref="ComObject"/> 클래스의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="handle"> 개체의 네이티브 핸들 값을 전달합니다. </param>
		public ComObject( IntPtr handle )
		{
			this.Handle = handle;

			AddRef();
		}

		/// <summary>
		/// 
		/// </summary>
		~ComObject()
		{
			Dispose();
		}

		/// <summary>
		/// 개체의 참조 횟수를 1회 감소시킵니다.
		/// </summary>
		public virtual void Dispose()
		{
			Release();
		}

		/// <summary>
		/// 개체의 참조 횟수를 1회 증가시킵니다.
		/// </summary>
		/// <returns> 개체의 현재 참조 횟수가 반환됩니다. </returns>
		public virtual long AddRef()
		{
			return Interlocked.Increment( ref @ref );
		}

		/// <summary>
		/// 개체의 참조 횟수를 1회 감소시킵니다.
		/// </summary>
		/// <returns> 개체의 현재 참조 횟수가 반환됩니다. </returns>
		public virtual long Release()
		{
			var @return = Interlocked.Decrement( ref @ref );
			if ( @return == 0 && !IsDisposed )
			{
				OnDisposing();
				IsDisposed = true;
			}

			return @return;
		}

		/// <summary>
		/// 사용 가능한 대상 인터페이스 개체를 조회합니다.
		/// </summary>
		/// <param name="iid"> 대상 인터페이스의 GUID를 전달합니다. </param>
		/// <param name="ppUnknown"> 인터페이스 개체를 받을 변수의 참조를 전달합니다. </param>
		/// <exception cref="NotSupportedException"> 요청한 GUID가 지원되지 않는 인터페이스를 나타내는 경우 발생합니다. </exception>
		public virtual void QueryInterface( Guid iid, out IUnknown ppUnknown )
		{
			if ( iid == typeof( ComObject ).GUID )
			{
				ppUnknown = this;
			}
			else if ( iid == typeof( IUnknown ).GUID )
			{
				ppUnknown = this;
			}
			else
			{
				ppUnknown = null;
				throw new NotSupportedException();
			}
		}

		/// <summary>
		/// 개체의 네이티브 핸들 값을 가져옵니다.
		/// </summary>
		public IntPtr Handle { get; }

		/// <summary>
		/// 개체가 종료되었는지 여부를 가져옵니다.
		/// </summary>
		public bool IsDisposed { get; private set; }

		/// <summary>
		/// 개체의 참조 횟수가 0이 되어 제거될 때 호출됩니다.
		/// </summary>
		protected abstract void OnDisposing();

		static Dictionary<Guid, CoCreateInstanceDelegate> coCreateInstanceDelegates = new Dictionary<Guid, CoCreateInstanceDelegate>();

		/// <summary>
		/// COM 구성 요소 클래스를 등록합니다.
		/// </summary>
		/// <param name="clsid"> 인터페이스 GUID를 전달합니다. </param>
		/// <param name="coCreateInstance"> 대리자 함수를 전달합니다. </param>
		public static void RegisterCLSID( Guid clsid, CoCreateInstanceDelegate coCreateInstance )
			=> coCreateInstanceDelegates.Add( clsid, coCreateInstance );

		/// <summary>
		/// COM 구성 요소 클래스를 등록합니다.
		/// </summary>
		/// <typeparam name="T"> 등록을 해제할 인터페이스 유형을 전달합니다. </typeparam>
		/// <param name="coCreateInstance"> 대리자 함수를 전달합니다. </param>
		public static void RegisterCLSID<T>( CoCreateInstanceDelegate coCreateInstance )
			=> RegisterCLSID( typeof( T ).GUID, coCreateInstance );

		/// <summary>
		/// COM 구성 요소 클래스의 등록을 해제합니다.
		/// </summary>
		/// <param name="clsid"> 인터페이스 GUID를 전달합니다. </param>
		public static void UnregisterCLSID( Guid clsid )
			=> coCreateInstanceDelegates.Remove( clsid );

		/// <summary>
		/// COM 구성 요소 클래스의 등록을 해제합니다.
		/// </summary>
		/// <typeparam name="T"> 등록을 해제할 인터페이스 유형을 전달합니다. </typeparam>
		public static void UnregisterCLSID<T>()
			=> UnregisterCLSID( typeof( T ).GUID );

		/// <summary>
		/// COM 구성 요소를 인스턴스화합니다.
		/// </summary>
		/// <param name="clsid"> 인터페이스 GUID를 전달합니다. </param>
		/// <param name="pUnknown"> 네이티브 COM 구성 요소 개체의 핸들을 전달합니다. </param>
		/// <returns> 생성된 인스턴스 개체가 반환됩니다. </returns>
		public static IUnknown CoCreateInstance( Guid clsid, IntPtr pUnknown )
		{
			if ( coCreateInstanceDelegates.ContainsKey( clsid ) )
			{
				return coCreateInstanceDelegates[clsid]( pUnknown );
			}
			else
			{
				throw new ComRegisterClassException();
			}
		}

		/// <summary>
		/// COM 구성 요소를 인스턴스화합니다.
		/// </summary>
		/// <param name="clsid"> 인터페이스 GUID를 전달합니다. </param>
		/// <returns> 생성된 인스턴스 개체가 반환됩니다. </returns>
		public static IUnknown CoCreateInstance( Guid clsid )
			=> CoCreateInstance( clsid, IntPtr.Zero );

		/// <summary>
		/// COM 구성 요소를 인스턴스화합니다.
		/// </summary>
		/// <typeparam name="T"> 인터페이스 유형을 전달합니다. </typeparam>
		/// <param name="pUnknown"> 네이티브 COM 구성 요소 개체의 핸들을 전달합니다. </param>
		/// <returns> 생성된 인스턴스 개체가 반환됩니다. </returns>
		public static T CoCreateInstance<T>( IntPtr pUnknown ) where T : class
		{
			var pUnk = CoCreateInstance( typeof( T ).GUID, pUnknown );
			return pUnk as T;
		}

		/// <summary>
		/// COM 구성 요소를 인스턴스화합니다.
		/// </summary>
		/// <typeparam name="T"> 인터페이스 유형을 전달합니다. </typeparam>
		/// <returns> 생성된 인스턴스 개체가 반환됩니다. </returns>
		public static T CoCreateInstance<T>() where T : class
			=> CoCreateInstance<T>( IntPtr.Zero );

		/// <summary>
		/// HRESULT 코드를 이용해 코드 내용에 따른 예외를 생성합니다.
		/// </summary>
		/// <param name="hResult"> 네이티브 HRESULT 코드를 전달합니다. </param>
		public static void HR( int hResult )
		{
			unchecked
			{
				if ( hResult < 0 )
				{
					uint hr = ( uint )hResult;
					throw hr switch
					{
						E_INVALIDARG => new ArgumentException( $"{nameof( E_INVALIDARG )}(0x{E_INVALIDARG:X8}): One or more arguments are invalid." ),
						DXGI_ERROR_INVALID_CALL => new InvalidOperationException( $"{nameof( DXGI_ERROR_INVALID_CALL )}(0x{DXGI_ERROR_INVALID_CALL:X8}): The application provided invalid parameter data; this must be debugged and fixed before the application is released." ),
						E_NOINTERFACE => new NotSupportedException( $"{nameof( DXGI_ERROR_DEVICE_REMOVED )}(0x{DXGI_ERROR_DEVICE_REMOVED:X8}): No such interface supported" ),
						DXGI_ERROR_DEVICE_REMOVED => new Exception( $"{nameof( DXGI_ERROR_DEVICE_REMOVED )}(0x{DXGI_ERROR_DEVICE_REMOVED:X8}): The GPU device instance has been suspended. Use GetDeviceRemovedReason to determine the appropriate action." ),
						D2DERR_WRONG_STATE => new Exception( $"{nameof( D2DERR_WRONG_STATE )}(0x{D2DERR_WRONG_STATE:X8}): The object was not in the correct state to process the method." ),
						ERROR_PATH_NOT_FOUND => new FileNotFoundException( $"{nameof( ERROR_PATH_NOT_FOUND )}(0x{ERROR_PATH_NOT_FOUND:X8}): The system cannot find the path specified." ),
						ERROR_FILE_NOT_FOUND => new FileNotFoundException( $"{nameof( ERROR_FILE_NOT_FOUND )}(0x{ERROR_FILE_NOT_FOUND:X8}): The system cannot find the file specified." ),
						_ => new Exception( $"0x{hResult:X8}: Unknown HRESULT exception." )
					};
				}
			}
		}

		const uint S_OK = 0x00000000;
		const uint E_INVALIDARG = 0x80070057;
		const uint DXGI_ERROR_INVALID_CALL = 0x887A0001;
		const uint E_NOINTERFACE = 0x80004002;
		const uint DXGI_ERROR_DEVICE_REMOVED = 0x887A0005;
		const uint D2DERR_WRONG_STATE = 0x88990001;
		const uint ERROR_PATH_NOT_FOUND = 0x80070003;
		const uint ERROR_FILE_NOT_FOUND = 0x80070002;
	}
}
