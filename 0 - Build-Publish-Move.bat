@echo off

dotnet restore

dotnet build --no-restore -c Release

move /Y Panosen.Xml\bin\Release\Panosen.Xml.*.nupkg D:\LocalSavoryNuget\

pause