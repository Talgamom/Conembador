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
        /*
        [HttpPost]
        public IActionResult Comparador(string fileContent, Arquivo model)
        {
            if (model.ItensArquivo == null || !model.ItensArquivo.Any())
            {
                model.ItensArquivo = _context.Itens.Where(i => i.id_arquivo == model.id_arquivo).ToList();                
            }
            ViewBag.FileContent = fileContent;
            return View("~/Views/Comparador/Comparador.cshtml", model);
        }
        */
        [HttpPost]
        public IActionResult Comparador(string fileContent, Arquivo model)
        {
            if (model.ItensArquivo == null || !model.ItensArquivo.Any())
            {
                model.ItensArquivo = _context.Itens.Where(i => i.id_arquivo == model.id_arquivo).ToList();
            }

            // Processar o conteúdo do arquivo TXT conforme as posições de início e fim
            var processedData = new List<string>();
            foreach (var item in model.ItensArquivo)
            {
                if (item.Inicio <= fileContent.Length && item.Fim <= fileContent.Length && item.Inicio <= item.Fim)
                {
                    processedData.Add(fileContent.Substring(item.Inicio - 1, item.Fim - item.Inicio + 1));
                }
                else
                {
                    processedData.Add("Dados fora do intervalo do arquivo");
                }
            }

            ViewBag.ProcessedData = processedData;
            ViewBag.FileContent = fileContent;
            return View("~/Views/Comparador/Comparador.cshtml", model);
        }

    }
}