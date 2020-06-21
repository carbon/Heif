@echo off

if not exist code (
    git clone https://github.com/ImageMagick/libheif code
    cd code
    git pull
    git checkout 45145e3a45f49975b48c027982d8e629ee2acddb
    copy /Y ..\CMakeLists.windows.txt libheif\CMakeLists.txt
    cmake . -D CMAKE_GENERATOR_PLATFORM=x64 -D LIBDE265_FOUND=1 -D LIBDE265_CFLAGS="-I ..\..\..\libde265\code" -D CMAKE_CXX_FLAGS_RELEASE="/MT" -D CMAKE_CXX_FLAGS_DEBUG="/MTd"
    cd ..
)
