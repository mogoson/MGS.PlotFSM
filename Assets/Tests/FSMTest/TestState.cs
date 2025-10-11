/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TestState.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/2/23
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.FSM.Tests
{
    /// <summary>
    /// Represents a test state.
    /// </summary>
    public class TestState : MonoState
    {
        int id;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestState"/> class with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the state.</param>
        public TestState(int id)
        {
            this.id = id;
        }

        /// <summary>
        /// Called when entering the state.
        /// </summary>
        public override void Enter()
        {
            base.Enter();
            Debug.Log($"Entering state {id}");

            StartDelayCoroutine(5, () =>
            {
                Debug.Log($"State {id} work completed");
                OnCompleted();
            });
        }

        /// <summary>
        /// Called when exiting the state.
        /// </summary>
        public override void Exit()
        {
            base.Exit();
            Debug.Log($"----------Exit State {id}----------");
        }
    }
}