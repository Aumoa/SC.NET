// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using static SC.ThirdParty.WinAPI.CursorFlags;
using static SC.ThirdParty.WinAPI.Kernel32;
using static SC.ThirdParty.WinAPI.SystemMetricsCode;
using static SC.ThirdParty.WinAPI.TrackMouseEventFlags;
using static SC.ThirdParty.WinAPI.User32;
using static SC.ThirdParty.WinAPI.WaitFlags;
using static SC.ThirdParty.WinAPI.WindowMessage;

namespace SC.ThirdParty.WinAPI
{
    /// <summary>
    /// 마우스 이벤트를 추적합니다.
    /// </summary>
    public unsafe class MouseTracker
    {
        const int RID_INPUT               = 0x10000003;
        const int RID_HEADER              = 0x10000005;

        const int RIM_TYPEMOUSE       = 0;
        const int RIM_TYPEKEYBOARD    = 1;
        const int RIM_TYPEHID         = 2;
        const int RIM_TYPEMAX         = 2;
        
        const int MOUSE_MOVE_RELATIVE         = 0;
        const int MOUSE_MOVE_ABSOLUTE         = 1;
        const int MOUSE_VIRTUAL_DESKTOP    = 0x02; // the coordinates are mapped to the virtual desktop
        const int MOUSE_ATTRIBUTES_CHANGED = 0x04; // requery for mouse attributes
        const int MOUSE_MOVE_NOCOALESCE    = 0x08; // do not coalesce mouse moves

        const int XBUTTON1      = 0x0001;
        const int XBUTTON2      = 0x0002;

        short LOWORD(int l)
        {
            return (short)(l & 0xffff);
        }

        short HIWORD(int l)
        {
            return (short)((l >> 16) & 0xffff);
        }

        short GET_WHEEL_DELTA_WPARAM(ulong wParam)
        {
            return HIWORD((int)wParam);
        }

        short GET_XBUTTON_WPARAM(ulong wParam)
        {
            return HIWORD((int)wParam);
        }

        /// <summary>
        /// 마우스 추적 모드를 표현합니다.
        /// </summary>
        public enum PositionMode
        {
            /// <summary>
            /// 절대 좌표를 사용합니다.
            /// </summary>
            Absolute,

            /// <summary>
            /// 상대 좌표를 사용합니다.
            /// </summary>
            Relative
        }

        /// <summary>
        /// 마우스 상태를 표현합니다.
        /// </summary>
        public struct State
        {
            /// <summary>
            /// 왼쪽 마우스 버튼 상태를 나타냅니다.
            /// </summary>
            public bool LeftButton;

            /// <summary>
            /// 가운데 마우스 버튼 상태를 나타냅니다.
            /// </summary>
            public bool MiddleButton;

            /// <summary>
            /// 오른쪽 마우스 버튼 상태를 나타냅니다.
            /// </summary>
            public bool RightButton;

            /// <summary>
            /// 마우스 X1 버튼 상태를 나타냅니다.
            /// </summary>
            public bool XButton1;

            /// <summary>
            /// 마우스 X2 버튼 상태를 나타냅니다.
            /// </summary>
            public bool XButton2;

            /// <summary>
            /// X 위치를 나타냅니다.
            /// </summary>
            /// <remarks>
            /// <para> <see cref="Mode"/>가 <see cref="PositionMode.Absolute"/>라면 화면상 절대 좌표를 나타냅니다. </para>
            /// <para> <see cref="Mode"/>가 <see cref="PositionMode.Relative"/>라면 이전 추적에서 상대적 좌표를 나타냅니다. </para>
            /// </remarks>
            public int X;

            /// <summary>
            /// Y 위치를 나타냅니다.
            /// </summary>
            /// <remarks>
            /// <para> <see cref="Mode"/>가 <see cref="PositionMode.Absolute"/>라면 화면상 절대 좌표를 나타냅니다. </para>
            /// <para> <see cref="Mode"/>가 <see cref="PositionMode.Relative"/>라면 이전 추적에서 상대적 좌표를 나타냅니다. </para>
            /// </remarks>
            public int Y;

            /// <summary>
            /// 스크롤 휠 값을 나타냅니다.
            /// </summary>
            public int ScrollWheelValue;

            /// <summary>
            /// 마우스 위치 추적 모드를 나타냅니다.
            /// </summary>
            public PositionMode Mode;
        }

        /// <summary>
        /// 마우스 버튼 상태를 추적합니다.
        /// </summary>
        public class ButtonStateTracker
        {
            /// <summary>
            /// 버튼의 상태를 표현합니다.
            /// </summary>
            public enum ButtonState
            {
                /// <summary>
                /// 마우스 버튼이 놓인 상태입니다.
                /// </summary>
                Up = 0,

                /// <summary>
                /// 마우스 버튼이 눌러진 상태입니다.
                /// </summary>
                Held = 1,

                /// <summary>
                /// 마우스 버튼이 놓였습니다.
                /// </summary>
                Released = 2,

                /// <summary>
                /// 마우스 버튼이 눌러졌습니다.
                /// </summary>
                Pressed = 3,
            }

            State _lastState;

            /// <summary>
            /// 개체를 초기화합니다.
            /// </summary>
            public ButtonStateTracker()
            {

            }

            ButtonState _leftButton;
            ButtonState _middleButton;
            ButtonState _rightButton;
            ButtonState _x1Button;
            ButtonState _x2Button;

            /// <summary>
            /// 왼쪽 마우스 버튼의 상태를 가져옵니다.
            /// </summary>
            public ButtonState LeftButton => _leftButton;

            /// <summary>
            /// 가운데 마우스 버튼의 상태를 가져옵니다.
            /// </summary>
            public ButtonState MiddleButton => _middleButton;

            /// <summary>
            /// 오른쪽 마우스 버튼의 상태를 가져옵니다.
            /// </summary>
            public ButtonState RightButton => _rightButton;

            /// <summary>
            /// 마우스 X1 버튼의 상태를 가져옵니다.
            /// </summary>
            public ButtonState XButton1 => _x1Button;

            /// <summary>
            /// 마우스 X2 버튼의 상태를 가져옵니다.
            /// </summary>
            public ButtonState XButton2 => _x2Button;

            /// <summary>
            /// 마우스 상태를 갱신합니다.
            /// </summary>
            /// <param name="state"> 상태를 전달합니다. </param>
            public void Update(State state)
            {
                UpdateButtonState(ref _leftButton, ref state.LeftButton);
                UpdateButtonState(ref _middleButton, ref state.MiddleButton);
                UpdateButtonState(ref _rightButton, ref state.RightButton);
                UpdateButtonState(ref _x1Button, ref state.XButton1);
                UpdateButtonState(ref _x2Button, ref state.XButton2);

                _lastState = state;
            }

            /// <summary>
            /// 상태를 초기화합니다.
            /// </summary>
            public void Reset()
            {
                _leftButton = 0;
                _middleButton = 0;
                _rightButton = 0;
                _x1Button = 0;
                _x2Button = 0;
                _lastState = new();
            }

            /// <summary>
            /// 마지막 상태를 가져옵니다.
            /// </summary>
            /// <returns> 값이 반환됩니다. </returns>
            public State GetLastState()
            {
                return _lastState;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            void UpdateButtonState(ref ButtonState field, ref bool inField)
            {
                field = (ButtonState)(((!!inField) ? 1 : 0) | (((!!inField ? 1 : 0) ^ (!!(field != 0) ? 1 : 0)) << 1));
            }
        }

        MouseTracker()
        {

        }

        static MouseTracker _instance;

        /// <summary>
        /// 싱글톤 인스턴스를 가져옵니다.
        /// </summary>
        /// <returns> 개체가 반환됩니다. </returns>
        public static MouseTracker GetInstance() => _instance ??= new MouseTracker();

        /// <summary>
        /// 마우스 보이기 상태를 설정합니다.
        /// </summary>
        public bool IsVisible
        {
            get
            {
                if (mMode == PositionMode.Relative)
                {
                    return false;
                }

                CURSORINFO info = new();
                info.cbSize = (uint)sizeof(CURSORINFO);
                if (!GetCursorInfo(ref info))
                {
                    return false;
                }

                return (info.flags & CURSOR_SHOWING) != 0;
            }
            set
            {
                if (IsVisible != value)
                {
                    _ = ShowCursor(value);
                }
            }
        }

        /// <summary>
        /// 마우스 디바이스와 연결된 상태인지 나타내는 값을 가져옵니다.
        /// </summary>
        public bool IsConnected
        {
            get
            {
                return GetSystemMetrics(SM_MOUSEPRESENT) != 0;
            }
        }

        Window mWindow;
        PositionMode mMode = PositionMode.Absolute;

        EventHandle mScrollWheelValue = new(EventFlags.ManualReset, GenericAccess.EventModifyState | GenericAccess.Synchronize);
        EventHandle mRelativeRead = new(EventFlags.ManualReset, GenericAccess.EventModifyState | GenericAccess.Synchronize);
        EventHandle mAbsoluteMode = new(accessFlags: GenericAccess.EventModifyState | GenericAccess.Synchronize);
        EventHandle mRelativeMode = new(accessFlags: GenericAccess.EventModifyState | GenericAccess.Synchronize);

        int mLastX;
        int mLastY;
        int mRelativeX = int.MaxValue;
        int mRelativeY = int.MaxValue;

        bool mInFocus = true;
        State mState;

        /// <summary>
        /// 현재 마우스 상태를 가져옵니다.
        /// </summary>
        /// <param name="state"> 상태가 반환됩니다. </param>
        public void GetState(out State state)
        {
            unchecked
            {
                state = mState;
                state.Mode = mMode;

                uint result = WaitForSingleObjectEx(mScrollWheelValue.GetHandle(), 0, false);
                if (result == (uint)WAIT_FAILED)
                {
                    throw new Win32Exception(GetLastError());
                }

                if (result == (uint)WAIT_OBJECT_0)
                {
                    state.ScrollWheelValue = 0;
                }

                if (state.Mode == PositionMode.Relative)
                {
                    result = WaitForSingleObjectEx(mRelativeRead.GetHandle(), 0, false);

                    if (result == (uint)WAIT_FAILED)
                    {
                        throw new Win32Exception(GetLastError());
                    }

                    if (result == (uint)WAIT_OBJECT_0)
                    {
                        state.X = 0;
                        state.Y = 0;
                    }
                    else
                    {
                        mRelativeRead.Set();
                    }
                }
            }
        }

        void ResetScrollWheelValue()
        {
            mScrollWheelValue.Set();
        }

        /// <summary>
        /// 마우스 위치 추적 모드를 설정합니다.
        /// </summary>
        /// <param name="mode"> 모드를 전달합니다. </param>
        public void SetMode(PositionMode mode)
        {
            if (mMode == mode)
            {
                return;
            }

            (mode == PositionMode.Absolute ? mAbsoluteMode : mRelativeMode).Set();
            if (mWindow is null)
            {
                throw new NullReferenceException();
            }

            TRACKMOUSEEVENT tme = new();
            tme.cbSize = (uint)sizeof(TRACKMOUSEEVENT);
            tme.dwFlags = (uint)TME_HOVER;
            tme.hwndTrack = mWindow.GetHandle();
            tme.dwHoverTime = 1;
            if (!TrackMouseEvent(ref tme))
            {
                throw new Win32Exception(GetLastError());
            }
        }

        void SetWindow(Window window)
        {
            if (mWindow == window)
            {
                return;
            }

            RAWINPUTDEVICE Rid = new();
            Rid.usUsagePage = 0x1;
            Rid.usUsage = 0x2;
            Rid.dwFlags = 0x100;
            Rid.hwndTarget = window.GetHandle();
            if (!RegisterRawInputDevices(ref Rid, 1, (uint)sizeof(RAWINPUTDEVICE)))
            {
                throw new Win32Exception(GetLastError());
            }

            mWindow = window;
        }

        void ClipToWindow()
        {
            RECT rect;
            GetClientRect(mWindow.GetHandle(), out rect);

            POINT ul;
            ul.x = rect.left;
            ul.y = rect.top;

            POINT lr;
            lr.x = rect.right;
            lr.y = rect.bottom;

            MapWindowPoints(mWindow.GetHandle(), IntPtr.Zero, ref ul, 1);
            MapWindowPoints(mWindow.GetHandle(), IntPtr.Zero, ref lr, 1);

            rect.left = ul.x;
            rect.top = ul.y;

            rect.right = lr.x;
            rect.bottom = lr.y;

            ClipCursor(ref rect);
        }

        /// <summary>
        /// 마우스 이벤트를 처리합니다.
        /// </summary>
        /// <param name="uMsg"> 메시지 ID를 전달합니다. </param>
        /// <param name="wParam"> 첫 번째 매개변수를 전달합니다. </param>
        /// <param name="lParam"> 두 번째 매개변수를 전달합니다. </param>
        /// <example>
        /// <code>
        /// switch (message)
        /// {
        ///     case WM_ACTIVATEAPP:
        ///     case WM_INPUT:
        ///     case WM_MOUSEMOVE:
        ///     case WM_LBUTTONDOWN:
        ///     case WM_LBUTTONUP:
        ///     case WM_RBUTTONDOWN:
        ///     case WM_RBUTTONUP:
        ///     case WM_MBUTTONDOWN:
        ///     case WM_MBUTTONUP:
        ///     case WM_MOUSEWHEEL:
        ///     case WM_XBUTTONDOWN:
        ///     case WM_XBUTTONUP:
        ///     case WM_MOUSEHOVER:
        ///         WinMouse::ProcessMessage(message, wParam, lParam);
        ///         break;
        /// }
        /// </code>
        /// </example>
        public void ProcessMessage(uint uMsg, ulong wParam, long lParam)
        {
            var events = new IntPtr[] { mScrollWheelValue.GetHandle(), mAbsoluteMode.GetHandle(), mRelativeMode.GetHandle() };
            switch ((WaitFlags)WaitForMultipleObjectsEx((uint)events.Length, events, false, 0, false))
            {
                case WAIT_OBJECT_0:
                    mState.ScrollWheelValue = 0;
                    ResetEvent(events[0]);
                    break;

                case (WAIT_OBJECT_0 + 1):
                    RECT rc = new();
                    mMode = PositionMode.Absolute;
                    ClipCursor(ref rc);

                    POINT point;
                    point.x = mLastX;
                    point.y = mLastY;

                    // We show the cursor before moving it to support Remote Desktop
                    ShowCursor(true);

                    if (MapWindowPoints(mWindow.GetHandle(), IntPtr.Zero, ref point, 1) != 0)
                    {
                        SetCursorPos(point.x, point.y);
                    }
                    mState.X = mLastX;
                    mState.Y = mLastY;
                    break;

                case WAIT_OBJECT_0 + 2:
                    mRelativeRead.Reset();

                    mMode = PositionMode.Relative;
                    mState.X = mState.Y = 0;
                    mRelativeX = int.MaxValue;
                    mRelativeY = int.MaxValue;

                    ShowCursor(false);

                    ClipToWindow();
                    break;

                case WAIT_FAILED:
                    throw new Win32Exception(GetLastError());

                case WAIT_TIMEOUT:
                default:
                    break;
            }

            switch ((WindowMessage)uMsg)
            {
                case WM_ACTIVATEAPP:
                    if (wParam != 0)
                    {
                        mInFocus = true;

                        if (mMode == PositionMode.Relative)
                        {
                            mState.X = mState.Y = 0;

                            ShowCursor(false);

                            ClipToWindow();
                        }
                    }
                    else
                    {
                        int scrollWheel = mState.ScrollWheelValue;
                        mState = new();
                        mState.ScrollWheelValue = scrollWheel;

                        mInFocus = false;
                    }
                    return;

                case WM_INPUT:
                    if (mInFocus && mMode == PositionMode.Relative)
                    {
                        RAWINPUT raw;
                        uint rawSize = (uint)sizeof(RAWINPUT);

                        uint resultData = GetRawInputData(new IntPtr(lParam), RID_INPUT, &raw, &rawSize, (uint)sizeof(RAWINPUTHEADER));
                        if (resultData == unchecked((uint)-1))
                        {
                            throw new Exception("GetRawInputData");
                        }

                        if (raw.header.dwType == RIM_TYPEMOUSE)
                        {
                            if ((raw.data.mouse.usFlags & MOUSE_MOVE_ABSOLUTE) == 0)
                            {
                                mState.X = raw.data.mouse.lLastX;
                                mState.Y = raw.data.mouse.lLastY;

                                mRelativeRead.Reset();
                            }
                            else if ((raw.data.mouse.usFlags & MOUSE_VIRTUAL_DESKTOP) != 0)
                            {
                                // This is used to make Remote Desktop sessons work
                                int width = GetSystemMetrics(SM_CXVIRTUALSCREEN);
                                int height = GetSystemMetrics(SM_CYVIRTUALSCREEN);

                                int x = (int)(raw.data.mouse.lLastX / 65535.0f * width);
                                int y = (int)(raw.data.mouse.lLastY / 65535.0f * height);

                                if (mRelativeX == int.MaxValue)
                                {
                                    mState.X = mState.Y = 0;
                                }
                                else
                                {
                                    mState.X = x - mRelativeX;
                                    mState.Y = y - mRelativeY;
                                }

                                mRelativeX = x;
                                mRelativeY = y;

                                mRelativeRead.Reset();
                            }
                        }
                    }
                    return;

                case WM_MOUSEMOVE:
                    break;

                case WM_LBUTTONDOWN:
                    mState.LeftButton = true;
                    break;

                case WM_LBUTTONUP:
                    mState.LeftButton = false;
                    break;

                case WM_RBUTTONDOWN:
                    mState.RightButton = true;
                    break;

                case WM_RBUTTONUP:
                    mState.RightButton = false;
                    break;

                case WM_MBUTTONDOWN:
                    mState.MiddleButton = true;
                    break;

                case WM_MBUTTONUP:
                    mState.MiddleButton = false;
                    break;

                case WM_MOUSEWHEEL:
                    mState.ScrollWheelValue += GET_WHEEL_DELTA_WPARAM(wParam);
                    return;

                case WM_XBUTTONDOWN:
                    switch (GET_XBUTTON_WPARAM(wParam))
                    {
                        case XBUTTON1:
                            mState.XButton1 = true;
                            break;

                        case XBUTTON2:
                            mState.XButton2 = true;
                            break;
                    }
                    break;

                case WM_XBUTTONUP:
                    switch (GET_XBUTTON_WPARAM(wParam))
                    {
                        case XBUTTON1:
                            mState.XButton1 = false;
                            break;

                        case XBUTTON2:
                            mState.XButton2 = false;
                            break;
                    }
                    break;

                case WM_MOUSEHOVER:
                    break;

                default:
                    // Not a mouse message, so exit
                    return;
            }

            if (mMode == PositionMode.Absolute)
            {
                int xPos = LOWORD((int)lParam);
                int yPos = HIWORD((int)lParam);

                mState.X = mLastX = xPos;
                mState.Y = mLastY = yPos;
            }
        }
    }
}