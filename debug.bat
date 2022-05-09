@echo on

dotnet build src/Skybrud.Essentials.Http --configuration Debug /t:rebuild /t:pack -p:BuildTools=1 -p:PackageOutputPath=c:/nuget