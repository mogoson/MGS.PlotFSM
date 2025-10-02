/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IFSM.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/2/19
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;

namespace MGS.FSM
{
    /// <summary>
    /// Finite state machine.
    /// </summary>
    public interface IFSM
    {
        /// <summary>
        /// Current index of the state.
        /// </summary>
        int Index { get; }

        /// <summary>
        /// Count of states.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Current state.
        /// </summary>
        IState State { get; }

        /// <summary>
        /// Enqueues state to state machine.
        /// </summary>
        /// <param name="states">The state to enqueue.</param>
        void Enqueue(IState state);

        /// <summary>
        /// Enqueues states to state machine.
        /// </summary>
        /// <param name="states">The states to enqueue.</param>
        void Enqueue(IEnumerable<IState> states);

        /// <summary>
        /// Dequeues a specific state from the state machine.
        /// </summary>
        /// <param name="state">The state to dequeue.</param>
        void Dequeue(IState state);

        /// <summary>
        /// Clears all states in the state machine.
        /// </summary>
        void Clear();

        /// <summary>
        /// Starts the state machine.
        /// </summary>
        void Start();

        /// <summary>
        /// Seeks the state machine to a specific index.
        /// </summary>
        /// <param name="index">The index to seek to.</param>
        void Seek(int index);

        /// <summary>
        /// Pauses the state machine.
        /// </summary>
        void Pause();

        /// <summary>
        /// Stops the state machine.
        /// </summary>
        void Stop();

        /// <summary>
        /// Releases all resources used by the state machine.
        /// </summary>
        void Release();
    }
}