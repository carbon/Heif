// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

namespace Heif
{
    /// <summary>
    /// Class that contains metadata of a heif image.
    /// </summary>
    public sealed class HeifMetadata
    {
        internal HeifMetadata(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Gets the height of the image.
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Gets the width of the image.
        /// </summary>
        public int Width { get; }
    }
}
