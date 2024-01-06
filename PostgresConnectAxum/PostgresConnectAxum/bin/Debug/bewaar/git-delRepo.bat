@echo off
cd %1
echo.
echo Dit is de :  del-Repo.bat    file
echo.

REM REM REM cd .git

REM REM REM setlocal enabledelayedexpansion

REM REM REM for /f "tokens=2 delims== " %%a in ('findstr "url" config') do ( set strfind=%%a )
REM REM REM set dvar=%strfind:~19,-5%
REM REM REM REM @echo %strfind%
REM REM REM REM @echo %dvar%
REM REM REM @echo.

REM REM REM for /f "tokens=1,2 delims=/" %%a in ("!dvar!") do (
    REM REM REM set aa=%%a
    REM REM REM set bb=%%b
REM REM REM )

REM REM REM cd ..
REM REM REM @echo.

REM REM REM REM echo %aa%
REM REM REM REM echo %bb%


set sLongString=%1

SET sSubStr=%sLongString:~3%

@echo %sSubStr%

gh repo delete %sSubStr% --yes | echo %sSubStr%


REM @echo on
REM @echo.
REM @echo Is the Repo already deleted, if so you get the message 404 ?
REM @echo.
REM gh repo delete %aa%/%bb% --yes | echo %aa%/%bb%
REM echo. off




REM gh "repo delete Willem65/%sSubStr%" --yes | echo Willem65/%sSubStr%