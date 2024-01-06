
@echo off
@cd %1
@echo.
@echo Make Repository on GitHub.
@echo.
@echo This is the :   git-repo.bat    file
@echo.


set sLongString=%1
rem set sLongString="C:\Users\willem\Documents\Visual Studio 2017\Projects\PostgresConnectAxum"
SET sSubStr="%sLongString:~3%
rem echo %sLongString%
REM echo %sSubStr%
for %%F in ("%sSubStr%") do set foldername=%%~nxF

set foldername=%foldername:"=%
@echo.
echo %foldername%
@echo.
gh.exe repo create %foldername% --public --source=%sLongString%  --remote=upstream --push

REM SET sSubStr="\Users\willem\Documents\Visual Studio 2017\Projects\PostgresConnectAxum"