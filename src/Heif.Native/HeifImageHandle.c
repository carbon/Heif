// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

#include "Stdafx.h"

HEIF_NATIVE_EXPORT struct heif_image_handle *HeifImageHandle_Create(struct heif_context *context)
{
  heif_item_id
    primary_image_id;

  struct heif_image_handle
    *image_handle;

  struct heif_error
    error;

  error = heif_context_get_primary_image_ID(context, &primary_image_id);
  if (error.code != 0)
    return (struct heif_image_handle *) NULL;

  error = heif_context_get_image_handle(context, primary_image_id, &image_handle);

  if (error.code != 0)
    return (struct heif_image_handle *) NULL;

  return image_handle;
}

HEIF_NATIVE_EXPORT void HeifImageHandle_Dispose(struct heif_image_handle *image_handle)
{
  heif_image_handle_release(image_handle);
}

HEIF_NATIVE_EXPORT int HeifImageHandle_Height(struct heif_image_handle *image_handle)
{
  return heif_image_handle_get_height(image_handle);
}

HEIF_NATIVE_EXPORT int HeifImageHandle_Width(struct heif_image_handle *image_handle)
{
  return heif_image_handle_get_width(image_handle);
}

HEIF_NATIVE_EXPORT void HeifImageHandle_GetExifProfileInfo(struct heif_image_handle *image_handle, heif_item_id *exif_id, size_t *size)
{
  int
    count;

  count = heif_image_handle_get_list_of_metadata_block_IDs(image_handle, "Exif", exif_id, 1);
  if (count == 0)
    *size = 0;
  else
    *size = heif_image_handle_get_metadata_size(image_handle, *exif_id);
}

HEIF_NATIVE_EXPORT int HeifImageHandle_GetExifProfileData(struct heif_image_handle *image_handle, heif_item_id exif_id, unsigned char *buffer)
{
  struct heif_error
    error;

  error = heif_image_handle_get_metadata(image_handle, exif_id, buffer);
  return error.code;
}
