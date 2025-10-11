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

using System.Collections;
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
        protected Coroutine cruiser;
        protected YieldInstruction instruction;

        /// <summary>
        /// Creates a new instance of MonoFSM.
        /// </summary>
        /// <param name="interval">Interval of cruiser (ms).</param>
        public MonoFSM(int interval = 250)
        {
            instruction = new WaitForSeconds(interval / 1000f);
            mono = new GameObject(GetType().Name).AddComponent<FSMMono>();
            Object.DontDestroyOnLoad(mono.gameObject);

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
            if (cruiser == null)
            {
                cruiser = mono.StartCoroutine(StartCruiser());
            }
        }

        /// <summary>
        /// Stops the FSM.
        /// </summary>
        public override void Stop()
        {
            base.Stop();
            if (cruiser != null)
            {
                mono.StopCoroutine(cruiser);
                cruiser = null;
            }
        }

        /// <summary>
        /// Dispose the FSM and clear assets.
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
            Object.Destroy(mono.gameObject);
            mono = null;
        }

        /// <summary>
        /// Start cruiser to tick loop.
        /// </summary>
        protected IEnumerator StartCruiser()
        {
            while (true)
            {
                Update();
                yield return instruction;
            }
        }
    }
}