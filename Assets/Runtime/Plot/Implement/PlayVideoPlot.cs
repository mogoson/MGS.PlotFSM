/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
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

namespace MGS.FSM.Plot
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
        /// <see cref="VideoRenderMode"/>
        /// </summary>
        public string renderMode;

        /// <summary>
        /// The aspect ratio of the video.
        /// <see cref="VideoAspectRatio"/>
        /// </summary>
        public string aspectRatio;

        /// <summary>
        /// Determines whether the video should loop.
        /// </summary>
        public bool loop;

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
        /// Enters the plot.
        /// </summary>
        public override void Enter()
        {
            base.Enter();

            videoPlayer = CreateVideoPlayer(param);
            videoPlayer.targetCamera = Camera.main;
            videoPlayer.Play();

            var isCustomDuration = param.duration > 0;
            if (isCustomDuration || !param.loop)
            {
                var duration = isCustomDuration ? param.duration : videoPlayer.clip.length;
                StartDelayCoroutine((float)duration, OnCompleted);
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

        /// <summary>
        /// Creates a new video player.
        /// </summary>
        /// <returns>The created video player.</returns>
        protected virtual VideoPlayer CreateVideoPlayer(VideoPlotParam param)
        {
            var go = new GameObject($"{GetType().Name}_{nameof(VideoPlayer)}");
            var videoPlayer = go.AddComponent<VideoPlayer>();

            videoPlayer.clip = LoadVideoClip(param.video);
            videoPlayer.renderMode = Enum.Parse<VideoRenderMode>(param.renderMode, true);
            videoPlayer.aspectRatio = Enum.Parse<VideoAspectRatio>(param.aspectRatio, true);
            videoPlayer.isLooping = param.loop;
            return videoPlayer;
        }

        /// <summary>
        /// Loads the video clip from the specified URL.
        /// </summary>
        /// <param name="url">The URL of the video clip.</param>
        /// <returns>The loaded video clip.</returns>
        protected virtual VideoClip LoadVideoClip(string url)
        {
            var clip = Resources.Load<VideoClip>(url);
            if (clip == null)
            {
                Debug.LogError($"Can not load VideoClip from {url}");
            }
            return clip;
        }
    }
}