@echo off
cd %1
echo.
echo Dit is de:  git-init.bat  
echo.
ping -n 2 127.0.0.1>NUL
git init .
ping -n 2 127.0.0.1>NUL
git add .
ping -n 2 127.0.0.1>NUL
git commit -m "Commit message1"

ping -n 2 127.0.0.1>NUL

rem git push origin master

