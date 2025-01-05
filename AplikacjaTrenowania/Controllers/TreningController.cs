using Microsoft.AspNetCore.Mvc;
using AplikacjaTrenowania.Models;
using AplikacjaTrenowania.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

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
        public ActionResult Index()
        {
            var trening = _context.Trening.Include(x => x.Serie);
            var daty = trening.Select(x => x.Data).Distinct().ToList();
            ViewBag.Daty = daty;
            return View(trening);
        }
        // GET: Trening/Details/5
        public ActionResult Details(int id) => View();
        public ActionResult Delete(int id)
        {
            var trening = _context.Trening.Find(id);
            if(trening != null) _context.Trening.Remove(trening);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Trening/Create
        public ActionResult Create()
        {
            ViewBag.Cwiczenia = cwiczenia;
            return View(new Trening());
        }
        // POST: Trening/Create
        [HttpPost]
        public ActionResult Create(Trening model) {
            _context.Trening.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Save", new{id=model.IdTreningu});
            
            
            
            }
        // GET: Trening/Save
        public ActionResult Save(int id)
        {
            var trening = _context.Trening.Include(x => x.Serie).FirstOrDefault(x => x.IdTreningu == id);
            return View(trening);
        }
    }
}
