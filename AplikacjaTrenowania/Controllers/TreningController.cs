using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AplikacjaTrenowania.Models;

namespace AplikacjaTrenowania.Controllers
{
    public class TreningController : Controller
    {
        private readonly ILogger<TreningController> _logger;
        private static List<Trening> zapisaneTreningi = new List<Trening>();
        private readonly Dictionary<string, List<string>> cwiczenia = new Dictionary<string, List<string>>
        {
            { "Siłowy", new List<string> { "Przysiady", "Martwy ciąg", "Wyciskanie sztangi" } },
            { "Kardio", new List<string> { "Bieganie", "Rower", "Skakanka" } },
            { "Stretching", new List<string> { "Joga", "Rozciąganie dynamiczne", "Pilates" } }
        };
        public TreningController(ILogger<TreningController> logger)
        {
            _logger = logger;
        }
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
            ViewBag.Cwiczenia = cwiczenia;
            return View(new Trening());
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
        public IActionResult ZapiszTrening(Trening model, int[] serieKg, int[] seriePowtorzenia)
        {
            for (int i = 0; i < serieKg.Length; i++)
            {
                model.Serie.Add(new Seria
                {
                    Kg = serieKg[i],
                    Powtorzenia = seriePowtorzenia[i]
                });
            }

            zapisaneTreningi.Add(model);
            return RedirectToAction("ListaTreningow");
        }
    }
}
