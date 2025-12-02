using Domain.Entities;
using Domain.Interfaces.UseCase;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Ejercicio3.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly IDepartamentoRepositoryUseCase _casoUso;

        public DepartamentosController(IDepartamentoRepositoryUseCase useCase)
        {
            _casoUso = useCase;
        }

        // GET: api/Departamentos
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<Departamento> listado = new List<Departamento>();

            try
            {
                listado = _casoUso.getListaDepartamento();
                salida = listado.Count == 0 ? NoContent() : Ok(listado);
            }
            catch (Exception ex)
            {
                salida = BadRequest($"Error al obtener los departamentos: {ex.Message}");
            }

            return salida;
        }

        // GET: api/Departamentos/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            try
            {
                var departamento = _casoUso.getDepartamentoId(id);
                salida = departamento != null ? Ok(departamento) : NotFound();
            }
            catch (Exception ex)
            {
                salida = BadRequest($"Error al obtener el departamento: {ex.Message}");
            }
            return salida;
        }

        // POST: api/Departamentos
        [HttpPost]
        public IActionResult Post([FromBody] Departamento departamento)
        {
            IActionResult salida;
            if (!ModelState.IsValid)
            {
                salida = BadRequest(ModelState);
            }
            else
            {
                try
                {
                    _casoUso.crearDepartamento(departamento);
                    salida = Ok("El departamento se creó correctamente");
                }
                catch (Exception ex)
                {
                    salida = BadRequest($"Error al crear el departamento: {ex.Message}");
                }
            }
            return salida;
        }

        // PUT: api/Departamentos/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Departamento departamento)
        {
            IActionResult salida;

            if (id != departamento.ID)
            {
                salida = BadRequest("El ID del departamento no coincide.");
            }
            else if (!ModelState.IsValid)
            {
                salida = BadRequest(ModelState);
            }
            else
            {
                try
                {
                    _casoUso.actualizarDepartamento(id, departamento);
                    salida = Ok("El departamento se actualizó correctamente");
                }
                catch (Exception ex)
                {
                    salida = BadRequest($"Error al actualizar el departamento: {ex.Message}");
                }
            }

            return salida;
        }

        // DELETE: api/Departamentos/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult salida;

            try
            {
                _casoUso.eliminarDepartamento(id);
                salida = Ok("El departamento se eliminó correctamente");
            }
            catch (InvalidOperationException ex)
            {
                // Maneja el caso de personas asociadas
                salida = BadRequest($"No se puede eliminar el departamento: {ex.Message}");
            }
            catch (Exception ex)
            {
                salida = BadRequest($"Error al eliminar el departamento: {ex.Message}");
            }

            return salida;
        }
    }
}