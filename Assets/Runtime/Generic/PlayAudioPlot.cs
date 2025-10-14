/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  PlayAudioPlot.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/3/15
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;

namespace MGS.FSM.Plot
{
    /// <summary>
    /// Represents the parameters for an audio plot.
    /// </summary>
    [Serializable]
    public class AudioPlotParam
    {
        /// <summary>
        /// The audio clip to be played.
        /// </summary>
        public string audio;

        /// <summary>
        /// The volume of the audio clip.
        /// </summary>
        public float volume;

        /// <summary>
        /// The pitch of the audio clip.
        /// </summary>
        public float pitch;

        /// <summary>
        /// Determines whether the audio should loop.
        /// </summary>
        public bool loop;

        /// <summary>
        /// The duration of the audio clip.
        /// </summary>
        public float duration;
    }

    /// <summary>
    /// Represents a plot that plays an audio clip.
    /// </summary>
    public class PlayAudioPlot : Plot<AudioPlotParam>
    {
        protected AudioSource audioSource;

        /// <summary>
        /// Enters the plot by playing the audio clip and delaying the completion of the plot.
        /// </summary>
        public override void Enter()
        {
            base.Enter();

            audioSource = CreateAudioSource(param);
            audioSource.Play();

            var isCustomDuration = param.duration > 0;
            if (isCustomDuration || !param.loop)
            {
                var duration = isCustomDuration ? param.duration : audioSource.clip.length;
                StartDelayCoroutine((float)duration, OnCompleted);
            }
        }

        /// <summary>
        /// Exits the plot by stopping the audio clip and destroying the audio source game object.
        /// </summary>
        public override void Exit()
        {
            base.Exit();
            audioSource.Stop();
            UnityEngine.Object.Destroy(audioSource.gameObject);
        }

        /// <summary>
        /// Creates an audio source game object and adds an audio source component to it.
        /// </summary>
        /// <returns>The created audio source.</returns>
        protected virtual AudioSource CreateAudioSource(AudioPlotParam param)
        {
            var go = new GameObject($"{GetType().Name}_{nameof(AudioSource)}");
            var audioSource = go.AddComponent<AudioSource>();

            audioSource.clip = LoadAudioClip(param.audio);
            audioSource.volume = param.volume;
            audioSource.pitch = param.pitch;
            audioSource.loop = param.loop;
            return audioSource;
        }

        /// <summary>
        /// Loads an audio clip from the specified URL.
        /// </summary>
        /// <param name="url">The URL of the audio clip.</param>
        /// <returns>The loaded audio clip.</returns>
        protected virtual AudioClip LoadAudioClip(string url)
        {
            var clip = Resources.Load<AudioClip>(url);
            if (clip == null)
            {
                Debug.LogError($"Can not load AudioClip from {url}");
            }
            return clip;
        }
    }
}