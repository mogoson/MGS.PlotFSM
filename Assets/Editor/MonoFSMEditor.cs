/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoFSMEditor.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/5/31
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEditor;
using UnityEngine;

namespace MGS.FSM.Editors
{
    public class MonoFSMEditor
    {
        [MenuItem("Tool/Mono FSM/Previous")]
        public static void Previous()
        {
            var fsmMono = Object.FindObjectOfType<FSMMono>();
            fsmMono?.Seek(-1);
        }

        [MenuItem("Tool/Mono FSM/Next")]
        public static void Next()
        {
            var fsmMono = Object.FindObjectOfType<FSMMono>();
            fsmMono?.Seek(1);
        }
    }
}