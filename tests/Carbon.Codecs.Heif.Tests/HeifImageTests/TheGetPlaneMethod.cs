// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

using System;
using Xunit;

namespace Carbon.Codecs.Heif.Tests
{
    public partial class HeifImageTests
    {
        public class TheGetPlaneMethod
        {
            [Theory]
            [InlineData(HeifChannel.Y, 1600)]
            [InlineData(HeifChannel.Cb, 800)]
            [InlineData(HeifChannel.Cr, 800)]
            public void ShouldReturnThePlane(HeifChannel channel, int stride)
            {
                using (var image = HeifImage.Decode(TestFiles.Camel))
                {
                    var plane = image.GetPlane(channel);

                    Assert.Equal(stride, plane.Stride);
                    Assert.NotEqual(IntPtr.Zero, plane.Data);
                }
            }
        }
    }
}
