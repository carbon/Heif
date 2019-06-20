@echo off

cd ..\..\tests\Heif.Tests

copy bin\x64\Release\netcoreapp2.0\Heif.dll "%1"
copy bin\x64\Release\netcoreapp2.0\Heif.Native.dll "%1"