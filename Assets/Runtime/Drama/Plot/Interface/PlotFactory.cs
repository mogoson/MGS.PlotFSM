/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  PlotFactory.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/2/23
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;

namespace MGS.Drama
{
    /// <summary>
    /// Factory class for creating plot instances.
    /// </summary>
    public sealed class PlotFactory
    {
        /// <summary>
        /// Creates a plot instance based on the provided plot metadata.
        /// </summary>
        /// <param name="meta">The plot metadata.</param>
        /// <returns>The created plot instance.</returns>
        public static IPlot CreateFromMeta(PlotMeta meta)
        {
            var type = Type.GetType(meta.type);
            var plot = (IPlot)Activator.CreateInstance(type);
            plot.Init(meta.param);
            return plot;
        }

        /// <summary>
        /// Creates a collection of plot instances based on the provided plot metadata collection.
        /// </summary>
        /// <param name="metas">The plot metadata collection.</param>
        /// <returns>The created plot instances.</returns>
        public static ICollection<IPlot> CreateFromMeta(ICollection<PlotMeta> metas)
        {
            var plots = new List<IPlot>();
            foreach (var meta in metas)
            {
                var plot = CreateFromMeta(meta);
                plots.Add(plot);
            }
            return plots;
        }
    }
}