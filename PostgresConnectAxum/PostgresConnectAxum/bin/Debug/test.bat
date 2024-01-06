REM echo off
REM set sLongString=%1
REM call :Substring %sLongString% 3 300 sSubStrResult

REM :Substring
REM SET sLongStr=%1
REM SET iFirstChar=%2
REM SET iCharCount=%3
REM CALL SET sSubStr=%%sLongStr:~%iFirstChar%,%iCharCount%%%

REM echo.%sSubStr%

REM echo.%sSubStr%



@Echo On
Set "SD=H:\Program Files (x86)\Test"
Set "SF=JobRunnerLogFile.winservice*.txt"
Set "SS=more than one matching element"
If Not Exist "%SD%\%SF%" Exit /B
For /F "Delims=" %%A In ('FindStr /IMC:"%SS%" "%SD%\%SF%"'
) Do Echo String match found in "%%~nxA"
Pause

