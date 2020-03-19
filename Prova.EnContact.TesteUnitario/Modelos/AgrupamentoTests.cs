using Prova.EnContact.Interfaces.Interfaces.Modelos;
using Prova.EnContact.Modelos.Modelos;
using Prova.EnContact.TesteUnitario.Utilitarios;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Prova.EnContact.TesteUnitario.Modelos
{
    public class AgrupamentoTests
    {
        [Theory]
        [ClassData(typeof(GeradorDeRecadosAgrupaveis))]
        public void CriarAgrupamentoSucessoTest(Recado primeiroRecado, Recado segundoRecado)
        {
            var agrupamento = new Agrupamento();
            agrupamento.AdicioneRecado(primeiroRecado);

            Assert.True(agrupamento.RecadoPertenceAoAgrupamanto(segundoRecado));
        }

        [Theory]
        [ClassData(typeof(GeradorDeRecadosNaoAgrupaveis))]
        public void CriarAgrupamentoFalhaTest(Recado primeiroRecado, Recado segundoRecado)
        {
            var agrupamento = new Agrupamento();
            agrupamento.AdicioneRecado(primeiroRecado);

            Assert.False(agrupamento.RecadoPertenceAoAgrupamanto(segundoRecado));
        }
    }
}
