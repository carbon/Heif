#!/bin/bash
set -e

dotnet build Carbon.Codecs.Heif.Tests.csproj -c Release
dotnet test Carbon.Codecs.Heif.Tests.csproj -c Release
