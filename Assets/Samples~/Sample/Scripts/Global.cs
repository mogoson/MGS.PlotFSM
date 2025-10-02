/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Global.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  10/01/2025
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Plot.Sample
{
    public sealed class Global
    {
        public static IPlotFSM PlotFSM { get; }

        static Global()
        {
            PlotFSM = new PlotFSM();
        }
    }
}