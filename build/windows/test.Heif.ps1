# Copyright (c) Carbon and contributors.
# Licensed under the MIT License.

. $PSScriptRoot\utils.ps1

function runTests()
{
    $vstest = "$($env:VSINSTALLDIR)\Common7\IDE\Extensions\TestPlatform\vstest.console.exe"

    $folder = fullPath "tests\Heif.Tests\bin\x64\Release\netcoreapp2.0"
    $fileName = "$folder\Carbon.Codecs.Heif.Tests.dll"

    & $vstest $fileName /platform:x64 /TestAdapterPath:$folder

    checkExitCode("Failed to test Heif")
}

runTests