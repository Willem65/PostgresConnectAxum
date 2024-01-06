@echo off
setlocal enabledelayedexpansion

set "path=C:\parent\child\grandchild"

for %%A in ("%path%") do (
  set "fullpath=%%~A"
rem  for %%B in ("!fullpath:\="^%") do (
rem    echo %%~B
rem  )
)

