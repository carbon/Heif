﻿// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

namespace Carbon.Codecs.Heif
{
    /// <summary>
    /// Heif color profile type.
    /// </summary>
    public enum HeifColorProfileType
    {
        /// <summary>
        /// Not present.
        /// </summary>
        NotPresent = 0,

        /// <summary>
        /// Icc.
        /// </summary>
        Icc = 1917403971,

        /// <summary>
        /// Nclx.
        /// </summary>
        Nclx = 1852009592,

        /// <summary>
        /// Prof.
        /// </summary>
        Prof = 1886547814,
    }
}
