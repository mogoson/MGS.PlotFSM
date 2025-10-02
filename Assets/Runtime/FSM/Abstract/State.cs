/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
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
    /// FSM State.
    /// </summary>
    public abstract class State : IState
    {
        /// <summary>
        /// Current status.
        /// </summary>
        public Status Status { protected set; get; }

        /// <summary>
        /// Prepares the state.
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
        /// Enters the state.
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
        /// Exits the state.
        /// </summary>
        public virtual void Exit()
        {
            Status = Status.None;
        }
    }
}