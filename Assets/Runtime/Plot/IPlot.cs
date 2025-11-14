/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IPlot.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/2/23
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.FSM.Plot
{
    /// <summary>
    /// Represents a plot in a drama.
    /// </summary>
    public interface IPlot : IState
    {
        /// <summary>
        /// Initializes the plot with the specified parameter.
        /// </summary>
        /// <param name="param">The parameter to initialize the plot.</param>
        void Initialize(string param);
    }
}