// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

namespace Heif
{
    public sealed class HeifMetadata
    {
        public HeifMetadata(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public byte[] ExifData { get; }

        public int Height { get; }

        public int Width { get; }
    }
}
