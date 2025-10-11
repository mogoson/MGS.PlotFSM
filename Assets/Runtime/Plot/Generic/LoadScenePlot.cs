/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LoadScenePlot.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/2/22
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections;
using UnityEngine.SceneManagement;

namespace MGS.Plot
{
    /// <summary>
    /// Parameters for the scene plot.
    /// </summary>
    [Serializable]
    public class ScenePlotParam
    {
        /// <summary>
        /// The name of the scene.
        /// </summary>
        public string sceneName;

        /// <summary>
        /// The load mode of the scene.
        /// <see cref="LoadSceneMode"/>
        /// </summary>
        public string loadMode;

        /// <summary>
        /// Whether to set scene active.
        /// </summary>
        public bool setActive;

        /// <summary>
        /// Whether to unload the scene on exit.
        /// </summary>
        public bool unloadExit;
    }

    /// <summary>
    /// Base class for load scene plot.
    /// </summary>
    /// <typeparam name="T">The type of the scene plot parameters.</typeparam>
    public class LoadScenePlot<T> : Plot<T> where T : ScenePlotParam
    {
        /// <summary>
        /// Enters the scene plot.
        /// </summary>
        public override void Enter()
        {
            base.Enter();
            var mode = Enum.Parse<LoadSceneMode>(param.loadMode, true);
            LoadSceneAsync(param.sceneName, mode, param.setActive, OnLoadSceneCompleted);
        }

        /// <summary>
        /// Exit the scene plot.
        /// </summary>
        public override void Exit()
        {
            base.Exit();
            if (param.unloadExit)
            {
                SceneManager.UnloadSceneAsync(param.sceneName);
            }
        }

        /// <summary>
        /// Load the scene asynchronously.
        /// </summary>
        /// <param name="sceneName">The name of the scene to load.</param>
        /// <param name="mode">The load mode of the scene.</param>
        /// <param name="setActive">The scene set active?</param>
        /// <param name="finished">The action to invoke when the scene is loaded.</param>
        protected void LoadSceneAsync(string sceneName, LoadSceneMode mode, bool setActive, Action finished)
        {
            IEnumerator LoadScene()
            {
                yield return SceneManager.LoadSceneAsync(sceneName, mode);
                if (setActive)
                {
                    var scene = SceneManager.GetSceneByName(sceneName);
                    SceneManager.SetActiveScene(scene);
                }
                finished?.Invoke();
            }
            StartCoroutine(LoadScene());
        }

        /// <summary>
        /// On load scene completed.
        /// </summary>
        protected virtual void OnLoadSceneCompleted()
        {
            OnCompleted();
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

    /// <summary>
    /// Represents a plot that load a scene.
    /// </summary>
    public class LoadScenePlot : LoadScenePlot<ScenePlotParam> { }
}