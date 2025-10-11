/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  RoutineAgent.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  10/03/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections;
using UnityEngine;

namespace MGS.FSM
{
    public sealed class RoutineAgent
    {
        /// <summary>
        /// Routine to invoke the specified action repeatedly each frame.
        /// </summary>
        /// <param name="tick">The action to invoke.</param>
        /// <returns>The coroutine object.</returns>
        public static IEnumerator TickRoutine(Action tick)
        {
            while (true)
            {
                tick?.Invoke();
                yield return null;
            }
        }

        /// <summary>
        /// Routine to invoke the specified action repeatedly each frame with a specified time interval.
        /// </summary>
        /// <param name="seconds">The time interval between invocations.</param>
        /// <param name="tick">The action to invoke.</param>
        /// <param name="arrive">The action to invoke when the timer arrives.</param>
        /// <returns>The coroutine object.</returns>
        public static IEnumerator TimerRoutine(float seconds, Action<float> tick, Action arrive)
        {
            var timer = 0f;
            while (timer < seconds)
            {
                timer += Time.deltaTime;
                tick?.Invoke(timer);
                yield return null;
            }
            arrive?.Invoke();
        }

        /// <summary>
        /// Routine to invoke the specified action when the specified condition is true.
        /// </summary>
        /// <param name="condition">The condition to check.</param>
        /// <param name="action">The action to invoke.</param>
        /// <returns>The coroutine object.</returns>
        public static IEnumerator WaitRoutine(Func<bool> condition, Action action)
        {
            while (!condition.Invoke())
            {
                yield return null;
            }
            action?.Invoke();
        }

        /// <summary>
        /// Routine to invoke the specified action repeatedly each frame until the specified condition is false.
        /// </summary>
        /// <param name="condition">The condition to check.</param>
        /// <param name="action">The action to invoke.</param>
        /// <returns>The coroutine object.</returns>
        public static IEnumerator UntilRoutine(Func<bool> condition, Action action)
        {
            while (condition.Invoke())
            {
                action?.Invoke();
                yield return null;
            }
        }

        /// <summary>
        /// Routine to invoke the specified action after a specified delay seconds.
        /// </summary>
        /// <param name="seconds">The delay in seconds.</param>
        /// <param name="action">The action to invoke.</param>
        /// <returns>The coroutine object.</returns>
        public static IEnumerator DelayRoutine(float seconds, Action action)
        {
            yield return new WaitForSeconds(seconds);
            action?.Invoke();
        }
    }
}