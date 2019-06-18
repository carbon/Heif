// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

#pragma once

#define LIBHEIF_STATIC_BUILD

#include <libheif/heif.h>

#if defined(HEIF_NATIVE_WINDOWS) 

__pragma(comment(lib, "libde265.lib"))
__pragma(comment(lib, "libheif.lib"))

#define HEIF_NATIVE_EXPORT __declspec(dllexport)

#else

#define HEIF_NATIVE_EXPORT __attribute__((visibility("default")))

#endif