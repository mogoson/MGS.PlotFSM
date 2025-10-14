/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  PlotSample.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  10/13/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;

namespace MGS.FSM.Plot.Tests
{
    [Serializable]
    public class PlotSampleParam : ScenePlotParam
    {
        public string objName;
    }

    public class PlotSample : LoadScenePlot<PlotSampleParam>
    {
        protected override void OnLoadSceneCompleted()
        {
            StartDelayCoroutine(2.5f, () =>
            {
                var objGo = GameObject.Find(param.objName);
                objGo.GetComponent<MeshRenderer>().material.color = Color.red;
            });
            StartDelayCoroutine(5.0f, OnCompleted);
        }
    }
}