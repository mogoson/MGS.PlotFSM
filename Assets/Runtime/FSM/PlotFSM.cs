/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  PlotFSM.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/2/23
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using System.Linq;

namespace MGS.FSM.Plot
{
    /// <summary>
    /// Represents a finite state machine for managing plots in a drama.
    /// </summary>
    public class PlotFSM : MonoFSM, IPlotFSM
    {
        /// <summary>
        /// Get the current plot.
        /// </summary>
        public IPlot Plot { get { return State as IPlot; } }

        /// <summary>
        /// Creates a new instance of PlotFSM.
        /// </summary>
        /// <param name="interval">Interval of cruiser (ms).</param>
        public PlotFSM(int interval = 250) : base(interval) { }

        /// <summary>
        /// Enqueue plot states base on plot meta.
        /// </summary>
        /// <param name="metas">Plot meta datas.</param>
        public void Enqueue(IEnumerable<PlotMeta> metas)
        {
            var plots = PlotFactory.CreateFromMeta(metas);
            Enqueue(plots);
        }

        /// <summary>
        /// Enqueues a collection of plots to be processed by the FSM.
        /// </summary>
        /// <param name="plots">The collection of plots to enqueue.</param>
        public void Enqueue(IEnumerable<IPlot> plots)
        {
            var states = plots.Cast<IState>();
            base.Enqueue(states);
        }
    }
}