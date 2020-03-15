using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prova.EnContact.Compartilhado.Constantes;
using Prova.EnContact.Modelos.Modelos;

namespace Prova.EnContact.UIWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Titulo"] = ConstantesPalavras.CADASTRAR_RECADO;

            return View();
        }
    }
}
