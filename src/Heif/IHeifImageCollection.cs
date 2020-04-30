// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Carbon.Codecs.Heif
{
    /// <summary>
    /// Representation of a heif image collection.
    /// </summary>
    public interface IHeifImageCollection : IReadOnlyCollection<HeifImage>, IDisposable
    {
    }
}
