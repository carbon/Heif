// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

using Xunit;

namespace Carbon.Codecs.Heif.Tests
{
    public partial class HeifImageTests
    {
        public class TheToYCbCrByteArrayMethod
        {
            [Fact]
            public void ShouldReturnByteArrayWithCorrectSize()
            {
                using (var image = HeifImage.Decode(TestFiles.Camel))
                {
                    var data = image.ToYCbCrByteArray();

                    Assert.NotNull(data);
                    Assert.Equal(1596 * 1064 * 3, data.Length);
                }
            }
        }
    }
}
