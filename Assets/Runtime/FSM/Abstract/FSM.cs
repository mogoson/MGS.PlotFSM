/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  FSM.cs
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
    public abstract class FSM : IFSM
    {
        /// <summary>
        /// Current index of the state.
        /// </summary>
        public int Index { protected set; get; }

        /// <summary>
        /// Count of states.
        /// </summary>
        public int Count { get { return states.Count; } }

        /// <summary>
        /// Current state.
        /// </summary>
        public IState State { protected set; get; }
        protected List<IState> states = new();

        /// <summary>
        /// Enqueues state to state machine.
        /// </summary>
        /// <param name="states">The state to enqueue.</param>
        public virtual void Enqueue(IState state)
        {
            states.Add(state);
        }

        /// <summary>
        /// Enqueues states to state machine.
        /// </summary>
        /// <param name="states">The states to enqueue.</param>
        public virtual void Enqueue(IEnumerable<IState> states)
        {
            this.states.AddRange(states);
        }

        /// <summary>
        /// Dequeues a specific state from the state machine.
        /// </summary>
        /// <param name="state">The state to dequeue.</param>
        public virtual void Dequeue(IState state)
        {
            if (state == State)
            {
                ExitState(state);
            }
            states.Remove(state);
        }

        /// <summary>
        /// Clears all states from the FSM.
        /// </summary>
        public virtual void Clear()
        {
            ExitState(State);
            states.Clear();
            Index = 0;
        }

        /// <summary>
        /// Starts the FSM.
        /// </summary>
        public abstract void Start();

        /// <summary>
        /// Seeks the state machine to a specific index.
        /// </summary>
        /// <param name="index">The index to seek to.</param>
        public virtual void Seek(int index)
        {
            if (Index != index)
            {
                ExitState(State);
                Index = index;
            }
        }

        /// <summary>
        /// Pauses the FSM.
        /// </summary>
        public abstract void Pause();

        /// <summary>
        /// Stops the FSM.
        /// </summary>
        public virtual void Stop()
        {
            ExitState(State);
            Index = 0;
        }

        /// <summary>
        /// Releases the FSM and clears all states.
        /// </summary>
        public virtual void Release()
        {
            Stop();
            states = null;
        }

        /// <summary>
        /// Updates the FSM.
        /// </summary>
        protected void Update()
        {
            State = Find(Index);
            if (State == null)
            {
                return;
            }

            switch (State.Status)
            {
                case Status.None:
                    State.Prepare();
                    break;

                case Status.Prepared:
                    State.Enter();
                    break;

                case Status.Working:
                    break;

                case Status.Completed:
                    var next = Find(Index + 1);
                    if (next == null || next.Status == Status.Prepared)
                    {
                        Index++;
                        State.Exit();
                        next?.Enter();
                    }
                    else if (next.Status == Status.None)
                    {
                        next.Prepare();
                    }
                    break;
            }
        }

        /// <summary>
        /// Finds a state in the FSM by index.
        /// </summary>
        /// <param name="index">The index of the state to find.</param>
        /// <returns>The state found, or null if not found.</returns>
        protected IState Find(int index)
        {
            if (index < 0 || index >= states.Count)
            {
                return null;
            }
            return states[index];
        }

        /// <summary>
        /// Exits a state in the FSM.
        /// </summary>
        /// <param name="state">The state to exit.</param>
        protected void ExitState(IState state)
        {
            if (state != null && state.Status != Status.None)
            {
                state.Exit();
            }
        }
    }
}