using Microsoft.AspNetCore.Mvc;

namespace _01HelloWorld.Controllers
{
    public class FileteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Empanado()
        {
            return View();
        }
    }
}
