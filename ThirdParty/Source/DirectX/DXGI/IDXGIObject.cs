// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// 모든 DXGI 개체에 공통으로 제공되는 함수를 표현합니다.
    /// </summary>
    [Guid( "AEC22FB8-76F3-4639-9BE0-28EB43A67A2E" )]
    [ComVisible( true )]
    public interface IDXGIObject : IUnknown
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
        /// 개체의 부모 개체를 가져옵니다.
        /// </summary>
        /// <param name="iid"> 부모 개체의 형식 인터페이스 GUID를 전달합니다. </param>
        /// <param name="ppUnknown"> 개체를 받을 변수의 참조를 전달합니다. </param>
        void GetParent( Guid iid, out IUnknown ppUnknown );
    }
}
