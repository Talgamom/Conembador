using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Conembador.Controllers
{
    public class NaoUtilizarArquivoController : Controller
    {
        // GET: ArquivoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ArquivoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArquivoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArquivoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArquivoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArquivoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArquivoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArquivoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
