// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// <see cref="DXGIFormat"/> 열거형의 확장 메서드를 제공합니다.
    /// </summary>
    public static class DXGIFormatExtensions
	{
		/// <summary>
		/// 해당 형식의 바이트 단위 크기를 가져옵니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <returns> 바이트 단위 크기가 반환됩니다. </returns>
		/// <exception cref="ArgumentException"> 형식이 크기를 가질 수 없는 형식일 경우 발생합니다. </exception>
		public static uint GetSizeInBytes( this DXGIFormat @this )
			=> @this switch
			{
				DXGIFormat.R32G32B32A32_TYPELESS => 16,
				DXGIFormat.R32G32B32A32_FLOAT => 16,
				DXGIFormat.R32G32B32A32_UINT => 16,
				DXGIFormat.R32G32B32A32_SINT => 16,
				DXGIFormat.R32G32B32_TYPELESS => 12,
				DXGIFormat.R32G32B32_FLOAT => 12,
				DXGIFormat.R32G32B32_UINT => 12,
				DXGIFormat.R32G32B32_SINT => 12,
				DXGIFormat.R16G16B16A16_TYPELESS => 8,
				DXGIFormat.R16G16B16A16_FLOAT => 8,
				DXGIFormat.R16G16B16A16_UNORM => 8,
				DXGIFormat.R16G16B16A16_UINT => 8,
				DXGIFormat.R16G16B16A16_SNORM => 8,
				DXGIFormat.R16G16B16A16_SINT => 8,
				DXGIFormat.R32G32_TYPELESS => 8,
				DXGIFormat.R32G32_FLOAT => 8,
				DXGIFormat.R32G32_UINT => 8,
				DXGIFormat.R32G32_SINT => 8,
				DXGIFormat.R8G8B8A8_UNORM => 4,
				DXGIFormat.R8G8B8A8_UNORM_SRGB => 4,
				DXGIFormat.R8G8B8A8_UINT => 4,
				DXGIFormat.R8G8B8A8_SNORM => 4,
				DXGIFormat.R8G8B8A8_SINT => 4,
				DXGIFormat.R16G16_TYPELESS => 4,
				DXGIFormat.R16G16_FLOAT => 4,
				DXGIFormat.R16G16_UNORM => 4,
				DXGIFormat.R16G16_UINT => 4,
				DXGIFormat.R16G16_SNORM => 4,
				DXGIFormat.R16G16_SINT => 4,
				DXGIFormat.R32_TYPELESS => 4,
				DXGIFormat.R32_FLOAT => 4,
				DXGIFormat.R32_UINT => 4,
				DXGIFormat.R32_SINT => 4,
				DXGIFormat.R8G8_TYPELESS => 2,
				DXGIFormat.R8G8_UNORM => 2,
				DXGIFormat.R8G8_UINT => 2,
				DXGIFormat.R8G8_SNORM => 2,
				DXGIFormat.R8G8_SINT => 2,
				DXGIFormat.R16_TYPELESS => 2,
				DXGIFormat.R16_FLOAT => 2,
				DXGIFormat.R16_UNORM => 2,
				DXGIFormat.R16_UINT => 2,
				DXGIFormat.R16_SNORM => 2,
				DXGIFormat.R16_SINT => 2,
				DXGIFormat.R8_TYPELESS => 1,
				DXGIFormat.R8_UNORM => 1,
				DXGIFormat.R8_UINT => 1,
				DXGIFormat.R8_SNORM => 1,
				DXGIFormat.R8_SINT => 1,
				DXGIFormat.A8_UNORM => 1,
				DXGIFormat.B8G8R8A8_UNORM => 4,
				DXGIFormat.B8G8R8A8_TYPELESS => 4,
				DXGIFormat.B4G4R4A4_UNORM => 2,
				_ => throw new ArgumentException( "크기를 측정할 수 없는 DXGIFormat 형식입니다." )
			};
	}
}
