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

        // GET: Personas
        public IActionResult Mostrar()
        {
            var lista = _useCase.getListaPersonasConNombreDepartameto();
            return View(lista);
        }

        // GET: Personas/Details/5
        public IActionResult Details(int id)
        {
            var persona = _repoPersonas.getPersonaPorId(id);
            var dto = _useCase.getPersonaConNombreDepartamento(id);

            return View(dto);
        }

        // GET: Personas/Create
        public IActionResult Create()
        {
            var persona = new Persona();
            var dto = new PersonaConListadoDepartamento(persona, _repoDepartamentos);

            return View(dto);
        }

        // POST: Personas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Persona personaNueva)
        {
            if (!ModelState.IsValid)
            {
                var dto = new PersonaConListadoDepartamento(personaNueva, _repoDepartamentos);
                return View(dto);
            }

            _useCase.crearPersona(personaNueva);
            return RedirectToAction(nameof(Mostrar));
        }

        // GET: Personas/Edit/5
        public IActionResult Edit(int id)
        {
            var persona = _repoPersonas.getPersonaPorId(id);
            var dto = new PersonaConListadoDepartamento(persona, _repoDepartamentos);

            return View(dto);
        }

        // POST: Personas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Persona personaActualizada)
        {
            if (!ModelState.IsValid)
            {
                var dto = new PersonaConListadoDepartamento(personaActualizada, _repoDepartamentos);
                return View(dto);
            }

            _useCase.actualizarPersona(id, personaActualizada);
            return RedirectToAction(nameof(Mostrar));
        }

        // GET: Personas/Delete/5
        public IActionResult Delete(int id)
        {
            var persona = _repoPersonas.getPersonaPorId(id);
            var dto = _useCase.getPersonaConNombreDepartamento(id);

            return View(dto);
        }

        // POST: Personas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            _useCase.eliminarPersona(id);
            return RedirectToAction(nameof(Mostrar));
        }
    }
}
