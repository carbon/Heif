#!/bin/bash
set -e

apt-get update -y

apt-get install -y autoconf git libtool pkg-config python3-pip

pip3 install cmake
cmake --version
