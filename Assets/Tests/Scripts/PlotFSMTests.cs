/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  PlotFSMTests.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/2/23
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections;
using System.IO;
using Newtonsoft.Json;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace MGS.FSM.Plot.Tests
{
    public class PlotFSMTests
    {
        IPlotFSM plotFSM;

        [SetUp]
        public void SetUp()
        {
            plotFSM = new PlotFSM();
        }

        [TearDown]
        public void TearDown()
        {
            plotFSM.Dispose();
            plotFSM = null;
        }

        [UnityTest]
        public IEnumerator RunPlotTest()
        {
            var file = $"{Application.dataPath}/Tests/Meta/PlotMeta.json";
            var json = File.ReadAllText(file);
            var metas = JsonConvert.DeserializeObject<PlotMeta[]>(json);

            plotFSM.Enqueue(metas);
            plotFSM.Activate();

            yield return new WaitForSeconds(12.5f);
        }
    }
}