@echo off

IF NOT EXIST "%1" (
    mkdir "%1"
)

cd ..\..\tests\Carbon.Codecs.Heif.Tests

copy bin\x64\Release\netcoreapp3.1\Carbon.Codecs.Heif.dll "%1"
copy bin\x64\Release\netcoreapp3.1\Carbon.Codecs.Heif.Native.dll "%1"