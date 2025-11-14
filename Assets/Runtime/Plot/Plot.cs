/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Plot.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/2/23
 *  Description  :  Initial development version.
 *************************************************************************/

using Newtonsoft.Json;

namespace MGS.FSM.Plot
{
    /// <summary>
    /// Represents a plot in a drama.
    /// </summary>
    /// <typeparam name="T">The type of the plot parameter.</typeparam>
    public abstract class Plot<T> : MonoState, IPlot
    {
        /// <summary>
        /// Parameter of plot.
        /// </summary>
        protected T param;

        /// <summary>
        /// Initializes the plot with the specified parameter.
        /// </summary>
        /// <param name="param">The parameter to initialize the plot with.</param>
        public virtual void Initialize(string param)
        {
            this.param = JsonConvert.DeserializeObject<T>(param);
        }
    }
}