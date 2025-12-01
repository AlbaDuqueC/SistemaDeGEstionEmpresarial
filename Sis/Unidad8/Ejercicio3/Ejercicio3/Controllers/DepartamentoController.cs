using Domain.Entities;
using Domain.Interfaces.UseCase;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio3.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IDepartamentoRepositoryUseCase _useCase;
        private readonly IDepartamentoRepository _repoDepartamentos;

        public DepartamentoController(
            IDepartamentoRepositoryUseCase useCase,
            IDepartamentoRepository repoDepartamentos)
        {
            _useCase = useCase;
            _repoDepartamentos = repoDepartamentos;
        }

        public IActionResult Index()
        {
            try
            {
                var lista = _useCase.getListaDepartamento();
                return View(lista);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Mostrar");
            }  
        }

        public IActionResult Mostrar()
        {

            try
            {

                var lista = _useCase.getListaDepartamento();
                return View(lista);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Mostrar");
            }
        }

        // GET: Departamento/Mostrar
        /*public IActionResult Index()
        {
            var lista = _useCase.getListaDepartamento();
            return View("Mostrar", lista);
        }*/

        // GET: Departamento/Details/5
        public IActionResult Details(int id)
        {
            try
            {

                var departamento = _repoDepartamentos.getDepartamentoPorId(id);
                return View(departamento);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Mostrar");
            }
        }

        // GET: Departamento/Create
        public IActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Mostrar");
            }
        }

        // POST: Departamento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Departamento departamentoNuevo)
        {

            try
            {

                if (!ModelState.IsValid)
                    return View(departamentoNuevo);

                _useCase.crearDepartamento(departamentoNuevo);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction("Mostrar");
            }
        }
        // GET: Departamento/Edit/5
        public IActionResult Edit(int id)
        {
            try
            {

                var departamento = _repoDepartamentos.getDepartamentoPorId(id);
                return View(departamento);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Mostrar");
            }
        }
        // POST: Departamento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Departamento departamentoActualizado)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(departamentoActualizado);

                _useCase.actualizarDepartamento(id, departamentoActualizado);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction("Mostrar");
            }
        }
        // GET: Departamento/Delete/5
        public IActionResult Delete(int id)
        {
            try
            {

                var departamento = _repoDepartamentos.getDepartamentoPorId(id);
                return View(departamento);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Mostrar");
            }
        }
        // POST: Departamento/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            try
            {
                // El use case se ENCARGA de no permitir borrar si hay personas
                int resultado = _useCase.eliminarDepartamento(id);

                if (resultado == -1)
                {
                    // Departamento con personas → NO se borra
                    ViewBag.ErrorMensaje = "No se puede eliminar un departamento que contiene personas.";
                    var departamento = _repoDepartamentos.getDepartamentoPorId(id);
                    return View("Delete", departamento);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction("Mostrar");
            }
        }
    }
}
