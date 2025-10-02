/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IPlotFSM.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/2/23
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using MGS.FSM;

namespace MGS.Plot
{
    /// <summary>
    /// Represents a plot finite state machine.
    /// </summary>
    public interface IPlotFSM : IFSM
    {
        /// <summary>
        /// Get the current plot state.
        /// </summary>
        new IPlot State { get; }

        /// <summary>
        /// Enqueue plot states base on plot meta.
        /// </summary>
        /// <param name="metas">Plot meta datas.</param>
        void Enqueue(IEnumerable<PlotMeta> metas);

        /// <summary>
        /// Enqueues a collection of plot states.
        /// </summary>
        /// <param name="plots">The collection of plot states to enqueue.</param>
        void Enqueue(IEnumerable<IPlot> plots);
    }
}