using Conembador.Contexto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Conembador.Models;

namespace Conembador.Controllers
{
    public class ItemController : Controller
    {
        private readonly ILogger<EdiController> _logger;
        private readonly ConembadorContext _context;

        public ItemController(ILogger<EdiController> logger, ConembadorContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Detalhes(int id)
        {
            var arquivo = await _context.Arquivos
                .Include(a => a.ItensArquivo)
                .FirstOrDefaultAsync(a => a.id_arquivo == id);

            if (arquivo == null)
            {
                return NotFound();
            }
            return View("~/Views/Item/ApresentarItens.cshtml", arquivo);
        }

        [HttpPost]
        public async Task<IActionResult> EnviarRespostas(List<Itens> Itens, int id_arquivo)
        {
            await Console.Out.WriteLineAsync($"Id_arquivo: {id_arquivo}");
            if (ModelState.IsValid)
            {
                await CadastrarItem(Itens,id_arquivo);
                return RedirectToAction("CadastrarItem");
            }
            return View("~/Views/Item/CadastrarItem.cshtml");
        }
        public async Task<IActionResult> CadastrarItem() //quando usa o await, tem que colocar async task no método.
        {
            var arquivos = await _context.Arquivos.ToListAsync();
            ViewBag.Arquivos = arquivos;
            return View("~/Views/Item/CadastrarItem.cshtml");
        }
        private async Task<ViewResult> CadastrarItem(List<Itens> itens, int id_arquivo)
        {
            if (ModelState.IsValid)
            {
                var arquivo = await _context.Arquivos.Include(a => a.ItensArquivo)
                .FirstOrDefaultAsync(a => a.id_arquivo == id_arquivo);

                var itensExistentes = await _context.Itens.Where(i => i.id_arquivo == id_arquivo).ToListAsync();
                if (itensExistentes.Any())
                {
                    _context.Itens.RemoveRange(itensExistentes);
                    await _context.SaveChangesAsync();
                }

                foreach (var item in itens)
                {
                    item.id_arquivo = id_arquivo;
                    arquivo.ItensArquivo.Add(item);
                }
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Arquivo: {arquivo.NomeEdi}, Versão: {arquivo.Versao}");

                foreach (var item in arquivo.ItensArquivo)
                {
                    _logger.LogInformation($"Item: {item.Descricao}, Início: {item.Inicio}, Fim: {item.Fim}");
                }
            }
            var arquivos = await _context.Arquivos.ToListAsync();
            ViewBag.Arquivos = arquivos;
            return View("CadastrarItem");
        }
    }
}
