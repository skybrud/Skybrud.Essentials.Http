@echo off

dotnet build src/Skybrud.Essentials.Http --configuration Release /t:rebuild /t:pack -p:PackageOutputPath=../../releases/nuget