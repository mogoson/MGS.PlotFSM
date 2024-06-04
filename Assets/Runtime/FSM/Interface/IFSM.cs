/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
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
    /// Represents a finite state machine.
    /// </summary>
    public interface IFSM
    {
        /// <summary>
        /// Gets the current index of the state machine.
        /// </summary>
        int Index { get; }

        /// <summary>
        /// Gets the current state of the state machine.
        /// </summary>
        IState State { get; }

        /// <summary>
        /// Enqueues a collection of states to be processed by the state machine.
        /// </summary>
        /// <param name="states">The collection of states to enqueue.</param>
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