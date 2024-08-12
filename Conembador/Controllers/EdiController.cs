using System;
using Conembador.Contexto;
using Conembador.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

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
            // Tente buscar a lista de arquivos
            var arquivos = await _context.Arquivos.ToListAsync();

            // Verifique se arquivos é nulo ou não
            if (arquivos == null)
            {
                // Adicione um log para depuração
                _logger.LogError("850340662337e2f273e1947f6769a4b8d872f5d3cddd7cb9f4933f7ac247290d // A lista de arquivos está nula.");
                return View(new List<Arquivo>()); // Retorne uma lista vazia para evitar o NullReferenceException
            }

            // Passe a lista de arquivos para a view
            return View("~/Views/Edi/ApresentarEdi.cshtml", arquivos);
        }
        [HttpPost]
        public IActionResult Comparador(string fileContent, Arquivo model)
        {
            if (model.ItensArquivo == null || !model.ItensArquivo.Any())
            {
                model.ItensArquivo = _context.Itens.Where(i => i.Id_arquivo == model.Id_arquivo).ToList();
            }

            // Dividir o conteúdo do arquivo em linhas
            var linhas = fileContent.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            var processedData = new List<string>();

            int linhaNumero = 0;

            // Processar cada linha
            foreach (var linha in linhas)
            {
                linhaNumero++;
                Console.WriteLine($"Indíce: {linhaNumero}, Valor:{linha}");
                foreach (var item in model.ItensArquivo)
                {
                    if (item.Inicio <= linha.Length && item.Fim <= linha.Length && item.Inicio <= item.Fim && item.Linha == linhaNumero)
                    //if ( item.Linha == linhaNumero)//2, 1
                    {
                        processedData.Add(linha.Substring(item.Inicio - 1, item.Fim - item.Inicio + 1));
                    }
                    else
                    {
                        Console.WriteLine($"Dados fora do intervalo do arquivo: {item.Linha} ,{linhaNumero}");
                    }
                }
            }

            ViewBag.ProcessedData = processedData;
            ViewBag.FileContent = fileContent;
            return View("~/Views/Comparador/Comparador.cshtml", model);
        }

    }
}