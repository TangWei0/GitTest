@echo off	

rem 「HashTool.dll」を「Share」へコピーする	
copy  HashTool\bin\DEBUG\HashTool.dll ..\Share\DEBUG\HashTool.dll	
if %ERRORLEVEL% NEQ 0 CALL :ERROR HashTool.dll	

copy  HashTool\bin\Release\HashTool.dll ..\Share\Release\HashTool.dll	
if %ERRORLEVEL% NEQ 0 CALL :ERROR HashTool.dll	

rem 「HashTool.pdb」を「Share」へコピーする	
copy  HashTool\bin\DEBUG\HashTool.pdb ..\Share\DEBUG\HashTool.pdb	
if %ERRORLEVEL% NEQ 0 CALL :ERROR HashTool.pdb	

copy  HashTool\bin\Release\HashTool.pdb ..\Share\Release\HashTool.pdb	
if %ERRORLEVEL% NEQ 0 CALL :ERROR HashTool.pdb	

echo COPY SUCCESS	
pause	
exit /b	

:ERROR	
echo %1 COPY ERROR	
pause	
exit /b