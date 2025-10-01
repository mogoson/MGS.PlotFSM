/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
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
using MGS.FSM;

namespace MGS.Plot
{
    /// <summary>
    /// Represents a finite state machine for managing plots in a drama.
    /// </summary>
    public class PlotFSM : MonoFSM, IPlotFSM
    {
        /// <summary>
        /// Gets the current state of the plot FSM.
        /// </summary>
        public new IPlot State { get { return base.State as IPlot; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlotFSM"/> class.
        /// </summary>
        public PlotFSM() : base() { }

        /// <summary>
        /// Initialize PlotFSM with plot metadata.
        /// </summary>
        /// <param name="metas">Plot meta datas.</param>
        public void Initialize(IEnumerable<PlotMeta> metas)
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