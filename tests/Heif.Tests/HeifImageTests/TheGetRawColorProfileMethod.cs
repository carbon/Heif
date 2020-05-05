// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

using Xunit;

namespace Carbon.Codecs.Heif.Tests
{
    public partial class HeifImageTests
    {
        public class TheGetRawColorProfileMethod
        {
            [Fact]
            public void ShouldReturnTheProfile()
            {
                using (var image = HeifImage.Decode(TestFiles.Dog))
                {
                    var profile = image.GetRawColorProfile();

                    Assert.NotNull(profile);
                    Assert.Equal(HeifColorProfileType.Prof, profile.Type);
                    Assert.NotNull(profile.Data);
                    Assert.Equal(548, profile.Data.Length);
                }
            }

            [Fact]
            public void ShouldReturnNullForImageWithoutRawColorProfile()
            {
                using (var image = HeifImage.Decode(TestFiles.Camel))
                {
                    var profile = image.GetRawColorProfile();

                    Assert.Null(profile);
                }
            }
        }
    }
}
