/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  DramaPlayer.cs
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
    /// Represents a drama player.
    /// </summary>
    /// <typeparam name="T">Type of the metadata of the drama.</typeparam>
    public class DramaPlayer<T> : IDramaPlayer<T> where T : DramaMeta
    {
        /// <summary>
        /// Gets or sets the drama meta.
        /// </summary>
        public T Meta { protected set; get; }

        /// <summary>
        /// The finite state machine for managing the plots.
        /// </summary>
        protected IPlotFSM plotFSM;

        /// <summary>
        /// Initializes a new instance of the <see cref="DramaPlayer"/> class.
        /// </summary>
        public DramaPlayer()
        {
            plotFSM = new PlotFSM();
        }

        /// <summary>
        /// Initializes the drama player with the specified drama meta.
        /// </summary>
        /// <param name="meta">The drama meta.</param>
        public virtual void Init(T meta)
        {
            Meta = meta;
            var plots = PlotFactory.CreateFromMeta(meta.plots);
            plotFSM.Enqueue(plots);
        }

        /// <summary>
        /// Starts playing the drama.
        /// </summary>
        public virtual void Start()
        {
            plotFSM.Start();
        }

        /// <summary>
        /// Pauses the drama.
        /// </summary>
        public virtual void Pause()
        {
            plotFSM.Pause();
        }

        /// <summary>
        /// Stops playing the drama.
        /// </summary>
        public virtual void Stop()
        {
            plotFSM.Stop();
        }

        /// <summary>
        /// Releases the resources used by the drama player.
        /// </summary>
        public virtual void Release()
        {
            plotFSM.Release();
            plotFSM = null;
        }
    }
}