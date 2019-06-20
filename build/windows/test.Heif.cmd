@echo off
call "init.visualstudio.cmd"

powershell .\test.Heif.ps1
if %errorlevel% neq 0 exit /b %errorlevel%