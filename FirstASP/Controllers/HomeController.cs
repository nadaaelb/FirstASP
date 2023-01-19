using Microsoft.AspNetCore.Mvc;

namespace FirstASP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Selection()
        {
            return Content("Please select a game to begin!");
        }
    }
}

    