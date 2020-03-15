using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Prova.EnContact.Compartilhado.Utilitarios
{
    public static class UtilitarioDeAplicacao
    {
        public static string ObtenhaValorDasConfiguracoes(this IServiceProvider services, string chave)
        {
            var configuracao = services.GetService<IConfiguration>();
            var resultado = configuracao != null ? configuracao.GetSection(chave).Value : null;
            return resultado;
        }

        public static bool ObtenhaBoolDasConfiguracoes(this IServiceProvider services, string chave)
        {
            var resultado = ObtenhaValorDasConfiguracoes(services, chave);
            var resultadoConvertido = false;

            bool.TryParse(resultado, out resultadoConvertido);
            return resultadoConvertido;
        }

        public static void ExecutaDML(this DatabaseFacade banco, string DML)
        {
            using (var transacao = banco.BeginTransaction())
            {
                try
                {
                    banco.ExecuteSqlCommand(DML);

                    transacao.Commit();
                }
                catch (Exception ex)
                {
                    transacao.Rollback();
                }
            }
        }
    }
}
