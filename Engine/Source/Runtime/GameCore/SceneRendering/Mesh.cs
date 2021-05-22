// Copyright 2020-2021 Aumoa.lib. All right reserved.

namespace SC.Engine.Runtime.GameCore.SceneRendering
{
    /// <summary>
    /// 메시 오브젝트에 대한 공통 함수를 제공합니다.
    /// </summary>
    public abstract class Mesh : IRenderAssets
    {
        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public Mesh()
        {
        }

        /// <inheritdoc/>
        public abstract void Dispose();

        /// <inheritdoc/>
        public abstract ulong GetEstimateMemorySizeInBytes();
    }
}
