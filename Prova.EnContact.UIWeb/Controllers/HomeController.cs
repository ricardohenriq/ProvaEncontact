using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prova.EnContact.Compartilhado.Constantes;
using Prova.EnContact.Modelos.Modelos;
using Prova.EnContact.Modelos.Modelos.VM;

namespace Prova.EnContact.UIWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Titulo"] = ConstantesPalavras.CADASTRAR_RECADO;

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
