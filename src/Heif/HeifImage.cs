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
        /// <param name="input">The data to load the image from.</param>
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
        /// Returns the exif profile of the image.
        /// </summary>
        /// <returns>The exif profile of the image.</returns>
        public byte[] GetExifProfile()
        {
            return this.handle.GetExifProfile();
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
        /// Returns a byte array of the Y, Cb and Cr channels for each pixel in the image.
        /// </summary>
        /// <returns>A byte array of the Y, Cb and Cr channels.</returns>
        public unsafe byte[] ToYCbCrByteArray()
        {
            var data = new byte[this.Metadata.Width * this.Metadata.Height * 3];

            var planeY = this.GetPlane(HeifChannel.Y);
            var planeCb = this.GetPlane(HeifChannel.Cb);
            var planeCr = this.GetPlane(HeifChannel.Cr);

            byte* pY = (byte*)planeY.Data;
            byte* pCb = (byte*)planeCb.Data;
            byte* pCr = (byte*)planeCr.Data;

            fixed (byte* pData = data)
            {
                byte* ptr = pData;

                for (var y = 0; y < this.Metadata.Height; y++)
                {
                    for (var x = 0; x < this.Metadata.Width; x++)
                    {
                        *ptr++ = *(pY + ((y * planeY.Stride) + x));
                        *ptr++ = *(pCb + (((y / 2) * planeCb.Stride) + (x / 2)));
                        *ptr++ = *(pCr + (((y / 2) * planeCr.Stride) + (x / 2)));
                    }
                }
            }

            return data;
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
