// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using SC.Engine.Runtime.Core.Collision;
using SC.Engine.Runtime.Core.Container;
using SC.Engine.Runtime.Core.Numerics;
using SC.Engine.Runtime.GameFramework.Camera;

namespace SC.Engine.Runtime.GameFramework.SceneRendering
{
    /// <summary>
    /// 씬 비저빌리티를 계산합니다.
    /// </summary>
    public class SceneVisibility
    {
        Scene _scene;
        MinimalViewInfo _view;
        bool _dirty;
        Frustum _frustum;
        TArray<int> _visibilities = new();

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="inScene"> 씬을 전달합니다. </param>
        public SceneVisibility(Scene inScene)
        {
            _scene = inScene;
        }

        /// <summary>
        /// 비저빌리티를 계산합니다.
        /// </summary>
        public void CalcVisibility()
        {
            if (_dirty)
            {
                ReadOnlySpan<PrimitiveSceneProxy> primitives = _scene.GetPrimitives();
                int bitsAlignedCount = GetBitsAlignedCount(primitives.Length);
                _visibilities.SetCount(GetBitsAlignedCount(primitives.Length), false);

                for (int i = 0; i < bitsAlignedCount; ++i)
                {
                    int scopeBits = 0;

                    for (int j = 0; j < 32; ++j)
                    {
                        int primitiveIndex = i * 32 + j;
                        if (primitiveIndex > primitives.Length)
                        {
                            // Is over than primitives count.
                            break;
                        }

                        PrimitiveSceneProxy proxy = primitives[primitiveIndex];
                        if (proxy is null)
                        {
                            // Null proxy always not be visible.
                            continue;
                        }

                        AxisAlignedCube? boundingBox = proxy.GetPrimitiveBoundingBox();
                        if (boundingBox is not null)
                        {
                            if (!OverlapTest.IsOverlap(_frustum, boundingBox.Value))
                            {
                                // Bounding box has been excluded from view frustum.
                                // Is not visible anywhere.
                                continue;
                            }
                        }

                        // Set on mask to bits.
                        scopeBits |= 1 << j;
                    }

                    // Set scoped bits mask.
                    _visibilities[i] = scopeBits;
                }

                _dirty = false;
            }
        }

        /// <summary>
        /// 씬 뷰를 업데이트합니다.
        /// </summary>
        /// <param name="inView"> 뷰의 참조를 전달합니다. </param>
        public void UpdateView(MinimalViewInfo inView)
        {
            _view = inView;
            _dirty = true;
            _frustum = Frustum.ConstructFromMatrix(_view.ViewProj);
        }

        int GetBitsAlignedCount(int length)
        {
            return (length - 1) / sizeof(int) + 1;
        }
    }
}
