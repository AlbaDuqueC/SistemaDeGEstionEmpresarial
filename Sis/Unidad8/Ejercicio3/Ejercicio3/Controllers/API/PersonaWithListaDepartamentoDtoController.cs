using Domain.dto;
using Domain.Interfaces.UseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio3.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaWithListaDepartamentoDtoController : ControllerBase
    {
        private readonly IPersonaRepositoryUseCase _personasUseCase;

        public PersonaWithListaDepartamentoDtoController(IPersonaRepositoryUseCase personasUseCase)
        {
            _personasUseCase = personasUseCase;
        }

        // GET: api/<PersonaWithListaDepartamentoDtoController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<PersonaConListadoDepartamento> lista;
            try
            {
                lista = _personasUseCase.getPersonaConListadoDepartamento();
                if (lista.Count == 0)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(lista);
                }
            }
            catch
            {
                salida = BadRequest();
            }

            return salida;
        }

        // GET api/<PersonaWithListaDepartamentoDtoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            PersonaConListadoDepartamento persona;
            IActionResult salida;

            try
            {
                persona = _personasUseCase.getPersonaConListadoDepartamento(id);
                salida = Ok(persona);
            }
            catch
            {
                salida = NotFound();
            }

            return salida;
        }
    }
}
