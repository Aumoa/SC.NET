// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    internal class ComRegisterClassException : Exception
	{
        public ComRegisterClassException() : base("DirectX COM 구성 요소를 사용해야 하지만, 구성 요소 DLL이 등록되지 않았습니다.")
        {

        }

		public ComRegisterClassException( Exception innerException ) : base( "DirectX COM 구성 요소를 사용해야 하지만, 구성 요소 DLL이 등록되지 않았습니다.", innerException )
		{

		}
	}
}