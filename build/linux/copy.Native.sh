#!/bin/bash
set -e

[ "$1" != "" ] && [ ! -d "$1" ] && mkdir "$1"

export file=libCarbon.Codecs.Heif.Native.dll.so
if ldd $file 2>&1 | grep "not found"
then
    exit 1
else
    echo "Verified ldd status for $file"
fi
if ld $file 2>&1 | grep "undefined reference"
then
    exit 1
else
    echo "Verified ld status for $file"
fi
cp $file $1/Carbon.Codecs.Heif.Native.dll.so
