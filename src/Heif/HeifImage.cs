// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Heif
{
    /// <summary>
    /// Representation of a heif image.
    /// </summary>
    public sealed partial class HeifImage : IDisposable
    {
        private readonly HeifContext context;
        private readonly HeifImageHandle handle;

        private HeifImage(HeifContext context, HeifImageHandle handle)
        {
            this.context = context;
            this.handle = handle;
            this.nativeInstance = new NativeHeifImage(handle);

            this.Metadata = new HeifMetadata(this.nativeInstance.Width, this.nativeInstance.Height);
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
            HeifContext? context = null;
            HeifImageHandle? handle = null;

            try
            {
                context = new HeifContext(input);
                handle = new HeifImageHandle(context);

                return new HeifImage(context, handle);
            }
            catch
            {
                handle?.Dispose();
                context?.Dispose();

                throw;
            }
        }

        /// <summary>
        /// Creates a new collection of <see cref="HeifImage"/> from the specified data.
        /// </summary>
        /// <param name="input">The data to load the image from.</param>
        /// <returns>A new <see cref="HeifImage"/> instance.</returns>
        public static IHeifImageCollection DecodeCollection(byte[] input)
        {
            var result = new HeifImageCollection();

            HeifImageHandle? handle = null;

            try
            {
                using (var context = new HeifContext(input))
                {
                    foreach (var imageId in context.GetImageIds())
                    {
                        handle = new HeifImageHandle(context, imageId);

                        result.Add(new HeifImage(context, handle));
                    }
                }
            }
            catch
            {
                foreach (var image in result)
                {
                    image.Dispose();
                }

                handle?.Dispose();

                throw;
            }

            return result;
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
        /// Creates a new collection of <see cref="HeifMetadata"/> from the specified data.
        /// </summary>
        /// <param name="input">The data to load the metadata from.</param>
        /// <returns>A new <see cref="HeifMetadata"/>.</returns>
        public static IReadOnlyCollection<HeifMetadata> GetCollectionMetadata(byte[] input)
        {
            using (var context = new HeifContext(input))
            {
                var result = new List<HeifMetadata>();
                foreach (var imageId in context.GetImageIds())
                {
                    using (var handle = new HeifImageHandle(context, imageId))
                    {
                        result.Add(handle.ToMetadata());
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Returns the exif profile of the image.
        /// </summary>
        /// <returns>The exif profile of the image.</returns>
        public byte[]? GetExifProfile() => this.handle.GetExifProfile();

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
            this.nativeInstance?.Dispose();
            this.handle?.Dispose();
            this.context?.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
