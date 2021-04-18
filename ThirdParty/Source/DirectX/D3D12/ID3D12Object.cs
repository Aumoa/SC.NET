// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 API에서 사용되는 개체에 대한 공통 함수를 제공합니다.
    /// </summary>
    [Guid( "C4FEC28F-7966-4E95-9F94-F431CB56C3B8" )]
    [ComVisible( true )]
	public interface ID3D12Object : IUnknown
    {
        /// <summary>
        /// GUID를 이름으로 하여 개체에 개인 데이터를 연결합니다.
        /// </summary>
        /// <param name="iid"> 식별 GUID를 전달합니다. </param>
        /// <param name="data"> 데이터 개체를 전달합니다. </param>
        void SetPrivateData( Guid iid, object data );

        /// <summary>
        /// 개체에 연결된 개인 데이터를 GUID 이름으로 가져옵니다.
        /// </summary>
        /// <param name="iid"> 식별 GUID를 전달합니다. </param>
        /// <returns> 개체가 존재할 경우 개체를, 존재하지 않을 경우 null을 반환합니다. </returns>
        object GetPrivateData( Guid iid );

        /// <summary>
        /// 개체의 디버그 이름을 설정합니다.
        /// </summary>
        /// <param name="name"> 이름을 전달합니다. </param>
        void SetName( string name );
    }
}
