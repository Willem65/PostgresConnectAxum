@echo off
@cd %1
@echo.
@echo Make Repository.
@echo.
@echo This is the :   git-private-repo.bat    file



set sLongString=%1

SET sSubStr=%sLongString:~3%

@echo %sSubStr%

REM echo %sSubStr%

REM @echo "C:\Program Files\GitHub CLI\gh.exe" repo create %sSubStr% --public --source=. --remote=upstream --push 
gh.exe repo create %sSubStr% --private --source=. --remote=upstream --push

REM @echo gh.exe repo edit --visibility private.