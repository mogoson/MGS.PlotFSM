/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
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
        /// Invokes the specified action repeatedly in each frame.
        /// </summary>
        /// <param name="tick">The action to invoke.</param>
        /// <returns>The coroutine object.</returns>
        protected Coroutine TickInvokeAsync(Action tick)
        {
            IEnumerator Invoke()
            {
                while (true)
                {
                    yield return null;
                    tick?.Invoke();
                }
            }
            return StartCoroutine(Invoke());
        }

        /// <summary>
        /// Invokes the specified action repeatedly with a specified time interval.
        /// </summary>
        /// <param name="seconds">The time interval between invocations.</param>
        /// <param name="tick">The action to invoke.</param>
        /// <param name="arrive">The action to invoke when the timer arrives.</param>
        /// <returns>The coroutine object.</returns>
        protected Coroutine TimerInvokeAsync(float seconds, Action<float> tick, Action arrive)
        {
            IEnumerator Invoke()
            {
                var timer = 0f;
                while (timer < seconds)
                {
                    yield return null;
                    timer += Time.deltaTime;
                    tick?.Invoke(timer);
                }
                arrive?.Invoke();
            }
            return StartCoroutine(Invoke());
        }

        /// <summary>
        /// Invokes the specified action after a specified delay.
        /// </summary>
        /// <param name="seconds">The delay in seconds.</param>
        /// <param name="action">The action to invoke.</param>
        /// <returns>The coroutine object.</returns>
        protected Coroutine DelayInvokeAsync(float seconds, Action action)
        {
            IEnumerator Invoke()
            {
                yield return new WaitForSeconds(seconds);
                action?.Invoke();
            }
            return StartCoroutine(Invoke());
        }

        /// <summary>
        /// Invokes the specified action when the specified condition is met.
        /// </summary>
        /// <param name="condition">The condition to check.</param>
        /// <param name="action">The action to invoke.</param>
        /// <returns>The coroutine object.</returns>
        protected Coroutine WaitInvokeAsync(Func<bool> condition, Action action)
        {
            IEnumerator Invoke()
            {
                while (!condition.Invoke())
                {
                    yield return null;
                }
                action?.Invoke();
            }
            return StartCoroutine(Invoke());
        }

        /// <summary>
        /// Starts a coroutine.
        /// </summary>
        /// <param name="routine">The coroutine to start.</param>
        /// <returns>The coroutine object.</returns>
        protected Coroutine StartCoroutine(IEnumerator routine)
        {
            return mono.StartCoroutine(routine);
        }

        /// <summary>
        /// Stops a coroutine.
        /// </summary>
        /// <param name="routine">The coroutine to stop.</param>
        protected void StopCoroutine(Coroutine routine)
        {
            mono.StopCoroutine(routine);
        }

        /// <summary>
        /// Exits the state.
        /// </summary>
        public override void Exit()
        {
            base.Exit();
            mono = null;
        }
    }
}