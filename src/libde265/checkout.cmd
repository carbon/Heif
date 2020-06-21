@echo off

if not exist code (
    git clone https://github.com/ImageMagick/libde265 code
    cd code
    git pull
    git checkout fe4201f038239c4534d786d9aa3400ddeab9f673
    copy /Y ..\CMakeLists.windows.txt libde265\CMakeLists.txt
    cmake .  -D CMAKE_GENERATOR_PLATFORM=x64 -D CMAKE_CXX_FLAGS_RELEASE="/MT" -D CMAKE_CXX_FLAGS_DEBUG="/MTd"
    cd ..
)