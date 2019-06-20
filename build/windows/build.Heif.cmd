@echo off
call "init.visualstudio.cmd"

powershell .\build.Heif.ps1
if %errorlevel% neq 0 exit /b %errorlevel%