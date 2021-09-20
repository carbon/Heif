@echo off

if not exist code (
    git clone https://github.com/ImageMagick/libde265 code
    cd code
    git pull
    git checkout 58ccddd4a8e5c86045630fda733c3b398f72267c
    copy /Y ..\CMakeLists.windows.txt libde265\CMakeLists.txt
    cmake .  -D CMAKE_GENERATOR_PLATFORM=x64 -D CMAKE_CXX_FLAGS_RELEASE="/MT" -D CMAKE_CXX_FLAGS_DEBUG="/MTd"
    cd ..
)