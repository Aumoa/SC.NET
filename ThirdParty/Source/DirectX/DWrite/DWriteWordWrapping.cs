// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DWrite 단어 래핑 방식을 표현합니다.
    /// </summary>
    public enum DWriteWordWrapping
	{
		/// <summary>
		/// 텍스트가 레이아웃의 경계를 넘지 않도록 단어가 여러 줄로 나뉩니다.
		/// </summary>
		Wrap = 0,

		/// <summary>
		/// <para> 텍스트가 레이아웃의 경계를 넘더라도 단어는 같은 줄에 유지됩니다. </para>
		/// <para> 이 옵션은 경계를 넘는 텍스트를 표시하기 위해 스크롤과 함께 주로 사용됩니다. </para>
		/// </summary>
		NoWrap = 1,

		/// <summary>
		/// <para> 텍스트가 레이아웃의 경계를 넘지 않도록 단어가 여러 줄로 나뉩니다. </para>
		/// <para> 단어가 최대 너비보다 큰 경우 긴급 줄 바꿈 알고리즘이 적용됩니다. </para>
		/// </summary>
		EmergencyBreak = 2,

		/// <summary>
		/// 
		/// </summary>
		WholeWord = 3,

		/// <summary>
		/// 유효한 문자 단위로 래핑합니다.
		/// </summary>
		Character = 4,
	}
}
