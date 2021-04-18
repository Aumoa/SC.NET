// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// <see cref="ID3D12CommandQueue"/> 인터페이스 개체에 대한 확장 메서드를 제공합니다.
    /// </summary>
    public static class ID3D12CommandQueueExtensions
	{
		/// <summary>
		/// 명령 목록을 이 대기열에서 실행합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="commandLists"> 명령 목록 목록을 전달합니다. </param>
		public static void ExecuteCommandLists( this ID3D12CommandQueue @this, params ID3D12CommandList[] commandLists )
			=> @this.ExecuteCommandLists( commandLists );

		/// <summary>
		/// 명령 목록을 이 대기열에서 실행합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="commandLists"> 그래픽 명령 목록 목록을 전달합니다. </param>
		public static void ExecuteCommandLists( this ID3D12CommandQueue @this, params ID3D12GraphicsCommandList[] commandLists )
		{
			var list = new ID3D12CommandList[commandLists.Length];
			for ( int i = 0; i < list.Length; ++i )
			{
				list[i] = commandLists[i];
			}
			@this.ExecuteCommandLists( list );
		}
	}
}
