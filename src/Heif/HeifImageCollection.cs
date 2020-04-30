// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Carbon.Codecs.Heif
{
    internal sealed class HeifImageCollection : List<HeifImage>, IHeifImageCollection
    {
        public void Dispose()
        {
            foreach (var image in this)
            {
                image.Dispose();
            }
        }
    }
}
