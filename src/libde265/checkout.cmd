@echo off

if not exist code (
    git clone https://github.com/strukturag/libde265 code
    cd code
    git pull
    git checkout tags/v1.0.4
    copy /Y ..\CMakeLists.windows.txt libde265\CMakeLists.txt
    cmake .  -D CMAKE_GENERATOR_PLATFORM=x64 -D CMAKE_CXX_FLAGS_RELEASE="/MT" -D CMAKE_CXX_FLAGS_DEBUG="/MTd"
    cd ..
)