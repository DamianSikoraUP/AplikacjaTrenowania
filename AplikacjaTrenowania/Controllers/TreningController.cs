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
        // GET: Trening/Edit
        [Route("Trening/Edit")]
        public ActionResult Edit(int id)
        {
            ViewBag.Cwiczenia = cwiczenia;
            var trening = _context.Trening.Include(x => x.Serie).FirstOrDefault(x => x.IdTreningu == id);
            if (trening != null)
            {
                return View("Edit",trening);
            }
            return BadRequest(new { error = "Wystapil blad" });
        }

        [HttpPost]
        [Route("Trening/Edit")]
        public IActionResult Edit(int id, Trening trening)
        {
            var treningDoEdycji = _context.Trening.Include(x => x.Serie).FirstOrDefault(x => x.IdTreningu == id);
            if (treningDoEdycji != null)
            {
                treningDoEdycji.RodzajTreningu = trening.RodzajTreningu;
                treningDoEdycji.WybierzCwiczenie = trening.WybierzCwiczenie;
                treningDoEdycji.Serie = trening.Serie;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound(new { error = "Nie znaleziono treningu" });
        }

        // GET: Trening/Delete
        [HttpPost]
        [Route("Trening/Delete/{id}")]
        public ActionResult Delete([FromBody] int id)
        {
            var trening = _context.Trening.Find(id);
            if (trening != null)
            {
                _context.Trening.Remove(trening);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest(new {error="Wystapil blad"});
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
