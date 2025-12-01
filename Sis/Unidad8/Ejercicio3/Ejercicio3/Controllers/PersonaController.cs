using Domain.dto;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio3.Controllers
{
    public class PersonaController : Controller
    {
        private readonly IPersonaRepositoryUseCase _useCase;
        private readonly IPersonaRepository _repoPersonas;
        private readonly IDepartamentoRepository _repoDepartamentos;

        public PersonaController(
            IPersonaRepositoryUseCase useCase,
            IPersonaRepository repoPersonas,
            IDepartamentoRepository repoDepartamentos)
        {
            _useCase = useCase;
            _repoPersonas = repoPersonas;
            _repoDepartamentos = repoDepartamentos;
        }

        public IActionResult Index()
        {
            try { 
                var lista = _useCase.getListaPersonasConNombreDepartameto();
                return View(lista);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Mostrar");
            }

            
        }

        // GET: Personas
        public IActionResult Mostrar()
        {
            try
            {
                var lista = _useCase.getListaPersonasConNombreDepartameto();
                return View(lista);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Mostrar");
            }
        }

        // GET: Personas/Details/5
        public IActionResult Details(int id)
        {
            try
            {
                var persona = _repoPersonas.getPersonaPorId(id);
                var dto = _useCase.getPersonaConNombreDepartamento(id);

                return View(dto);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Mostrar");
            }
        }

        // GET: Personas/Create
        public IActionResult Create()
        {
            try
            {

                var persona = new Persona();
                var dto = new PersonaConListadoDepartamento(persona, _repoDepartamentos);

                return View(dto);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Mostrar");
            }
        }

        // POST: Personas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Persona personaNueva)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    var dto = new PersonaConListadoDepartamento(personaNueva, _repoDepartamentos);
                    return View(dto);
                }

                _useCase.crearPersona(personaNueva);
                return RedirectToAction(nameof(Mostrar));
            }
            catch (Exception ex)
            {
                return RedirectToAction("Mostrar");
            }
        }

        // GET: Personas/Edit/5
        public IActionResult Edit(int id)
        {
            try
            {

                var persona = _repoPersonas.getPersonaPorId(id);
                var dto = new PersonaConListadoDepartamento(persona, _repoDepartamentos);

                return View(dto);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Mostrar");
            }
        }

        // POST: Personas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Persona personaActualizada)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    var dto = new PersonaConListadoDepartamento(personaActualizada, _repoDepartamentos);
                    return View(dto);
                }

                _useCase.actualizarPersona(id, personaActualizada);
                return RedirectToAction(nameof(Mostrar));
            }
            catch (Exception ex)
            {
                return RedirectToAction("Mostrar");
            }
        }

        // GET: Personas/Delete/5
        public IActionResult Delete(int id)
        {
            try
            {
                var persona = _repoPersonas.getPersonaPorId(id);

                var dto = _useCase.getPersonaConNombreDepartamento(id);

                return View(dto);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Mostrar");
            }
        }

        // POST: Personas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            try
            {
                _useCase.eliminarPersona(id);
                return RedirectToAction(nameof(Mostrar));
            }
            catch (Exception ex)
            {
                return RedirectToAction("Mostrar");
            }
        }
    }
}
