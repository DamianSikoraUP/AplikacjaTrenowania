using Microsoft.AspNetCore.Mvc;
using AplikacjaTrenowania.Models;
using AplikacjaTrenowania.Areas.Identity.Data;

namespace AplikacjaTrenowania.Controllers
{
    public class TreningController : Controller
    {
        private readonly ApplicationDBContext _context;
        public TreningController(ApplicationDBContext context)
        {
            _context = context;
        }
        private readonly ILogger<TreningController> _logger;
        private static List<Trening> zapisaneTreningi = new List<Trening>();
        private readonly Dictionary<string, List<string>> cwiczenia = new() {
            { "Siłowy", new List<string> { "Przysiady", "Martwy ciąg", "Wyciskanie sztangi" } },
            { "Kardio", new List<string> { "Bieganie", "Rower", "Skakanka" } },
            { "Stretching", new List<string> { "Joga", "Rozciąganie dynamiczne", "Pilates" } }
        };
        // GET: Trening
        public ActionResult Index() => View();

        // GET: Trening/Details/5
        public ActionResult Details(int id) => View();

        // GET: Trening/Create
        public ActionResult Create()
        {
            ViewBag.Cwiczenia = cwiczenia;
            return View(new Trening());
        }
        // POST: Trening/Create
        [HttpPost]
        public ActionResult Create(Trening model) => RedirectToAction("Save", model);
        // GET: Trening/Save
        public ActionResult Save(Trening model) => View(model);
    }
}
