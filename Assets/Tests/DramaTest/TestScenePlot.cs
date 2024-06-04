/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TestScenePlot.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/2/23
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using MGS.Drama;
using UnityEngine;

namespace DramaTest
{
    [Serializable]
    /// <summary>
    /// Parameters for the TestScenePlot.
    /// </summary>
    public class TestScenePlotParam : ScenePlotParam
    {
        /// <summary>
        /// The name of the object.
        /// </summary>
        public string objName;
    }

    /// <summary>
    /// Represents a test scene plot.
    /// </summary>
    public class TestScenePlot : ScenePlot<TestScenePlotParam>
    {
        /// <summary>
        /// Called when entering the test scene plot.
        /// </summary>
        public override void Enter()
        {
            base.Enter();

            var objGo = GameObject.Find(param.objName);
            objGo.GetComponent<MeshRenderer>().material.color = Color.red;

            DelayInvokeAsync(10, OnCompleted);
        }
    }
}