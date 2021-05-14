// Copyright 2020 Aumoa.lib. All right reserved.

using System;

using SC.Engine.Runtime.Core.Mathematics;

namespace SC.Engine.Runtime.Core.Numerics
{
    /// <summary>
    /// 사원수를 정의합니다.
    /// </summary>
    public struct Quaternion : INearlyEquatable<Quaternion, float>, IFormattable, IVectorType
    {
        /// <summary>
        /// 사원수의 허수부 X 값을 나타냅니다.
        /// </summary>
        public float X;

        /// <summary>
        /// 사원수의 허수부 Y 값을 나타냅니다.
        /// </summary>
        public float Y;

        /// <summary>
        /// 사원수의 허수부 Z 값을 나타냅니다.
        /// </summary>
        public float Z;

        /// <summary>
        /// 사원수의 실수부 W 값을 나타냅니다.
        /// </summary>
        public float W;

        /// <summary>
        /// 값을 지정하여 <see cref="Quaternion"/> 구조체의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="x"> 허수부 X 값을 전달합니다. </param>
        /// <param name="y"> 허수부 Y 값을 전달합니다. </param>
        /// <param name="z"> 허수부 Z 값을 전달합니다. </param>
        /// <param name="w"> 실수부 W 값을 전달합니다. </param>
        public Quaternion(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// 실수부 및 허수부를 지정하여 <see cref="Quaternion"/> 구조체의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="xyz"> 허수부 값을 전달합니다. </param>
        /// <param name="w"> 실수부 값을 전달합니다. </param>
        public Quaternion(Vector3 xyz, float w)
        {
            X = xyz.X;
            Y = xyz.Y;
            Z = xyz.Z;
            W = w;
        }

        /// <summary>
        /// 대상 오브젝트가 사원수일 경우, 두 사원수가 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="obj"> 대상 오브젝트를 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public override bool Equals(object obj)
        {
            if (obj is Quaternion q)
            {
                return Equals(q);
            }
            else
            {
                return base.Equals(obj);
            }
        }

        /// <summary>
        /// 사원수의 전체 값의 해시 코드를 가져옵니다.
        /// </summary>
        /// <returns> 해시 코드가 반환됩니다. </returns>
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode() ^ W.GetHashCode();
        }

        /// <summary>
        /// {X, Y, Z, W} 형식의 문자열을 가져옵니다.
        /// </summary>
        /// <returns> 생성된 문자열이 반환됩니다. </returns>
        public override string ToString()
        {
            return string.Format("{{{0}, {1}, {2}, {3}}}", X, Y, Z, W);
        }

        /// <summary>
        /// 두 사원수가 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="v"> 대상 사원수를 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public bool Equals(Quaternion v)
        {
            return this == v;
        }

        /// <inheritdoc/>
        public bool NearlyEquals(Quaternion right, float epsilon)
        {
            return Math.Abs(X - right.X) <= epsilon
                && Math.Abs(Y - right.Y) <= epsilon
                && Math.Abs(Z - right.Z) <= epsilon
                && Math.Abs(W - right.W) <= epsilon;
        }

        /// <summary>
        /// 서식을 지정하여 {X, Y, Z, W} 형식의 문자열을 가져옵니다.
        /// </summary>
        /// <param name="format"> 서식 문자열을 전달합니다. </param>
        /// <param name="formatProvider"> 문화권 정보를 전달합니다. </param>
        /// <returns> 생성된 문자열이 반환됩니다. </returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("{{{0}, {1}, {2}, {3}}}",
                X.ToString(format, formatProvider),
                Y.ToString(format, formatProvider),
                Z.ToString(format, formatProvider),
                W.ToString(format, formatProvider));
        }

        /// <inheritdoc/>
        public unsafe float GetComponentOrDefault(int index)
        {
            fixed (float* ptr = &X)
            {
                if (index < Count)
                {
                    return ptr[index];
                }
                else
                {
                    return default;
                }
            }
        }

        /// <inheritdoc/>
        public void Construct<T>(T vector) where T : IVectorType
        {
            if (vector is not null)
            {
                X = vector.GetComponentOrDefault(0);
                Y = vector.GetComponentOrDefault(1);
                Z = vector.GetComponentOrDefault(2);
                W = vector.GetComponentOrDefault(3);
            }
            else
            {
                X = 0;
                Y = 0;
                Z = 0;
                W = 0;
            }
        }

        /// <inheritdoc/>
        public T Convert<T>() where T : IVectorType, new()
        {
            var value = new T();
            value.Construct(this);
            return value;
        }

        /// <inheritdoc/>
        public bool Contains(int index)
        {
            return index >= 0 && index < 4;
        }

        /// <summary>
        /// 이 사원수를 회전축과 각도로 분리합니다.
        /// </summary>
        /// <param name="outAxis"> 회전축을 받을 변수의 참조를 전달합니다. </param>
        /// <param name="outAngle"> 회전 각도를 받을 변수의 참조를 전달합니다. </param>
        public void ToAxisAngle(out Vector3 outAxis, out float outAngle)
        {
            outAxis = RotationAxis;
            outAngle = Angle;
        }

        /// <summary>
        /// 이 사원수 회전 값을 이용해 벡터를 회전합니다.
        /// </summary>
        /// <param name="v"> 회전할 벡터를 전달합니다. </param>
        /// <returns> 회전한 벡터가 반환됩니다. </returns>
        public Vector3 RotateVector(Vector3 v)
        {
            var Q = new Vector3(X, Y, Z);
            Vector3 T = 2.0f * Vector3.CrossProduct(Q, v);
            Vector3 result = v + (W * T) + Vector3.CrossProduct(Q, T);

            return result;
        }

        /// <inheritdoc/>
        public unsafe float this[int index]
        {
            get => GetComponentOrDefault(index);
            set
            {
                fixed (float* ptr = &X)
                {
                    if (index < Count)
                    {
                        ptr[index] = value;
                    }
                }
            }
        }

        /// <inheritdoc/>
        public int Count
        {
            get => 4;
        }

        /// <summary>
        /// 허수 벡터 부분을 설정하거나 가져옵니다.
        /// </summary>
        public Vector3 VectorPart
        {
            get => new Vector3(X, Y, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// 이 사원수의 켤레 사원수를 가져옵니다.
        /// </summary>
        public Quaternion Conjugate
        {
            get => new Quaternion(-X, -Y, -Z, W);
        }

        /// <summary>
        /// 이 사원수의 회전을 나타내는 값을 가져옵니다.
        /// </summary>
        public float Angle
        {
            get => 2.0f * MathEx.Acos(W);
        }

        /// <summary>
        /// 이 사원수의 회전을 나타내는 회전 축을 가져옵니다.
        /// </summary>
        public Vector3 RotationAxis
        {
            get
            {
                float S = MathEx.Sqrt(Math.Max(1.0f - (W * W), 0.0f));

                if (S >= 0.0001)
                {
                    return new Vector3(X / S, Y / S, Z / S);
                }

                return new Vector3(1, 0, 0);
            }
        }

        /// <summary>
        /// 이 사원수의 역을 가져옵니다.
        /// </summary>
        public Quaternion Inverse
        {
            get => new Quaternion(-X, -Y, -Z, W);
        }

        /// <summary>
        /// 정규화된 사원수 값을 가져옵니다.
        /// </summary>
        public Quaternion Normalized
        {
            get
            {
                var length = MathEx.Sqrt(X * X + Y * Y + Z * Z + W * W);
                return new Quaternion(X / length, Y / length, Z / length, W / length);
            }
        }

        /// <summary>
        /// 사원수를 회전 행렬로 변환합니다.
        /// </summary>
        /// <returns> 값이 반환됩니다. </returns>
        public Matrix4x4 ToMatrix()
        {
            float x2 = X * X;
            float y2 = Y * Y;
            float z2 = Z * Z;
            float xy = X * Y;
            float xz = X * Z;
            float yz = Y * Z;
            float wx = W * X;
            float wy = W * Y;
            float wz = W * Z;

            Matrix4x4 M;
            M._11 = 1.0f - 2.0f * (y2 + z2);
            M._12 = 2.0f * (xy - wz);
            M._13 = 2.0f * (xz + wy);
            M._14 = 0.0f;

            M._21 = 2.0f * (xy + wz);
            M._22 = 1.0f - 2.0f * (x2 + z2);
            M._23 = 2.0f * (yz - wx);
            M._24 = 0.0f;

            M._31 = 2.0f * (xz - wy);
            M._32 = 2.0f * (yz + wx);
            M._33 = 1.0f - 2.0f * (x2 + y2);
            M._34 = 0.0f;

            M._41 = 2.0f * (xz - wy);
            M._42 = 2.0f * (yz + wx);
            M._43 = 1.0f - 2.0f * (x2 + y2);
            M._44 = 0.0f;

            return M;
        }

        /// <summary>
        /// 두 사원수가 나타내는 회전을 더한 회전을 나타내는 사원수를 계산합니다.
        /// </summary>
        /// <param name="InLeft"> 첫 번째 사원수를 전달합니다. </param>
        /// <param name="InRight"> 두 번째 사원수를 전달합니다. </param>
        /// <returns> 계산된 사원수 개체가 반환됩니다. </returns>
        public static Quaternion Concatenate(Quaternion InLeft, Quaternion InRight)
        {
            Quaternion quaternion;
            float x = (InRight.Y * InLeft.Z) - (InRight.Z * InLeft.Y);
            float y = (InRight.Z * InLeft.X) - (InRight.X * InLeft.Z);
            float z = (InRight.X * InLeft.Y) - (InRight.Y * InLeft.X);
            float w = ((InRight.X * InLeft.X) + (InRight.Y * InLeft.Y)) + (InRight.Z * InLeft.Z);
            quaternion.X = ((InRight.X * InLeft.W) + (InLeft.X * InRight.W)) + x;
            quaternion.Y = ((InRight.Y * InLeft.W) + (InLeft.Y * InRight.W)) + y;
            quaternion.Z = ((InRight.Z * InLeft.W) + (InLeft.Z * InRight.W)) + z;
            quaternion.W = (InRight.W * InLeft.W) - w;
            return quaternion;
        }

        /// <summary>
        /// 전달된 사원수가 나타내는 회전을 더한 회전을 나타내는 사원수를 계산합니다. 계산은 첫 번째 인자부터 순서대로 진행됩니다.
        /// </summary>
        /// <param name="InQuats"> 사원수 목록을 전달합니다. </param>
        /// <returns> 계산된 사원수 개체가 반환됩니다. </returns>
        public static Quaternion Concatenate(params Quaternion[] InQuats)
        {
            Quaternion quaternion = InQuats[0];

            for (int i = 1; i < InQuats.Length; ++i)
            {
                quaternion = Concatenate(quaternion, InQuats[i]);
            }

            return quaternion;
        }

        /// <summary>
        /// 축 및 각도로부터 축에 회전하는 사원수를 계산합니다.
        /// </summary>
        /// <param name="InAxis"> 정규화된 축을 전달합니다. </param>
        /// <param name="InAngleRadian"> 각도를 라디안 단위로 전달합니다. </param>
        /// <returns> 계산된 사원수가 반환됩니다. </returns>
        public static Quaternion FromAxisAngle(Vector3 InAxis, float InAngleRadian)
        {
            float half = InAngleRadian * 0.5f;
            float vsin = MathEx.Sin(half);
            float vcos = MathEx.Cos(half);

            Quaternion quat;
            quat.X = InAxis.X * vsin;
            quat.Y = InAxis.Y * vsin;
            quat.Z = InAxis.Z * vsin;
            quat.W = vcos;

            return quat;
        }

        /// <summary>
        /// 회전을 나타내는 행렬로부터 사원수를 계산합니다.
        /// </summary>
        /// <param name="InRotMatrix"> 회전을 나타내는 행렬을 전달합니다. </param>
        /// <returns> 계산된 사원수가 반환됩니다. </returns>
        public static Quaternion FromMatrix(Matrix4x4 InRotMatrix)
        {
            float side = (InRotMatrix._11 + InRotMatrix._22) + InRotMatrix._33;

            var quaternion = new Quaternion();
            if (side > 0)
            {
                float sq = MathEx.Sqrt(side + 1);
                float sqiv = 0.5f / sq;
                quaternion.W = sq * 0.5f;
                quaternion.X = (InRotMatrix._23 - InRotMatrix._32) * sqiv;
                quaternion.Y = (InRotMatrix._31 - InRotMatrix._13) * sqiv;
                quaternion.Z = (InRotMatrix._12 - InRotMatrix._21) * sqiv;
            }

            else if ((InRotMatrix._11 >= InRotMatrix._22) && (InRotMatrix._11 >= InRotMatrix._33))
            {
                float sq = MathEx.Sqrt(((1 + InRotMatrix._11) - InRotMatrix._22) - InRotMatrix._33);
                float sqiv = 0.5f / sq;
                quaternion.X = 0.5f * sq;
                quaternion.Y = (InRotMatrix._12 + InRotMatrix._21) * sqiv;
                quaternion.Z = (InRotMatrix._13 + InRotMatrix._31) * sqiv;
                quaternion.W = (InRotMatrix._23 - InRotMatrix._32) * sqiv;
            }

            else if (InRotMatrix._22 > InRotMatrix._33)
            {
                float sq = MathEx.Sqrt(((1 + InRotMatrix._22) - InRotMatrix._11) - InRotMatrix._33);
                float sqiv = 0.5f / sq;
                quaternion.X = (InRotMatrix._21 + InRotMatrix._12) * sqiv;
                quaternion.Y = 0.5f * sq;
                quaternion.Z = (InRotMatrix._32 + InRotMatrix._23) * sqiv;
                quaternion.W = (InRotMatrix._31 - InRotMatrix._13) * sqiv;
            }

            else
            {
                float sq = MathEx.Sqrt(((1 + InRotMatrix._33) - InRotMatrix._11) - InRotMatrix._22);
                float sqiv = 0.5f / sq;
                quaternion.X = (InRotMatrix._31 + InRotMatrix._13) * sqiv;
                quaternion.Y = (InRotMatrix._32 + InRotMatrix._23) * sqiv;
                quaternion.Z = 0.5f * sq;
                quaternion.W = (InRotMatrix._12 - InRotMatrix._21) * sqiv;
            }

            return quaternion;
        }

        /// <summary>
        /// 오일러 각도 조합으로부터 회전을 생성합니다. 회전 우선 순위는 Yaw, Pitch, Roll 순입니다.
        /// </summary>
        /// <param name="InYaw"> 요 회전 각도를 전달합니다. </param>
        /// <param name="InPitch"> 피치 회전 각도를 전달합니다. </param>
        /// <param name="InRoll"> 롤 회전 각도를 전달합니다. </param>
        /// <returns> 생성된 회전 사원수 개체가 반환됩니다. </returns>
        public static Quaternion FromEuler(float InYaw, float InPitch, float InRoll)
        {
            var yaw = FromAxisAngle(Vector3.Up, InYaw.ToRadians());
            var pitch = FromAxisAngle(Vector3.Right, InPitch.ToRadians());
            var roll = FromAxisAngle(Vector3.Forward, InRoll.ToRadians());

            return Concatenate(yaw, pitch, roll);
        }

        /// <summary>
        /// 두 사원수의 내적 연산한 결과를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 사원수를 전달합니다. </param>
        /// <param name="right"> 두 번째 사원수를 전달합니다. </param>
        /// <returns> 연산 결과가 반환됩니다. </returns>
        public static float DotProduct(Quaternion left, Quaternion right)
        {
            return left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.X * right.W;
        }

        /// <summary>
        /// 선형 보간 결과를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 사원수 값을 전달합니다. </param>
        /// <param name="right"> 두 번째 사원수 값을 전달합니다. </param>
        /// <param name="t"> 보간 값을 전달합니다. </param>
        /// <returns> 보간된 사원수가 반환됩니다. </returns>
        public static Quaternion Lerp(Quaternion left, Quaternion right, float t)
        {
            float Dot = DotProduct(left, right);
            float Bias = Dot >= 0 ? 1.0f : -1.0f;
            return (right * t) + (left * (Bias * (1 - t)));
        }

        /// <summary>
        /// 원형 보간 결과를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 사원수 값을 전달합니다. </param>
        /// <param name="right"> 두 번째 사원수 값을 전달합니다. </param>
        /// <param name="t"> 보간 값을 전달합니다. </param>
        /// <returns> 보간된 사원수가 반환됩니다. </returns>
        public static Quaternion Slerp(Quaternion left, Quaternion right, float t)
        {
            float Threshold = 0.9995f;

            Quaternion v0 = left.Normalized;
            Quaternion v1 = right.Normalized;

            float dot = DotProduct(v0, v1);

            if (dot < 0)
            {
                v1 = -v1;
                dot = -dot;
            }

            float theta_0 = MathEx.Acos(dot);
            float theta = theta_0 * t;
            theta = Math.Clamp(theta, 0.0f, 3.1415926535f);
            if (theta > theta_0)
            {
                return left;
            }

            if (dot > Threshold)
            {
                return Lerp(v0, v1, t).Normalized;
            }

            float sin_theta = MathEx.Sin(theta);
            float sin_theta_0 = MathEx.Sin(theta_0);

            float s0 = MathEx.Cos(theta) - dot * sin_theta / sin_theta_0;
            float s1 = sin_theta / sin_theta_0;

            return v0 * s0 + v1 * s1;
        }

        /// <summary> 방향을 바라보는 회전 사원수를 가져옵니다. </summary>
        /// <param name="forward"> 방향을 전달합니다. </param>
        /// <param name="up"> 상향 벡터를 전달합니다. </param>
        public static Quaternion LookTo(Vector3 forward, Vector3 up)
        {
            Quaternion t;

            forward = forward.Normalized;
            Vector3 right = Vector3.CrossProduct(up, forward).Normalized;
            up = Vector3.CrossProduct(forward, right).Normalized;

            var rotation = new Matrix4x4(
                right.X, up.X, forward.X, 0,
                right.Y, up.Y, forward.Y, 0,
                right.Z, up.Z, forward.Z, 0,
                0, 0, 0, 1
            );

            t.W = MathEx.Sqrt(1.0f + rotation._11 + rotation._22 + rotation._33) * 0.5f;

            float w4_recip = 1.0f / (4.0f * t.W);
            t.X = (rotation._32 - rotation._23) * w4_recip;
            t.Y = (rotation._13 - rotation._31) * w4_recip;
            t.Z = (rotation._21 - rotation._12) * w4_recip;

            return t.Normalized;
        }

        /// <summary>
        /// 부호가 변경된 사원수 값을 가져옵니다.
        /// </summary>
        /// <param name="left"> 사원수를 전달합니다. </param>
        /// <returns> 사원수가 반환됩니다. </returns>
        public static Quaternion operator -(Quaternion left)
        {
            return new Quaternion(-left.X, -left.Y, -left.Z, -left.W);
        }

        /// <summary>
        /// 두 사원수를 단순 덧셈한 사원수를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 사원수를 전달합니다. </param>
        /// <param name="right"> 두 번째 사원수를 전달합니다. </param>
        /// <returns> 계산된 사원수가 반환됩니다. </returns>
        public static Quaternion operator +(Quaternion left, Quaternion right)
        {
            return new Quaternion(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
        }

        /// <summary>
        /// 두 사원수를 단순 뺄셈한 사원수를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 사원수를 전달합니다. </param>
        /// <param name="right"> 두 번째 사원수를 전달합니다. </param>
        /// <returns> 계산된 사원수가 반환됩니다. </returns>
        public static Quaternion operator -(Quaternion left, Quaternion right)
        {
            return new Quaternion(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);
        }

        /// <summary>
        /// 두 사원수를 단순 곱셈한 사원수를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 사원수를 전달합니다. </param>
        /// <param name="right"> 두 번째 사원수를 전달합니다. </param>
        /// <returns> 계산된 사원수가 반환됩니다. </returns>
        public static Quaternion operator *(Quaternion left, Quaternion right)
        {
            return new Quaternion(left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W * right.W);
        }

        /// <summary>
        /// 두 사원수를 단순 곱셈한 사원수를 가져옵니다. 스칼라 값은 모든 원소가 동일한 사원수로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 사원수를 전달합니다. </param>
        /// <param name="right"> 두 번째 사원수를 전달합니다. </param>
        /// <returns> 계산된 사원수가 반환됩니다. </returns>
        public static Quaternion operator *(float left, Quaternion right)
        {
            return new Quaternion(left * right.X, left * right.Y, left * right.Z, left * right.W);
        }

        /// <summary>
        /// 두 사원수를 단순 곱셈한 사원수를 가져옵니다. 스칼라 값은 모든 원소가 동일한 사원수로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 사원수를 전달합니다. </param>
        /// <param name="right"> 두 번째 사원수를 전달합니다. </param>
        /// <returns> 계산된 사원수가 반환됩니다. </returns>
        public static Quaternion operator *(Quaternion left, float right)
        {
            return new Quaternion(left.X * right, left.Y * right, left.Z * right, left.W * right);
        }

        /// <summary>
        /// 두 사원수를 단순 나눗셈한 사원수를 가져옵니다.
        /// </summary>
        /// <param name="left"> 첫 번째 사원수를 전달합니다. </param>
        /// <param name="right"> 두 번째 사원수를 전달합니다. </param>
        /// <returns> 계산된 사원수가 반환됩니다. </returns>
        public static Quaternion operator /(Quaternion left, Quaternion right)
        {
            return new Quaternion(left.X / right.X, left.Y / right.Y, left.Z / right.Z, left.W / right.W);
        }

        /// <summary>
        /// 두 사원수를 단순 나눗셈한 사원수를 가져옵니다. 스칼라 값은 모든 원소가 동일한 사원수로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 사원수를 전달합니다. </param>
        /// <param name="right"> 두 번째 사원수를 전달합니다. </param>
        /// <returns> 계산된 사원수가 반환됩니다. </returns>
        public static Quaternion operator /(float left, Quaternion right)
        {
            return new Quaternion(left / right.X, left / right.Y, left / right.Z, left / right.W);
        }

        /// <summary>
        /// 두 사원수를 단순 나눗셈한 사원수를 가져옵니다. 스칼라 값은 모든 원소가 동일한 사원수로 치환됩니다.
        /// </summary>
        /// <param name="left"> 첫 번째 사원수를 전달합니다. </param>
        /// <param name="right"> 두 번째 사원수를 전달합니다. </param>
        /// <returns> 계산된 사원수가 반환됩니다. </returns>
        public static Quaternion operator /(Quaternion left, float right)
        {
            return new Quaternion(left.X / right, left.Y / right, left.Z / right, left.W / right);
        }

        /// <summary>
        /// 두 사원수의 내적을 계산합니다.
        /// </summary>
        /// <param name="left"> 첫 번째 사원수를 전달합니다. </param>
        /// <param name="right"> 두 번째 사원수를 전달합니다. </param>
        /// <returns> 계산된 스칼라가 반환됩니다. </returns>
        public static float operator |(Quaternion left, Quaternion right)
        {
            return DotProduct(left, right);
        }

        /// <summary>
        /// 두 사원수가 서로 같은지 비교합니다.
        /// </summary>
        /// <param name="left"> 첫 번째 사원수를 전달합니다. </param>
        /// <param name="right"> 두 번째 사원수를 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator ==(Quaternion left, Quaternion right)
        {
            return left.X == right.X && left.Y == right.Y && left.Z == right.Z && left.W == right.W;
        }

        /// <summary>
        /// 두 사원수가 서로 같지 않은지 비교합니다.
        /// </summary>
        /// <param name="left"> 첫 번째 사원수를 전달합니다. </param>
        /// <param name="right"> 두 번째 사원수를 전달합니다. </param>
        /// <returns> 비교 결과가 반환됩니다. </returns>
        public static bool operator !=(Quaternion left, Quaternion right)
        {
            return left.X != right.X || left.Y != right.Y || left.Z != right.Z || left.W != right.W;
        }

        /// <summary>
        /// 모든 값이 0인 사원수를 가져옵니다.
        /// </summary>
        public static Quaternion Zero
        {
            get => new Quaternion(0, 0, 0, 0);
        }

        /// <summary>
        /// 모든 값이 1인 사원수를 가져옵니다.
        /// </summary>
        public static Quaternion One
        {
            get => new Quaternion(1, 1, 1, 1);
        }

        /// <summary>
        /// 단위 사원수를 가져옵니다.
        /// </summary>
        public static Quaternion Identity
        {
            get => new Quaternion(0, 0, 0, 1);
        }
    }
}
