// Copyright 2020-2021 Aumoa.lib. All right reserved.

#pragma once

#include "pch.h"

namespace SC::ThirdParty::WindowsCodecs
{
	enum class ImagePixelFormat;

	/// <summary>
	/// 이미지 개체에 대한 공통 함수를 제공합니다.
	/// </summary>
	public ref class Image abstract : public System::Object
	{
		using Super = System::Object;

	internal:
		IWICBitmapSource* _source;

		int _width;
		int _height;
		int _bitsPerPixel;
		ImagePixelFormat _format;

	internal:
		void CalcFormat();

	public:
		/// <summary>
		/// 개체를 초기화합니다.
		/// </summary>
		Image();

		/// <summary>
		/// 대상 버퍼로 픽셀 데이터를 복사합니다.
		/// </summary>
		/// <param name="copyRect"> 복사 영역을 전달합니다. </param>
		/// <param name="rowStride"> 행 바이트 수를 전달합니다. </param>
		/// <param name="bufferSize"> 버퍼 크기를 전달합니다. </param>
		/// <param name="buffer"> 버퍼 위치를 전달합니다. </param>
		virtual void CopyPixels(System::Nullable<System::Drawing::Rectangle> copyRect, int rowStride, int bufferSize, System::IntPtr buffer);

		/// <summary>
		/// 대상 버퍼로 픽셀 데이터를 복사합니다.
		/// </summary>
		/// <param name="rowStride"> 행 바이트 수를 전달합니다. </param>
		/// <param name="bufferSize"> 버퍼 크기를 전달합니다. </param>
		/// <param name="buffer"> 버퍼 위치를 전달합니다. </param>
		void CopyPixels(int rowStride, int bufferSize, System::IntPtr buffer) { CopyPixels({}, rowStride, bufferSize, buffer); }

		/// <summary>
		/// 대상 버퍼로 픽셀 데이터를 복사합니다.
		/// </summary>
		/// <param name="rowStride"> 행 바이트 수를 전달합니다. </param>
		/// <param name="buffer"> 버퍼 위치를 전달합니다. </param>
		void CopyPixels(int rowStride, System::IntPtr buffer) { CopyPixels(rowStride, rowStride * (_height - 1) + _bitsPerPixel * _width, buffer); }

		/// <summary>
		/// 이미지의 픽셀 단위 너비를 가져옵니다.
		/// </summary>
		property int Width { int get() { return _width; } }

		/// <summary>
		/// 이미지의 픽셀 단위 높이를 가져옵니다.
		/// </summary>
		property int Height { int get() { return _height; } }

		/// <summary>
		/// 이미지 픽셀 형식을 가져옵니다.
		/// </summary>
		property ImagePixelFormat PixelFormat { ImagePixelFormat get() { return _format; } }
	};
}