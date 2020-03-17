dotnet restore
dotnet clean
dotnet build
dotnet test ./Prova.EnContact.TesteUnitario/Prova.EnContact.TesteUnitario.csproj --logger trx
pause