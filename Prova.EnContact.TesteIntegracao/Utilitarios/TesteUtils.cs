using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using Prova.EnContact.Compartilhado.Utilitarios;
using Prova.EnContact.Interfaces.Interfaces.Servicos;
using Prova.EnContact.Mapeadores.Data;
using Prova.EnContact.Modelos.Modelos;
using Prova.EnContact.Servicos.Servicos;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Text;

namespace Prova.EnContact.TesteIntegracao.Utilitarios
{
    public static class TesteUtils
    {
        public static IServiceProvider ObtenhaProviderMock()
        {
            var configuracao = UtilitarioDeArquivos.CarregueJsonArquivo("appsettings.json");
            var conexaoDoBanco = configuracao.BDTeste.SQliteBDConnectionString;
            var conexaoDoBancoString = ((JValue)conexaoDoBanco).Value as string;

            var services = new ServiceCollection();

            services.AddTransient(typeof(IRecadoServico<Recado>), typeof(RecadoServico));
            services.AddTransient(typeof(IAgrupamentoServico<Agrupamento>), typeof(AgrupamentoServico));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(conexaoDoBancoString, x => x.SuppressForeignKeyEnforcement())
                .EnableSensitiveDataLogging());

            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
