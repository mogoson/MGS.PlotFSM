/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Status.cs
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
    /// Status of FSM State.
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// None status.
        /// </summary>
        None = 0,

        /// <summary>
        /// Enter status.
        /// </summary>
        Enter = 1,

        /// <summary>
        /// Completed status.
        /// </summary>
        Completed = 2,

        /// <summary>
        /// Exit status.
        /// </summary>
        Exit = 3
    }
}