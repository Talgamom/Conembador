using Conembador.Contexto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Conembador.Models;

namespace Conembador.Controllers
{
    public class ItemController : Controller
    {
        private readonly ILogger<ItemController> _logger;
        private readonly ConembadorContext _context;

        public ItemController(ILogger<ItemController> logger, ConembadorContext context)
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
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation($"Número de itens recebidos: {Itens.Count}");
                    foreach (var item in Itens)
                    {
                        _logger.LogInformation($"Descrição do Item: {item.Descricao}, Início: {item.Inicio}, Fim: {item.Fim}");
                    }
                    await CadastrarItem(Itens, id_arquivo);
                    return RedirectToAction("CadastrarItem", new { id = id_arquivo });
                }
                else
                {
                    _logger.LogError("ModelState is invalid.");
                    foreach (var key in ModelState.Keys)
                    {
                        var state = ModelState[key];
                        foreach (var error in state.Errors)
                        {
                            _logger.LogError($"Error in {key}: {error.ErrorMessage}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao processar EnviarRespostas.");
                throw; // ou trate o erro conforme necessário
            }

            return View("~/Views/Item/CadastrarItem.cshtml");
        }


        [HttpGet]
        public async Task<IActionResult> CadastrarItem(int id)
        {
            var arquivos = await _context.Arquivos.ToListAsync();
            var itens = await _context.Itens.Where(i => i.id_arquivo == id).ToListAsync();

            if (arquivos == null)
            {
                return NotFound();
            }

            ViewBag.Arquivos = arquivos;
            ViewBag.Itens = itens;
            ViewBag.id_arquivo = id;
            return View("~/Views/Item/CadastrarItem.cshtml");
        }

        private async Task CadastrarItem(List<Itens> itens, int id_arquivo)
        {
            if (ModelState.IsValid)
            {
                var arquivo = await _context.Arquivos.Include(a => a.ItensArquivo)
                .FirstOrDefaultAsync(a => a.id_arquivo == id_arquivo);

                if (arquivo != null)
                {
                    var itensAnteriores = await _context.Itens.Where(i => i.id_arquivo == id_arquivo).ToListAsync();
                    if (itensAnteriores.Any())
                    {
                        _context.Itens.RemoveRange(itensAnteriores);
                        await _context.SaveChangesAsync();
                    }

                    foreach (var item in itens)
                    {
                        item.id_arquivo = id_arquivo;
                        _context.Itens.Add(item);
                    }
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}

