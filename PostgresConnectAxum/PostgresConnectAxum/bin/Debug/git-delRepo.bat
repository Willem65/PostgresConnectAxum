@echo off
cd %1
echo.
echo Dit is de:  del-Repo.bat 
echo.
echo De Repository op GitHub wordt nu verwijdert
echo.



@echo off
setlocal EnableDelayedExpansion
set "path=%1"
for %%i in ("%path%") do set "last_folder=%%~nxi"
echo %last_folder%



@echo on


gh repo delete %last_folder:~0,-2% --yes




