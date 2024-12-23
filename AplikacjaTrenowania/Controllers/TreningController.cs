using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AplikacjaTrenowania.Models;

namespace AplikacjaTrenowania.Controllers
{
    public class TreningController : Controller
    {
        // GET: TreningController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TreningController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TreningController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TreningController/Create
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

        // GET: TreningController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TreningController/Edit/5
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

        // GET: TreningController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TreningController/Delete/5
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
