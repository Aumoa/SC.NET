// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;

namespace SC.Engine.Runtime.GameFramework.Camera
{
    /// <summary>
    /// 뷰에 필요한 최소한의 정보를 제공합니다.
    /// </summary>
    public struct MinimalViewInfo
    {
        float _fov;
        float _aspectRatio;
        float _nearPlane;
        float _farPlane;
        Vector3 _location;
        Quaternion _rotation;
        bool _applied;

        /// <summary>
        /// 시야각을 나타냅니다.
        /// </summary>
        public float FOV
        {
            get => _fov;
            set
            {
                _fov = value;
                _applied = false;
            }
        }

        /// <summary>
        /// 종횡비를 나타냅니다.
        /// </summary>
        public float AspectRatio
        {
            get => _aspectRatio;
            set
            {
                _aspectRatio = value;
                _applied = false;
            }
        }

        /// <summary>
        /// 최소 근접 깊이를 나타냅니다.
        /// </summary>
        public float NearPlane
        {
            get => _nearPlane;
            set
            {
                _nearPlane = value;
                _applied = false;
            }
        }

        /// <summary>
        /// 최대 깊이를 나타냅니다.
        /// </summary>
        public float FarPlane
        {
            get => _farPlane;
            set
            {
                _farPlane = value;
                _applied = false;
            }
        }

        /// <summary>
        /// 뷰의 위치를 나타냅니다.
        /// </summary>
        public Vector3 Location
        {
            get => _location;
            set
            {
                _location = value;
                _applied = false;
            }
        }

        /// <summary>
        /// 뷰의 회전을 나타냅니다.
        /// </summary>
        public Quaternion Rotation
        {
            get => _rotation;
            set
            {
                _rotation = value;
                _applied = false;
            }
        }

        Matrix4x4 _viewProj;
        Matrix4x4 _viewProjInv;

        /// <summary>
        /// 뷰 행렬을 가져옵니다.
        /// </summary>
        public Matrix4x4 ViewProj
        {
            get
            {
                if (!_applied)
                {
                    Apply();
                    _applied = true;
                }

                return _viewProj;
            }
        }

        /// <summary>
        /// 뷰 행렬의 역행렬을 가져옵니다.
        /// </summary>
        public Matrix4x4 ViewProjInv
        {
            get
            {
                if (!_applied)
                {
                    Apply();
                    _applied = true;
                }

                return _viewProjInv;
            }
        }

        /// <summary>
        /// 현재 뷰 상태를 적용합니다. 값이 미리 계산됩니다.
        /// </summary>
        public void Apply()
        {
            Vector3 forward = Rotation.RotateVector(Vector3.Forward);
            Vector3 up = Rotation.RotateVector(Vector3.Up);

            var lookTo = Matrix4x4.LookToLH(Location, forward, up);
            Matrix4x4 proj;

            if (FOV != 0)
            {
                proj = Matrix4x4.PerspectiveFovLH(FOV, AspectRatio, NearPlane, FarPlane);
            }
            else
            {
                proj = Matrix4x4.OrthographicLH(AspectRatio, 1.0f, NearPlane, FarPlane);
            }

            var vp = Matrix4x4.Multiply(lookTo, proj);

            _viewProj = vp;
            _viewProjInv = vp.Inverse;
        }
    }
}
