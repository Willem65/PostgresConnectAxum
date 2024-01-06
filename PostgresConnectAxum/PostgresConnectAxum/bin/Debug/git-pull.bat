echo off
cd %1
rem cd "C:\Users\willem\Documents\Visual Studio 2017\Projects\PostgresConnectAxum"
echo.
echo This is the:  git-pull.bat
echo.


cd .git

setlocal enabledelayedexpansion


rem hieronder wordt de string uit het bestand config gehaald ( https://github.com/Willem65/PostgresConnectAxum )
for /f "tokens=2 delims== " %%a in ('findstr "url" config') do ( set b=%%a )
set dvar=%b%
echo %dvar%

cd ..


rem git init

git pull %dvar%



REM git add .
REM @echo.
REM git commit -m "Commit message"
REM @echo on
REM git pull %url%
