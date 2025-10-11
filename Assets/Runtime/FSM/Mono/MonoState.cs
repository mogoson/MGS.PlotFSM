/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoState.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/2/22
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections;
using UnityEngine;

namespace MGS.FSM
{
    /// <summary>
    /// Represents a base class for mono states in a finite state machine.
    /// </summary>
    public abstract class MonoState : State
    {
        /// <summary>
        /// MonoBehaviour of this agent.
        /// </summary>
        protected MonoBehaviour mono;

        /// <summary>
        /// Injects the MonoBehaviour instance into the state.
        /// </summary>
        /// <param name="mono">The MonoBehaviour instance to inject.</param>
        public void Inject(MonoBehaviour mono)
        {
            this.mono = mono;
        }

        /// <summary>
        /// Start coroutine to invoke the specified action repeatedly each frame.
        /// </summary>
        /// <param name="tick">The action to invoke.</param>
        /// <returns>The coroutine object.</returns>
        protected Coroutine StartTickCoroutine(Action tick)
        {
            var routine = RoutineAgent.TickRoutine(tick);
            return StartCoroutine(routine);
        }

        /// <summary>
        /// Start coroutine to invoke the specified action repeatedly each frame with a specified time interval.
        /// </summary>
        /// <param name="seconds">The time interval between invocations.</param>
        /// <param name="tick">The action to invoke.</param>
        /// <param name="arrive">The action to invoke when the timer arrives.</param>
        /// <returns>The coroutine object.</returns>
        protected Coroutine StartTimerCoroutine(float seconds, Action<float> tick, Action arrive)
        {
            var routine = RoutineAgent.TimerRoutine(seconds, tick, arrive);
            return StartCoroutine(routine);
        }

        /// <summary>
        /// Start coroutine to invoke the specified action when the specified condition is true.
        /// </summary>
        /// <param name="condition">The condition to check.</param>
        /// <param name="action">The action to invoke.</param>
        /// <returns>The coroutine object.</returns>
        protected Coroutine StartWaitCoroutine(Func<bool> condition, Action action)
        {
            var routine = RoutineAgent.WaitRoutine(condition, action);
            return StartCoroutine(routine);
        }

        /// <summary>
        /// Start coroutine to invoke the specified action repeatedly each frame until the specified condition is false.
        /// </summary>
        /// <param name="condition">The condition to check.</param>
        /// <param name="action">The action to invoke.</param>
        /// <returns>The coroutine object.</returns>
        protected Coroutine StartUntilCoroutine(Func<bool> condition, Action action)
        {
            var routine = RoutineAgent.UntilRoutine(condition, action);
            return StartCoroutine(routine);
        }

        /// <summary>
        /// Start coroutine to invoke the specified action after a specified delay seconds.
        /// </summary>
        /// <param name="seconds">The delay in seconds.</param>
        /// <param name="action">The action to invoke.</param>
        /// <returns>The coroutine object.</returns>
        protected Coroutine StartDelayCoroutine(float seconds, Action action)
        {
            var routine = RoutineAgent.DelayRoutine(seconds, action);
            return StartCoroutine(routine);
        }

        /// <summary>
        /// Starts a Coroutine.
        /// </summary>
        /// <returns></returns>
        protected Coroutine StartCoroutine(IEnumerator routine)
        {
            return mono.StartCoroutine(routine);
        }

        /// <summary>
        /// Stops the coroutine stored in routine running on this behaviour.
        /// </summary>
        /// <param name="routine"></param>
        protected void StopCoroutine(IEnumerator routine)
        {
            mono.StopCoroutine(routine);
        }
    }
}