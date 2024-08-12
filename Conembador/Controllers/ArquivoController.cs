using Conembador.Contexto;
using Conembador.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Conembador.Controllers
{
    public class ArquivoController : Controller
    {

        private readonly ILogger<ArquivoController> _logger;
        private readonly ConembadorContext _context;

        public ArquivoController(ILogger<ArquivoController> logger, ConembadorContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult CadastrarArquivo()
        {
            return View("~/Views/Arquivo/CadastrarArquivo.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> EnviarArquivo(Arquivo arquivo)
        {
            await Console.Out.WriteLineAsync($"Nome: {arquivo.NomeEdi}, versão: {arquivo.Versao}");
            //Console.WriteLine("b0bd2f0e89319b4868068560c988b9acc49b125b323a604df53d5f16c4159a23");           
            var arquivos = await _context.Arquivos.ToListAsync();
            arquivos.Add(arquivo);
            await _context.SaveChangesAsync();
            return View("~/Views/Edi/ApresentarEdi.cshtml");
            //return View("~/Views/Edi/ApresentarEdi.cshtml");
        }
    }
}
