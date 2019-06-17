// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

using System;

namespace Heif
{
    /// <summary>
    ///  Represents errors that occur during heif execution.
    /// </summary>
    public sealed class HeifException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HeifException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public HeifException(string message)
            : base(message)
        {
        }
    }
}
