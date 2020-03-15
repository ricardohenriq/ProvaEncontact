using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prova.EnContact.Compartilhado.Constantes;
using Prova.EnContact.Compartilhado.Utilitarios;
using Prova.EnContact.Interfaces.Interfaces.Modelos;
using Prova.EnContact.Interfaces.Interfaces.Servicos;
using Prova.EnContact.Modelos.Modelos;

namespace Prova.EnContact.UIWeb.Controllers
{
    public class RecadosController : Controller
    {
        [TempData]
        public string MensagemDeStatus { get; set; }

        private const string chavePermitirDataRetroativa = "ConfiguracoesDaAplicacao:PermitirExibirCampoDataDoRecado";
        protected readonly IRecadoServico<Recado> _recadoServico;
        protected readonly IAgrupamentoServico<Agrupamento> _agrupamentoServico;
        private readonly bool _permitirExibirCampoDataDoRecadoParaDataRetroativa;

        public RecadosController(IServiceProvider services)
        {
            _recadoServico = services.GetRequiredService<IRecadoServico<Recado>>();
            _agrupamentoServico = services.GetRequiredService<IAgrupamentoServico<Agrupamento>>();
            _permitirExibirCampoDataDoRecadoParaDataRetroativa = services.ObtenhaBoolDasConfiguracoes(chavePermitirDataRetroativa);
        }

        public ActionResult Cadastrar()
        {
            ViewData["Titulo"] = ConstantesPalavras.CADASTRAR_RECADO;
            ViewData["Mensagem"] = MensagemDeStatus;
            ViewData["PermitirDataRetroativa"] = _permitirExibirCampoDataDoRecadoParaDataRetroativa;
            return View(new Recado());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Recado recado)
        {
            try
            {
                ViewData["Titulo"] = ConstantesPalavras.CADASTRAR_RECADO;

                if (ModelState.IsValid)
                {
                    _agrupamentoServico.SalvarRecado(recado);
                    MensagemDeStatus = ConstantesPalavras.RECADO_CADASTRADO_SUCESSO;
                    return RedirectToAction(nameof(Cadastrar));
                }

                return View(nameof(Cadastrar), recado);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(string.Format(ConstantesPalavras.ERRO, ex.Message));
                throw;
            }
        }

        public ActionResult VerRecados()
        {
            try
            {
                ViewData["Titulo"] = ConstantesPalavras.VER_RECADOS;
                var recados = _agrupamentoServico.ObtenhaTodos();
                return View(recados);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format(ConstantesPalavras.ERRO, ex.Message));
                throw;
            }
        }
    }
}