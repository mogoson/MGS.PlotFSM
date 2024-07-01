/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IDramaPlayer.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/2/23
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Drama
{
    /// <summary>
    /// Interface for playing dramas.
    /// </summary>
    /// <typeparam name="T">Type of the metadata of the drama.</typeparam>
    public interface IDramaPlayer<T> where T : DramaMeta
    {
        /// <summary>
        /// Gets the metadata of the drama.
        /// </summary>
        T Meta { get; }

        /// <summary>
        /// Initializes the drama player with the specified metadata.
        /// </summary>
        /// <param name="meta">The metadata of the drama.</param>
        void Init(T meta);

        /// <summary>
        /// Starts playing the drama.
        /// </summary>
        void Start();

        /// <summary>
        /// Pauses the playback of the drama.
        /// </summary>
        void Pause();

        /// <summary>
        /// Stops playing the drama.
        /// </summary>
        void Stop();

        /// <summary>
        /// Releases the resources used by the drama player.
        /// </summary>
        void Release();
    }
}