// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

using SC.Engine.Runtime.Core.Container;
using SC.Engine.Runtime.RenderCore;
using SC.Engine.Runtime.RenderCore.PrimitiveTypes;

namespace SC.Engine.Runtime.GameFramework.Assets
{
    /// <summary>
    /// 스태틱 메시 오브젝트를 표현합니다.
    /// </summary>
    public class StaticMesh : Mesh
    {
        ICollection<RHIVertex> _vertices;
        ICollection<uint> _indices;

        RHIResource _vertexBuffer;
        RHIResource _indexBuffer;
        ulong _estimateMemorySize;

        StaticMesh()
        {
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            _vertexBuffer?.Dispose();
            _indexBuffer?.Dispose();

            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        public override ulong GetEstimateMemorySizeInBytes()
        {
            return _estimateMemorySize;
        }

        /// <summary>
        /// 스태틱 메시 오브젝트를 생성합니다.
        /// </summary>
        /// <param name="deviceBundle"> 디바이스를 전달합니다. </param>
        /// <param name="vertices"> 정점 목록을 전달합니다. </param>
        /// <param name="indices"> 색인 목록을 전달합니다. </param>
        /// <returns> 개체가 반환됩니다. </returns>
        public static StaticMesh CreateStaticMesh(RHIDeviceBundle deviceBundle, ICollection<RHIVertex> vertices, ICollection<uint> indices)
        {
            ReadOnlySpan<RHIVertex> vertices_span = Internal_AsSpan(vertices);
            ReadOnlySpan<uint> indices_span = Internal_AsSpan(indices);

            StaticMesh instance = new();
            instance._vertexBuffer = deviceBundle.CreateVertexBuffer(vertices_span);
            instance._indexBuffer = deviceBundle.CreateIndexBuffer(indices_span);
            instance._vertices = vertices;
            instance._indices = indices;
            instance.CalcEstimateMemorySize();

            return instance;
        }

        static ReadOnlySpan<T> Internal_AsSpan<T>(ICollection<T> collection)
        {
            switch (collection)
            {
                case List<T> isList:
                    return CollectionsMarshal.AsSpan(isList);
                case T[] isArray:
                    return new ReadOnlySpan<T>(isArray);
                case TArray<T> isTArray:
                    return isTArray.AsReadOnlySpan();
                default:
                    return new ReadOnlySpan<T>(collection.ToArray());
            }
        }

        unsafe void CalcEstimateMemorySize()
        {
            ulong vertexBufferSize = (ulong)(sizeof(RHIVertex) * _vertices.Count);
            ulong indexBufferSize = (ulong)(sizeof(uint) * _indices.Count);
            _estimateMemorySize = vertexBufferSize + indexBufferSize;
        }
    }
}
