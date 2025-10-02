/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoFSM.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/2/22
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace MGS.FSM
{
    /// <summary>
    /// Represents a MonoBehaviour-based finite state machine.
    /// </summary>
    public class MonoFSM : FSM
    {
        /// <summary>
        /// The FSMMono instance used by the MonoFSM.
        /// </summary>
        protected FSMMono mono;

        /// <summary>
        /// Creates a new instance of MonoFSM.
        /// </summary>
        public MonoFSM()
        {
            mono = new GameObject(nameof(FSMMono)).AddComponent<FSMMono>();
            Object.DontDestroyOnLoad(mono.gameObject);

            mono.enabled = false;
            mono.OnUpdate += Update;

#if UNITY_EDITOR
            mono.OnSeek += snap => Seek(Index + snap);
#endif
        }

        /// <summary>
        /// Enqueues state to state machine.
        /// </summary>
        /// <param name="states">The state to enqueue.</param>
        public override void Enqueue(IState state)
        {
            base.Enqueue(state);
            (state as MonoState)?.Inject(mono);
        }

        /// <summary>
        /// Enqueues a collection of states to the FSM.
        /// </summary>
        /// <param name="states">The states to enqueue.</param>
        public override void Enqueue(IEnumerable<IState> states)
        {
            base.Enqueue(states);
            foreach (var state in states)
            {
                (state as MonoState)?.Inject(mono);
            }
        }

        /// <summary>
        /// Starts the FSM.
        /// </summary>
        public override void Start()
        {
            mono.enabled = true;
        }

        /// <summary>
        /// Pauses the FSM.
        /// </summary>
        public override void Pause()
        {
            mono.enabled = false;
        }

        /// <summary>
        /// Stops the FSM.
        /// </summary>
        public override void Stop()
        {
            base.Stop();
            mono.enabled = false;
        }

        /// <summary>
        /// Releases the FSM.
        /// </summary>
        public override void Release()
        {
            base.Release();
            Object.Destroy(mono.gameObject);
            mono = null;
        }
    }
}