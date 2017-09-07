@echo off
echo Clean: Cleaning up...

if /I "%1"=="-no"         set NestedOnly=true
if /I "%1"=="-nestedOnly" set NestedOnly=true

if not "%NestedOnly%"=="true" (
  echo Clean:   Cleaning root Bin and Obj folders...
  if exist "Bin" (
    pushd "Bin"
    for /D %%i in (*) do rmdir /S /Q "%%i"
    popd
  )
  rmdir /S /Q "Obj"
)

echo Clean:   Cleaning nested Bin, Lib, bin, obj, etc.
for /D %%i in (*) do (
  if not exist "%%i\DoNotClean.txt" (
    pushd "%%i"
    for /R /D %%i in (ProxyAssemblyCache.*) do rmdir /S /Q "%%i"
    for /R /D %%i in (bin.*) do rmdir /S /Q "%%i"
    for /R /D %%i in (obj.*) do rmdir /S /Q "%%i"
    del /Q "%%i\TestResult.xml" >nul 2>nul
    if exist "Bin" (
      pushd "Bin"
      for /D %%j in (*) do rmdir /S /Q "%%j"
      popd
    )
    if exist "Lib" (
      pushd "Lib"
      del /Q *.* >nul 2>nul
      popd
    )
    popd
  )
)

echo Clean:   Done.

