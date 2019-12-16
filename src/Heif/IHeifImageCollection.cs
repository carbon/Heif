// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Heif
{
    /// <summary>
    /// Representation of a heif image collection.
    /// </summary>
    public interface IHeifImageCollection : IReadOnlyCollection<HeifImage>, IDisposable
    {
    }
}
