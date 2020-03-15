# Prova enContact

## Requisitos

1. Visual Studio (preferivelmente a partir do 2015)
2. .NET Core 2.0 SDK instalado [Link para download](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-2.0.0-windows-x64-installer) aproximadamente 112 MB
3. Necessário criar um banco de dados: __SQL Server__ com o nome: __enContactBanco__
4. Necessário criar um usuário para o banco acima com nome: __enContactUsuario__ e senha: __enContactSenha__
5. Necessário configurar as seguintes "funções do servidor" para o usuário acima: __dbcreator__, __public__ e __sysadmin__, através do caminho: Segurança -> Logons -> __enContactUsuario__ -> Propriedades de logon (botão direito) -> Funções do servidor
6. Para executar os testes unitários e de integração será necessário que abra a janela de testes do VS: __Botão Test__ -> __Windows__ -> __Test Explorer__, assim que aberto deve-se realizar o rebuild da aplicação para que os testes sejam "descobertos" pelo VS.
7. Versão do __xunit__ e __xunit.runner.visualstudio__ é a 2.4.0
8. Para mudar se o aplicativo será lançado como __RELEASE__ ou __DEBUG__ deverá ser alterado o ambiente no arquivo __launchSettings.json__ (Development, Release) que fica dentro do projeto __UIWEB__
8. **Caso queira pré carregar o banco com o exemplo demonstrado no enunciado da prova será necessário abrir o arquivo __Program.cs__, descomentar a linha: __SeedDB.Seed__ e recompilar o projeto, para que o resultado seja identico ao da prova é necessário que o banco esteja vazio.
9. **Caso queira que a __Data do Recado__ seja editável na tela para simular manualmente datas arbitrárias será necessário descomentar as linhas __9 a 14__ do arquivo __Cadastrar.cshtml__
