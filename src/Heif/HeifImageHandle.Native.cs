// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;

namespace Carbon.Codecs.Heif
{
    internal sealed partial class HeifImageHandle
    {
        private readonly NativeHeifImageHandle nativeInstance;

        private static class NativeMethods
        {
            [DllImport(NativeLibrary.Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern uint HeifImageHandle_ColorProfileType(IntPtr instance);

            [DllImport(NativeLibrary.Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr HeifImageHandle_Create(IntPtr context);

            [DllImport(NativeLibrary.Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr HeifImageHandle_CreateById(IntPtr context, uint image_id);

            [DllImport(NativeLibrary.Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void HeifImageHandle_Dispose(IntPtr instance);

            [DllImport(NativeLibrary.Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern int HeifImageHandle_Width(IntPtr instance);

            [DllImport(NativeLibrary.Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern int HeifImageHandle_Height(IntPtr instance);

            [DllImport(NativeLibrary.Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void HeifImageHandle_GetExifProfileInfo(IntPtr instance, out uint exif_id, out uint size);

            [DllImport(NativeLibrary.Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern int HeifImageHandle_GetExifProfileData(IntPtr instance, uint exif_id, byte[] data);
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

            public NativeHeifImageHandle(HeifContext context, uint imageId)
            {
                var instance = NativeMethods.HeifImageHandle_CreateById(HeifContext.GetInstance(context), imageId);
                if (instance == IntPtr.Zero)
                {
                    throw new HeifException("Unable to load heif image handle.");
                }

                this.Instance = instance;
            }

            public HeifColorProfileType ColorProfileType => (HeifColorProfileType)NativeMethods.HeifImageHandle_ColorProfileType(this.Instance);

            public int Width => NativeMethods.HeifImageHandle_Width(this.Instance);

            public int Height => NativeMethods.HeifImageHandle_Height(this.Instance);

            protected override string TypeName => nameof(HeifImageHandle);

            public void GetExifProfileInfo(out uint exifId, out uint size) => NativeMethods.HeifImageHandle_GetExifProfileInfo(this.Instance, out exifId, out size);

            public unsafe bool GetExifProfileData(uint exifId, byte[] data)
            {
                var result = NativeMethods.HeifImageHandle_GetExifProfileData(this.Instance, exifId, data);
                return result == 0;
            }

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
