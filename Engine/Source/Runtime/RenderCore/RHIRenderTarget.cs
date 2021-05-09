// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;
using SC.ThirdParty.DirectX;

namespace SC.Engine.Runtime.RenderCore
{
    /// <summary>
    /// 렌더 타겟 정의를 가져옵니다.
    /// </summary>
    public struct RHIRenderTarget
    {
        internal ID3D12Resource Resource;
        internal D3D12CPUDescriptorHandle CPUHandle;
        internal ID2D1Bitmap1 Bitmap;

        /// <summary>
        /// 렌더 타겟에 대한 간단한 설명입니다.
        /// </summary>
        public string Description;

        /// <summary>
        /// 렌더 타겟 초기화 색상입니다.
        /// </summary>
        public Color? ClearColor;
    }
}
