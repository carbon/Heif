#!/bin/bash
set -e

dotnet build Carbon.Codecs.Heif.Tests.csproj -f netcoreapp2.0 -c Release
dotnet test Carbon.Codecs.Heif.Tests.csproj -f netcoreapp2.0 -c Release
