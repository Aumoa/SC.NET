// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;

namespace SC.Engine.Runtime.RenderCore.Slate.Layout
{
    /// <summary>
    /// 배치된 트랜스폼을 표현합니다.
    /// </summary>
    public readonly struct LayoutGeometry
    {
        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="inLocalToParent"> 부모 트랜스폼으로 이행하기 위한 트랜스폼을 전달합니다. </param>
        /// <param name="sizeInLocalSpace"> 로컬 공간에서의 크기를 전달합니다. </param>
        public LayoutGeometry(SlateLayoutTransform inLocalToParent, Vector2 sizeInLocalSpace)
        {
            LocalToParent = inLocalToParent;
            LocalSize = sizeInLocalSpace;
        }

        /// <summary>
        /// 부모 공간에서의 크기를 가져옵니다.
        /// </summary>
        /// <returns> 벡터 값이 반환됩니다. </returns>
        public readonly Vector2 GetSizeInParentSpace()
        {
            return LocalToParent.TransformVector(LocalSize);
        }

        /// <summary>
        /// 부모 공간에서의 오프셋을 가져옵니다.
        /// </summary>
        /// <returns> 벡터 값이 반환됩니다. </returns>
        public readonly Vector2 GetOffsetInParentSpace()
        {
            return LocalToParent.Translation;
        }

        /// <summary>
        /// 로컬 공간에서 슬레이트의 사각 영역을 가져옵니다.
        /// </summary>
        /// <returns> 값이 반환됩니다. </returns>
        public readonly Rectangle GetRectInLocalSpace()
        {
            return new Rectangle(Vector2.Zero, LocalSize);
        }

        /// <summary>
        /// 부모 공간에서 슬레이트의 사각 영역을 가져옵니다.
        /// </summary>
        /// <returns> 값이 반환됩니다. </returns>
        public readonly Rectangle GetRectInParentSpace()
        {
            return LocalToParent.TransformRect(GetRectInLocalSpace());
        }

        /// <summary>
        /// 부모 트랜스폼으로 이행하기 위한 트랜스폼을 가져옵니다.
        /// </summary>
        public readonly SlateLayoutTransform LocalToParent;

        /// <summary>
        /// 로컬 공간 크기를 가져옵니다.
        /// </summary>
        public readonly Vector2 LocalSize;
    }
}
