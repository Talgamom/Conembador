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
                foreach (var item in Itens)
                {
                    _logger.LogInformation($"33559bac5dc7b9f1a895c16cb8f2e11d5a534dee8893f5fa87d9645533dcc7f1 // Descricao Item: {item.Descricao}");                    
                }
                await CadastrarItem(Itens,id_arquivo);
                return RedirectToAction("CadastrarItem");
            }
            return View("~/Views/Item/CadastrarItem.cshtml");
        }
        public async Task<IActionResult> CadastrarItem(int id) //quando usa o await, tem que colocar async task no método, por algum motivo, quando coloca id, funciona, id_arquivo não funciona
        {
            //_logger.LogInformation($"94817ffdd52e82631dc1de205e3a5e824a784f6b73eeef8daad37f3cbf36f215 // Carregando dados do arquivo: {id}");
            var arquivos = await _context.Arquivos.ToListAsync();
            var itens = await _context.Itens.Where(i => i.id_arquivo == id).ToListAsync();

            if (arquivos == null)
            {
                //_logger.LogInformation($"8a21fed18f0a5d11bfec7740d23a06d451adbd32ffd57b99e5e3280351d6203b // Arquivos null.");
                return NotFound();
            }           
            ViewBag.Arquivos = arquivos;
            ViewBag.Itens = itens;            
            ViewBag.id_arquivo = id;
            return View("~/Views/Item/CadastrarItem.cshtml");
        }
        private async Task<ViewResult> CadastrarItem(List<Itens> itens, int id_arquivo)
        {
            if (ModelState.IsValid)
            {
                var arquivo = await _context.Arquivos.Include(a => a.ItensArquivo)
                .FirstOrDefaultAsync(a => a.id_arquivo == id_arquivo);

                var itensAnteriores = await _context.Itens.Where(i => i.id_arquivo == id_arquivo).ToListAsync();
                if (itensAnteriores.Any())
                {
                    _logger.LogInformation($"192f0899912866f7efae032b1b84cf501a4d19b584b893865f78a80b58dcf96d // id_arquivo: {id_arquivo}");
                    _context.Itens.RemoveRange(itensAnteriores);
                    await _context.SaveChangesAsync();
                }

                foreach (var item in itens)
                {
                    _logger.LogInformation($"3fe3c4da28f61402a6566add3cb5e1e6112ec2de82b7e6658001637e3c3fc467 // Descricao Item: {item.Descricao}");
                    item.id_arquivo = id_arquivo;
                    arquivo.ItensArquivo.Add(item);
                }
                await _context.SaveChangesAsync();

                //_logger.LogInformation($"348f16d09a07c99fa1a3b01e9978cc7ddd5a3d5e4ef5b95ca056e53817dc628e // Arquivo: {arquivo.NomeEdi}, Versão: {arquivo.Versao}");
                /*
                foreach (var item in arquivo.ItensArquivo)
                {
                    _logger.LogInformation($"Item: {item.Descricao}, Início: {item.Inicio}, Fim: {item.Fim}");
                }
                */
            }
            var arquivos = await _context.Arquivos.ToListAsync();
            ViewBag.Arquivos = arquivos;            
            //return View("ApresentarEdi");
            return View("CadastrarItem");
        }
    }
}
