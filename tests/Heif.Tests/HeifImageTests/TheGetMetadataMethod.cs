// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

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
                var metadata = HeifImage.GetMetadata(TestFiles.Camel);

                Assert.Equal(1596, metadata.Width);
                Assert.Equal(1064, metadata.Height);
            }
        }
    }
}
