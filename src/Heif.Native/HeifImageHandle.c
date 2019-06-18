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
