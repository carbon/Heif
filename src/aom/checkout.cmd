@echo off

if not exist code (
    git clone https://github.com/ImageMagick/aom code
    cd code
    git pull
    git checkout e2d48104f26fb634031f104da5b7a3a9bfe81673
    cd ..
)
