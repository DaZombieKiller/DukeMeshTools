echo off
pushd %~dp0.\DukeMeshTool
dotnet publish -r win-x64 -c Release -p:PublishAOT=true
popd
