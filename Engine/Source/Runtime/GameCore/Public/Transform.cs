// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.Runtime.CompilerServices;

using SC.Engine.Runtime.Core.Numerics;

namespace SC.Engine.Runtime.GameCore
{
    /// <summary>
    /// 개체의 트랜스폼을 표현합니다.
    /// </summary>
    public struct Transform : IEquatable<Transform>, INearlyEquatable<Transform, float>
    {
        /// <summary>
        /// 이동 값을 나타냅니다.
        /// </summary>
        public Vector3 Translation;

        /// <summary>
        /// 비례 값을 나타냅니다.
        /// </summary>
        public Vector3 Scale;

        /// <summary>
        /// 회전 값을 나타냅니다.
        /// </summary>
        public Quaternion Rotation;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="translation"> 이동 값을 전달합니다. </param>
        /// <param name="scale"> 비례 값을 전달합니다. </param>
        /// <param name="rotation"> 회전 값을 전달합니다. </param>
        public Transform(Vector3 translation, Vector3 scale, Quaternion rotation)
        {
            Translation = translation;
            Scale = scale;
            Rotation = rotation;
        }

        /// <inheritdoc/>
        public override bool Equals(object rh)
        {
            if (rh is Transform tp)
            {
                return tp.Equals(this);
            }
            else
            {
                return base.Equals(rh);
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return Translation.GetHashCode()
                ^ Scale.GetHashCode()
                ^ Rotation.GetHashCode();
        }

        /// <inheritdoc/>
        public bool Equals(Transform rh)
        {
            return Translation.Equals(rh.Translation)
                && Scale.Equals(rh.Scale)
                && Rotation.Equals(rh.Rotation);
        }

        /// <inheritdoc/>
        public bool NearlyEquals(in Transform rh, float epsilon)
        {
            return Translation.NearlyEquals(rh.Translation, epsilon)
                && Scale.NearlyEquals(rh.Scale, epsilon)
                && Rotation.NearlyEquals(rh.Rotation, epsilon);
        }
        
        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{{T: {0}, S: {1}, R: {2}}}", Translation, Scale, Rotation);
        }

        /// <summary>
        /// 벡터를 트랜스폼에 맞춰 이동합니다.
        /// </summary>
        /// <param name="v"> 벡터를 전달합니다. </param>
        /// <returns> 이동된 값이 반환됩니다. </returns>
        public Vector3 TransformVector(Vector3 v)
        {
            return TransformVector(new Vector4(v.X, v.Y, v.Z, 1.0f)).Convert<Vector3>();
        }

        /// <summary>
        /// 벡터를 트랜스폼에 맞춰 이동합니다.
        /// </summary>
        /// <param name="v"> 벡터를 전달합니다. </param>
        /// <returns> 이동된 값이 반환됩니다. </returns>
        public Vector4 TransformVector(Vector4 v)
        {
            Vector4 scaled = v * new Vector4(Scale, 1.0f);
            Vector4 rotated = Rotation.RotateVector(scaled.Convert<Vector3>()).Convert<Vector4>();
            return rotated + new Vector4(Translation * v.W, v.W);
        }

        /// <summary>
        /// 상대적 트랜스폼을 계산합니다.
        /// </summary>
        /// <param name="rh"> 계산할 값을 전달합니다. </param>
        /// <returns> 계산 결과가 반환됩니다. </returns>
        public Transform GetRelativeTransform(Transform rh)
        {
            Vector3 recipScale = 1.0f / rh.Scale;
            Quaternion invRotation = rh.Rotation.Inverse;

            Transform r;
            r.Scale = Scale * recipScale;
            r.Rotation = invRotation * Rotation;
            r.Translation = invRotation.RotateVector(Translation - rh.Translation) * recipScale;

            return r;
        }

        /// <summary>
        /// 트랜스폼의 역을 가져옵니다.
        /// </summary>
        public Transform Inverse
        {
            get
            {
                Transform inverse;
                inverse.Translation = -Translation;
                inverse.Scale = 1.0f / Scale;
                inverse.Rotation = Rotation.Inverse;
                return inverse;
            }
        }

        /// <summary>
        /// 트랜스폼의 행렬 형식을 가져옵니다.
        /// </summary>
        public Matrix4x4 Matrix => Matrix4x4.AffineTransformation(Translation, Scale, Rotation);

        /// <summary>
        /// 두 값을 비교합니다.
        /// </summary>
        /// <param name="lh"> 첫 번째 값을 전달합니다. </param>
        /// <param name="rh"> 두 번째 값을 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator ==(Transform lh, Transform rh)
        {
            return lh.Translation == rh.Translation
                && lh.Scale == rh.Scale
                && lh.Rotation == rh.Rotation;
        }

        /// <summary>
        /// 두 값을 비교합니다.
        /// </summary>
        /// <param name="lh"> 첫 번째 값을 전달합니다. </param>
        /// <param name="rh"> 두 번째 값을 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator !=(Transform lh, Transform rh)
        {
            return lh.Translation != rh.Translation
                || lh.Scale != rh.Scale
                || lh.Rotation != rh.Rotation;
        }

        /// <summary>
        /// 행렬로부터 트랜스폼 데이터를 생성합니다.
        /// </summary>
        /// <param name="value"> 행렬 값을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public static Transform FromMatrix(Matrix4x4 value)
        {
            Unsafe.SkipInit(out Transform T);
            value.Decompose(out T.Scale, out T.Rotation, out T.Translation);
            return T;
        }

        /// <summary>
        /// 두 트랜스폼을 더합니다.
        /// </summary>
        /// <param name="lh"> 첫 번째 값을 전달합니다. </param>
        /// <param name="rh"> 두 번째 값을 전달합니다. </param>
        /// <returns> 값이 반환됩니다. </returns>
        public static Transform Multiply(Transform lh, Transform rh)
        {
            var M = Matrix4x4.Multiply(lh.Matrix, rh.Matrix);
            Unsafe.SkipInit(out Transform T);
            M.Decompose(out T.Scale, out T.Rotation, out T.Translation);
            return T;
        }

        /// <summary>
        /// 단위 트랜스폼을 가져옵니다.
        /// </summary>
        public static Transform Identity => new Transform(Vector3.Zero, Vector3.One, Quaternion.Identity);
    }
}
