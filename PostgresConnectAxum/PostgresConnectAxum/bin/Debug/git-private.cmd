@echo off
rem @cd %1
set sLongString="C:\Users\willem\Documents\Visual Studio 2017\Projects\PostgresConnectAxum"
SET sSubStr=%sLongString:~3%
echo %sLongString%
echo %sSubStr%
for %%S in ("%sSubStr%") do set foldername=%%~nxS
gh.exe repo create %foldername% --private --source=%sLongString%  --remote=upstream
rem gh.exe repo create %foldername% --private --source="C:\Users\willem\Documents\Visual Studio 2017\Projects\PostgresConnectAxum"  --remote=upstream
rem "C:\Program Files\GitHub CLI\gh" repo create %foldername% --private --source=%sLongString%  --remote=upstream --push









 
 
 
 