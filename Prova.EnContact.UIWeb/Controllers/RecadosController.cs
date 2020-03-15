using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Prova.EnContact.Compartilhado.Constantes;
using Prova.EnContact.Interfaces.Interfaces.Modelos;
using Prova.EnContact.Interfaces.Interfaces.Servicos;
using Prova.EnContact.Modelos.Modelos;

namespace Prova.EnContact.UIWeb.Controllers
{
    public class RecadosController : Controller
    {
        protected readonly IRecadoServico<Recado> _recadoServico;
        protected readonly IAgrupamentoServico<Agrupamento> _agrupamentoServico;

        public RecadosController(IServiceProvider services)
        {
            _recadoServico = services.GetRequiredService<IRecadoServico<Recado>>();
            _agrupamentoServico = services.GetRequiredService<IAgrupamentoServico<Agrupamento>>();
        }

        public ActionResult Cadastrar()
        {
            ViewData["Titulo"] = ConstantesPalavras.CADASTRAR_RECADO;
            return View();
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
                    return View();
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