using Microsoft.AspNetCore.Mvc;
using AplikacjaTrenowania.Models;
using AplikacjaTrenowania.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
        // GET: Trening
        public ActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var trening = _context.Trening.Include(x => x.Serie).Include(x => x.DefinicjaTreningu).Where(x => userId == x.UserId );
            var daty = trening.Select(x => x.Data).Distinct().ToList();
            ViewBag.Daty = daty;
            return View(trening);
        }
        // GET: Trening/Edit
        [Route("Trening/Edit")]
        public ActionResult Edit(int id)
        {
            var listaDefinicjiTreningu = _context.DefinicjaTreningu.ToList();
            ViewBag.Cwiczenia = listaDefinicjiTreningu
            .GroupBy(d => d.RodzajTreningu)
            .ToDictionary(
                g => g.Key,
                g => g.Select(d => d.WybierzCwiczenie).ToList()
            );
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
            var treningDoEdycji = _context.Trening.Include(x => x.Serie).Include(x => x.DefinicjaTreningu).FirstOrDefault(x => x.IdTreningu == id);
            if (treningDoEdycji != null)
            {
                treningDoEdycji.DefinicjaTreningu.RodzajTreningu = trening.DefinicjaTreningu.RodzajTreningu;
                treningDoEdycji.DefinicjaTreningu.WybierzCwiczenie = trening.DefinicjaTreningu.WybierzCwiczenie;
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return BadRequest();
            var listaDefinicjiTreningu = _context.DefinicjaTreningu.ToList();
            ViewBag.Cwiczenia = listaDefinicjiTreningu
            .GroupBy(d => d.RodzajTreningu)
            .ToDictionary(
                g => g.Key,
                g => g.Select(d => d.WybierzCwiczenie).ToList()
            );
            return View(new Trening(userId));
        }
        // POST: Trening/Create
        [HttpPost]
        public ActionResult Create(Trening model, string rodzajTreningu, string wybierzCwiczenie) {
            var definicjaTreningu = _context.DefinicjaTreningu.Where(x => x.RodzajTreningu == rodzajTreningu && x.WybierzCwiczenie == wybierzCwiczenie).FirstOrDefault();
            if(definicjaTreningu == null) return BadRequest();
            model.DefinicjaTreningu = definicjaTreningu;
            _context.Trening.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Save", new{id=model.IdTreningu});
            }
        // GET: Trening/Save
        public ActionResult Save(int id)
        {
            var trening = _context.Trening.Include(x => x.Serie).Include(x => x.DefinicjaTreningu).FirstOrDefault(x => x.IdTreningu == id);
            return View(trening);
        }
        public ActionResult Dod_Kat()
        {
            ViewBag.Rodzaje = _context.DefinicjaTreningu.Select(x => x.RodzajTreningu).Distinct().ToList();
            return View(new DefinicjaTreningu());
        }
        [HttpPost]
        public ActionResult Dod_Kat(DefinicjaTreningu definicjaTreningu)
        {
            _context.DefinicjaTreningu.Add(definicjaTreningu);
            _context.SaveChanges();
            return RedirectToAction("Dod_Kat");
        }
    }
}
