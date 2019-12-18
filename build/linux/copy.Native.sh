#!/bin/bash
set -e

[ ! -d "$1" ] && mkdir $1

cp libHeif.Native.dll.so $1/Heif.Native.dll.so
