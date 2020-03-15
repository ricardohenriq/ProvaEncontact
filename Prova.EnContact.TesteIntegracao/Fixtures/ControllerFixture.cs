using Microsoft.Extensions.DependencyInjection;
using Prova.EnContact.Compartilhado.Constantes;
using Prova.EnContact.Mapeadores.Data;
using Prova.EnContact.TesteIntegracao.Utilitarios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Prova.EnContact.TesteIntegracao.Fixtures
{
    public class ControllerFixture
    {
        public IServiceProvider Provider { get; set; }

        public void RestauraBanco()
        {
            Provider = TesteUtils.ObtenhaProviderMock();
            ExcluiBanco();
            CriaBanco();
        }

        private void ExcluiBanco()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (File.Exists(ConstantesUtilitarios._NOME_BANCO_SQLITE))
            {
                File.Delete(ConstantesUtilitarios._NOME_BANCO_SQLITE);
            }
        }

        private void CriaBanco()
        {
            var contexto = Provider.GetRequiredService<ApplicationDbContext>();
            contexto.Database.EnsureCreated();
        }
    }
}
