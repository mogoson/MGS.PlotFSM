/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  PlayVideoPlot.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/3/15
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;
using UnityEngine.Video;

namespace MGS.Drama
{
    /// <summary>
    /// Represents the parameters for a video plot.
    /// </summary>
    [Serializable]
    public class VideoPlotParam
    {
        /// <summary>
        /// The video URL.
        /// </summary>
        public string video;

        /// <summary>
        /// The render mode of the video.
        /// </summary>
        public string renderMode;

        /// <summary>
        /// The aspect ratio of the video.
        /// </summary>
        public string aspectRatio;

        /// <summary>
        /// Determines whether the video should loop.
        /// </summary>
        public bool isLooping;

        /// <summary>
        /// The duration of the video.
        /// </summary>
        public float duration;
    }

    /// <summary>
    /// Represents a plot that plays a video.
    /// </summary>
    /// <typeparam name="VideoPlotParam">The type of the video plot parameters.</typeparam>
    public class PlayVideoPlot : Plot<VideoPlotParam>
    {
        protected VideoPlayer videoPlayer;

        /// <summary>
        /// Prepares the plot for execution.
        /// </summary>
        public override void Prepare()
        {
            base.Prepare();

            videoPlayer = CreateVideoPlayer();
            videoPlayer.targetCamera = Camera.main;
            videoPlayer.renderMode = Enum.Parse<VideoRenderMode>(param.renderMode, true);
            videoPlayer.aspectRatio = Enum.Parse<VideoAspectRatio>(param.aspectRatio, true);

            videoPlayer.prepareCompleted += OnPrepareCompleted;
            videoPlayer.loopPointReached += OnLoopPointReached;

            videoPlayer.clip = LoadVideoClip(param.video);
            videoPlayer.isLooping = param.isLooping;
            videoPlayer.Prepare();
        }

        /// <summary>
        /// Loads the video clip from the specified URL.
        /// </summary>
        /// <param name="url">The URL of the video clip.</param>
        /// <returns>The loaded video clip.</returns>
        protected VideoClip LoadVideoClip(string url)
        {
            return Resources.Load<VideoClip>(url);
        }

        /// <summary>
        /// Called when the video player has completed preparing.
        /// </summary>
        /// <param name="source">The video player that completed preparing.</param>
        private void OnPrepareCompleted(VideoPlayer source)
        {
            OnPrepared();
        }

        /// <summary>
        /// Called when the video player reaches the loop point.
        /// </summary>
        /// <param name="source">The video player that reached the loop point.</param>
        private void OnLoopPointReached(VideoPlayer source)
        {
            if (param.isLooping || param.duration > 0)
            {
                return;
            }
            OnCompleted();
        }

        /// <summary>
        /// Creates a new video player.
        /// </summary>
        /// <returns>The created video player.</returns>
        protected VideoPlayer CreateVideoPlayer()
        {
            var go = new GameObject(GetType().Name);
            return go.AddComponent<VideoPlayer>();
        }

        /// <summary>
        /// Enters the plot.
        /// </summary>
        public override void Enter()
        {
            base.Enter();
            videoPlayer.Play();
            if (param.duration > 0)
            {
                DelayInvokeAsync(param.duration, OnCompleted);
            }
        }

        /// <summary>
        /// Exits the plot.
        /// </summary>
        public override void Exit()
        {
            base.Exit();
            videoPlayer.Stop();
            UnityEngine.Object.Destroy(videoPlayer.gameObject);
        }
    }
}