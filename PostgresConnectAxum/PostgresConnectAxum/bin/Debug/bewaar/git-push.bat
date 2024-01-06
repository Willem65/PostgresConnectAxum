@echo off

cd %1

echo.
echo This is the   upload   git-push.bat
echo.

cd .git

setlocal enabledelayedexpansion

for /f "tokens=2 delims== " %%a in ('findstr "url" config') do ( set b=%%a )
set dvar=%b:~0,-5%

cd ..

@echo on
@echo.
git add .
@echo.
git commit -m "Commit message"
@echo.
git push %dvar%



