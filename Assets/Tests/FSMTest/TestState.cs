/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TestState.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/2/23
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.FSM;
using UnityEngine;

namespace FSMTest
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
        /// Called when the state is being prepared.
        /// </summary>
        public override void Prepare()
        {
            base.Prepare();
            Debug.Log($"State {id} is Preparing");

            DelayInvokeAsync(1, () =>
            {
                OnPrepared();
                Debug.Log($"State {id} is Prepared");
            });
        }

        /// <summary>
        /// Called when entering the state.
        /// </summary>
        public override void Enter()
        {
            base.Enter();
            Debug.Log($"Entering state {id}");

            DelayInvokeAsync(5, () =>
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