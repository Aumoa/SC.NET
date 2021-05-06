// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.Engine.Runtime.Core.Diagnostics
{
    /// <summary>
    /// 정밀한 시간 측정을 위한 고해상도 타이머 함수를 지원합니다.
    /// </summary>
    public class StepTimer
    {
        /// <summary>
        /// 특정 주기마다 실행되는 함수의 대리자입니다.
        /// </summary>
        /// <param name="Sender"> 이 이벤트를 호출한 개체가 전달됩니다. </param>
        public delegate void StepTimerCallbackDelegate(StepTimer Sender);

        readonly ulong Frequency;
        readonly double InvFrequency;
        ulong _standard;

        ulong _lastTime;

        /// <summary>
        /// 이전 프레임으로부터 지날 수 있는 최대 시간을 계수로 설정하거나 가져옵니다.
        /// </summary>
        public ulong MaxDeltaTicks { get; set; }

        /// <summary>
        /// 이전 프레임으로부터 지날 수 있는 최대 시간을 초로 설정하거나 가져옵니다.
        /// </summary>
        public double MaxDeltaSeconds
        {
            get => TicksToSeconds(MaxDeltaTicks);
            set => MaxDeltaTicks = SecondsToTicks(value);
        }

        /// <summary>
        /// 이전 프레임으로부터 현재 프레임까지 경과한 시간을 계수로 나타냅니다.
        /// </summary>
        public ulong ElapsedTicks { get; private set; }

        /// <summary>
        /// 이전 프레임으로부터 현재 프레임까지 경과한 시간을 초로 나타냅니다.
        /// </summary>
        public double ElapsedSeconds => TicksToSeconds(ElapsedTicks);

        /// <summary>
        /// 타이머가 시작된 후 총 경과한 시간을 계수로 나타냅니다.
        /// </summary>
        public ulong TotalTicks { get; private set; }

        /// <summary>
        /// 타이머가 시작된 후 총 경과한 시간을 초로 나타냅니다.
        /// </summary>
        public double TotalSeconds => TicksToSeconds(TotalTicks);

        ulong _leftOverTicks;

        uint _frameCount;
        uint _framesPerSecond;
        uint _framesThisSecond;
        ulong _secondCounter;

        ulong _targetElapsedSeconds;

        /// <summary>
        /// 새 타이머 개체를 생성합니다.
        /// </summary>
        public StepTimer()
        {
            Frequency = QueryPerformanceFrequency();
            InvFrequency = 1.0 / Frequency;
            _standard = QueryPerformanceCounter();
        }

        /// <summary>
        /// Windows 지원: 퍼포먼스 카운터의 해상도를 가져옵니다.
        /// </summary>
        /// <returns> 해상도 값이 반환됩니다. </returns>
        private static ulong QueryPerformanceFrequency()
        {
            QueryPerformanceFrequency(out long freq);
            return (ulong)freq;
        }

        /// <summary>
        /// Windows 지원: 퍼포먼스 카운터의 현재 계측 개수를 가져옵니다.
        /// </summary>
        /// <returns> 값이 반환됩니다. </returns>
        private static ulong QueryPerformanceCounter()
        {
            QueryPerformanceCounter(out long count);
            return (ulong)count;
        }

        /// <summary>
        /// 표준으로부터 현재 계측 값의 차이를 가져옵니다.
        /// </summary>
        private ulong StandardPerformanceCounter => QueryPerformanceCounter() - _standard;

        /// <summary>
        /// 고정 시간 주기를 사용할지 설정합니다.
        /// </summary>
        public bool bFixedTimeStep;

        /// <summary>
        /// 초 값을 계수 값으로 변환합니다. 
        /// </summary>
        /// <param name="inValue"> 초 값을 전달합니다. </param>
        /// <returns> 계수 값이 반환됩니다. </returns>
        private ulong SecondsToTicks(double inValue)
        {
            return (ulong)(inValue * Frequency);
        }

        /// <summary>
        /// 계수 값을 초 값으로 변환합니다.
        /// </summary>
        /// <param name="inValue"> 계수 값을 전달합니다. </param>
        /// <returns> 초 값이 반환됩니다. </returns>
        private double TicksToSeconds(ulong inValue)
        {
            return inValue / InvFrequency;
        }

        /// <summary>
        /// 고정 시간 주기를 사용할 때, 고정 시간 주기로 사용할 초 값을 설정하거나 가져옵니다.
        /// </summary>
        public double TargetElapsedSeconds
        {
            get => TicksToSeconds(_targetElapsedSeconds);
            set => _targetElapsedSeconds = SecondsToTicks(value);
        }

        /// <summary>
        /// 초당 틱 수를 가져옵니다.
        /// </summary>
        public int TicksPerSecond => (int)_framesPerSecond;

        /// <summary>
        /// 타이머의 시간을 갱신합니다.
        /// </summary>
        public void Tick()
        {
            ulong currentTime = StandardPerformanceCounter;
            ulong timeDelta = currentTime - _lastTime;

            _lastTime = currentTime;
            _secondCounter += timeDelta;

            // 시간 이동량은 최대 값을 넘어설 수 없습니다.
            if (MaxDeltaTicks != 0 && timeDelta > MaxDeltaTicks)
            {
                timeDelta = MaxDeltaTicks;
            }

            uint lastFrameCount = _frameCount;
            if (bFixedTimeStep)
            {
                if (Math.Abs((long)(timeDelta - _targetElapsedSeconds)) < (long)TicksPerSecond / 4000)
                {
                    timeDelta = _targetElapsedSeconds;
                }

                // 남은 시간에서 흐른 시간을 누적합니다.
                _leftOverTicks += _targetElapsedSeconds;

                // 누적 시간 값이 고정 시간 주기보다 클 경우입니다.
                if (_leftOverTicks >= _targetElapsedSeconds)
                {
                    ElapsedTicks = _targetElapsedSeconds;
                    TotalTicks += _targetElapsedSeconds;
                    _leftOverTicks -= _targetElapsedSeconds;
                    _frameCount += 1;

                    StepTimerCallback?.Invoke(this);
                }
            }
            else
            {
                ElapsedTicks = timeDelta;
                TotalTicks += timeDelta;
                _leftOverTicks = 0;
                _frameCount += 1;

                StepTimerCallback?.Invoke(this);
            }

            // 프레임이 진행되었으면 현재 초의 프레임 수를 1회 증가시킵니다.
            if (_frameCount != lastFrameCount)
            {
                _framesThisSecond += 1;
            }

            // 초 카운터가 1초를 넘겼을 경우입니다.
            if (_secondCounter >= Frequency)
            {
                _framesPerSecond = _framesThisSecond;
                _framesThisSecond = 0;
                _secondCounter %= Frequency;
            }
        }

        /// <summary>
        /// 흐른 시간값을 초기화합니다.
        /// </summary>
        public void ResetElapsedTime()
        {
            _lastTime = StandardPerformanceCounter;
            _framesPerSecond = 0;
            _framesThisSecond = 0;
            _secondCounter = 0;
        }

        /// <summary>
        /// 타이머의 일정 틱 주기마다 호출됩니다.
        /// </summary>
        public event StepTimerCallbackDelegate StepTimerCallback;

        [DllImport("Kernel32.dll")]
        private static extern ulong QueryPerformanceFrequency(out long OutFrequency);
        [DllImport("Kernel32.dll")]
        private static extern ulong QueryPerformanceCounter(out long OutPerformanceCount);
    }
}