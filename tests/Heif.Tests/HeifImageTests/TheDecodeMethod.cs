// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

using Xunit;

namespace Heif.Tests
{
    public partial class HeifImageTests
    {
        public class TheDecodeMethod
        {
            [Fact]
            public void ShouldLoadTheMetadata()
            {
                using (var image = HeifImage.Decode(TestFiles.Camel))
                {
                    Assert.Equal(1596, image.Metadata.Width);
                    Assert.Equal(1064, image.Metadata.Height);
                }
            }
        }
    }
}
