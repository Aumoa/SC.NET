// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using SC.Engine.Runtime.Core.Mathematics;
using SC.Engine.Runtime.Core.Numerics;
using SC.Engine.Runtime.RenderCore.Slate.Widgets;

namespace SC.Engine.Runtime.RenderCore.Slate.Layout
{
    /// <summary>
    /// 슬레이트 트랜스폼을 표현합니다.
    /// </summary>
    public struct Geometry
    {
        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="inLocalSize"> 로컬 크기를 전달합니다. </param>
        /// <param name="inLocalLayoutTransform"> 로컬 공간에서 부모 공간으로의 트랜스폼을 전달합니다. </param>
        /// <param name="inLocalRenderTransform"> 렌더링될 때 추가되는 로컬 트랜스폼을 전달합니다. </param>
        /// <param name="inLocalRenderTransformPivot"> 정규화된 로컬 공간에서의 트랜스폼 기준점을 전달합니다. </param>
        /// <param name="parentAccumulatedLayoutTransform"> 부모 개체의 누적된 레이아웃 트랜스폼을 전달합니다. </param>
        /// <param name="parentAccumulatedRenderTransform"> 부모 개체의 누적된 렌더링 트랜스폼을 전달합니다. </param>
        Geometry(Vector2 inLocalSize, SlateLayoutTransform inLocalLayoutTransform, SlateRenderTransform inLocalRenderTransform, Vector2 inLocalRenderTransformPivot, SlateLayoutTransform parentAccumulatedLayoutTransform, SlateRenderTransform parentAccumulatedRenderTransform)
        {
            Size = inLocalSize;
            Scale = 1.0f;
            AbsolutePosition = new Vector2(0, 0);
            _accumulatedRenderTransform =
                // convert the pivot to local space and make it the origin
                new Scale2D(inLocalSize).TransformPoint(inLocalRenderTransformPivot).Inverse().
                // apply the render transform in local space centered around the pivot
                Concatenate(inLocalRenderTransform).
                // translate the pivot point back.
                Concatenate(new Scale2D(inLocalSize).TransformPoint(inLocalRenderTransformPivot)).
                // apply the layout transform next.
                Concatenate(inLocalLayoutTransform).
                // finally apply the parent accumulated transform, which takes us to the root.
                Concatenate(parentAccumulatedRenderTransform);

            SlateLayoutTransform accumulatedLayoutTransform = inLocalLayoutTransform.Concatenate(parentAccumulatedLayoutTransform);
            AbsolutePosition = accumulatedLayoutTransform.Translation;
            Scale = accumulatedLayoutTransform.Scale;
            Position = inLocalLayoutTransform.Translation;
        }

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="inLocalSize"> 로컬 크기를 전달합니다. </param>
        /// <param name="inLocalLayoutTransform"> 로컬 공간에서 부모 공간으로의 트랜스폼을 전달합니다. </param>
        /// <param name="parentAccumulatedLayoutTransform"> 부모 개체의 누적된 레이아웃 트랜스폼을 전달합니다. </param>
        /// <param name="parentAccumulatedRenderTransform"> 부모 개체의 누적된 렌더링 트랜스폼을 전달합니다. </param>
        /// <param name="hasRenderTransform"> 렌더 트랜스폼이 포함됩니다.</param>
        Geometry(Vector2 inLocalSize, SlateLayoutTransform inLocalLayoutTransform, SlateLayoutTransform parentAccumulatedLayoutTransform, SlateRenderTransform parentAccumulatedRenderTransform, bool hasRenderTransform)
        {
            Size = inLocalSize;
            Scale = 1.0f;
            AbsolutePosition = new Vector2(0, 0);
            if (hasRenderTransform)
            {
                _accumulatedRenderTransform = inLocalLayoutTransform.Concatenate(parentAccumulatedRenderTransform);
            }
            else
            {
                _accumulatedRenderTransform = null;
            }

            SlateLayoutTransform accumulatedLayoutTransform = inLocalLayoutTransform.Concatenate(parentAccumulatedLayoutTransform);
            AbsolutePosition = accumulatedLayoutTransform.Translation;
            Scale = accumulatedLayoutTransform.Scale;
            Position = inLocalLayoutTransform.Translation;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is Geometry geo)
            {
                return Equals(geo);
            }
            else
            {
                return base.Equals(obj);
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"[Abs={AbsolutePosition}, Scale={Scale}, Size={Size}";
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return AbsolutePosition.GetHashCode() ^ Scale.GetHashCode() ^ Size.GetHashCode();
        }

        /// <inheritdoc/>
        public bool Equals(Geometry rhs)
        {
            return this == rhs;
        }

        /// <inheritdoc/>
        public bool NearlyEquals(Geometry rhs, float epsilon)
        {
            return AbsolutePosition.NearlyEquals(rhs.AbsolutePosition, epsilon)
                && MathEx.Abs(Scale - rhs.Scale) <= epsilon
                && Size.NearlyEquals(rhs.Size, epsilon);
        }

        /// <inheritdoc/>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"[Abs={AbsolutePosition.ToString(format, formatProvider)}, Scale={Scale.ToString(format, formatProvider)}, Size={Size.ToString(format, formatProvider)}";
        }

        /// <summary>
        /// 루트 트랜스폼을 생성합니다.
        /// </summary>
        /// <param name="inLocalSize"> 로컬 크기를 전달합니다. </param>
        /// <param name="layoutTransform"> 레이아웃 트랜스폼을 전달합니다. </param>
        /// <returns> 트랜스폼이 반환됩니다. </returns>
        public static Geometry MakeRoot(Vector2 inLocalSize, SlateLayoutTransform layoutTransform)
        {
            return new Geometry(inLocalSize, layoutTransform, new SlateLayoutTransform(1.0f, Vector2.Zero), SlateRenderTransform.Identity, false);
        }

        /// <summary>
        /// 루트 트랜스폼을 생성합니다.
        /// </summary>
        /// <param name="inLocalSize"> 로컬 크기를 전달합니다. </param>
        /// <param name="layoutTransform"> 레이아웃 트랜스폼을 전달합니다. </param>
        /// <param name="renderTransform"> 렌더 트랜스폼을 전달합니다. </param>
        /// <returns> 트랜스폼이 반환됩니다. </returns>
        public static Geometry MakeRoot(Vector2 inLocalSize, SlateLayoutTransform layoutTransform, SlateRenderTransform renderTransform)
        {
            return new Geometry(inLocalSize, layoutTransform, new SlateLayoutTransform(1.0f, Vector2.Zero), renderTransform, true);
        }

        /// <summary>
        /// 자식 트랜스폼을 생성합니다.
        /// </summary>
        /// <param name="inLocalSize"> 로컬 크기를 전달합니다. </param>
        /// <param name="layoutTransform"> 레이아웃 트랜스폼을 전달합니다. </param>
        /// <param name="renderTransform"> 렌더 트랜스폼을 전달합니다. </param>
        /// <param name="renderTransformPivot"> 렌더 트랜스폼의 기준점을 전달합니다. </param>
        /// <returns> 트랜스폼이 반환됩니다. </returns>
        public readonly Geometry MakeChild(Vector2 inLocalSize, SlateLayoutTransform layoutTransform, SlateRenderTransform renderTransform, Vector2 renderTransformPivot)
        {
            return new Geometry(inLocalSize, layoutTransform, renderTransform, renderTransformPivot, GetAccumulatedLayoutTransform(), AccumulatedRenderTransform);
        }

        /// <summary>
        /// 자식 트랜스폼을 생성합니다.
        /// </summary>
        /// <param name="inLocalSize"> 로컬 크기를 전달합니다. </param>
        /// <param name="layoutTransform"> 레이아웃 트랜스폼을 전달합니다. </param>
        /// <returns> 트랜스폼이 반환됩니다. </returns>
        public readonly Geometry MakeChild(Vector2 inLocalSize, SlateLayoutTransform layoutTransform)
        {
            return new Geometry(inLocalSize, layoutTransform, GetAccumulatedLayoutTransform(), AccumulatedRenderTransform, bHasRenderTransform);
        }

        /// <summary>
        /// 자식 트랜스폼을 생성합니다.
        /// </summary>
        /// <param name="renderTransform"> 렌더 트랜스폼을 전달합니다. </param>
        /// <param name="renderTransformPivot"> 렌더 트랜스폼의 기준점을 전달합니다. </param>
        /// <returns></returns>
        public readonly Geometry MakeChild(SlateRenderTransform renderTransform, Vector2 renderTransformPivot)
        {
            return new Geometry(Size, new SlateLayoutTransform(1.0f, Vector2.Zero), renderTransform, renderTransformPivot, GetAccumulatedLayoutTransform(), AccumulatedRenderTransform);
        }

        /// <summary>
        /// 자식 트랜스폼을 생성합니다.
        /// </summary>
        /// <param name="renderTransform"> 렌더 트랜스폼을 전달합니다. </param>
        /// <returns> 트랜스폼이 반환됩니다. </returns>
        public readonly Geometry MakeChild(SlateRenderTransform renderTransform) => MakeChild(renderTransform, new Vector2(0.5f));

        /// <summary>
        /// 자식 트랜스폼을 생성합니다.
        /// </summary>
        /// <param name="childWidget"> 자식 위젯 개체를 전달합니다. </param>
        /// <param name="layoutGeometry"> 레이아웃 트랜스폼을 전달합니다. </param>
        /// <returns> 재배열된 위젯이 반환됩니다. </returns>
        public readonly ArrangedWidget MakeChild(SWidget childWidget, LayoutGeometry layoutGeometry) => MakeChild(childWidget, layoutGeometry.LocalSize, layoutGeometry.LocalToParent);

        /// <summary>
        /// 자식 트랜스폼을 생성합니다.
        /// </summary>
        /// <param name="childWidget"> 자식 위젯 개체를 전달합니다. </param>
        /// <param name="inLocalSize"> 자식 위젯의 로컬 공간 크기를 전달합니다. </param>
        /// <param name="layoutTransform"> 레이아웃 트랜스폼을 전달합니다.  </param>
        /// <returns> 재배열된 위젯이 반환됩니다. </returns>
        public readonly ArrangedWidget MakeChild(SWidget childWidget, Vector2 inLocalSize, SlateLayoutTransform layoutTransform)
        {
            SlateRenderTransform? renderTransform = childWidget.GetRenderTransformWithRespectToFlowDirection();
            if (renderTransform.HasValue)
            {
                Vector2 renderTransformPivot = childWidget.GetRenderTransformPivotWithRespectToFlowDirection();
                return new ArrangedWidget(childWidget, MakeChild(inLocalSize, layoutTransform, renderTransform.Value, renderTransformPivot));
            }
            else
            {
                return new ArrangedWidget(childWidget, MakeChild(inLocalSize, layoutTransform));
            }
        }

        /// <summary>
        /// 자식 트랜스폼을 생성합니다.
        /// </summary>
        /// <param name="childOffset"> 자식 개체의 오프셋을 전달합니다. </param>
        /// <param name="inLocalSize"> 로컬 크기를 전달합니다. </param>
        /// <param name="childScale"> 자식 개체의 비례 수치를 전달합니다. </param>
        /// <returns> 트랜스폼이 반환됩니다. </returns>
        public readonly Geometry MakeChild(Vector2 childOffset, Vector2 inLocalSize, float childScale)
        {
            return new Geometry(inLocalSize, new SlateLayoutTransform(childScale, new Scale2D(childScale).TransformPoint(childOffset)), GetAccumulatedLayoutTransform(), AccumulatedRenderTransform, bHasRenderTransform);
        }

        /// <summary>
        /// 자식 트랜스폼을 생성합니다.
        /// </summary>
        /// <param name="childWidget"> 자식 위젯 개체를 전달합니다. </param>
        /// <param name="childOffset"> 자식 개체의 오프셋을 전달합니다. </param>
        /// <param name="inLocalSize"> 자식 위젯의 로컬 공간 크기를 전달합니다. </param>
        /// <param name="childScale"> 자식 개체의 비례 수치를 전달합니다. </param>
        /// <returns> 재배열된 위젯이 반환됩니다. </returns>
        public readonly ArrangedWidget MakeChild(SWidget childWidget, Vector2 childOffset, Vector2 inLocalSize, float childScale = 1.0f)
        {
            return MakeChild(childWidget, inLocalSize, new SlateLayoutTransform(childScale, new Scale2D(childScale).TransformPoint(childOffset)));
        }

        /// <summary>
        /// 렌더린 전용 트랜스폼을 가져옵니다.
        /// </summary>
        /// <returns> 값이 반환됩니다. </returns>
        public readonly PaintGeometry ToPaintGeometry()
        {
            return new PaintGeometry(GetAccumulatedLayoutTransform(), AccumulatedRenderTransform, Size, bHasRenderTransform);
        }

        /// <summary>
        /// 렌더링 전용 트랜스폼을 가져옵니다.
        /// </summary>
        /// <param name="inLocalSize"> 로컬 공간 크기를 전달합니다. </param>
        /// <param name="inLayoutTransform"> 레이아웃 트랜스폼을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public readonly PaintGeometry ToPaintGeometry(Vector2 inLocalSize, SlateLayoutTransform inLayoutTransform)
        {
            SlateLayoutTransform newAccumulatedLayoutTransform = inLayoutTransform.Concatenate(GetAccumulatedLayoutTransform());
            return new PaintGeometry(newAccumulatedLayoutTransform, inLayoutTransform.Concatenate(AccumulatedRenderTransform), inLocalSize, bHasRenderTransform);
        }

        /// <summary>
        /// 렌더링 전용 트랜스폼을 가져옵니다.
        /// </summary>
        /// <param name="inLocalSize"> 로컬 크기를 전달합니다. </param>
        /// <param name="inLayoutTransform"> 레이아웃 트랜스폼을 전달합니다.  </param>
        /// <param name="renderTransform"> 렌더 트랜스폼을 전달합니다. </param>
        /// <param name="renderTransformPivot"> 렌더 트랜스폼의 기준점을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public readonly PaintGeometry ToPaintGeometry(Vector2 inLocalSize, SlateLayoutTransform inLayoutTransform, SlateRenderTransform renderTransform, Vector2 renderTransformPivot)
        {
            return MakeChild(inLocalSize, inLayoutTransform, renderTransform, renderTransformPivot).ToPaintGeometry();
        }

        /// <summary>
        /// 렌더링 전용 트랜스폼을 가져옵니다.
        /// </summary>
        /// <param name="layoutTransform"> 레이아웃 트랜스폼을 전달합니다.  </param>
        /// <returns> 값이 반환됩니다. </returns>
        public readonly PaintGeometry ToPaintGeometry(SlateLayoutTransform layoutTransform)
        {
            return ToPaintGeometry(Size, layoutTransform);
        }

        /// <summary>
        /// 렌더링 전용 트랜스폼을 가져옵니다.
        /// </summary>
        /// <param name="inLocalOffset"> 로컬 공간 오프셋을 전달합니다. </param>
        /// <param name="inLocalSize"> 로컬 크기를 전달합니다. </param>
        /// <param name="inLocalScale"> 로컬 공간 비례 계수를 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public readonly PaintGeometry ToPaintGeometry(Vector2 inLocalOffset, Vector2 inLocalSize, float inLocalScale)
        {
            return ToPaintGeometry(inLocalSize, new SlateLayoutTransform(inLocalScale, new Scale2D(inLocalScale).TransformPoint(inLocalOffset)));
        }

        /// <summary>
        /// 렌더링 전용 트랜스폼을 가져옵니다.
        /// </summary>
        /// <param name="localOffset"> 로컬 공간 오프셋을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public readonly PaintGeometry ToOffsetPaintGeometry(Vector2 localOffset)
        {
            return ToPaintGeometry(new SlateLayoutTransform(localOffset));
        }

        /// <summary>
        /// 렌더링 전용 트랜스폼을 가져옵니다.
        /// </summary>
        /// <param name="inflateAmount"> 값을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public readonly PaintGeometry ToInflatedPaintGeometry(Vector2 inflateAmount)
        {
            Vector2 newSize = Size + inflateAmount * 2;
            return ToPaintGeometry(newSize, new SlateLayoutTransform(-inflateAmount));
        }

        /// <summary>
        /// 대상 위치가 포함되어 있는지 검사합니다.
        /// </summary>
        /// <param name="absoluteCoordinate"> 대상 위치를 전달합니다. </param>
        /// <returns> 결과가 반환됩니다. </returns>
        public readonly bool IsUnderLocation(Vector2 absoluteCoordinate)
        {
            SlateRotatedRect rect = AccumulatedRenderTransform.TransformRect(new SlateRotatedRect(new Rectangle(Vector2.Zero, Size)));
            return rect.IsUnderLocation(absoluteCoordinate);
        }

        /// <summary>
        /// 절대 좌표를 로컬 공간 좌표로 변환합니다.
        /// </summary>
        /// <param name="absoluteCoordinate"> 절대 좌표를 전달합니다. </param>
        /// <returns> 결과가 반환됩니다. </returns>
        public readonly Vector2 AbsoluteToLocal(Vector2 absoluteCoordinate)
        {
            return AccumulatedRenderTransform.Inverse().TransformPoint(absoluteCoordinate);
        }

        /// <summary>
        /// 로컬 공간 좌표를 절대 좌표로 변환합니다.
        /// </summary>
        /// <param name="localCoordinate"> 로컬 공간 좌표를 전달합니다. </param>
        /// <returns> 결과가 반환됩니다. </returns>
        public readonly Vector2 LocalToAbsolute(Vector2 localCoordinate)
        {
            return AccumulatedRenderTransform.TransformPoint(localCoordinate);
        }

        /// <summary>
        /// 스냅된 로컬 공간 좌표로 변환합니다.
        /// </summary>
        /// <param name="localCoordinate"> 로컬 공간 좌표를 전달합니다. </param>
        /// <returns> 결과가 반환됩니다. </returns>
        public readonly Vector2 LocalToRoundedLocal(Vector2 localCoordinate)
        {
            Vector2 absoluteCoordinate = LocalToAbsolute(localCoordinate);
            Vector2 absoluteCoordinateRounded = absoluteCoordinate.Round();

            return AbsoluteToLocal(absoluteCoordinateRounded);
        }

        /// <summary>
        /// 레이아웃 바운딩 영역을 가져옵니다.
        /// </summary>
        /// <returns> 값이 반환됩니다. </returns>
        public readonly Rectangle GetLayoutBoundingRect() => GetLayoutBoundingRect(new Rectangle(Vector2.Zero, Size));

        /// <summary>
        /// 레이아웃 바운딩 영역을 가져옵니다.
        /// </summary>
        /// <param name="localSpaceExtendBy"> 로컬 공간 확장 영역을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public readonly Rectangle GetLayoutBoundingRect(Margin localSpaceExtendBy) => GetLayoutBoundingRect(new Rectangle(Vector2.Zero, Size).ExtendBy(localSpaceExtendBy));

        /// <summary>
        /// 레이아웃 바운딩 영역을 가져옵니다.
        /// </summary>
        /// <param name="localSpaceRect"> 로컬 공간 영역을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public readonly Rectangle GetLayoutBoundingRect(Rectangle localSpaceRect)
        {
            return GetAccumulatedLayoutTransform().TransformRect(new SlateRotatedRect(localSpaceRect)).ToBoundingRect();
        }

        /// <summary>
        /// 렌더링 바운딩 영역을 가져옵니다.
        /// </summary>
        /// <returns> 값이 반환됩니다. </returns>
        public readonly Rectangle GetRenderBoundingRect() => GetRenderBoudningRect(new Rectangle(Vector2.Zero, Size));

        /// <summary>
        /// 렌더링 바운딩 영역을 가져옵니다.
        /// </summary>
        /// <param name="localSpaceExtendBy"> 로컬 공간 확장 영역을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public readonly Rectangle GetRenderBoundingRect(Margin localSpaceExtendBy) => GetRenderBoudningRect(new Rectangle(Vector2.Zero, Size).ExtendBy(localSpaceExtendBy));

        /// <summary>
        /// 렌더링 바운딩 영역을 가져옵니다.
        /// </summary>
        /// <param name="localSpaceRect"> 로컬 공간 영역을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public readonly Rectangle GetRenderBoudningRect(Rectangle localSpaceRect)
        {
            return AccumulatedRenderTransform.TransformRect(new SlateRotatedRect(localSpaceRect)).ToBoundingRect();
        }

        /// <summary>
        /// 누적된 레이아웃 트랜스폼을 가져옵니다.
        /// </summary>
        /// <returns> 값이 반환됩니다. </returns>
        public readonly SlateLayoutTransform GetAccumulatedLayoutTransform()
        {
            return new SlateLayoutTransform(Scale, AbsolutePosition);
        }

        /// <summary>
        /// 레이아웃 트랜스폼을 더합니다.
        /// </summary>
        /// <param name="layoutTransform"> 레이아웃 트랜스폼을 전달합니다. </param>
        public void AppendTransform(SlateLayoutTransform layoutTransform)
        {
            SlateLayoutTransform accumulatedLayoutTransform = GetAccumulatedLayoutTransform().Concatenate(layoutTransform);
            AccumulatedRenderTransform = AccumulatedRenderTransform.Concatenate(layoutTransform);
            AbsolutePosition = accumulatedLayoutTransform.Translation;
            Scale = accumulatedLayoutTransform.Scale;
        }

        /// <summary>
        /// 렌더 공간에서 절대 위치를 가져옵니다.
        /// </summary>
        /// <returns> 위치가 반환됩니다. </returns>
        public readonly Vector2 GetAbsolutePosition()
        {
            return AccumulatedRenderTransform.TransformPoint(Vector2.Zero);
        }

        /// <summary>
        /// 렌더 공간에서 절대 크기를 가져옵니다.
        /// </summary>
        /// <returns> 크기가 반환됩니다. </returns>
        public readonly Vector2 GetAbsoluteSize()
        {
            return AccumulatedRenderTransform.TransformVector(Size);
        }

        /// <summary>
        /// 정규화된 좌표로부터 표면의 절대적 위치를 가져옵니다.
        /// </summary>
        /// <param name="normalCoordinates"> 정규화된 좌표를 전달합니다. </param>
        /// <returns> 절대 위치가 반환됩니다. </returns>
	    public readonly Vector2 GetAbsolutePositionAtCoordinates(Vector2 normalCoordinates)
	    {
		    return AccumulatedRenderTransform.TransformPoint(normalCoordinates * Size);
	    }

        /// <summary>
        /// 정규화된 좌표로부터 표면의 로컬 공간 위치를 가져옵니다.
        /// </summary>
        /// <param name="normalCoordinates"> 정규화된 좌표를 전달합니다. </param>
        /// <returns> 로컬 공간 위치가 반환됩니다. </returns>
	    public readonly Vector2 GetLocalPositionAtCoordinates(Vector2 normalCoordinates)
	    {
		    return Position + (normalCoordinates * Size);
	    }

        /// <summary>
        /// 크기를 가져옵니다.
        /// </summary>
        public Vector2 Size { readonly get; private set; }

        /// <summary>
        /// 비례 계수를 가져옵니다.
        /// </summary>
        public float Scale { readonly get; private set; }

        /// <summary>
        /// 절대적 위치를 가져옵니다.
        /// </summary>
        public Vector2 AbsolutePosition { readonly get; private set; }

        /// <summary>
        /// 위치를 가져옵니다.
        /// </summary>
        public Vector2 Position { readonly get; private set; }

        /// <summary>
        /// 누적된 렌더 트랜스폼을 가져옵니다.
        /// </summary>
        public SlateRenderTransform AccumulatedRenderTransform
        {
            readonly get => _accumulatedRenderTransform ?? SlateRenderTransform.Identity;
            private set => _accumulatedRenderTransform = value;
        }

        SlateRenderTransform? _accumulatedRenderTransform;

        /// <summary>
        /// 렌더 트랜스폼이 존재하는지 나타내는 값을 가져옵니다.
        /// </summary>
        public readonly bool bHasRenderTransform => _accumulatedRenderTransform.HasValue;

        /// <summary>
        /// 두 값이 같은지 비교합니다.
        /// </summary>
        /// <param name="lhs"> 첫 번째 값을 전달합니다. </param>
        /// <param name="rhs"> 두 번째 값을 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator ==(in Geometry lhs, in Geometry rhs)
            => lhs.Size == rhs.Size && lhs.Scale == rhs.Scale && lhs.AbsolutePosition == rhs.AbsolutePosition && lhs.AccumulatedRenderTransform == rhs.AccumulatedRenderTransform && lhs.bHasRenderTransform == rhs.bHasRenderTransform;


        /// <summary>
        /// 두 값이 같지 않은지 비교합니다.
        /// </summary>
        /// <param name="lhs"> 첫 번째 값을 전달합니다. </param>
        /// <param name="rhs"> 두 번째 값을 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator !=(in Geometry lhs, in Geometry rhs)
            => lhs.Size != rhs.Size || lhs.Scale != rhs.Scale || lhs.AbsolutePosition != rhs.AbsolutePosition || lhs.AccumulatedRenderTransform != rhs.AccumulatedRenderTransform || lhs.bHasRenderTransform != rhs.bHasRenderTransform;
    }
}
