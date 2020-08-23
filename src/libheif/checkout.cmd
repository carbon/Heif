@echo off

if not exist code (
    git clone https://github.com/ImageMagick/libheif code
    cd code
    git pull
    git checkout debdbeecf0380afa222b992730cfdd9ee7f6e2bc
    copy /Y ..\CMakeLists.windows.txt libheif\CMakeLists.txt
    cmake . -D CMAKE_GENERATOR_PLATFORM=x64 -D LIBDE265_FOUND=1 -D LIBDE265_CFLAGS="-I ..\..\..\libde265\code" -D AOM_FOUND=1 -D AOM_CFLAGS="-I ..\..\..\aom\code" -D CMAKE_CXX_FLAGS_RELEASE="/MT" -D CMAKE_CXX_FLAGS_DEBUG="/MTd"
    cd ..
)
