using System.Diagnostics;
using Ejercicio1.Models;
using Microsoft.AspNetCore.Mvc;
using Ejercicio1.Models.Entities;

namespace Ejercicio1.Controllers
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
            
            int hora = DateTime.Now.Hour;
            string saludo;
            Persona persona;

            if (hora >= 6 && hora < 12)
                saludo = "Buenos días";
            else if (hora >= 12 && hora < 20)
                saludo = "Buenas tardes";
            else
                saludo = "Buenas noches";

            ViewData["Saludo"] = saludo;

            // Fecha actual en formato largo
            ViewBag.Fecha = DateTime.Now.ToLongDateString();

            //Crear persona y pasarla por el modelo
            persona = new Persona(1, "Alba", 19);

            return View(persona);
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

        public IActionResult listadoPersona()
        {
            List<Persona> listaPersonas = new List<Persona>()
            {
                new Persona(1, "Alba", 19),
                new Persona(2, "Juan", 25),
                new Persona(3, "María", 30),
                new Persona(4, "Luis", 22),
                new Persona(5, "Ana", 27)
            };
            return View(listaPersonas);
        }


    }
}
