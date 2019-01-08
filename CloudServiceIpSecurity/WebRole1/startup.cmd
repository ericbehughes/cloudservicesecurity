echo Installing "IPv4 Address and Domain Restrictions" feature 
abc > C:\dev\myfile.txt
echo Unlocking configuration for "IPv4 Address and Domain Restrictions" feature 
%windir%\system32\inetsrv\AppCmd.exe unlock config -section:system.webServer/security/ipSecurity
EXIT /B 0