// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;

namespace Heif
{
    internal sealed partial class HeifContext
    {
        private NativeHeifContext nativeInstance;

        private static class NativeMethods
        {
            [DllImport(NativeLibrary.Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr HeifContext_Create(IntPtr file_data, uint size);

            [DllImport(NativeLibrary.Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void HeifContext_Dispose(IntPtr instance);

            [DllImport(NativeLibrary.Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr HeifContext_GetImageIds(IntPtr instance, out uint count);

            [DllImport(NativeLibrary.Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern uint HeifContext_GetImageId(IntPtr imageIDs, int offset);

            [DllImport(NativeLibrary.Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void HeifContext_DisposeImageIds(IntPtr imageIDs);
        }

        private sealed class NativeHeifContext : NativeInstance
        {
            public NativeHeifContext(IntPtr file_data, uint size)
            {
                var instance = NativeMethods.HeifContext_Create(file_data, size);
                if (instance == IntPtr.Zero)
                {
                    throw new HeifException("Unable to create heif context.");
                }

                this.Instance = instance;
            }

            protected override string TypeName => nameof(HeifContext);

            public IntPtr GetImageIds(out uint count) => NativeMethods.HeifContext_GetImageIds(this.Instance, out count);

            public uint GetImageId(IntPtr imageIDs, int offset) => NativeMethods.HeifContext_GetImageId(imageIDs, offset);

            public void DisposeImageIds(IntPtr imageIDs) => NativeMethods.HeifContext_DisposeImageIds(imageIDs);

            protected override void Dispose(IntPtr instance)
            {
                if (instance != IntPtr.Zero)
                {
                    NativeMethods.HeifContext_Dispose(instance);
                }
            }
        }
    }
}
