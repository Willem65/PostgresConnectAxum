@echo off
echo.
echo Dit is de:  git-private.bat  
echo.
rem @cd %1
set sLongString=%1
rem set sLongString="C:\Users\willem\Documents\Visual Studio 2017\Projects\PostgresConnectAxum"
SET sSubStr="%sLongString:~3%
echo %sLongString%
REM echo %sSubStr%
for %%F in ("%sSubStr%") do set foldername=%%~nxF

set foldername=%foldername:"=%
echo %foldername%
gh.exe repo create %foldername% --public --source=%sLongString%  --remote=upstream --push
rem gh.exe repo create %foldername% --private --source="C:\Users\willem\Documents\Visual Studio 2017\Projects\PostgresConnectAxum" --remote=upstream --push

REM SET sSubStr="\Users\willem\Documents\Visual Studio 2017\Projects\PostgresConnectAxum"