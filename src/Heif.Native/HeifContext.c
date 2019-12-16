// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

#include "Stdafx.h"

HEIF_NATIVE_EXPORT struct heif_context *HeifContext_Create(const unsigned char *file_data, size_t length)
{
  struct heif_context
    *heif_context;

  struct heif_error
    error;

  heif_context = heif_context_alloc();
  error = heif_context_read_from_memory_without_copy(heif_context, file_data, length, NULL);
  if (error.code != 0)
    return (struct heif_context *) NULL;

  return heif_context;
}

HEIF_NATIVE_EXPORT void HeifContext_Dispose(struct heif_context *instance)
{
  heif_context_free(instance);
}

HEIF_NATIVE_EXPORT heif_item_id *HeifContext_GetImageIds(struct heif_context *instance, int *count)
{
  heif_item_id
    *image_ids;

  *count = heif_context_get_number_of_top_level_images(instance);

  image_ids = malloc(sizeof(*image_ids) * (*count));
  if (image_ids != (heif_item_id *) NULL)
    (void) heif_context_get_list_of_top_level_image_IDs(instance, image_ids, *count);

  return image_ids;
}

HEIF_NATIVE_EXPORT heif_item_id HeifContext_GetImageId(heif_item_id *imageIDs, int offset)
{
  return *(imageIDs + offset);
}

HEIF_NATIVE_EXPORT void HeifContext_DisposeImageIds(heif_item_id *imageIDs)
{
  free(imageIDs);
}