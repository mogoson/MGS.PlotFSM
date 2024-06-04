/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  State.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/2/19
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.FSM
{
    /// <summary>
    /// Represents a state in a finite state machine.
    /// </summary>
    public abstract class State : IState
    {
        /// <summary>
        /// Gets the current status of the state.
        /// </summary>
        public Status Status { protected set; get; }

        /// <summary>
        /// Called when the state is being prepared.
        /// </summary>
        public virtual void Prepare()
        {
            Status = Status.Preparing;
        }

        /// <summary>
        /// Called when the state has been prepared.
        /// </summary>
        protected virtual void OnPrepared()
        {
            Status = Status.Prepared;
        }

        /// <summary>
        /// Called when the state is being entered.
        /// </summary>
        public virtual void Enter()
        {
            Status = Status.Working;
        }

        /// <summary>
        /// Called when the state has been completed.
        /// </summary>
        protected virtual void OnCompleted()
        {
            Status = Status.Completed;
        }

        /// <summary>
        /// Called when the state is being exited.
        /// </summary>
        public virtual void Exit()
        {
            Status = Status.None;
        }
    }
}