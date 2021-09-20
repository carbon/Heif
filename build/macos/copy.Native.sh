#!/bin/bash
set -e

[ ! -d "$1" ] && mkdir $1

cp libCarbon.Codecs.Heif.Native.dll.dylib $1/Carbon.Codecs.Heif.Native.dll.dylib

mkdir -p ../../tests/Carbon.Codecs.Heif.Tests/bin/Release/netcoreapp3.1
cp libCarbon.Codecs.Heif.Native.dll.dylib ../../tests/Carbon.Codecs.Heif.Tests/bin/Release/netcoreapp3.1
