// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

namespace Carbon.Codecs.Heif
{
    /// <summary>
    /// Raw color profile.
    /// </summary>
    public sealed class HeifRawColorProfile
    {
        internal HeifRawColorProfile(byte[] data, HeifColorProfileType type)
        {
            this.Data = data;
            this.Type = type;
        }

        /// <summary>
        /// Gets the data of the color profile.
        /// </summary>
        public byte[] Data { get; }

        /// <summary>
        /// Gets the type of the color profile.
        /// </summary>
        public HeifColorProfileType Type { get; }
    }
}