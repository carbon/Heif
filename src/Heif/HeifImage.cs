// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

namespace Heif
{
    public sealed class HeifImage
    {
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
