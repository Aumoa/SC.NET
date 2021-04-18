// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// CPU 엑세스에 대한 속성을 나타냅니다.
    /// </summary>
    public enum D3D12CPUPageProperty
	{
		/// <summary>
		/// 알 수 없는 속성을 의미합니다.
		/// </summary>
		Unknown = 0,

		/// <summary>
		/// CPU 엑세스가 지원되지 않음을 의미합니다.
		/// </summary>
		NotAvailable = 1,

		/// <summary>
		/// CPU에서 전송된 데이터가 병합됨을 의미합니다.
		/// </summary>
		WriteCombine = 2,

		/// <summary>
		/// CPU에서 GPU 데이터를 읽을 수 있음을 의미합니다.
		/// </summary>
		WriteBack = 3
	}
}
