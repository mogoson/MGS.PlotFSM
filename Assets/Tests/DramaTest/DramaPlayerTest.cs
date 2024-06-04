/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  DramaPlayerTest.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/2/23
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Drama;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.TestTools;

namespace DramaTest
{
    /// <summary>
    /// Unit test class for DramaPlayer.
    /// </summary>
    public class DramaPlayerTest
    {
        IDramaPlayer player;

        /// <summary>
        /// Set up the test environment before each test case.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            player = new DramaPlayer();
        }

        /// <summary>
        /// Tear down the test environment after each test case.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            player.Release();
            player = null;
        }

        /// <summary>
        /// Unit test for running plots in the DramaPlayer.
        /// </summary>
        [UnityTest]
        public IEnumerator TestPlayerRunPlots()
        {
            var file = $"{Application.dataPath}/Tests/DramaTest/DramaMeta.json";
            var json = File.ReadAllText(file);
            var meta = JsonConvert.DeserializeObject<DramaMeta>(json);

            player.Init(meta);
            player.Start();

            yield return new WaitForSeconds(30);
        }
    }
}