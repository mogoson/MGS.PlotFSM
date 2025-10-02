/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
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
        /// Updates the FSM.
        /// </summary>
        private void Update()
        {
            OnUpdate?.Invoke();
        }

#if UNITY_EDITOR
        /// <summary>
        /// Event triggered when seek.
        /// </summary>
        public event Action<int> OnSeek;

        /// <summary>
        /// Seek to the Index+snap state in the FSM.
        /// </summary>
        public void Seek(int snap)
        {
            OnSeek?.Invoke(snap);
        }
#endif
    }
}