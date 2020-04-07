// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

using System.IO;

namespace Heif.Tests
{
    public static class TestFiles
    {
        public static byte[] C034 => LoadEmbeddedImage("C034.heic");

        public static byte[] Camel => LoadEmbeddedImage("camel.heic");

        public static byte[] Collection => LoadEmbeddedImage("collection.heic");

        public static byte[] Dog => LoadEmbeddedImage("dog.heic"); // XDR

        public static byte[] Computer => LoadEmbeddedImage("computer.heic");

        private static byte[] LoadEmbeddedImage(string fileName)
        {
            var assembly = typeof(TestFiles).Assembly;

            using (var stream = assembly.GetManifestResourceStream($"Heif.Tests.images.{fileName}"))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    return memoryStream.ToArray();
                }
            }
        }
    }
}
