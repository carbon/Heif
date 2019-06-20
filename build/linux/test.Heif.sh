#!/bin/bash
set -e

dotnet build Heif.Tests.csproj -f netcoreapp2.0 -c Release
dotnet test Heif.Tests.csproj -f netcoreapp2.0 -c Release
