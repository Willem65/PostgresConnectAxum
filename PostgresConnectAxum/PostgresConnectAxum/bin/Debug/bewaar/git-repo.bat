
@echo off
@cd %1
@echo.
@echo Make Repository.
@echo.
@echo This is the :   git-repo.bat    file



set sLongString=%1

SET sSubStr=%sLongString:~3%

@echo %sSubStr%

REM echo %sSubStr%

REM @echo "C:\Program Files\GitHub CLI\gh.exe" repo create %sSubStr% --public --source=. --remote=upstream --push 
gh.exe repo create %sSubStr% --public --source=. --remote=upstream --push

REM call :Substring %sLongString% 3 300 sSubStrResult

REM :Substring
REM SET sLongStr=%1
REM SET iFirstChar=%2
REM SET iCharCount=%3
REM SET sSubStr=%%sLongStr:~%iFirstChar%,%iCharCount%%%