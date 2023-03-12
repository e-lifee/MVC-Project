using Microsoft.AspNetCore.Mvc;

namespace FE.Controllers
{
    public class DefaultController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult Partial1()
        {
            return PartialView();
        }
    }
}
