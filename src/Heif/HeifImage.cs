// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

using System;

namespace Heif
{
    /// <summary>
    /// Representation of a heif image.
    /// </summary>
    public sealed partial class HeifImage : IDisposable
    {
        private readonly HeifContext context;
        private readonly HeifImageHandle handle;

        private HeifImage(HeifContext context, HeifImageHandle handle, HeifMetadata metadata)
        {
            this.context = context;
            this.handle = handle;
            this.Metadata = metadata;

            this.nativeInstance = new NativeHeifImage(handle);
        }

        /// <summary>
        /// Gets the metadata of the image.
        /// </summary>
        public HeifMetadata Metadata { get; }

        /// <summary>
        /// Creates a new <see cref="HeifImage"/> from the specified data.
        /// </summary>
        /// <param name="input">The data to load the metadata from.</param>
        /// <returns>A new <see cref="HeifImage"/> instance.</returns>
        public static HeifImage Decode(byte[] input)
        {
            HeifContext context = null;
            HeifImageHandle handle = null;

            try
            {
                context = new HeifContext(input);
                handle = new HeifImageHandle(context);

                var metadata = handle.ToMetadata();

                return new HeifImage(context, handle, metadata);
            }
            catch
            {
                if (handle != null)
                {
                    handle.Dispose();
                }

                if (context != null)
                {
                    context.Dispose();
                }

                throw;
            }
        }

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
                    return handle.ToMetadata();
                }
            }
        }

        /// <summary>
        /// Returns the plane for the specified channel.
        /// </summary>
        /// <param name="channel">The channel to get the plane for.</param>
        /// <returns>The plane for the specified channel.</returns>
        public HeifPlane GetPlane(HeifChannel channel)
        {
            var data = this.nativeInstance.GetPlane(channel, out int stride);

            return new HeifPlane(data, stride);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this.nativeInstance != null)
            {
                this.nativeInstance.Dispose();
            }

            if (this.handle != null)
            {
                this.handle.Dispose();
            }

            if (this.context != null)
            {
                this.context.Dispose();
            }

            GC.SuppressFinalize(this);
        }
    }
}
