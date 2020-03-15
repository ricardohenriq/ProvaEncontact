using Prova.EnContact.Compartilhado.Constantes;
using Prova.EnContact.TesteIntegracao.Fixtures;
using Prova.EnContact.TesteIntegracao.Utilitarios;
using Prova.EnContact.UIWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Prova.EnContact.TesteIntegracao.Controllers
{
    [Collection(ConstantesUtilitarios._CONTROLLER_COLLECTION)]
    public class RecadosControllerTests
    {
        private readonly RecadosController _controller;
        private readonly ControllerFixture _controllerFixture;

        public RecadosControllerTests(ControllerFixture controllerFixture)
        {
            _controller = new RecadosController(TesteUtils.ObtenhaProviderMock());
            _controllerFixture = controllerFixture;
            _controllerFixture.RestauraBanco();
        }

        [Fact]
        public void CarregueViewCadastrarTest()
        {

        }

        [Fact]
        public void SalveRecadoTest()
        {

        }

        [Fact]
        public void VerRecadosTest()
        {

        }
    }
}
