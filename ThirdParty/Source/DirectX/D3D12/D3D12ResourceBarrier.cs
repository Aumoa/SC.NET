// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 자원 상태 장벽을 표현합니다.
    /// </summary>
    public struct D3D12ResourceBarrier
	{
		ValueType valueType;

		/// <summary>
		/// 자원 장벽 유형을 나타냅니다.
		/// </summary>
		public D3D12ResourceBarrierType Type;

		/// <summary>
		/// 자원 장벽 속성을 나타냅니다.
		/// </summary>
		public D3D12ResourceBarrierFlags Flags;

		/// <summary>
		/// 자원 상태 전이 장벽을 나타냅니다. <see cref="D3D12ResourceBarrierType.Transition"/> 유형일 경우 사용됩니다.
		/// </summary>
		public D3D12ResourceTransitionBarrier Transition
		{
			get
			{
				if ( valueType is D3D12ResourceTransitionBarrier t )
				{
					return t;
				}
				else
				{
					if ( valueType == null )
					{
						var v = new D3D12ResourceTransitionBarrier();
						valueType = v;
						return v;
					}
					else
					{
						throw new InvalidCastException();
					}
				}
			}
			set
			{
				Type = D3D12ResourceBarrierType.Transition;
				valueType = value;
			}
		}

		/// <summary>
		/// 자원 앨리어싱 장벽을 나타냅니다. <see cref="D3D12ResourceBarrierType.Aliasing"/> 유형일 경우 사용됩니다.
		/// </summary>
		public D3D12ResourceAliasingBarrier Aliasing
		{
			get
			{
				if ( valueType is D3D12ResourceAliasingBarrier t )
				{
					return t;
				}
				else
				{
					if ( valueType == null )
					{
						var v = new D3D12ResourceAliasingBarrier();
						valueType = v;
						return v;
					}
					else
					{
						throw new InvalidCastException();
					}
				}
			}
			set
			{
				Type = D3D12ResourceBarrierType.Aliasing;
				valueType = value;
			}
		}

		/// <summary>
		/// 순서없는 접근 자원 장벽을 나타냅니다. <see cref="D3D12ResourceBarrierType.UAV"/> 유형일 경우 사용됩니다.
		/// </summary>
		public D3D12ResourceUAVBarrier UAV
		{
			get
			{
				if ( valueType is D3D12ResourceUAVBarrier t )
				{
					return t;
				}
				else
				{
					if ( valueType == null )
					{
						var v = new D3D12ResourceUAVBarrier();
						valueType = v;
						return v;
					}
					else
					{
						throw new InvalidCastException();
					}
				}
			}
			set
			{
				Type = D3D12ResourceBarrierType.UAV;
				valueType = value;
			}
		}

		/// <summary>
		/// <see cref="D3D12ResourceBarrier"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="transition"> 상태 전이 장벽을 전달합니다. </param>
		public D3D12ResourceBarrier( D3D12ResourceTransitionBarrier transition )
		{
			this.Type = D3D12ResourceBarrierType.Transition;
			this.Flags = D3D12ResourceBarrierFlags.None;
			this.valueType = transition;
		}

		/// <summary>
		/// <see cref="D3D12ResourceBarrier"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="aliasing"> 앨리어싱 장벽을 전달합니다. </param>
		public D3D12ResourceBarrier( D3D12ResourceAliasingBarrier aliasing )
		{
			this.Type = D3D12ResourceBarrierType.Transition;
			this.Flags = D3D12ResourceBarrierFlags.None;
			this.valueType = aliasing;
		}

		/// <summary>
		/// <see cref="D3D12ResourceBarrier"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="uav"> 순서없는 접근 장벽을 전달합니다. </param>
		public D3D12ResourceBarrier( D3D12ResourceUAVBarrier uav )
		{
			this.Type = D3D12ResourceBarrierType.Transition;
			this.Flags = D3D12ResourceBarrierFlags.None;
			this.valueType = uav;
		}

		/// <summary>
		/// 구조체의 간단한 텍스트 형식을 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public override string ToString()
		{
			return string.Format( "{0}: Type = {1}, Barrier = {2}", base.ToString(), Type, valueType );
		}

		/// <summary>
		/// 자원의 변환 이전 상태와 이후 상태를 교환합니다. 이 메서드는 <see cref="D3D12ResourceBarrierType.Transition"/> 또는 <see cref="D3D12ResourceBarrierType.Aliasing"/> 일 경우에만 작동합니다.
		/// </summary>
		/// <returns> 교환에 성공하였을 경우 true를, 아닐 경우 false를 반환합니다. </returns>
		public bool Swap()
		{
			switch ( Type )
			{
				case D3D12ResourceBarrierType.Transition:
					var t = Transition;
					t.Swap();
					Transition = t;
					return true;
				case D3D12ResourceBarrierType.Aliasing:
					var a = Aliasing;
					a.Swap();
					Aliasing = a;
					return true;
			}

			return false;
		}

		/// <summary>
		/// 자원 상태 전이 배리어 구조체를 생성합니다.
		/// </summary>
		/// <param name="pResource"> 자원을 전달합니다. </param>
		/// <param name="stateBefore"> 변경 이전 상태를 전달합니다. </param>
		/// <param name="stateAfter"> 변경 이후 상태를 전달합니다. </param>
		/// <param name="subresourceIndex"> 서브리소스 인덱스를 전달합니다. </param>
		/// <returns> 생성된 구조체가 반환됩니다.</returns>
		public static D3D12ResourceBarrier TransitionBarrier( ID3D12Resource pResource, D3D12ResourceStates stateBefore, D3D12ResourceStates stateAfter, uint subresourceIndex = 0 )
			=> new D3D12ResourceBarrier(
				new D3D12ResourceTransitionBarrier
				{
					pResource = pResource,
					StateBefore = stateBefore,
					StateAfter = stateAfter,
					Subresource = subresourceIndex
				} );
	}
}
