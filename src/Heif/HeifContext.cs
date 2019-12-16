// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Heif
{
    internal sealed partial class HeifContext : IDisposable
    {
        private GCHandle dataPointer;
        private int referenceCount;

        public HeifContext(byte[] data)
        {
            this.dataPointer = GCHandle.Alloc(data, GCHandleType.Pinned);

            this.nativeInstance = new NativeHeifContext(this.dataPointer.AddrOfPinnedObject(), (uint)data.Length);

            this.referenceCount = 1;
        }

        public void AddReference() => this.referenceCount++;

        public IEnumerable<uint> GetImageIds()
        {
            var imageIds = IntPtr.Zero;
            try
            {
                imageIds = this.nativeInstance.GetImageIds(out var count);
                for (var offset = 0; offset < count; offset++)
                {
                    yield return this.nativeInstance.GetImageId(imageIds, offset);
                }
            }
            finally
            {
                if (imageIds != IntPtr.Zero)
                {
                    this.nativeInstance.DisposeImageIds(imageIds);
                }
            }
        }

        public void Dispose()
        {
            if (--this.referenceCount != 0)
            {
                return;
            }

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
