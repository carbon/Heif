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