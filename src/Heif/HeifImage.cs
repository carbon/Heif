// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

namespace Heif
{
    /// <summary>
    /// Representation of a heif image.
    /// </summary>
    public sealed class HeifImage
    {
        /// <summary>
        /// Creates a new <see cref="HeifMetadata"/> from the specified data.
        /// </summary>
        /// <param name="input">The data to load the metadata from.</param>
        /// <returns>A new <see cref="HeifMetadata"/>.</returns>
        public static HeifMetadata GetMetadata(byte[] input)
        {
            using (var context = new HeifContext(input))
            {
                using (var handle = new HeifImageHandle(context))
                {
                    return new HeifMetadata(handle.Width, handle.Height);
                }
            }
        }
    }
}
