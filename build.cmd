@echo off

pushd %~dp0

tools\nuget\NuGet.exe update -self
tools\nuget\NuGet.exe install FAKE -ConfigFile tools\nuget\Nuget.Config -OutputDirectory src\packages -ExcludeVersion -Version 4.7.3

set encoding=utf-8
src\packages\FAKE\tools\FAKE.exe build.fsx %*

popd
