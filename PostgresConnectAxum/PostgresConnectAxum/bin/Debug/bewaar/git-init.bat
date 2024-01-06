@echo on
cd %1
echo.
echo Dit is de :  git-init.bat    file
echo.

git init

git add .

git commit -m "Commit message"

git push origin master
