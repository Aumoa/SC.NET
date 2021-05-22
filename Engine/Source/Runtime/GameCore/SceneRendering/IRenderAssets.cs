// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

namespace SC.Engine.Runtime.GameCore.SceneRendering
{
    /// <summary>
    /// 렌더 에셋에 대한 공통 함수를 제공합니다.
    /// </summary>
    public interface IRenderAssets : IDisposable
    {
        /// <summary>
        /// 예상되는 사용 메모리 크기를 가져옵니다.
        /// </summary>
        /// <returns> 바이트 단위의 크기가 반환됩니다. </returns>
        ulong GetEstimateMemorySizeInBytes();
    }
}
