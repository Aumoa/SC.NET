// Copyright 2020 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;
using SC.ThirdParty.WinAPI;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI 출력 디스플레이 정보를 서술합니다.
    /// </summary>
    public struct DXGIOutputDesc
	{
		/// <summary>
		/// 장치 이름을 표현합니다.
		/// </summary>
		public string DeviceName;

		/// <summary>
		/// 장치의 바탕화면 좌표를 표현합니다.
		/// </summary>
		public Rectangle DesktopCoordinates;

		/// <summary>
		/// 바탕화면을 사용하는지 여부를 표현합니다.
		/// </summary>
		public bool AttachedToDesktop;

		/// <summary>
		/// 회전 각도를 표현합니다.
		/// </summary>
		public DXGIModeRotation Rotation;

		/// <summary>
		/// Windows 모니터 핸들을 표현합니다.
		/// </summary>
		public IPlatformHandle Monitor;

		/// <summary>
		/// 구조체의 간단한 텍스트 형식을 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public override string ToString()
		{
			return string.Format( "{0}: {1}, DesktopCoordinates: {2}", base.ToString(), DeviceName, DesktopCoordinates );
		}
	}
}
