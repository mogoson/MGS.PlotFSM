/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  FSMMono.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/5/31
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;

namespace MGS.FSM
{
    /// <summary>
    /// The MonoBehaviour used to update the FSM.
    /// </summary>
    public class FSMMono : MonoBehaviour
    {
        /// <summary>
        /// Event triggered on each update.
        /// </summary>
        public event Action OnUpdate;

        /// <summary>
        /// Creates a new instance of FSMMono.
        /// </summary>
        /// <returns>The created FSMMono instance.</returns>
        public static FSMMono CreateOne()
        {
            var go = new GameObject(typeof(FSMMono).Name);
            DontDestroyOnLoad(go);

            var mono = go.AddComponent<FSMMono>();
            mono.enabled = false;
            return mono;
        }

        /// <summary>
        /// Updates the FSM.
        /// </summary>
        private void Update()
        {
            OnUpdate?.Invoke();
        }

        /// <summary>
        /// Releases the FSMMono instance.
        /// </summary>
        public void Release()
        {
            OnUpdate = null;
            Destroy(gameObject);
        }

#if UNITY_EDITOR
        /// <summary>
        /// Event triggered when skip.
        /// </summary>
        public event Action OnSkip;

        /// <summary>
        /// Skips to the next state in the FSM.
        /// </summary>
        public void Skip()
        {
            OnSkip?.Invoke();
        }
#endif
    }
}