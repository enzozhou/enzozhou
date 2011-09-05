@echo off
:checkagain
@echo Waiting CEVA RF-Picking System to exit.
tasklist | find "CEVA RF-Picking"   >nul
if ERRORLEVEL 1 goto check2
ping -n 4 127.0.0.1  >nul
goto checkagain
:check2
tasklist | find "SWSRF"   >nul
if ERRORLEVEL 1 goto Upgrade
ping -n 4 127.0.0.1  >nul
goto checkagain
:Upgrade
ping -n 4 127.0.0.1  >nul
set JustLogin=0
if exist "\\10.40.17.3\upgrade" goto LoginOK
echo logon...
net use \\10.40.17.3\upgrade  CevaUP2011  /user:up   >nul
echo Return code is %ERRORLEVEL%
if not %ERRORLEVEL%==0 (
echo 无法登录服务器.
goto Exit
)
set JustLogin=1
:LoginOK
echo 开始程序升级...
rem pause
xcopy  \\10.40.17.3\Upgrade\*.*  .     /c /h /r /d /y /s
xcopy  \\10.40.17.3\Upgrade\Interop.Excel.dll    . /y     >nul
xcopy  \\10.40.17.3\Upgrade\Interop.Office.dll    . /y  >nul
del IFSrv.*  >nul
if not %JustLogin%==1 goto Completed
echo log off
echo y|net use \\10.40.17.3\upgrade /delete >nul
:Completed
echo 升级完成.
:Exit
ping -n 1 127.0.0.1  >nul
