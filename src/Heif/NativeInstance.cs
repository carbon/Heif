// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

using System;

namespace Carbon.Codecs.Heif
{
    internal abstract class NativeInstance : IDisposable
    {
        private IntPtr instance = IntPtr.Zero;

        public IntPtr Instance
        {
            get
            {
                if (this.instance == IntPtr.Zero)
                {
                    throw new ObjectDisposedException(this.TypeName);
                }

                return this.instance;
            }

            set
            {
                if (this.instance != IntPtr.Zero)
                {
                    this.Dispose(this.instance);
                }

                this.instance = value;
            }
        }

        protected abstract string TypeName { get; }

        public void Dispose()
        {
            this.Instance = IntPtr.Zero;
            GC.SuppressFinalize(this);
        }

        protected abstract void Dispose(IntPtr instance);
    }
}
