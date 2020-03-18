using Microsoft.AspNetCore.Mvc;
using Prova.EnContact.Compartilhado.Constantes;
using Prova.EnContact.Modelos.Modelos;
using Prova.EnContact.Servicos.Utilitarios;
using Prova.EnContact.TesteIntegracao.Fixtures;
using Prova.EnContact.TesteIntegracao.Utilitarios;
using Prova.EnContact.UIWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void CarregarViewCadastrarSucessoTest()
        {
            var resultado = _controller.Cadastrar();

            var viewResult = Assert.IsType<ViewResult>(resultado);
            Assert.IsAssignableFrom<Recado>(viewResult.ViewData.Model);
        }

        [Fact]
        public void SalvarRecadoSucessoTest()
        {
            _controllerFixture.RestauraBanco();

            var resultado = _controller.Cadastrar((Recado)GeradorDeEntidadesMock.ObtenhaRecado());

            var redirect = Assert.IsType<RedirectToActionResult>(resultado);
            Assert.Equal(nameof(RecadosController.Cadastrar), redirect.ActionName);
        }

        [Fact]
        public void SalvarRecadoSemPreencherCamposObrigatoriosFalhaTest()
        {
            _controllerFixture.RestauraBanco();

            var recado = new Recado();
            _controller.ModelState.AddModelError(nameof(Recado.Assunto), string.Format(ConstantesPalavras.CAMPO_OBRIGATORIO, nameof(Recado.Assunto)));
            var resultado = _controller.Cadastrar(recado);

            var viewResult = Assert.IsType<ViewResult>(resultado);
            Assert.IsAssignableFrom<Recado>(viewResult.ViewData.Model);
            Assert.False(_controller.ModelState.IsValid);
            Assert.True(_controller.ModelState.ContainsKey(nameof(Recado.Assunto)));
        }

        [Fact]
        public void VerRecadosSucessoTest()
        {
            _controllerFixture.RestauraBanco();

            var recados = GeradorDeEntidadesMock.ObtenhaRecadosMock();
            foreach(var recado in recados)
            {
                _controller.Cadastrar((Recado)recado);
            }

            var resultado = _controller.VerRecados();
            var viewResult = Assert.IsType<ViewResult>(resultado);
            var agrupamentos = Assert.IsAssignableFrom<IList<Agrupamento>>(viewResult.ViewData.Model);

            Assert.Equal(4, agrupamentos.Count);

            Assert.Equal(6, agrupamentos[0].ObtenhaListaDeRecados().Count);
            Assert.Equal(agrupamentos[0].ObtenhaListaDeRecados().Select(x => x.Assunto).ToArray(), 
                new string[] 
                {
                    "Primeiro recado",
                    "respondendo: Primeiro recado",
                    "complementando: Primeiro recado",
                    "referente: Primeiro recado",
                    "Primeiro recado",
                    "Primeiro recado"
                });

            Assert.Equal(1, agrupamentos[1].ObtenhaListaDeRecados().Count);
            Assert.Equal(agrupamentos[1].ObtenhaListaDeRecados().Select(x => x.Assunto).ToArray(), new string[] { "Segundo recado" });

            Assert.Equal(1, agrupamentos[2].ObtenhaListaDeRecados().Count);
            Assert.Equal(agrupamentos[2].ObtenhaListaDeRecados().Select(x => x.Assunto).ToArray(), new string[] { "respondendo: Segundo recado" });

            Assert.Equal(1, agrupamentos[3].ObtenhaListaDeRecados().Count);
            Assert.Equal(agrupamentos[3].ObtenhaListaDeRecados().Select(x => x.Assunto).ToArray(), new string[] { "Primeiro recado" });
        }

        [Fact]
        public void EditarCriandoUmNovoAgrupamentoSucessoTest()
        {
            _controllerFixture.RestauraBanco();

            var recados = GeradorDeEntidadesMock.ObtenhaRecadosMock();
            foreach (var recado in recados)
            {
                _controller.Cadastrar((Recado)recado);
            }

            var primeiroRecado = recados.First().CloneDescompartilhado();
            primeiroRecado.De = "BELTRANO";
            primeiroRecado.Para = "BELTRANO";

            _controller.Editar((Recado)primeiroRecado);

            var resultado = _controller.VerRecados();
            var viewResult = Assert.IsType<ViewResult>(resultado);
            var agrupamentos = Assert.IsAssignableFrom<IList<Agrupamento>>(viewResult.ViewData.Model);

            Assert.Equal(5, agrupamentos.Count);

            Assert.Equal(5, agrupamentos[0].ObtenhaListaDeRecados().Count);
            Assert.Equal(agrupamentos[0].ObtenhaListaDeRecados().Select(x => x.Assunto).ToArray(),
                new string[]
                {
                    "respondendo: Primeiro recado",
                    "complementando: Primeiro recado",
                    "referente: Primeiro recado",
                    "Primeiro recado",
                    "Primeiro recado"
                });

            Assert.Equal(1, agrupamentos[4].ObtenhaListaDeRecados().Count);
            Assert.Equal(agrupamentos[4].ObtenhaListaDeRecados().Select(x => x.Assunto).ToArray(), new string[] { "Primeiro recado" });
        }

        [Fact]
        public void EditarExcluindoUmAgrupamentoSucessoTest()
        {
            _controllerFixture.RestauraBanco();

            var recados = GeradorDeEntidadesMock.ObtenhaRecadosMock();
            foreach (var recado in recados)
            {
                _controller.Cadastrar((Recado)recado);
            }

            var primeiroRecado = recados.First(x => x.Assunto.Equals("Segundo recado")).CloneDescompartilhado();
            primeiroRecado.Assunto = "Primeiro recado";
            primeiroRecado.De = "Fulano";
            primeiroRecado.Para = "Ciclano";

            _controller.Editar((Recado)primeiroRecado);

            var resultado = _controller.VerRecados();
            var viewResult = Assert.IsType<ViewResult>(resultado);
            var agrupamentos = Assert.IsAssignableFrom<IList<Agrupamento>>(viewResult.ViewData.Model);

            Assert.Equal(3, agrupamentos.Count);

            Assert.Equal(7, agrupamentos[0].ObtenhaListaDeRecados().Count);
            Assert.Equal(agrupamentos[0].ObtenhaListaDeRecados().Select(x => x.Assunto).ToArray(),
                new string[]
                {
                    "Primeiro recado",
                    "respondendo: Primeiro recado",
                    "Primeiro recado",
                    "complementando: Primeiro recado",
                    "referente: Primeiro recado",
                    "Primeiro recado",
                    "Primeiro recado"
                });
        }
    }
}