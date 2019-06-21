// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

using Xunit;

namespace Heif.Tests
{
    public partial class HeifImageTests
    {
        public class TheGetExifProfileMethod
        {
            [Fact]
            public void ShouldReturnTheProfile()
            {
                using (var image = HeifImage.Decode(TestFiles.C034))
                {
                    var profile = image.GetExifProfile();

                    Assert.NotNull(profile);
                    Assert.Equal(176, profile.Length);
                }
            }
        }
    }
}
