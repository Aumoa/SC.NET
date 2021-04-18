// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D11 스트림 출력 선언 엔트리 정보를 표현합니다.
    /// </summary>
    public struct D3D11SODeclarationEntry
	{
		/// <summary>
		/// 
		/// </summary>
		public uint Stream;

		/// <summary>
		/// 
		/// </summary>
		public string SemanticName;

		/// <summary>
		/// 
		/// </summary>
		public uint SemanticIndex;

		/// <summary>
		/// 
		/// </summary>
		public byte StartComponent;

		/// <summary>
		/// 
		/// </summary>
		public byte ComponentCount;

		/// <summary>
		/// 
		/// </summary>
		public byte OutputSlot;
	}
}
