using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WESL
{
    /// <summary>
    /// Timer class extending Unity's built in time class to time set durations and indefinitely time
    /// </summary>
    public class Timer : ITimer, IEquatable<Timer>, IComparable<Timer>
    {
        private float _startTime, _duration = 0;
        /// <summary>
        /// The time that the timer started at.
        /// </summary>
        public float startTime => (_duration >= 0) ? _startTime : _startTime + _duration;

        /// <summary>
        /// Duration of the timer.
        /// </summary>
        public float duration => Mathf.Abs(_duration);

        /// <summary>
        /// The time that the timer will end.
        /// </summary>
        public float endTime => (_duration >= 0) ? _startTime + _duration : _startTime;

        public override string ToString() => GetTime().ToString();

        public virtual float getGlobalTime() => Time.time;

        /// <summary>
        /// Create a Timer that will count indefinitely.
        /// </summary>
        public Timer ()
        {
            _startTime = getGlobalTime();
        }

        /// <summary>
        /// Create a Timer set to time to the duration.
        /// </summary>
        /// <param name="duration">Timer will time to this duration: from 0, to infinity.</param>
        public Timer (float duration)
        {
            _startTime = getGlobalTime();
            _duration = duration;
        }

        /// <summary>
        /// Returns the time elapsed since the Timer was started.
        /// </summary>
        /// <returns>Time elapsed since the Timer was started.</returns>
        public float GetTime ()
        {
            return (_duration != 0) ? Mathf.Clamp(Mathf.Abs(getGlobalTime() - _startTime), 0, duration) : Mathf.Abs(getGlobalTime() - _startTime);
        }

        /// <summary>
        /// Returns the percentage of the duration elapsed since the Timer was started.
        /// </summary>
        /// <returns>Percentage of the duration elapsed since the Timer was started.</returns>
        public float GetPercentage()
        {
            return (_duration != 0) ? Mathf.Clamp(Mathf.Abs((getGlobalTime() - _startTime) / duration), 0, 1) : 0;
        }

        /// <summary>
        /// Returns the start time of the timer.
        /// </summary>
        /// <returns>Start time of timer.</returns>
        public float GetStartTime()
        {
            return _startTime;
        }

        /// <summary>
        /// Returns the duration of the timer.
        /// </summary>
        /// <returns>Duration of the timer.</returns>
        public float GetDuration()
        {
            return _duration;
        }

        /// <summary>
        /// Returns a boolean indicating if the Timer is done.
        /// </summary>
        /// <returns>A boolean indicating if the Timer is done.</returns>
        public bool IsDone() {
            if (_duration > 0)
            {
                return getGlobalTime() - _startTime >= _duration;
            } else if (_duration < 0)
            {
                return getGlobalTime() - _startTime >= 0;
            } else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns a boolean indicating if the Timer is reversed.
        /// </summary>
        /// <returns>A boolean indicating if the Timer is reversed.</returns>
        public bool IsReversed()
        {
            if (_duration >= 0) return false; else return true;
        }
        
        /// <summary>
        /// Resets the Timer so that the elapsed time is 0.
        /// </summary>
        public void Reset()
        {
            if (_duration >= 0)
                _startTime = getGlobalTime();
            else
                _startTime = getGlobalTime() + duration;
        }

        /// <summary>
        /// Resets the Timer so that the elapsed time is 0 with a new duration.
        /// </summary>
        /// <param name="duration">Set Timer duration: from 0, to infinity.</param>
        public void Reset (float duration)
        {
            if (_duration >= 0)
            {
                _startTime = getGlobalTime();
                _duration = duration;
            } else if (_duration < 0)
            {
                _startTime = getGlobalTime() + duration;
                _duration = -duration;
            } 
        }

        /// <summary>
        /// Set the time of the Timer.
        /// </summary>
        /// <param name="time">From 0, to duration.</param>
        public void SetTime(float time)
        {
            time = Mathf.Clamp(time, 0, duration);
            if (_duration >= 0) _startTime = getGlobalTime() - time;
            else _startTime = getGlobalTime() + time;
        }

        /// <summary>
        /// Set the percentage of the Timer.
        /// </summary>
        /// <param name="percentage">From 0, to 1.</param>
        public void SetPercentage (float percentage)
        {
            if (_duration != 0) _startTime = getGlobalTime() - Mathf.Clamp(percentage, 0, 1) * _duration;
        }

        /// <summary>
        /// Reverse the direction of the timer with the same duration.
        /// </summary>
        public void Reverse ()
        {
            if (_duration > 0) _startTime = getGlobalTime() + _duration;
            else _startTime = getGlobalTime();
            _duration *= -1;
        }

        /// <summary>
        /// Reverse the direction of the timer and set the duration.
        /// </summary>
        /// <param name="duration">Set the duration of the Timer: from 0, to infinity</param>
        public void Reverse(float duration)
        {
            if (_duration >= 0)
            {
                _startTime = getGlobalTime() + duration;
                _duration = -duration;
            }
            else
            {
                _startTime = getGlobalTime();
                _duration = duration;
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Timer);
        }

        public bool Equals(Timer other)
        {
            return other != null &&
                   _startTime == other._startTime &&
                   _duration == other._duration;
        }

        public int CompareTo(Timer other)
        {
            return (_duration >= other._duration) ? ((_duration == other._duration) ? ((_startTime > other.startTime) ? 1 : -1) : 1 ) : -1;
        }

        public static bool operator ==(Timer timer1, Timer timer2)
        {
            return EqualityComparer<Timer>.Default.Equals(timer1, timer2);
        }

        public static bool operator !=(Timer timer1, Timer timer2)
        {
            return !(timer1 == timer2);
        }
    }
}
