/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IPlotFSM.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/2/23
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.FSM;
using System.Collections.Generic;

namespace MGS.Drama
{
    /// <summary>
    /// Represents a plot finite state machine.
    /// </summary>
    public interface IPlotFSM : IFSM
    {
        /// <summary>
        /// Gets or sets the current plot state.
        /// </summary>
        new IPlot State { get; }

        /// <summary>
        /// Enqueues a collection of plot states.
        /// </summary>
        /// <param name="states">The collection of plot states to enqueue.</param>
        void Enqueue(IEnumerable<IPlot> states);
    }
}