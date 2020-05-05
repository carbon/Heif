// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

using System;

namespace Carbon.Codecs.Heif
{
    /// <summary>
    /// Representation of a heif plane.
    /// </summary>
    public readonly struct HeifPlane
    {
        internal HeifPlane(IntPtr data, int stride)
        {
            this.Data = data;
            this.Stride = stride;
        }

        /// <summary>
        /// Gets the data of the plane.
        /// </summary>
        public IntPtr Data { get; }

        /// <summary>
        /// Gets the stride of the plane.
        /// </summary>
        public int Stride { get; }
    }
}
