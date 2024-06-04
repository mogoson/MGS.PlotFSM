/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  DramaMeta.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/2/23
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace MGS.Drama
{
    [Serializable]
    /// <summary>
    /// Represents the metadata of a drama.
    /// </summary>
    public class DramaMeta
    {
        /// <summary>
        /// The name of the drama.
        /// </summary>
        public string name;

        /// <summary>
        /// The description of the drama.
        /// </summary>
        public string description;

        /// <summary>
        /// The version of the drama.
        /// </summary>
        public string version;

        /// <summary>
        /// The setting of the drama.
        /// </summary>
        public object setting;

        /// <summary>
        /// The plots of the drama.
        /// </summary>
        public PlotMeta[] plots;
    }
}