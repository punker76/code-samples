@echo on
call "%VS120COMNTOOLS%vsvars32.bat"

msbuild.exe /ToolsVersion:4.0 "MahAppsMetroDataGridSample\MahAppsMetroDataGridSample.sln" /p:configuration=Debug /p:platform="Any CPU" /m /t:Clean,Rebuild
msbuild.exe /ToolsVersion:4.0 "MahAppsMetroSample\MahAppsMetroSample.sln" /p:configuration=Debug /p:platform="Any CPU" /m /t:Clean,Rebuild
msbuild.exe /ToolsVersion:4.0 "MahAppsMetroStyleOnlyWindowSample\MahAppsMetroSample.sln" /p:configuration=Debug /p:platform="Any CPU" /m /t:Clean,Rebuild
msbuild.exe /ToolsVersion:4.0 "MahAppsMetroVBSample\MahAppsMetroVBSample.sln" /p:configuration=Debug /p:platform="Any CPU" /m /t:Clean,Rebuild
msbuild.exe /ToolsVersion:4.0 "ToolTipAutoMoveSample\ToolTipAutoMoveSample.sln" /p:configuration=Debug /p:platform="Any CPU" /m /t:Clean,Rebuild
