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

# Build libheif
cd ../../libheif/code
autoreconf -fiv
chmod +x ./configure
./configure --disable-shared --disable-go --prefix=/usr/local CFLAGS="$FLAGS" CXXFLAGS="$FLAGS" PKG_CONFIG_PATH="$PKG_PATH"
make install

# Build Heif.native
cd ../../Heif.Native
cmake . -D PLATFORM=MACOS
make
