:: 批量解析protocol文件

@echo off

set TOOl_PATH=./Protocol/tool/protoc-3.15.8-win64/bin/protoc.exe
set IMPORT_PATH=./Protocol/proto/
set DST_DIR=./Unity/Assets/Scripts/Proto/

:: exe protoc

for /f %%f in ('dir /b /s Protocol\proto\') do (
    If not exist %%f echo.>%%f
    "%TOOl_PATH%" --proto_path %IMPORT_PATH% --csharp_out %DST_DIR% %%~nxf
     echo build %%f
)
pause