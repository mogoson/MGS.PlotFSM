/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LoadSceneOnlyPlot.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/3/15
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Plot
{
    /// <summary>
    /// Represents a plot that loads a scene.
    /// </summary>
    /// <typeparam name="ScenePlotParam">The type of the plot parameter.</typeparam>
    public class LoadSceneOnlyPlot : LoadScenePlot<ScenePlotParam>
    {
        /// <summary>
        /// Called when the plot is entered.
        /// </summary>
        public override void Enter()
        {
            base.Enter();
            OnCompleted();
        }
    }
}