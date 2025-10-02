/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  PlotFSMTest.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/2/23
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections;
using System.IO;
using MGS.Plot;
using Newtonsoft.Json;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace PlotTest
{
    /// <summary>
    /// Unit test class for DramaPlayer.
    /// </summary>
    public class PlotFSMTest
    {
        IPlotFSM plotFSM;

        /// <summary>
        /// Set up the test environment before each test case.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            plotFSM = new PlotFSM();
        }

        /// <summary>
        /// Tear down the test environment after each test case.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            plotFSM.Release();
            plotFSM = null;
        }

        /// <summary>
        /// Unit test for running plots in the PlotFSM.
        /// </summary>
        [UnityTest]
        public IEnumerator TestFSMRunPlots()
        {
            var file = $"{Application.dataPath}/Tests/PlotTest/Meta/PlotMeta.json";
            var json = File.ReadAllText(file);
            var metas = JsonConvert.DeserializeObject<PlotMeta[]>(json);

            plotFSM.Enqueue(metas);
            plotFSM.Start();

            yield return new WaitForSeconds(30);
        }
    }
}