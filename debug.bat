@echo on

dotnet build src/Skybrud.Essentials.Http --configuration Debug /t:rebuild /t:pack -p:PackageOutputPath=c:/nuget