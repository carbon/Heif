// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;

namespace Heif
{
    internal sealed partial class HeifContext : IDisposable
    {
        private GCHandle dataPointer;

        public HeifContext(byte[] data)
        {
            this.dataPointer = GCHandle.Alloc(data, GCHandleType.Pinned);

            this.nativeInstance = new NativeHeifContext(this.dataPointer.AddrOfPinnedObject(), (uint)data.Length);
        }

        public void Dispose()
        {
            if (this.nativeInstance != null)
            {
                this.nativeInstance.Dispose();
            }

            if (this.dataPointer.IsAllocated)
            {
                this.dataPointer.Free();
            }

            GC.SuppressFinalize(this);
        }

        internal static IntPtr GetInstance(HeifContext context)
        {
            if (context == null)
            {
                return IntPtr.Zero;
            }

            return context.nativeInstance.Instance;
        }
    }
}
