using Conembador.Contexto;
using Conembador.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TesteInsert;

namespace Conembador.Controllers
{
    public class TesteController : Controller
    {
        private readonly ILogger<TesteController> _logger;
        public TesteController(ILogger<TesteController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Teste001()
        {
            return View("~/Views/Teste01/Teste001.cshtml");
        }
        [HttpGet]
        public IActionResult ApresentarEdi()
        {
            //return RedirectToPage("/Views/Teste01/ApresentarEdi"); // ainda não consegui fazer o Razer funcionar, ficará para imprementações futuras.
            return View("~/Views/Teste01/ApresentarEdi.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> EnviarRespostas(List<Itens> Itens)
        {

            if (ModelState.IsValid)
            {
                TesteInsert01 teste = new TesteInsert01();
                teste.TesteInsertAbc(Itens);
                return RedirectToAction("Teste001");
            }
            return View("~/Views/Teste01/Teste001.cshtml");
        }
    }
}