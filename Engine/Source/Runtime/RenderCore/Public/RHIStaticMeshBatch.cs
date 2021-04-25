// Copyright 2020-2021 Aumoa.lib. All right reserved.

namespace SC.Engine.Runtime.RenderCore
{
    /// <summary>
    /// 스태틱 매시 렌더링 배치를 표현합니다.
    /// </summary>
    public struct RHIStaticMeshBatch
    {
        /// <summary>
        /// 프리미티브 형태를 나타냅니다.
        /// </summary>
        public RHIPrimitiveTopology Topology;

        /// <summary>
        /// 정점 버퍼 뷰를 나타냅니다.
        /// </summary>
        public ulong VertexBufferView;

        /// <summary>
        /// 인덱스 버퍼 뷰를 나타냅니다.
        /// </summary>
        public ulong IndexBufferView;

        /// <summary>
        /// 정점 개수를 나타냅니다.
        /// </summary>
        public uint VertexCount;

        /// <summary>
        /// 인덱스 개수를 나타냅니다.
        /// </summary>
        public uint IndexCount;
    }
}
