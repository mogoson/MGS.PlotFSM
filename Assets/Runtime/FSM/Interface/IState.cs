/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IState.cs
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
    public interface IState
    {
        /// <summary>
        /// Current status.
        /// </summary>
        Status Status { get; }

        /// <summary>
        /// Prepares the state.
        /// </summary>
        void Prepare();

        /// <summary>
        /// Enters the state.
        /// </summary>
        void Enter();

        /// <summary>
        /// Exits the state.
        /// </summary>
        void Exit();
    }
}