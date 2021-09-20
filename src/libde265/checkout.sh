#!/bin/bash
set -e

git clone https://github.com/ImageMagick/libde265 code
cd code
git checkout 58ccddd4a8e5c86045630fda733c3b398f72267c