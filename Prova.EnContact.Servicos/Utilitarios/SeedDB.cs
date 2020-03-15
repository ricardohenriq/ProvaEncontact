using Microsoft.Extensions.DependencyInjection;
using Prova.EnContact.Interfaces.Interfaces.Servicos;
using Prova.EnContact.Modelos.Modelos;
using Prova.EnContact.Servicos.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.EnContact.UIWeb.Servicos
{
    public static class SeedDB
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            var agrupamentoServico = serviceProvider.GetRequiredService<IAgrupamentoServico<Agrupamento>>();
            var recados = GeradorDeEntidadesMock.ObtenhaRecadosMock();

            foreach(var recado in recados)
            {
                agrupamentoServico.SalvarRecado(recado);
            }
        }
    }
}
