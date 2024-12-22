using System.Diagnostics;
using AplikacjaTrenowania.Models;
using Microsoft.AspNetCore.Mvc;

namespace AplikacjaTrenowania.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Trening()
        {
            return View();
        }
        public IActionResult Woda()
        {
            return View();
        }
        public IActionResult Bia�ko()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
