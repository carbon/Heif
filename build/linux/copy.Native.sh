#!/bin/bash
set -e

[ "$1" != "" ] && [ ! -d "$1" ] && mkdir "$1"

cp libCarbon.Codecs.Heif.Native.dll.so $1/Carbon.Codecs.Heif.Native.dll.so
