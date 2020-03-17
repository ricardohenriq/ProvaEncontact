dotnet restore
dotnet clean
dotnet build
dotnet test ./Prova.EnContact.TesteIntegracao/Prova.EnContact.TesteIntegracao.csproj --logger trx
pause