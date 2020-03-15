using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Prova.EnContact.Compartilhado.Constantes;
using Prova.EnContact.Compartilhado.Utilitarios;
using Prova.EnContact.Mapeadores.Data;
using Prova.EnContact.UIWeb.Servicos;

namespace Prova.EnContact.UIWeb
{
    public class Program
    {
        private const string chaveCarregarBancoDeExemploDaProva = "ConfiguracoesDaAplicacao:CarregarBancoDeExemploDaProva";

        public static void Main(string[] args)
        {
            try
            {
                var host = BuildWebHost(args).Build();

                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var serviceProvider = services.GetRequiredService<IServiceProvider>();
                    var contexto = serviceProvider.GetRequiredService<ApplicationDbContext>();

                    if (contexto.Database.IsSqlServer())
                    {
                        contexto.Database.Migrate();
                    }
                    else if (contexto.Database.IsSqlite())
                    {
                        contexto.Database.EnsureCreated();
                    }

                    var carregarBancoDeExemploDaProva = services.ObtenhaBoolDasConfiguracoes(chaveCarregarBancoDeExemploDaProva);
                    if (carregarBancoDeExemploDaProva)
                    {
                        contexto.Database.ExecutaDML("DELETE FROM Agrupamentos");
                        SeedDB.Seed(serviceProvider);
                    }
                }

                host.Run();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format(ConstantesPalavras.ERRO, ex.Message));
                throw;
            }
        }

        public static IWebHostBuilder BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
