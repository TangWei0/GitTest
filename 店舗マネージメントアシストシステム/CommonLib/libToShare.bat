@echo off
 
rem 「Common.dll」を「Share」へコピーする
copy  Common\bin\ManagerAssist\Common.dll ..\Share\DEBUG\Common.dll
if %ERRORLEVEL% NEQ 0 CALL :ERROR Common.dll

copy  Common\bin\ManagerAssist\Common.dll ..\Share\Release\Common.dll
if %ERRORLEVEL% NEQ 0 CALL :ERROR Common.dll

rem 「Common.pdb」を「Share」へコピーする
copy  Common\bin\ManagerAssist\Common.pdb ..\Share\DEBUG\Common.pdb
if %ERRORLEVEL% NEQ 0 CALL :ERROR Common.pdb

copy  Common\bin\ManagerAssist\Common.pdb ..\Share\Release\Common.pdb
if %ERRORLEVEL% NEQ 0 CALL :ERROR Common.pdb

rem 「EnumExtension.dll」を「Share」へコピーする
copy  EnumExtension\bin\DEBUG\EnumExtension.dll ..\Share\DEBUG\EnumExtension.dll
if %ERRORLEVEL% NEQ 0 CALL :ERROR EnumExtension.dll

copy  EnumExtension\bin\Release\EnumExtension.dll ..\Share\Release\EnumExtension.dll
if %ERRORLEVEL% NEQ 0 CALL :ERROR EnumExtension.dll

rem 「EnumExtension.pdb」を「Share」へコピーする
copy  EnumExtension\bin\DEBUG\EnumExtension.pdb ..\Share\DEBUG\EnumExtension.pdb
if %ERRORLEVEL% NEQ 0 CALL :ERROR EnumExtension.pdb

copy  EnumExtension\bin\Release\EnumExtension.pdb ..\Share\Release\EnumExtension.pdb
if %ERRORLEVEL% NEQ 0 CALL :ERROR EnumExtension.pdb

rem 「Time.dll」を「Share」へコピーする
copy  Time\bin\DEBUG\Time.dll ..\Share\DEBUG\Time.dll
if %ERRORLEVEL% NEQ 0 CALL :ERROR Time.dll

copy  Time\bin\Release\Time.dll ..\Share\Release\Time.dll
if %ERRORLEVEL% NEQ 0 CALL :ERROR Time.dll

rem 「Time.pdb」を「Share」へコピーする
copy  Time\bin\DEBUG\Time.pdb ..\Share\DEBUG\Time.pdb
if %ERRORLEVEL% NEQ 0 CALL :ERROR Time.pdb

copy  Time\bin\Release\Time.pdb ..\Share\Release\Time.pdb
if %ERRORLEVEL% NEQ 0 CALL :ERROR Time.pdb

echo COPY SUCCESS
pause
exit /b

:ERROR
echo %1 COPY ERROR
pause
exit /b