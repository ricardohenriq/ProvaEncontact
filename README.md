# Prova enContact

## Requisitos

1. Visual Studio (preferivelmente a partir do 2015)
2. .NET Core 2.0 SDK instalado [Link para download](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-2.0.0-windows-x64-installer) aproximadamente 112 MB
3. Necessário criar um banco de dados: __SQL Server__ com o nome: __enContactBanco__
4. Necessário criar um usuário para o banco acima com nome: __enContactUsuario__ e senha: __enContactSenha__
5. Necessário configurar as seguintes "funções do servidor" para o usuário acima: __dbcreator__, __public__ e __sysadmin__, através do caminho: Segurança -> Logons -> __enContactUsuario__ -> Propriedades de logon (botão direito) -> Funções do servidor
6. **Caso queira pré carregar o banco com o exemplo demonstrado no enunciado da prova será necessário abrir o arquivo __Program.cs__, descomentar a linha: __SeedDB.Seed__ e recompilar o projeto, para que o resultado seja identico ao da prova é necessário que o banco esteja vazio.