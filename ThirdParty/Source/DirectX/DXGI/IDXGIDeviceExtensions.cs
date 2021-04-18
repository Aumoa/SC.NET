// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// <see cref="IDXGIDevice"/> 인터페이스 개체에 대한 확장 메서드를 제공합니다.
    /// </summary>
    public static class IDXGIDeviceExtensions
	{
		/// <summary>
		/// 리소스의 메모리 위치를 조회합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="unknowns"> 리소스 목록을 전달합니다. </param>
		/// <returns> 리소스의 위치를 나타내는 열거형 목록을 반환합니다. </returns>
		public static DXGIResidency[] QueryResourceResidency( this IDXGIDevice @this, params IUnknown[] unknowns )
			=> @this.QueryResourceResidency( unknowns );
	}
}
