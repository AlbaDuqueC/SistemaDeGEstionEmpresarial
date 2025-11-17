using Domain.RepositoriesInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPersonaRepositoryUseCase _personaUseCase;

        public HomeController(ILogger<HomeController> logger, IPersonaRepositoryUseCase personaUseCase)
        {
            _logger = logger;
            _personaUseCase = personaUseCase;
        }

        public IActionResult Index()
        {
            var personas = _personaUseCase.GetListadoPersonas();
            return View(personas);
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
