// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

using Xunit;

namespace Carbon.Codecs.Heif.Tests
{
    public partial class HeifImageTests
    {
        public class TheColorProfileTypeMethod
        {
            [Fact]
            public void ShouldReturnNotPresentWhenImageHasNoColorProfile()
            {
                using (var image = HeifImage.Decode(TestFiles.C034))
                {
                    Assert.Equal(HeifColorProfileType.NotPresent, image.ColorProfileType);
                }
            }
        }
    }
}
