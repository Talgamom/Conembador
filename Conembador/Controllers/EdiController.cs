using Conembador.Contexto;
using Conembador.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;



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
        public IActionResult CadastrarItem()
        {
            return View("~/Views/Edi/CadastrarItem.cshtml");
        }

        [HttpGet]
        public async Task<IActionResult> ApresentarEdi()
        {
            await Console.Out.WriteLineAsync("Entrou aqui");
            // Tente buscar a lista de arquivos
            var arquivos = await _context.Arquivos.ToListAsync();

            // Verifique se arquivos é nulo ou não
            if (arquivos == null)
            {
                // Adicione um log para depuração
                _logger.LogError("A lista de arquivos está nula");
                return View(new List<Arquivo>()); // Retorne uma lista vazia para evitar o NullReferenceException
            }

            // Passe a lista de arquivos para a view
            return View("~/Views/Edi/ApresentarEdi.cshtml", arquivos);
        }

        private async Task TesteInsertAbc(List<Itens> itens)
        {
            Arquivo arquivo = new Arquivo
            {
                NomeEdi = "Teste01",
                Versao = 1,
                ItensArquivo = new List<Itens>()
            };

            _context.Arquivos.Add(arquivo);

            foreach (var item in itens)
            {
                item.id_arquivo = arquivo.id_arquivo;
                arquivo.ItensArquivo.Add(item);
                _context.Itens.Add(item);
            }

            await _context.SaveChangesAsync();

            _logger.LogInformation($"Arquivo: {arquivo.NomeEdi}, Versão: {arquivo.Versao}");

            foreach (var item in arquivo.ItensArquivo)
            {
                _logger.LogInformation($"Item: {item.Descricao}, Início: {item.Inicio}, Fim: {item.Fim}");
            }

        }
        [HttpPost]
        public async Task<IActionResult> EnviarRespostas(List<Itens> Itens)
        {

            if (ModelState.IsValid)
            {
                await TesteInsertAbc(Itens);
                return RedirectToAction("CadastrarItem");
            }
            return View("~/Views/Edi/CadastrarItem.cshtml");
        }
    }
}