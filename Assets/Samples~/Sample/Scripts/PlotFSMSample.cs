/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  PlotFSMSample.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  10/01/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace MGS.Plot.Sample
{
    public class PlotFSMSample : MonoBehaviour
    {
        private void Start()
        {
            var file = $"{Application.dataPath}/Samples/Plot FSM/1.0.0/Sample/Meta/PlotMeta.json";
            var json = File.ReadAllText(file);
            var metas = JsonConvert.DeserializeObject<PlotMeta[]>(json);

            Global.PlotFSM.Enqueue(metas);
            Global.PlotFSM.Start();
        }
    }
}