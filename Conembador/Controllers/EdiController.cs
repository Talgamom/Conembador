using Conembador.Contexto;
using Conembador.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TesteInsert;



namespace Conembador.Controllers
{
    public class EdiController : Controller
    {
        private readonly ILogger<EdiController> _logger;
        private readonly ConembadorContext _context;

        public EdiController(ILogger<EdiController> logger, ConembadorContext context)
        {
            _logger = logger;
            _context = context;
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
                //TesteInsert01 teste = new TesteInsert01();
                //teste.TesteInsertAbc(Itens);
                return RedirectToAction("Teste001");
            }
            return View("~/Views/Teste01/Teste001.cshtml");
        }

        public async Task<IActionResult> ApresentarEdi(int id)
        {
            var arquivo = await _context.Arquivos
                .Include(a => a.ItensArquivo)
                .FirstOrDefaultAsync(a => a.id_arquivo == id);

            if (arquivo == null)
            {
                return NotFound();
            }

            await Console.Out.WriteLineAsync($"{arquivo.NomeEdi}");

            return View(arquivo);
        }

    }
}