/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoFSMTests.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/2/23
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace MGS.FSM.Tests
{
    /// <summary>
    /// Unit test class for MonoFSM.
    /// </summary>
    public class MonoFSMTests
    {
        IFSM fSM;

        /// <summary>
        /// Set up the test environment.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            fSM = new MonoFSM();
        }

        /// <summary>
        /// Tear down the test environment.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            fSM.Dispose();
            fSM = null;
        }

        /// <summary>
        /// Test the execution of FSM states.
        /// </summary>
        [UnityTest]
        public IEnumerator FSMRunStatesTest()
        {
            var states = new List<IState>()
            {
                new TestState(1),
                new TestState(2)
            };
            fSM.Enqueue(states);
            fSM.Start();
            while (fSM.State != null)
            {
                yield return null;
            }

            Debug.Log("----------Added states execution completed----------");
            yield return new WaitForSeconds(3);
            Debug.Log("----------Continue execution with additional states----------");

            states = new List<IState>()
            {
                new TestState(3),
                new TestState(4)
            };
            fSM.Enqueue(states);
            while (fSM.State != null)
            {
                yield return null;
            }
        }
    }
}