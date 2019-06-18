// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;

namespace Heif
{
    internal sealed partial class HeifImageHandle
    {
        private NativeHeifImageHandle nativeInstance;

        private static class NativeMethods
        {
            [DllImport(NativeLibrary.Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr HeifImageHandle_Create(IntPtr context);

            [DllImport(NativeLibrary.Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void HeifImageHandle_Dispose(IntPtr instance);

            [DllImport(NativeLibrary.Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern int HeifImageHandle_Width(IntPtr instance);

            [DllImport(NativeLibrary.Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern int HeifImageHandle_Height(IntPtr instance);
        }

        private sealed class NativeHeifImageHandle : NativeInstance
        {
            public NativeHeifImageHandle(HeifContext context)
            {
                var instance = NativeMethods.HeifImageHandle_Create(HeifContext.GetInstance(context));
                if (instance == IntPtr.Zero)
                {
                    throw new HeifException("Unable to load heif image handle.");
                }

                this.Instance = instance;
            }

            public int Width => NativeMethods.HeifImageHandle_Width(this.Instance);

            public int Height => NativeMethods.HeifImageHandle_Height(this.Instance);

            protected override string TypeName => nameof(HeifImageHandle);

            protected override void Dispose(IntPtr instance)
            {
                if (instance != IntPtr.Zero)
                {
                    NativeMethods.HeifImageHandle_Dispose(instance);
                }
            }
        }
    }
}
