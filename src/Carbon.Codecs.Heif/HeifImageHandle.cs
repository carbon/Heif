﻿// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

using System;

namespace Carbon.Codecs.Heif
{
    internal sealed partial class HeifImageHandle : IDisposable
    {
        public HeifImageHandle(HeifContext context)
        {
            this.nativeInstance = new NativeHeifImageHandle(context);
        }

        public HeifImageHandle(HeifContext context, uint imageId)
        {
            this.nativeInstance = new NativeHeifImageHandle(context, imageId);
            context.AddReference();
        }

        public HeifColorProfileType ColorProfileType => this.nativeInstance.ColorProfileType;

        public int Width => this.nativeInstance.Width;

        public int Height => this.nativeInstance.Height;

        public HeifMetadata ToMetadata() => new HeifMetadata(this.Width, this.Height);

        public void Dispose()
        {
            this.nativeInstance?.Dispose();

            GC.SuppressFinalize(this);
        }

        public byte[]? GetExifProfile()
        {
            this.nativeInstance.GetExifProfileInfo(out uint exifId, out uint size);
            if (size == 0)
            {
                return null;
            }

            var result = new byte[size];

            if (!this.nativeInstance.GetExifProfileData(exifId, result))
            {
                return null;
            }

            return result;
        }

        public byte[]? GetRawColorProfile()
        {
            var size = this.nativeInstance.GetRawColorProfileSize();
            if (size == 0)
            {
                return null;
            }

            var result = new byte[size];

            if (this.nativeInstance.GetRawColorProfileData(result) != 0)
            {
                return null;
            }

            return result;
        }

        internal static IntPtr GetInstance(HeifImageHandle handle)
        {
            if (handle == null)
            {
                return IntPtr.Zero;
            }

            return handle.nativeInstance.Instance;
        }
    }
}
