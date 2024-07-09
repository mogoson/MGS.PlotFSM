/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  BaseScenePlot.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/2/22
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MGS.Plot
{
    /// <summary>
    /// Parameters for scene plot.
    /// </summary>
    [Serializable]
    public class ScenePlotParam
    {
        /// <summary>
        /// The name of loading UI.
        /// </summary>
        public string loadingUI;

        /// <summary>
        /// The name of scene.
        /// </summary>
        public string sceneName;

        /// <summary>
        /// The load mode (value range is <see cref="LoadSceneMode"/>).
        /// </summary>
        public string loadMode;

        /// <summary>
        /// Whether to unload the scene on exit.
        /// </summary>
        public bool exitUnload;
    }

    /// <summary>
    /// Base class for load scene plots.
    /// </summary>
    /// <typeparam name="T">The type of the scene plot parameters.</typeparam>
    public abstract class BaseScenePlot<T> : Plot<T> where T : ScenePlotParam
    {
        protected GameObject loadingUIGo;

        /// <summary>
        /// Prepare the scene plot.
        /// </summary>
        public override void Prepare()
        {
            base.Prepare();

            loadingUIGo = GameObject.Find(param.loadingUI);
            loadingUIGo?.SetActive(true);

            var mode = (LoadSceneMode)Enum.Parse(typeof(LoadSceneMode), param.loadMode);
            LoadSceneAsync(param.sceneName, mode, OnPrepared);
        }

        /// <summary>
        /// Enter the scene plot.
        /// </summary>
        public override void Enter()
        {
            base.Enter();
            loadingUIGo?.SetActive(false);
        }

        /// <summary>
        /// Exit the scene plot.
        /// </summary>
        public override void Exit()
        {
            base.Exit();
            if (param.exitUnload)
            {
                SceneManager.UnloadSceneAsync(param.sceneName);
            }
        }

        /// <summary>
        /// Load the scene asynchronously.
        /// </summary>
        /// <param name="sceneName">The name of the scene to load.</param>
        /// <param name="mode">The load mode of the scene.</param>
        /// <param name="finished">The action to invoke when the scene is loaded.</param>
        protected void LoadSceneAsync(string sceneName, LoadSceneMode mode, Action finished)
        {
            IEnumerator LoadScene()
            {
                yield return SceneManager.LoadSceneAsync(sceneName, mode);
                finished?.Invoke();
            }
            StartCoroutine(LoadScene());
        }

        /// <summary>
        /// Unload the scene asynchronously.
        /// </summary>
        /// <param name="sceneName">The name of the scene to unload.</param>
        /// <param name="finished">The action to invoke when the scene is unloaded.</param>
        protected void UnloadSceneAsync(string sceneName, Action finished)
        {
            IEnumerator UnloadScene()
            {
                yield return SceneManager.UnloadSceneAsync(sceneName);
                finished?.Invoke();
            }
            StartCoroutine(UnloadScene());
        }
    }
}