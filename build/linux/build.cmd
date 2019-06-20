@echo off

docker build ../.. -f Dockerfile.build -t heif-linux
docker run -v %~dp0output:/output -w /src/Heif.Native heif-linux /build/copy.Native.sh /output