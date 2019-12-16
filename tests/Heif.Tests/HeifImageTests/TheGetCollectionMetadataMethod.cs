// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

using Xunit;

namespace Heif.Tests
{
    public partial class HeifImageTests
    {
        public class TheGetCollectionMetadataMethod
        {
            [Fact]
            public void ShouldThrowExceptionWhenFileIsInvalid()
            {
                var data = new byte[] { 42 };

                var exception = Assert.Throws<HeifException>(() => HeifImage.GetCollectionMetadata(data));

                Assert.Equal("Unable to create heif context.", exception.Message);
            }

            [Fact]
            public void ShouldReturnTheCorrectWidthAndHeight()
            {
                var metadatas = HeifImage.GetCollectionMetadata(TestFiles.Collection);

                Assert.Equal(4, metadatas.Count);

                foreach (var metadata in metadatas)
                {
                    Assert.Equal(1280, metadata.Width);
                    Assert.Equal(720, metadata.Height);
                }
            }
        }
    }
}
