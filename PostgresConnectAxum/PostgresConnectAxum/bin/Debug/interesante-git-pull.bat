echo off
rem cd %1
cd "C:\Users\willem\Documents\Visual Studio 2017\Projects\PostgresConnectAxum"
echo.
echo This is the:  git-pull.bat
echo.
rem geeft de huidige directory waar je nu staat
rem set p="%~dp0"
rem echo %p%

cd .git

setlocal enabledelayedexpansion

rem hieronder wordt de string uit het bestand config gehaald ( https://github.com/Willem65/PostgresConnectAxum )
for /f "tokens=2 delims== " %%a in ('findstr "url" config') do ( set b=%%a )
set dvar=%b:~0,-4%
echo %dvar%
echo %b%
cd ..

rem hieronder wordt de 4e en 5e naam uit de string gehaald ( Willem65, .... )
SET "string=%dvar%"
SET "count=0"
FOR %%a IN ("!string:/=" "!") DO (
  SET /A count+=1
  IF !count! EQU 4 (
    SET "lk=%%~a"
  )
  IF !count! EQU 5 (
    SET "lm=%%~a"
  )
)
echo %lk%
echo %lm%

rem git init

rem git pull 

set "lk=https://github.com/%lk%/%lm%"
echo %lk%

REM git add .
REM @echo.
REM git commit -m "Commit message"
REM @echo on
REM git pull %url%

rem exit the batch script
rem EXIT /B
