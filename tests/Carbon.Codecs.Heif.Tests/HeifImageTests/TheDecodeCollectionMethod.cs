// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

using Xunit;

namespace Carbon.Codecs.Heif.Tests
{
    public partial class HeifImageTests
    {
        public class TheDecodeCollectionMethod
        {
            [Fact]
            public void ShouldThrowExceptionWhenFileIsInvalid()
            {
                var data = new byte[] { 42 };

                var exception = Assert.Throws<HeifException>(() => HeifImage.DecodeCollection(data));

                Assert.Equal("Unable to create heif context.", exception.Message);
            }

            [Fact]
            public void ShouldLoadTheMetadata()
            {
                using (var images = HeifImage.DecodeCollection(TestFiles.Collection))
                {
                    Assert.Equal(4, images.Count);

                    foreach (var image in images)
                    {
                        Assert.Equal(1280, image.Metadata.Width);
                        Assert.Equal(720, image.Metadata.Height);
                    }
                }
            }
        }
    }
}
