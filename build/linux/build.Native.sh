#!/bin/bash
set -e

export FLAGS="-O3 -fPIC"
export PKG_PATH="/usr/local/lib/pkgconfig"

# Build libde265
cd libde265/code
autoreconf -fiv
chmod +x ./configure
./configure --disable-shared --disable-dec265 --prefix=/usr/local CFLAGS="$FLAGS" CXXFLAGS="$FLAGS"
make install

# Build aom
cd ../../aom/code
mkdir aom_build
cd aom_build
cmake .. -DCMAKE_INSTALL_PREFIX=/usr/local -DBUILD_SHARED_LIBS=off -DCMAKE_BUILD_TYPE=Release -DAOM_TARGET_CPU=generic -DENABLE_DOCS=0 -DENABLE_EXAMPLES=0 -DENABLE_TESTS=0 -DENABLE_TOOLS=0 -DCONFIG_WEBM_IO=0 -DCMAKE_C_FLAGS="$FLAGS"
make install

# Build libheif
cd ../../../libheif/code
autoreconf -fiv
chmod +x ./configure
./configure --disable-shared --disable-go --prefix=/usr/local CFLAGS="$FLAGS" CXXFLAGS="$FLAGS" PKG_CONFIG_PATH="$PKG_PATH"
make install

# Build Carbon.Codecs.Heif.native
cd ../../Carbon.Codecs.Heif.Native
cmake .
make
