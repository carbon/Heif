@echo off

if not exist code (
    git clone https://github.com/strukturag/libheif code
    cd code
    git pull
    git checkout tags/v1.6.2
    copy /Y ..\CMakeLists.windows.txt libheif\CMakeLists.txt
    cmake . -D CMAKE_GENERATOR_PLATFORM=x64 -D LIBDE265_FOUND=1 -D LIBDE265_CFLAGS="-I ..\..\..\libde265\code" -D CMAKE_CXX_FLAGS_RELEASE="/MT" -D CMAKE_CXX_FLAGS_DEBUG="/MTd"
    cd ..
)
