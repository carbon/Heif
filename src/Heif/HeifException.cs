// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

using System;

namespace Heif
{
    public sealed class HeifException : Exception
    {
        public HeifException(string message)
            : base(message)
        {
        }
    }
}
