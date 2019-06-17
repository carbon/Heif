// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

using System.IO;
using Xunit;

namespace Heif.Tests
{
    public partial class HeifImageTests
    {
        public class TheGetMetadataMethod
        {
            [Fact]
            public void ShouldThrowExceptionWhenFileIsInvalid()
            {
                var data = new byte[] { 42 };

                var exception = Assert.Throws<HeifException>(() => HeifImage.GetMetadata(data));

                Assert.Equal("Unable to create heif context.", exception.Message);
            }

            [Fact]
            public void ShouldReturnTheCorrectWidthAndHeight()
            {
                var data = File.ReadAllBytes("i:/heic/test.heic");

                var metadata = HeifImage.GetMetadata(data);

                Assert.Equal(3024, metadata.Width);
                Assert.Equal(4032, metadata.Height);
            }
        }
    }
}
