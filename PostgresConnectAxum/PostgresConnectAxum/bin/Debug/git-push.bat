@echo off

cd %1

echo.
echo This is the   upload   git-push.bat
echo.

cd .git

setlocal enabledelayedexpansion

for /f "tokens=2 delims== " %%a in ('findstr "url" config') do ( set b=%%a )
set dvar=%b%

cd ..

rem git config --system --unset credential.helper

rem git config --system --add safe.directory %1

@echo on
@echo.

rem git init

git add .
@echo.
git commit -m "Commit push message"
@echo.

rem git remote add origin %dvar%

git remote -v

git push %dvar% --force



