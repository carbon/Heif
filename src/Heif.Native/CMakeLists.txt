cmake_minimum_required (VERSION 2.8.8)

set(LIBRARY_NAME Heif.Native.dll)

project(${LIBRARY_NAME})

include_directories(/usr/local/include)

set(LIB_DIR /usr/local/lib)
set(CMAKE_CXX_FLAGS "-Wall -O3")

set (ALL_FILES HeifContext.c HeifImage.c HeifImageHandle.c Stdafx.c Heif.cxx)

if (PLATFORM STREQUAL "MACOS")
    set(STDCPLUSPLUS stdc++)
else()
    find_package(Threads REQUIRED)
    set(THREADLIB Threads::Threads)
    set(STDCPLUSPLUS -static-libstdc++ -static-libgcc)
endif()

add_library(${LIBRARY_NAME} SHARED ${ALL_FILES})

target_link_libraries(
    ${LIBRARY_NAME}

    ${LIB_DIR}/libheif.a
    ${LIB_DIR}/libde265.a

    ${THREADLIB}

    ${STDCPLUSPLUS}
)