using FE.Models;
using FE.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FE.Controllers
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
        public IActionResult AboutUs()
        {
            return View();
        }
       /* public IActionResult AdvisorOutfit()
        {
            StyleAdvisor sa = new StyleAdvisor();
            sa.Name = "Elif Nur TABAKLI";
            sa.email = "elifnur37@gmail.com";
            
            return View(sa);
        }

        [HttpPost]
        public IActionResult AdvisorOutfit(StyleAdvisor sa)
        {
            return View(sa);
        }*/
        public IActionResult OutfitStyles()
        {
            return View();
        }
        public IActionResult Privacy()
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