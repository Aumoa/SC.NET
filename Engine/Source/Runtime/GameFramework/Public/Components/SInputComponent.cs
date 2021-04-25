// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.GameCore;
using SC.ThirdParty.WinAPI;

namespace SC.Engine.Runtime.GameFramework.Components
{
    /// <summary>
    /// 입력을 처리하는 컴포넌트입니다.
    /// </summary>
    public class SInputComponent : SActorComponent
    {
        /// <summary>
        /// 키를 나타냅니다.
        /// </summary>
        public enum Key
        {
#pragma warning disable CS1591 // 공개된 형식 또는 멤버에 대한 XML 주석이 없습니다.
            None = 0,

            Back = 0x8,
            Tab = 0x9,

            Enter = 0xd,

            Pause = 0x13,
            CapsLock = 0x14,
            Kana = 0x15,

            Kanji = 0x19,

            Escape = 0x1b,
            ImeConvert = 0x1c,
            ImeNoConvert = 0x1d,

            Space = 0x20,
            PageUp = 0x21,
            PageDown = 0x22,
            End = 0x23,
            Home = 0x24,
            Left = 0x25,
            Up = 0x26,
            Right = 0x27,
            Down = 0x28,
            Select = 0x29,
            Print = 0x2a,
            Execute = 0x2b,
            PrintScreen = 0x2c,
            Insert = 0x2d,
            Delete = 0x2e,
            Help = 0x2f,
            D0 = 0x30,
            D1 = 0x31,
            D2 = 0x32,
            D3 = 0x33,
            D4 = 0x34,
            D5 = 0x35,
            D6 = 0x36,
            D7 = 0x37,
            D8 = 0x38,
            D9 = 0x39,

            A = 0x41,
            B = 0x42,
            C = 0x43,
            D = 0x44,
            E = 0x45,
            F = 0x46,
            G = 0x47,
            H = 0x48,
            I = 0x49,
            J = 0x4a,
            K = 0x4b,
            L = 0x4c,
            M = 0x4d,
            N = 0x4e,
            O = 0x4f,
            P = 0x50,
            Q = 0x51,
            R = 0x52,
            S = 0x53,
            T = 0x54,
            U = 0x55,
            V = 0x56,
            W = 0x57,
            X = 0x58,
            Y = 0x59,
            Z = 0x5a,
            LeftWindows = 0x5b,
            RightWindows = 0x5c,
            Apps = 0x5d,

            Sleep = 0x5f,
            NumPad0 = 0x60,
            NumPad1 = 0x61,
            NumPad2 = 0x62,
            NumPad3 = 0x63,
            NumPad4 = 0x64,
            NumPad5 = 0x65,
            NumPad6 = 0x66,
            NumPad7 = 0x67,
            NumPad8 = 0x68,
            NumPad9 = 0x69,
            Multiply = 0x6a,
            Add = 0x6b,
            Separator = 0x6c,
            Subtract = 0x6d,

            Decimal = 0x6e,
            Divide = 0x6f,
            F1 = 0x70,
            F2 = 0x71,
            F3 = 0x72,
            F4 = 0x73,
            F5 = 0x74,
            F6 = 0x75,
            F7 = 0x76,
            F8 = 0x77,
            F9 = 0x78,
            F10 = 0x79,
            F11 = 0x7a,
            F12 = 0x7b,
            F13 = 0x7c,
            F14 = 0x7d,
            F15 = 0x7e,
            F16 = 0x7f,
            F17 = 0x80,
            F18 = 0x81,
            F19 = 0x82,
            F20 = 0x83,
            F21 = 0x84,
            F22 = 0x85,
            F23 = 0x86,
            F24 = 0x87,

            NumLock = 0x90,
            Scroll = 0x91,

            LeftShift = 0xa0,
            RightShift = 0xa1,
            LeftControl = 0xa2,
            RightControl = 0xa3,
            LeftAlt = 0xa4,
            RightAlt = 0xa5,
            BrowserBack = 0xa6,
            BrowserForward = 0xa7,
            BrowserRefresh = 0xa8,
            BrowserStop = 0xa9,
            BrowserSearch = 0xaa,
            BrowserFavorites = 0xab,
            BrowserHome = 0xac,
            VolumeMute = 0xad,
            VolumeDown = 0xae,
            VolumeUp = 0xaf,
            MediaNextTrack = 0xb0,
            MediaPreviousTrack = 0xb1,
            MediaStop = 0xb2,
            MediaPlayPause = 0xb3,
            LaunchMail = 0xb4,
            SelectMedia = 0xb5,
            LaunchApplication1 = 0xb6,
            LaunchApplication2 = 0xb7,

            OemSemicolon = 0xba,
            OemPlus = 0xbb,
            OemComma = 0xbc,
            OemMinus = 0xbd,
            OemPeriod = 0xbe,
            OemQuestion = 0xbf,
            OemTilde = 0xc0,

            OemOpenBrackets = 0xdb,
            OemPipe = 0xdc,
            OemCloseBrackets = 0xdd,
            OemQuotes = 0xde,
            Oem8 = 0xdf,

            OemBackslash = 0xe2,

            ProcessKey = 0xe5,

            OemCopy = 0xf2,
            OemAuto = 0xf3,
            OemEnlW = 0xf4,

            Attn = 0xf6,
            Crsel = 0xf7,
            Exsel = 0xf8,
            EraseEof = 0xf9,
            Play = 0xfa,
            Zoom = 0xfb,

            Pa1 = 0xfd,
            OemClear = 0xfe,
#pragma warning restore CS1591 // 공개된 형식 또는 멤버에 대한 XML 주석이 없습니다.
        };

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
        /// 키가 눌러졌을 때 발생되는 이벤트의 대리자입니다.
        /// </summary>
        /// <param name="key"> 키가 전달됩니다. </param>
        public delegate void KeyPressedDelegate(Key key);

        /// <summary>
        /// 키가 놓였을 때 발생되는 이벤트의 대리자입니다.
        /// </summary>
        /// <param name="key"> 키가 전달됩니다. </param>
        public delegate void KeyReleasedDelegate(Key key);

        /// <summary>
        /// 마우스가 이동되었을 때 발생하는 이벤트의 대리자입니다.
        /// </summary>
        /// <param name="mode"> 좌표 지정 모드가 전달됩니다. </param>
        /// <param name="x"> X 좌표가 전달됩니다. <see cref="PositionMode.Relative"/>일 경우 이동량이 전달됩니다. </param>
        /// <param name="y"> Y 좌표가 전달됩니다. <see cref="PositionMode.Relative"/>일 경우 이동량이 전달됩니다. </param>
        public delegate void MouseMovedDelegate(PositionMode mode, int x, int y);

        /// <summary>
        /// 마우스 버튼이 클릭되었을 때 발생하는 이벤트의 대리자입니다.
        /// </summary>
        public delegate void MouseKeyPressedDelegate();

        /// <summary>
        /// 마우스 버튼이 놓였을 때 발생되는 이벤트의 대리자입니다.
        /// </summary>
        public delegate void MouseKeyReleasedDelegate();

        /// <summary>
        /// 마우스 휠이 이동되었을 때 발생하는 이벤트의 대리자입니다.
        /// </summary>
        /// <param name="dy"> 이동량이 전달됩니다. </param>
        public delegate void MouseWheelMovedDelegate(int dy);

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public SInputComponent()
        {
            var keyTracker = KeyboardTracker.GetInstance();
            keyTracker.KeyPressed += (key) => KeyPressed?.Invoke((Key)key);
            keyTracker.KeyReleased += (key) => KeyReleased?.Invoke((Key)key);

            var mouseTracker = MouseTracker.GetInstance();
            mouseTracker.MouseMoved += (mode, x, y) => MouseMoved?.Invoke((PositionMode)mode, x, y);
            mouseTracker.LeftButtonPressed += () => LeftButtonPressed?.Invoke();
            mouseTracker.LeftButtonReleased += () => LeftButtonReleased?.Invoke();
            mouseTracker.MiddleButtonPressed += () => MiddleButtonPressed?.Invoke();
            mouseTracker.MiddleButtonReleased += () => MiddleButtonReleased?.Invoke();
            mouseTracker.RightButtonPressed += () => RightButtonPressed?.Invoke();
            mouseTracker.RightButtonReleased += () => RightButtonReleased?.Invoke();
            mouseTracker.X1ButtonPressed += () => X1ButtonPressed?.Invoke();
            mouseTracker.X1ButtonReleased += () => X1ButtonReleased?.Invoke();
            mouseTracker.X2ButtonPressed += () => X2ButtonPressed?.Invoke();
            mouseTracker.X2ButtonReleased += () => X2ButtonReleased?.Invoke();
            mouseTracker.MouseWheelMoved += (dy) => MouseWheelMoved?.Invoke(dy);
        }

        /// <inheritdoc/>
        public override void TickComponent(double deltaTime)
        {
            base.TickComponent(deltaTime);
        }

        /// <summary>
        /// 키가 눌러졌을 때 발생되는 이벤트입니다.
        /// </summary>
        public event KeyPressedDelegate KeyPressed;

        /// <summary>
        /// 키가 놓였을 때 발생하는 이벤트입니다.
        /// </summary>
        public event KeyReleasedDelegate KeyReleased;

        /// <summary>
        /// 마우스가 이동되었을 때 발생하는 이벤트입니다.
        /// </summary>
        public event MouseMovedDelegate MouseMoved;

        /// <summary>
        /// 마우스 왼쪽 버튼이 클릭되었을 때 발생하는 이벤트입니다.
        /// </summary>
        public event MouseKeyPressedDelegate LeftButtonPressed;

        /// <summary>
        /// 마우스 왼쪽 버튼이 놓였을 때 발생하는 이벤트입니다.
        /// </summary>
        public event MouseKeyReleasedDelegate LeftButtonReleased;

        /// <summary>
        /// 마우스 가운데 버튼이 클릭되었을 때 발생하는 이벤트입니다.
        /// </summary>
        public event MouseKeyPressedDelegate MiddleButtonPressed;

        /// <summary>
        /// 마우스 가운데 버튼이 놓였을 때 발생하는 이벤트입니다.
        /// </summary>
        public event MouseKeyReleasedDelegate MiddleButtonReleased;

        /// <summary>
        /// 마우스 오른쪽 버튼이 클릭되었을 때 발생하는 이벤트입니다.
        /// </summary>
        public event MouseKeyPressedDelegate RightButtonPressed;

        /// <summary>
        /// 마우스 오른쪽 버튼이 놓였을 때 발생하는 이벤트입니다.
        /// </summary>
        public event MouseKeyReleasedDelegate RightButtonReleased;

        /// <summary>
        /// 마우스 X1 버튼이 클릭되었을 때 발생하는 이벤트입니다.
        /// </summary>
        public event MouseKeyPressedDelegate X1ButtonPressed;

        /// <summary>
        /// 마우스 X1 버튼이 놓였을 때 발생하는 이벤트입니다.
        /// </summary>
        public event MouseKeyReleasedDelegate X1ButtonReleased;

        /// <summary>
        /// 마우스 X2 버튼이 클릭되었을 때 발생하는 이벤트입니다.
        /// </summary>
        public event MouseKeyPressedDelegate X2ButtonPressed;

        /// <summary>
        /// 마우스 X2 버튼이 놓였을 때 발생하는 이벤트입니다.
        /// </summary>
        public event MouseKeyReleasedDelegate X2ButtonReleased;

        /// <summary>
        /// 마우스 휠이 이동되었을 때 발생하는 이벤트입니다.
        /// </summary>
        public event MouseWheelMovedDelegate MouseWheelMoved;
    }
}
