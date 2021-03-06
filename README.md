# Prova enContact

## Requisitos

1. Visual Studio (preferivelmente a partir do 2015)

2. .NET Core 2.0 SDK instalado [Link para download](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-2.0.0-windows-x64-installer) aproximadamente 112 MB

3. __[opcional]__ Banco SQL Server (opcional pois é possivel executar a aplicação com SQLite embarcado)

4. Instalar a versão do __xunit__ e __xunit.runner.visualstudio__ é a 2.4.0


## Procedimentos

1. Realizar o Clone/Download do repositório [Link](https://github.com/ricardohenriq/ProvaEncontact.git)

2. É possível executar a aplicação somente executando o __IniciarAplicacao.bat__, ele irá baixar os pacotes, realizar o build e iniciar a aplicação (será exibido uma URL para ser acessada em qualquer browser)

3. É possível executar os testes unitários e de integração ao executar os bats: __ExecutarTestesUnitario.bat__ e __ExecutarTestesIntegracao.bat__ respectivamente, ambos irão gerar seus arquivo __.trx__ padrão nas pastas: __./Prova.EnContact.TesteUnitario/TestResults__ e __./Prova.EnContact.TesteIntegracao/TestResults__ respectivamente.

4. Caso deseje executar a aplicação via algum dos arquivos __.bat__ NÃO se deve executa-los como administrador.

5. __[Opcional]:__ Alterar o arquivo __./Prova.EnContact.UIWeb/appsettings.json__

	5.1 É possível marcar que a __Data do Recado__ será visivel no cadastro do recado (para testar datas passadas), para isso altere a propriedade: __PermitirExibirCampoDataDoRecado__ para "true", por padrão é "false".
	
	5.2 É possível pré cadastrar o exemplo dado no enunciado da prova, para isso altere a propriedade: __CarregarBancoDeExemploDaProva__ para "true", por padrão é "false".
	
	5.3 É possível alterar qual o tipo de banco de dados a ser utilizado, para isso altere a propriedade: __BancoDeDadosUtilizado__ para um dos valores: __SqlServer__ ou __SQLite__ por padrão é "Sqlite".
	
6. __[Opcional]:__ Caso selecione o banco __SqlServer__ será necessário criar um banco com o nome: __enContactBanco__, um usuário para o banco com nome: __enContactUsuario__ e senha: __enContactSenha__

	6.1. __[Opcional]:__ Caso selecione o banco __SqlServer__ será necessário configurar as seguintes "funções do servidor" para o usuário acima: __dbcreator__, __public__ e __sysadmin__, através do caminho: Segurança -> Logons -> __enContactUsuario__ -> Propriedades de logon (botão direito) -> Funções do servidor

7. __[Opcional]:__ Caso queira mudar se o aplicativo será lançado como __Release__ ou __Development__ deverá ser alterado o ambiente no arquivo __launchSettings.json__ que fica dentro do projeto __UIWEB__, por padrão está como "Release"

8. __[Observação]:__ Aplicação é "Case insensitive" ou seja: "Ricardo" é igual a "ricardo"

9. __[Observação]:__ Aplicação realiza um "Trim" nos assunto a título de comparação ou seja: " Este é o assunto  " é igual a "Este é o assunto" mas não é igual a " Este é o   assunto  " mas no banco será salvo o assunto da forma como o usuário inseriu.