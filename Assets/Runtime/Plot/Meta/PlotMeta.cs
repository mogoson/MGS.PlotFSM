/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  PlotMeta.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/2/23
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace MGS.Plot
{
    /// <summary>
    /// Represents a plot meta.
    /// </summary>
    [Serializable]
    public class PlotMeta
    {
        /// <summary>
        /// Gets or sets the type of the plot.
        /// </summary>
        public string type;

        /// <summary>
        /// Gets or sets the parameter of the plot.
        /// </summary>
        public object param;
    }
}