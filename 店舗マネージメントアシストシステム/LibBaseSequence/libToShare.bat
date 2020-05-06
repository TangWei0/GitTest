@echo off
 
rem 「LibBaseSequence.dll」を「Share」へコピーする
copy  LibBaseSequence\bin\DEBUG\LibBaseSequence.dll ..\Share\DEBUG\LibBaseSequence.dll
if %ERRORLEVEL% NEQ 0 CALL :ERROR LibBaseSequence.dll

copy  LibBaseSequence\bin\Release\LibBaseSequence.dll ..\Share\Release\LibBaseSequence.dll
if %ERRORLEVEL% NEQ 0 CALL :ERROR LibBaseSequence.dll

rem 「LibBaseSequence.pdb」を「Share」へコピーする
copy  LibBaseSequence\bin\DEBUG\LibBaseSequence.pdb ..\Share\DEBUG\LibBaseSequence.pdb
if %ERRORLEVEL% NEQ 0 CALL :ERROR LibBaseSequence.pdb

copy  LibBaseSequence\bin\Release\LibBaseSequence.pdb ..\Share\Release\LibBaseSequence.pdb
if %ERRORLEVEL% NEQ 0 CALL :ERROR LibBaseSequence.pdb

echo COPY SUCCESS
pause
exit /b

:ERROR
echo %1 COPY ERROR
pause
exit /b