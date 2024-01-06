echo off
cd %1
echo.
echo This is the   Download   git-pull.bat
echo.
REM cd .git

set url=https://github.com/Willem65/temp5.git

REM setlocal enabledelayedexpansion

REM for /f "tokens=2 delims== " %%a in ('findstr "url" config') do ( set b=%%a )
REM set dvar=%b:~0,-5%

REM cd ..


@echo.
REM git add .
@echo.
REM git commit -m "Commit message"
@echo on
git pull %url%
