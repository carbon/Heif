@echo off

if not exist code (
    git clone https://github.com/ImageMagick/aom code
    cd code
    git pull
    git checkout fddf8b07d4d5a32bd3b02295bd09bb975d0dc291
    cd ..
)
