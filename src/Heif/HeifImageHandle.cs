// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

using System;

namespace Heif
{
    internal sealed partial class HeifImageHandle : IDisposable
    {
        public HeifImageHandle(HeifContext context)
        {
            this.nativeInstance = new NativeHeifImageHandle(context);
        }

        public int Width => this.nativeInstance.Width;

        public int Height => this.nativeInstance.Height;

        public HeifMetadata ToMetadata()
        {
            return new HeifMetadata(this.Width, this.Height);
        }

        public void Dispose()
        {
            if (this.nativeInstance != null)
            {
                this.nativeInstance.Dispose();
            }

            GC.SuppressFinalize(this);
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
