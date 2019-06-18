#include "Stdafx.h"

HEIF_NATIVE_EXPORT struct heif_image *HeifImage_Create(struct heif_image_handle *image_handle)
{
  struct heif_error
    error;

  struct heif_image
    *image;

  error = heif_decode_image(image_handle, &image, heif_colorspace_YCbCr, heif_chroma_420, (struct heif_decoding_options *) NULL);

  if (error.code != 0)
    return (struct heif_image *) NULL;

  return image;
}

HEIF_NATIVE_EXPORT void HeifImage_Dispose(struct heif_image *image)
{
  heif_image_release(image);
}

HEIF_NATIVE_EXPORT const uint8_t *HeifImage_GetPlane(struct heif_image*image, enum heif_channel channel, int *stride)
{
  return heif_image_get_plane_readonly(image, channel, stride);
}