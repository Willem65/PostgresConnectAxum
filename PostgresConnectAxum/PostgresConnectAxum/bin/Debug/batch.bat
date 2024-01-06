@echo off
rem @cd %1
cd "C:\Users\willem\Documents\Visual Studio 2017\Projects\PostgresConnectAxum\PostgresConnectAxum"
SET sSubStr=%sLongString:~3%
set a=%sSubStr%
echo %sSubStr%
echo REM ################################################################################################
for /f "delims=\" %%a in (%a%) do set b=%%~nxa
REM for /F "delims=\" %%b in ("'%a%'") do ( set c=%%~nxb )
REM set path=%sSubStr%
rem for %%F in ("C:"%path%") do set filename=%%~nxF
echo REM OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
set foldername=%filename:"=%

echo %foldername%
echo "%sLongString%"
echo REM ################################################################################################
cd \
gh.exe repo create PostgresConnectAxum --private --source="C:\Users\willem\Documents\Visual Studio 2017\Projects\PostgresConnectAxum"  --remote=upstream
"C:\Program Files\GitHub CLI\gh" repo create %foldername% --private --source=%sLongString%  --remote=upstream --push


REM #################################################### TOT HIER ##################################
echo willem