@echo off

IF NOT "%VS110COMNTOOLS%" == "" (call "%VS110COMNTOOLS%vsvars32.bat")
IF NOT "%VS120COMNTOOLS%" == "" (call "%VS120COMNTOOLS%vsvars32.bat")
IF NOT "%VS130COMNTOOLS%" == "" (call "%VS130COMNTOOLS%vsvars32.bat")
IF NOT "%VS140COMNTOOLS%" == "" (call "%VS140COMNTOOLS%vsvars32.bat")

@echo on

.paket\paket.bootstrapper.exe
.paket\paket.exe update

msbuild.exe /ToolsVersion:4.0 "MahAppsMetroDataGridSample\MahAppsMetroDataGridSample.sln" /p:configuration=Debug /p:platform="Any CPU" /m /t:Clean,Rebuild
msbuild.exe /ToolsVersion:4.0 "MahAppsMetroSample\MahAppsMetroSample.sln" /p:configuration=Debug /p:platform="Any CPU" /m /t:Clean,Rebuild
msbuild.exe /ToolsVersion:4.0 "MahAppsMetroStyleOnlyWindowSample\MahAppsMetroSample.sln" /p:configuration=Debug /p:platform="Any CPU" /m /t:Clean,Rebuild
msbuild.exe /ToolsVersion:4.0 "MahAppsMetroVBSample\MahAppsMetroVBSample.sln" /p:configuration=Debug /p:platform="Any CPU" /m /t:Clean,Rebuild
msbuild.exe /ToolsVersion:4.0 "ToolTipAutoMoveSample\ToolTipAutoMoveSample.sln" /p:configuration=Debug /p:platform="Any CPU" /m /t:Clean,Rebuild
