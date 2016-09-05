@echo off

IF NOT "%VS140COMNTOOLS%" == "" (call "%VS140COMNTOOLS%vsvars32.bat")

.paket\paket.bootstrapper.exe
.paket\paket.exe update

msbuild.exe /tv:14.0 "MahAppsMetroDataGridSample\MahAppsMetroDataGridSample.sln" /p:configuration=Debug /p:platform="Any CPU" /m /t:Clean,Rebuild
msbuild.exe /tv:14.0 "MahAppsMetroFullScreen\MahAppsMetroFullScreen.sln" /p:configuration=Debug /p:platform="Any CPU" /m /t:Clean,Rebuild
msbuild.exe /tv:14.0 "MahAppsMetroSample\MahAppsMetroSample.sln" /p:configuration=Debug /p:platform="Any CPU" /m /t:Clean,Rebuild
msbuild.exe /tv:14.0 "MahAppsMetroStyleOnlyWindowSample\MahAppsMetroSample.sln" /p:configuration=Debug /p:platform="Any CPU" /m /t:Clean,Rebuild
msbuild.exe /tv:14.0 "MahAppsMetroThemesSample\MahAppsMetroThemesSample.sln" /p:configuration=Debug /p:platform="Any CPU" /m /t:Clean,Rebuild
msbuild.exe /tv:14.0 "MahAppsMetroVBSample\MahAppsMetroVBSample.sln" /p:configuration=Debug /p:platform="Any CPU" /m /t:Clean,Rebuild
msbuild.exe /tv:14.0 "MahAppsMetroWindowButtonCommands\MahAppsMetroWindowButtonCommands.sln" /p:configuration=Debug /p:platform="Any CPU" /m /t:Clean,Rebuild
msbuild.exe /tv:14.0 "ToolTipAutoMoveSample\ToolTipAutoMoveSample.sln" /p:configuration=Debug /p:platform="Any CPU" /m /t:Clean,Rebuild
