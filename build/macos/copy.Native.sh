#!/bin/bash
set -e

[ ! -d "$1" ] && mkdir $1

cp libHeif.Native.dll.dylib $1/Heif.Native.dll.dylib

mkdir -p ../../tests/Heif.Tests/bin/Release/netcoreapp2.0
cp libHeif.Native.dll.dylib ../../tests/Heif.Tests/bin/Release/netcoreapp2.0
